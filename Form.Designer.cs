namespace OBS_J
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.ConnectButton = new System.Windows.Forms.Button();
            this.State_Var = new System.Windows.Forms.Label();
            this.RelationGrid = new System.Windows.Forms.DataGridView();
            this.SetupButton = new System.Windows.Forms.Button();
            this.SortEnabledButton = new System.Windows.Forms.Button();
            this.TestGameButton = new System.Windows.Forms.Button();
            this.ReferenceButton = new System.Windows.Forms.Button();
            this.obsSelectDialog = new System.Windows.Forms.OpenFileDialog();
            this.words = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Folders = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.RelationGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // ConnectButton
            // 
            this.ConnectButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(64)))), ((int)(((byte)(75)))));
            this.ConnectButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(64)))), ((int)(((byte)(75)))));
            this.ConnectButton.FlatAppearance.BorderSize = 0;
            this.ConnectButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(27)))), ((int)(((byte)(38)))));
            this.ConnectButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(83)))), ((int)(((byte)(94)))));
            this.ConnectButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ConnectButton.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConnectButton.ForeColor = System.Drawing.Color.White;
            this.ConnectButton.Location = new System.Drawing.Point(12, 8);
            this.ConnectButton.Margin = new System.Windows.Forms.Padding(0);
            this.ConnectButton.Name = "ConnectButton";
            this.ConnectButton.Padding = new System.Windows.Forms.Padding(2);
            this.ConnectButton.Size = new System.Drawing.Size(104, 26);
            this.ConnectButton.TabIndex = 0;
            this.ConnectButton.Text = "Connect";
            this.ConnectButton.UseVisualStyleBackColor = false;
            this.ConnectButton.Click += new System.EventHandler(this.Connect_Clicked);
            // 
            // State_Var
            // 
            this.State_Var.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(51)))), ((int)(((byte)(57)))));
            this.State_Var.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.State_Var.Font = new System.Drawing.Font("Meiryo UI", 10F, System.Drawing.FontStyle.Bold);
            this.State_Var.ForeColor = System.Drawing.Color.IndianRed;
            this.State_Var.Location = new System.Drawing.Point(126, 8);
            this.State_Var.Margin = new System.Windows.Forms.Padding(0);
            this.State_Var.Name = "State_Var";
            this.State_Var.Padding = new System.Windows.Forms.Padding(2);
            this.State_Var.Size = new System.Drawing.Size(126, 26);
            this.State_Var.TabIndex = 2;
            this.State_Var.Text = "inactive";
            this.State_Var.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // RelationGrid
            // 
            this.RelationGrid.AllowUserToAddRows = false;
            this.RelationGrid.AllowUserToDeleteRows = false;
            this.RelationGrid.AllowUserToResizeColumns = false;
            this.RelationGrid.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.RelationGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.RelationGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.RelationGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.RelationGrid.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(46)))), ((int)(((byte)(56)))));
            this.RelationGrid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.RelationGrid.CausesValidation = false;
            this.RelationGrid.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.RelationGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(64)))), ((int)(((byte)(75)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Meiryo UI", 9.75F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(2);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(64)))), ((int)(((byte)(75)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.RelationGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.RelationGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.RelationGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.words,
            this.Folders});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(46)))), ((int)(((byte)(56)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.RelationGrid.DefaultCellStyle = dataGridViewCellStyle5;
            this.RelationGrid.EnableHeadersVisualStyles = false;
            this.RelationGrid.GridColor = System.Drawing.Color.DimGray;
            this.RelationGrid.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.RelationGrid.Location = new System.Drawing.Point(257, 8);
            this.RelationGrid.MultiSelect = false;
            this.RelationGrid.Name = "RelationGrid";
            this.RelationGrid.ReadOnly = true;
            this.RelationGrid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.RelationGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.RelationGrid.RowHeadersVisible = false;
            this.RelationGrid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.RelationGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.RelationGrid.Size = new System.Drawing.Size(262, 233);
            this.RelationGrid.TabIndex = 3;
            this.RelationGrid.TabStop = false;
            this.RelationGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.RelationGrid_CellContentClick);
            // 
            // SetupButton
            // 
            this.SetupButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(64)))), ((int)(((byte)(75)))));
            this.SetupButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(64)))), ((int)(((byte)(75)))));
            this.SetupButton.FlatAppearance.BorderSize = 0;
            this.SetupButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(27)))), ((int)(((byte)(38)))));
            this.SetupButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(83)))), ((int)(((byte)(94)))));
            this.SetupButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SetupButton.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SetupButton.ForeColor = System.Drawing.Color.White;
            this.SetupButton.Location = new System.Drawing.Point(9, 152);
            this.SetupButton.Margin = new System.Windows.Forms.Padding(0);
            this.SetupButton.Name = "SetupButton";
            this.SetupButton.Padding = new System.Windows.Forms.Padding(2);
            this.SetupButton.Size = new System.Drawing.Size(243, 26);
            this.SetupButton.TabIndex = 4;
            this.SetupButton.Text = "Open Setup File";
            this.SetupButton.UseVisualStyleBackColor = false;
            this.SetupButton.Click += new System.EventHandler(this.SetupButton_Click);
            // 
            // SortEnabledButton
            // 
            this.SortEnabledButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(64)))), ((int)(((byte)(75)))));
            this.SortEnabledButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(64)))), ((int)(((byte)(75)))));
            this.SortEnabledButton.FlatAppearance.BorderSize = 0;
            this.SortEnabledButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(27)))), ((int)(((byte)(38)))));
            this.SortEnabledButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(83)))), ((int)(((byte)(94)))));
            this.SortEnabledButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SortEnabledButton.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SortEnabledButton.ForeColor = System.Drawing.Color.White;
            this.SortEnabledButton.Location = new System.Drawing.Point(12, 44);
            this.SortEnabledButton.Margin = new System.Windows.Forms.Padding(0);
            this.SortEnabledButton.Name = "SortEnabledButton";
            this.SortEnabledButton.Padding = new System.Windows.Forms.Padding(2);
            this.SortEnabledButton.Size = new System.Drawing.Size(240, 26);
            this.SortEnabledButton.TabIndex = 5;
            this.SortEnabledButton.Text = "Sort Enable";
            this.SortEnabledButton.UseVisualStyleBackColor = false;
            this.SortEnabledButton.Click += new System.EventHandler(this.SortEnabledButton_Click);
            // 
            // TestGameButton
            // 
            this.TestGameButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(64)))), ((int)(((byte)(75)))));
            this.TestGameButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(64)))), ((int)(((byte)(75)))));
            this.TestGameButton.FlatAppearance.BorderSize = 0;
            this.TestGameButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(27)))), ((int)(((byte)(38)))));
            this.TestGameButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(83)))), ((int)(((byte)(94)))));
            this.TestGameButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TestGameButton.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TestGameButton.ForeColor = System.Drawing.Color.White;
            this.TestGameButton.Location = new System.Drawing.Point(12, 80);
            this.TestGameButton.Margin = new System.Windows.Forms.Padding(0);
            this.TestGameButton.Name = "TestGameButton";
            this.TestGameButton.Padding = new System.Windows.Forms.Padding(2);
            this.TestGameButton.Size = new System.Drawing.Size(240, 26);
            this.TestGameButton.TabIndex = 6;
            this.TestGameButton.Text = "Highlight Current Game";
            this.TestGameButton.UseVisualStyleBackColor = false;
            this.TestGameButton.Click += new System.EventHandler(this.Highlight_Click);
            // 
            // ReferenceButton
            // 
            this.ReferenceButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(64)))), ((int)(((byte)(75)))));
            this.ReferenceButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(64)))), ((int)(((byte)(75)))));
            this.ReferenceButton.FlatAppearance.BorderSize = 0;
            this.ReferenceButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(27)))), ((int)(((byte)(38)))));
            this.ReferenceButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(83)))), ((int)(((byte)(94)))));
            this.ReferenceButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ReferenceButton.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReferenceButton.ForeColor = System.Drawing.Color.White;
            this.ReferenceButton.Location = new System.Drawing.Point(12, 116);
            this.ReferenceButton.Margin = new System.Windows.Forms.Padding(0);
            this.ReferenceButton.Name = "ReferenceButton";
            this.ReferenceButton.Padding = new System.Windows.Forms.Padding(2);
            this.ReferenceButton.Size = new System.Drawing.Size(240, 26);
            this.ReferenceButton.TabIndex = 7;
            this.ReferenceButton.Text = "Select OBS Studio file";
            this.ReferenceButton.UseVisualStyleBackColor = false;
            this.ReferenceButton.Click += new System.EventHandler(this.ReferenceButton_Click);
            // 
            // obsSelectDialog
            // 
            this.obsSelectDialog.FileName = "obs64.exe";
            this.obsSelectDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // words
            // 
            this.words.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(64)))), ((int)(((byte)(75)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Noto Sans JP Medium", 9.75F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(2);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(64)))), ((int)(((byte)(75)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            this.words.DefaultCellStyle = dataGridViewCellStyle3;
            this.words.FillWeight = 80F;
            this.words.HeaderText = "Search Word";
            this.words.Name = "words";
            this.words.ReadOnly = true;
            this.words.Width = 115;
            // 
            // Folders
            // 
            this.Folders.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(64)))), ((int)(((byte)(75)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Noto Sans JP Medium", 9.75F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Padding = new System.Windows.Forms.Padding(2);
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(64)))), ((int)(((byte)(75)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            this.Folders.DefaultCellStyle = dataGridViewCellStyle4;
            this.Folders.HeaderText = "Folder Name";
            this.Folders.Name = "Folders";
            this.Folders.ReadOnly = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(46)))), ((int)(((byte)(56)))));
            this.ClientSize = new System.Drawing.Size(531, 253);
            this.Controls.Add(this.ReferenceButton);
            this.Controls.Add(this.TestGameButton);
            this.Controls.Add(this.SortEnabledButton);
            this.Controls.Add(this.SetupButton);
            this.Controls.Add(this.RelationGrid);
            this.Controls.Add(this.State_Var);
            this.Controls.Add(this.ConnectButton);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "OBSJ";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.RelationGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ConnectButton;
        private System.Windows.Forms.Label State_Var;
        private System.Windows.Forms.Button SetupButton;
        private System.Windows.Forms.Button SortEnabledButton;
        private System.Windows.Forms.Button TestGameButton;
        private System.Windows.Forms.Button ReferenceButton;
        private System.Windows.Forms.OpenFileDialog obsSelectDialog;
        private System.Windows.Forms.DataGridView RelationGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn words;
        private System.Windows.Forms.DataGridViewTextBoxColumn Folders;
    }
}

