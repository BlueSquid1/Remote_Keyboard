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
            this.keyTest = new System.Windows.Forms.Button();
            this.StartListerning = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.Connect = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // keyTest
            // 
            this.keyTest.Location = new System.Drawing.Point(95, 112);
            this.keyTest.Name = "keyTest";
            this.keyTest.Size = new System.Drawing.Size(75, 23);
            this.keyTest.TabIndex = 0;
            this.keyTest.Text = "Keyboard";
            this.keyTest.UseVisualStyleBackColor = true;
            this.keyTest.Click += new System.EventHandler(this.keyTest_Click);
            // 
            // StartListerning
            // 
            this.StartListerning.Location = new System.Drawing.Point(95, 75);
            this.StartListerning.Name = "StartListerning";
            this.StartListerning.Size = new System.Drawing.Size(75, 23);
            this.StartListerning.TabIndex = 1;
            this.StartListerning.Text = "Listen";
            this.StartListerning.UseVisualStyleBackColor = true;
            this.StartListerning.Click += new System.EventHandler(this.StartListerning_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(187, 210);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 3;
            // 
            // Connect
            // 
            this.Connect.Location = new System.Drawing.Point(95, 206);
            this.Connect.Name = "Connect";
            this.Connect.Size = new System.Drawing.Size(75, 23);
            this.Connect.TabIndex = 4;
            this.Connect.Text = "Connect";
            this.Connect.UseVisualStyleBackColor = true;
            this.Connect.Click += new System.EventHandler(this.Connect_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 261);
            this.Controls.Add(this.Connect);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.StartListerning);
            this.Controls.Add(this.keyTest);
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyDownEvent);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button keyTest;
        private System.Windows.Forms.Button StartListerning;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button Connect;
    }
}

