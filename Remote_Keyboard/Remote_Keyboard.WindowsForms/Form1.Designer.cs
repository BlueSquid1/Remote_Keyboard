namespace Remote_Keyboard.WindowsForms
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            clipboardEvent.DisposeClipboard();
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tabControl = new System.Windows.Forms.TabControl();
            this.inputTab = new System.Windows.Forms.TabPage();
            this.PeersTab = new System.Windows.Forms.TabPage();
            this.peerListView = new System.Windows.Forms.ListView();
            this.ipAddress = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AcceptInput = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.status = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imgListOS = new System.Windows.Forms.ImageList(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ConnectBtn = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SettingsTab = new System.Windows.Forms.TabPage();
            this.chkBtnkeyboard = new System.Windows.Forms.CheckBox();
            this.chkBtnServer = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.KeysPressed = new System.Windows.Forms.TextBox();
            this.tabControl.SuspendLayout();
            this.PeersTab.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SettingsTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.inputTab);
            this.tabControl.Controls.Add(this.PeersTab);
            this.tabControl.Controls.Add(this.SettingsTab);
            this.tabControl.ItemSize = new System.Drawing.Size(42, 18);
            this.tabControl.Location = new System.Drawing.Point(12, 56);
            this.tabControl.Multiline = true;
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.ShowToolTips = true;
            this.tabControl.Size = new System.Drawing.Size(568, 273);
            this.tabControl.TabIndex = 5;
            // 
            // inputTab
            // 
            this.inputTab.Location = new System.Drawing.Point(4, 22);
            this.inputTab.Name = "inputTab";
            this.inputTab.Padding = new System.Windows.Forms.Padding(3);
            this.inputTab.Size = new System.Drawing.Size(560, 247);
            this.inputTab.TabIndex = 0;
            this.inputTab.Text = "Input";
            this.inputTab.UseVisualStyleBackColor = true;
            // 
            // PeersTab
            // 
            this.PeersTab.Controls.Add(this.peerListView);
            this.PeersTab.Controls.Add(this.groupBox1);
            this.PeersTab.Location = new System.Drawing.Point(4, 22);
            this.PeersTab.Name = "PeersTab";
            this.PeersTab.Size = new System.Drawing.Size(560, 247);
            this.PeersTab.TabIndex = 2;
            this.PeersTab.Text = "Peers";
            this.PeersTab.UseVisualStyleBackColor = true;
            // 
            // peerListView
            // 
            this.peerListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ipAddress,
            this.AcceptInput,
            this.status});
            this.peerListView.FullRowSelect = true;
            this.peerListView.GridLines = true;
            this.peerListView.LargeImageList = this.imgListOS;
            this.peerListView.Location = new System.Drawing.Point(102, 99);
            this.peerListView.Name = "peerListView";
            this.peerListView.Size = new System.Drawing.Size(384, 143);
            this.peerListView.SmallImageList = this.imgListOS;
            this.peerListView.TabIndex = 4;
            this.peerListView.UseCompatibleStateImageBehavior = false;
            this.peerListView.View = System.Windows.Forms.View.Details;
            // 
            // ipAddress
            // 
            this.ipAddress.Text = "IP Address";
            this.ipAddress.Width = 150;
            // 
            // AcceptInput
            // 
            this.AcceptInput.Text = "Accept Input";
            this.AcceptInput.Width = 88;
            // 
            // status
            // 
            this.status.Text = "Status";
            // 
            // imgListOS
            // 
            this.imgListOS.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgListOS.ImageStream")));
            this.imgListOS.TransparentColor = System.Drawing.Color.Transparent;
            this.imgListOS.Images.SetKeyName(0, "Windows_icon.png");
            this.imgListOS.Images.SetKeyName(1, "mac_icon.png");
            this.imgListOS.Images.SetKeyName(2, "linux_icon.png");
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ConnectBtn);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Location = new System.Drawing.Point(102, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(323, 60);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Direct Connect";
            // 
            // ConnectBtn
            // 
            this.ConnectBtn.Location = new System.Drawing.Point(200, 19);
            this.ConnectBtn.Name = "ConnectBtn";
            this.ConnectBtn.Size = new System.Drawing.Size(75, 23);
            this.ConnectBtn.TabIndex = 1;
            this.ConnectBtn.Text = "Connect";
            this.ConnectBtn.UseVisualStyleBackColor = true;
            this.ConnectBtn.Click += new System.EventHandler(this.DirectConnect);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(54, 21);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(140, 20);
            this.textBox1.TabIndex = 0;
            // 
            // SettingsTab
            // 
            this.SettingsTab.Controls.Add(this.chkBtnkeyboard);
            this.SettingsTab.Controls.Add(this.chkBtnServer);
            this.SettingsTab.Location = new System.Drawing.Point(4, 22);
            this.SettingsTab.Name = "SettingsTab";
            this.SettingsTab.Padding = new System.Windows.Forms.Padding(3);
            this.SettingsTab.Size = new System.Drawing.Size(560, 247);
            this.SettingsTab.TabIndex = 1;
            this.SettingsTab.Text = "Settings";
            this.SettingsTab.UseVisualStyleBackColor = true;
            // 
            // chkBtnkeyboard
            // 
            this.chkBtnkeyboard.AutoSize = true;
            this.chkBtnkeyboard.Checked = true;
            this.chkBtnkeyboard.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBtnkeyboard.Location = new System.Drawing.Point(29, 51);
            this.chkBtnkeyboard.Name = "chkBtnkeyboard";
            this.chkBtnkeyboard.Size = new System.Drawing.Size(155, 17);
            this.chkBtnkeyboard.TabIndex = 1;
            this.chkBtnkeyboard.Text = "Enable Keyboard Listerning";
            this.chkBtnkeyboard.UseVisualStyleBackColor = true;
            // 
            // chkBtnServer
            // 
            this.chkBtnServer.AutoSize = true;
            this.chkBtnServer.Checked = true;
            this.chkBtnServer.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBtnServer.Location = new System.Drawing.Point(29, 27);
            this.chkBtnServer.Name = "chkBtnServer";
            this.chkBtnServer.Size = new System.Drawing.Size(150, 17);
            this.chkBtnServer.TabIndex = 0;
            this.chkBtnServer.Text = "Enable Network Listerning";
            this.chkBtnServer.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(502, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Keys Pressed:";
            // 
            // KeysPressed
            // 
            this.KeysPressed.Enabled = false;
            this.KeysPressed.Location = new System.Drawing.Point(366, 34);
            this.KeysPressed.Name = "KeysPressed";
            this.KeysPressed.Size = new System.Drawing.Size(207, 20);
            this.KeysPressed.TabIndex = 7;
            this.KeysPressed.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 341);
            this.Controls.Add(this.KeysPressed);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tabControl);
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "Air Keyboard";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyDownEvent);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyUpEvent);
            this.tabControl.ResumeLayout(false);
            this.PeersTab.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.SettingsTab.ResumeLayout(false);
            this.SettingsTab.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage inputTab;
        private System.Windows.Forms.TabPage SettingsTab;
        private System.Windows.Forms.CheckBox chkBtnServer;
        private System.Windows.Forms.TabPage PeersTab;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button ConnectBtn;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.CheckBox chkBtnkeyboard;
        private System.Windows.Forms.ListView peerListView;
        private System.Windows.Forms.ColumnHeader ipAddress;
        private System.Windows.Forms.ColumnHeader status;
        private System.Windows.Forms.ImageList imgListOS;
        private System.Windows.Forms.ColumnHeader AcceptInput;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox KeysPressed;
    }
}

