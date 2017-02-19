namespace AirKeyboard
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
            this.txtPressKeys = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabInput = new System.Windows.Forms.TabPage();
            this.tabPeers = new System.Windows.Forms.TabPage();
            this.lvPeers = new System.Windows.Forms.ListView();
            this.Peers = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabInput.SuspendLayout();
            this.tabPeers.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtPressKeys
            // 
            this.txtPressKeys.Location = new System.Drawing.Point(290, 6);
            this.txtPressKeys.Name = "txtPressKeys";
            this.txtPressKeys.Size = new System.Drawing.Size(218, 20);
            this.txtPressKeys.TabIndex = 1;
            this.txtPressKeys.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyDownEvent);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabInput);
            this.tabControl1.Controls.Add(this.tabPeers);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(522, 341);
            this.tabControl1.TabIndex = 2;
            this.tabControl1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyDownEvent);
            this.tabControl1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyUpEvent);
            // 
            // tabInput
            // 
            this.tabInput.Controls.Add(this.label3);
            this.tabInput.Controls.Add(this.groupBox2);
            this.tabInput.Controls.Add(this.txtPressKeys);
            this.tabInput.Location = new System.Drawing.Point(4, 22);
            this.tabInput.Name = "tabInput";
            this.tabInput.Padding = new System.Windows.Forms.Padding(3);
            this.tabInput.Size = new System.Drawing.Size(514, 315);
            this.tabInput.TabIndex = 0;
            this.tabInput.Text = "Input";
            this.tabInput.UseVisualStyleBackColor = true;
            // 
            // tabPeers
            // 
            this.tabPeers.Controls.Add(this.groupBox1);
            this.tabPeers.Controls.Add(this.lvPeers);
            this.tabPeers.Location = new System.Drawing.Point(4, 22);
            this.tabPeers.Name = "tabPeers";
            this.tabPeers.Padding = new System.Windows.Forms.Padding(3);
            this.tabPeers.Size = new System.Drawing.Size(514, 315);
            this.tabPeers.TabIndex = 1;
            this.tabPeers.Text = "Peers";
            this.tabPeers.UseVisualStyleBackColor = true;
            // 
            // lvPeers
            // 
            this.lvPeers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Peers});
            this.lvPeers.FullRowSelect = true;
            this.lvPeers.GridLines = true;
            this.lvPeers.Location = new System.Drawing.Point(133, 18);
            this.lvPeers.Name = "lvPeers";
            this.lvPeers.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lvPeers.Size = new System.Drawing.Size(195, 156);
            this.lvPeers.TabIndex = 3;
            this.lvPeers.UseCompatibleStateImageBehavior = false;
            this.lvPeers.View = System.Windows.Forms.View.Details;
            // 
            // Peers
            // 
            this.Peers.Text = "Known Peers";
            this.Peers.Width = 141;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.btnConnect);
            this.groupBox1.Location = new System.Drawing.Point(88, 211);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(285, 81);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Manual Connection";
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(164, 45);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 0;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(109, 19);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(130, 20);
            this.textBox1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "IP Address:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(196, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Type Here";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(19, 55);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(468, 231);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(214, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Keys Strokes:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(546, 365);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Air Keyboard";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyDownEvent);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyUpEvent);
            this.tabControl1.ResumeLayout(false);
            this.tabInput.ResumeLayout(false);
            this.tabInput.PerformLayout();
            this.tabPeers.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox txtPressKeys;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabInput;
        private System.Windows.Forms.TabPage tabPeers;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.ListView lvPeers;
        private System.Windows.Forms.ColumnHeader Peers;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
    }
}

