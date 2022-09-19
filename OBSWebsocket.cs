using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.WebSockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OBS_J
{
    public class OBSWebsocket
    {
        //接続用のurl+ポート格納インスタンス、websocketインスタンス
        private Uri uri;
        private ClientWebSocket ws;

        private string passwd;

        //イベントタスクのキャンセル用のトークン
        private CancellationTokenSource _recvEventTokenSource;
        private CancellationToken _recvEventToken;

        //設定ファイル(obsj_setting.json)のパス、格納インスタンス
        public string jsonFilePath;
        private dynamic obsConfigJson;

        //ソートの有効/無効変数(ボタンで切替)
        public bool SortEnabled;
        
        //録画イベントをフォーム側に飛ばすためのデリゲート
        //デリゲートの宣言
        public delegate void SaveEventHandler(object sender, string e);
        //イベントハンドラの宣言
        public event SaveEventHandler SavedEvent;

        public OBSWebsocket()
        {
            SortEnabled = true;
            //jsonファイルは"Documents\OBSJ"内に保存
            jsonFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "OBSJ\\obsj_setting.json");

            //jsonファイルがない場合、プログラムの実行ファイルと同パスにあるオリジナルをコピー
            //この場合メッセージボックスで通知
            if (!File.Exists(jsonFilePath))
            {
                File.Copy("obsj_setting.json", jsonFilePath);
                MessageBox.Show("ドキュメントフォルダに設定ファイルを作成しました", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            //認証設定等を更新(取得)
            updateObsConfig();

            //イベント待機キャンセルトークンを初期化
            _recvEventTokenSource = new CancellationTokenSource();
            _recvEventToken = _recvEventTokenSource.Token;
        }

        private void updateObsConfig()
        {
            StreamReader sr = new StreamReader(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "OBSJ\\obsj_setting.json"));
            var textConfig = sr.ReadToEnd();
            sr.Close();
            obsConfigJson = JObject.Parse(textConfig);

            uri = new Uri("ws://localhost:" + (string)obsConfigJson.AUTH.PORT);
            passwd = (string)obsConfigJson.AUTH.PASSWD;
        }

        public void Set_obsPath(string path)
        {
            obsConfigJson.OBSDirectory = path;
            StreamWriter sw = new StreamWriter(jsonFilePath);
            sw.Write(obsConfigJson.ToString());
            sw.Close();
        }


        //接続メソッド
        public async Task<bool> Connect()
        {
            //websocketのインスタンスを初期化、
            ws = new ClientWebSocket();

            //送信データ用のバッファー
            ArraySegment<Byte> bufferseg = new ArraySegment<byte>(new byte[1024 * 4]);

            //認証設定等を更新
            updateObsConfig();

            //接続結果を格納するインスタンス
            WebSocketReceiveResult result;

            //接続時例外があった場合(OBS非起動時など)はfalseを返す
            try
            {
                await ws.ConnectAsync(uri, CancellationToken.None);
                result = await ws.ReceiveAsync(bufferseg, CancellationToken.None);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }

            //websocketサーバー(obs)から受け取ったデータを文字列→jsonオブジェクトに変換
            String jsonText = Encoding.UTF8.GetString(bufferseg.Array);
            dynamic jsonData = JObject.Parse(jsonText);

            //送信データ用の変数
            string senddata;

            //認証が必要な場合
            if (jsonData.d.ContainsKey("authentication"))
            {
                //認証に必要な情報を受信メッセージから取得、演算
                var Challenge = (string)jsonData.d.authentication.challenge.Value;
                var Salt = (string)jsonData.d.authentication.salt.Value;

                //認証用の返信メッセージ
                var authres = AuthHash(Challenge, Salt);

                /*
                {
                    "op":1,
                    "d":{
                        "rpcVersion":1,
                        "authentication":authres
                    }
                } 
                */
                senddata = @"{""op"": 1,""d"": {""rpcVersion"": 1, ""authentication"": """ + authres + @"""}}";
            }
            //認証が必要ない場合
            else
            {
                /*
                {
                    "op":1,
                    "d":{
                        "rpcVersion": 1
                    }
                } 
                */
                senddata = @"{""op"": 1,""d"": {""rpcVersion"": 1}}";
            }

            //(認証&)識別メッセージを送信
            string strResult = await Send(senddata);
            
            /*
            ・サーバーから返信がない
            ・opが2でない（認証に失敗した）
            ・その他例外が発生した
            場合、falseをreturn
            */
            try
            {
                dynamic jsonResult = JObject.Parse(strResult);
                //Console.WriteLine(jsonResult);

                if ((int)jsonResult.op == 2)
                {
                    //認証に成功した場合、イベント待機を開始
                    RecvEvent(_recvEventToken);
                    return true;
                }
                return false;
            }
            catch (Exception){return false;}

        }

        public async Task Disconnect()
        {
            await ws.CloseAsync(WebSocketCloseStatus.NormalClosure, "User's Close Request", CancellationToken.None);
            _recvEventTokenSource.Cancel();
        }

        private string AuthHash(string challenge, string salt)
        {
            SHA256CryptoServiceProvider sha256 = new SHA256CryptoServiceProvider();
            var SHAhash = sha256.ComputeHash(Encoding.UTF8.GetBytes(passwd + salt));
            sha256.Clear();
            var base64_secret = Convert.ToBase64String(SHAhash);

            sha256 = new SHA256CryptoServiceProvider();
            var authhash = sha256.ComputeHash(Encoding.UTF8.GetBytes(base64_secret + challenge));
            var authres = Convert.ToBase64String(authhash);
            return authres;
        }

        public async Task<String> Send(String message)
        {

            var buffer = Encoding.UTF8.GetBytes(message);

            ArraySegment<Byte> bufferseg = new ArraySegment<byte>(buffer);
            await ws.SendAsync(bufferseg, WebSocketMessageType.Text, true, CancellationToken.None);

            var state = ws.State;
            if (state == WebSocketState.Open)
            {

                WebSocketReceiveResult result;
                ArraySegment<Byte> recvseg = new ArraySegment<byte>(new byte[1024]);

                do
                {
                    result = await ws.ReceiveAsync(recvseg, CancellationToken.None);

                } while (!result.EndOfMessage);
                return Encoding.UTF8.GetString(recvseg.Array);
            }
            else
            {
                return "not connect";
            }
        }

        public string GetCurrentGame()
        {
            //ゲーム辞書
            dynamic games = obsConfigJson.GAMES;
            //保存先フォルダ名の変数
            string subDir = "";

            //起動中のプロセスを取得
            foreach (Process p in Process.GetProcesses())
            {
                //ウィンドウタイトルを全小文字で取得
                var Title = p.MainWindowTitle.ToLower();
                //タイトルが1文字以下の場合はスキップ
                if (Title.Length < 2) continue;
                //webブラウザの場合はスキップ
                if (Title.Contains("chrome") || Title.Contains("edge") || Title.Contains("firefox")) continue;

                foreach (JProperty game in games)
                {
                    //ゲーム名を含むかを判定
                    if (Title.Contains(game.Name.ToLower()))
                    {
                        subDir = (string)game.Value;
                        break;
                    }

                }
            }
            return subDir;
        }

        private async Task RecvEvent(CancellationToken ct)
        {
            //受信結果を格納するインスタンス
            WebSocketReceiveResult result;
            //受信メッセージを格納するバッファー
            ArraySegment<Byte> bufferseg;

            //ゲーム一覧をjsonオブジェクトとして設定オブジェクトから取得
            

            while (true)
            {
                //キャンセルトークンが起きた場合メソッドを終了
                if (ct.IsCancellationRequested) return;

                //受信メッセージ用のバッファー
                bufferseg = new ArraySegment<byte>(new byte[1024]);

                //メッセージが終了するまで受信をループ
                do { result = await ws.ReceiveAsync(bufferseg, CancellationToken.None); 
                } while (!result.EndOfMessage);

                dynamic jsonData = JObject.Parse(Encoding.UTF8.GetString(bufferseg.Array));

                //opが5でない場合(受信したのがイベントデータでない場合)
                if ((int)jsonData.op != 5) break;

                //リプレイバッファの保存が終了した際の処理
                if ((string.Compare((string)jsonData.d.eventType, "ReplayBufferSaved") == 0) && SortEnabled)
                {
                    string subDir = GetCurrentGame();

                    //保存先フォルダ名が空でない場合
                    if (subDir.Length > 1)
                    {
                        //obsイベントデータから動画ファイルのパスを取得
                        string Path = (string)jsonData.d.eventData.savedReplayPath;

                        //動画ファイルのフォルダパスとファイル名を取得
                        string orgDir = System.IO.Path.GetDirectoryName(Path);
                        string fileName = System.IO.Path.GetFileName(Path);

                        //移動先のフォルダと元のパスを結合 ～\SaveFolder + GameName + VideoName
                        string dir2Move = System.IO.Path.Combine(orgDir, subDir);
                        string path2Move = System.IO.Path.Combine(dir2Move, fileName);

                        //移動先のフォルダがない場合作成
                        if (!Directory.Exists(dir2Move))
                            Directory.CreateDirectory(dir2Move);

                        //動画ファイル移動
                        File.Move(Path, path2Move);

                        //フォーム向けに保存イベントを発火
                        SavedEvent(this, subDir);
                    }

                }
                //録画状態の変更イベントを取得
                else if ((string.Compare((string)jsonData.d.eventType, "RecordStateChanged") == 0) && SortEnabled)
                {
                    //録画の状態が「録画終了」出ない場合はスキップ
                    if (string.Compare((string)jsonData.d.eventData.outputState, "OBS_WEBSOCKET_OUTPUT_STOPPED") != 0)
                        continue;

                    //後の動作はリプレイバッファと同じ
                    string subDir = GetCurrentGame();


                    if (subDir.Length > 1)
                    {
                        string Path = (string)jsonData.d.eventData.outputPath;

                        string orgDir = System.IO.Path.GetDirectoryName(Path);
                        string fileName = System.IO.Path.GetFileName(Path);

                        string dir2Move = System.IO.Path.Combine(orgDir, subDir);
                        string path2Move = System.IO.Path.Combine(dir2Move, fileName);

                        if (!Directory.Exists(dir2Move))
                            Directory.CreateDirectory(dir2Move);

                        File.Move(Path, path2Move);
                        SavedEvent(this, subDir);
                    }

                }
                //OBSの終了開始のイベントを取得
                else if (string.Compare((string)jsonData.d.eventType, "ExitStarted") == 0)
                {
                    //obs終了時は切断後にアプリケーションを終了。
                    await Disconnect();
                    Application.Exit();
                }
            }

        }


        public WebSocketState State
        {
            get
            {
                if (ws == null)
                {
                    return WebSocketState.None;
                }
                else
                {
                    return ws.State;
                }
            }
        }

        public JObject obsConfig => obsConfigJson;
    }

}
