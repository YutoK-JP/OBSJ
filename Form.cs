using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.WebSockets;
using System.Threading;
using System.Diagnostics;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Security.Cryptography;



namespace OBS_J
{
    public partial class Form1 : Form
    {
        //obsのインスタンス
        OBSWebsocket obs;

        public Form1()
        {
            //コンポーネント初期化
            InitializeComponent();
            //インスタンス初期化
            obs = new OBSWebsocket();
            //obsの保存イベントとSavedReceivedメソッドを紐づけ
            obs.SavedEvent += new OBSWebsocket.SaveEventHandler(SavedReceived);
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            //ソート有効化ボタンの初期状態を設定
            if (obs.SortEnabled)
                SortButtonEnable();
            else
                SortButtonDisable();

            //グリッド用にOBSインスタンスから設定を取得
            dynamic obsconfig = obs.obsConfig;
            dynamic games = obsconfig.GAMES;

            //グリッドにデータを追加
            foreach (JProperty game in games)
            {
                RelationGrid.Rows.Add(game.Name, game.Value);
            }

            await launchOBS((string)obsconfig.OBSDirectory);
            
        }

        private bool searchOBSProcess()
        {
            //起動中のプロセスを取得
            foreach (Process p in Process.GetProcesses())
            {
                //プロセスのウィンドウ名を取得
                var Title = p.MainWindowTitle.ToLower();
                //ウィンドウ名の短いアプリはスキップ
                if (Title.Length < 2) continue;
                try
                {
                    //モジュールが空の場合スキップ
                    if(p.MainModule == null) continue;
                    //実行ファイルのあるパスを取得
                    var filePath = p.MainModule.FileName;
                    //ファイル名を取得
                    var fileName = Path.GetFileName(filePath);
                    
                    //obsだった場合、trueを返す
                    if (fileName.Contains("obs64")) return true;
                }
                catch (Win32Exception){ continue ;}
            }
            //obsが起動していなかった場合、falseを返す
            return false;
        }

        private async Task launchOBS(string obsdir)
        {
            //obs本体の起動を確認
            var obsLaunched = searchOBSProcess();
            //obsが起動していない場合、起動する
            if (!obsLaunched)
            {
                //obsの設定ファイルから実行ファイルのパスを取得
                //実行ファイルが存在しない場合、起動をスキップ
                if (File.Exists(Path.Combine(obsdir, "obs64.exe")))
                {
                    try
                    {
                        var proc = new Process();
                        proc.StartInfo.WorkingDirectory = obsdir;
                        proc.StartInfo.FileName = "obs64";
                        proc.Start();
                        await Task.Delay(2000);
                        //接続ボタンをクリック
                        
                    }
                    catch (Exception er) { Console.WriteLine(er); }
                }
            }
            ConnectButton.PerformClick();
        }
        private async void SavedReceived(object sender, string dirName)
        {
            //保存をobsインスタンスから受け取った時のメソッド
            foreach(DataGridViewRow row in RelationGrid.Rows)
            {
                //保存先フォルダとセルの右値が一致したとき、3秒間背景を帰る
                if (string.Compare(row.Cells[1].Value.ToString(), dirName) == 0)
                {
                    Debug.WriteLine("Here");
                    row.DefaultCellStyle.BackColor = Color.FromArgb(40, 76, 184);
                    row.DefaultCellStyle.SelectionBackColor = Color.FromArgb(40, 76, 184);
                    await Task.Delay(3000);
                    row.DefaultCellStyle.BackColor = Color.FromArgb(60, 64, 75);
                    row.DefaultCellStyle.SelectionBackColor = Color.FromArgb(60, 64, 75);
                    break;
                }
            }
            return;
        }

        private void SortButtonDisable()
        {
            SortEnabledButton.BackColor = Color.FromArgb(60, 64, 75);
        }
        private void SortButtonEnable()
        {
            SortEnabledButton.BackColor = Color.FromArgb(40,76,184);
        }


        private async void Connect_Clicked(object sender, EventArgs e)
        {
            //obsインスタンスの接続状況を取得
            var state = obs.State;

            //obs接続していない場合の処理
            if (state != WebSocketState.Open)
            {
                //接続ボタンを無効化
                ConnectButton.Enabled = false;
                //接続ボタンの状態を「接続中」に
                State_Var.Text = "connecting...";
                State_Var.ForeColor = Color.DarkGoldenrod;

                //接続を試行
                var conresult = await obs.Connect();
                //接続成功した場合の処理
                if (conresult)
                {
                    //ステータスをアクティブに
                    State_Var.Text = "active";
                    State_Var.ForeColor = Color.ForestGreen;
                    ConnectButton.ForeColor = Color.White;
                    //接続ボタンを無効化、「接続済み」に
                    ConnectButton.Text = "Connected.";
                    ConnectButton.Enabled = false;
                }
                //接続失敗した場合の処理
                else
                {
                    //ステータスを接続失敗に
                    State_Var.Text = "failed.";
                    State_Var.ForeColor = Color.IndianRed;
                    //接続ボタンを有効化、「再接続」に
                    ConnectButton.Enabled = true;
                    ConnectButton.Text = "Reconnect";
                }

            }
            //接続済みの場合
            //無効にしているため使われない処理、念のため保持
            else
            {
                //接続ボタン無効化
                ConnectButton.Enabled = false;
                //ステータスを処理中に
                State_Var.Text = "proccessing...";
                State_Var.ForeColor = Color.DarkGoldenrod;
                //接続解除
                await obs.Disconnect();
                //ステータスを切断済みに
                State_Var.Text = "inactive";
                State_Var.ForeColor = Color.IndianRed;
                //接続ボタンを有効化、「再接続」に
                ConnectButton.Enabled = true;
                ConnectButton.Text = "Reconnect";
            }
            

        }

        private void SetupButton_Click(object sender, EventArgs e)
        {
            //セットアップボタンを押した場合、メモ帳でjsonファイルを開く
            ProcessStartInfo procArg = new ProcessStartInfo();
            procArg.FileName = "notepad.exe";
            procArg.Arguments = obs.jsonFilePath;
            Process.Start(procArg);
        }


        private void SortEnabledButton_Click(object sender, EventArgs e)
        {
            //ソート有効時、ソートボタン有効化
            if (obs.SortEnabled)
                SortButtonDisable();
            else
                SortButtonEnable();

            //obsインスタンスのソート状態を切り替える
            obs.SortEnabled = !obs.SortEnabled;
        }

        private void Highlight_Click(object sender, EventArgs e)
        {
            string subDir = obs.GetCurrentGame();
            if (subDir.Length > 2)
                SavedReceived(sender, subDir);
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private async void ReferenceButton_Click(object sender, EventArgs e)
        {
            DialogResult dr = obsSelectDialog.ShowDialog();
            if (dr == DialogResult.OK)
            {
                string obsExePath = Path.GetDirectoryName(obsSelectDialog.FileName);
                obs.Set_obsPath(obsExePath);
                await launchOBS(obsExePath);                
            }
        }
    }

    
}

