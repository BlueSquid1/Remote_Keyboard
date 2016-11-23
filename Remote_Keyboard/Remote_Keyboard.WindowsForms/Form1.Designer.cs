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
            this.testKey = new System.Windows.Forms.Button();
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
            // testKey
            // 
            this.testKey.Location = new System.Drawing.Point(95, 164);
            this.testKey.Name = "testKey";
            this.testKey.Size = new System.Drawing.Size(75, 23);
            this.testKey.TabIndex = 2;
            this.testKey.Text = "test key";
            this.testKey.UseVisualStyleBackColor = true;
            this.testKey.Click += new System.EventHandler(this.testKey_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.testKey);
            this.Controls.Add(this.StartListerning);
            this.Controls.Add(this.keyTest);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button keyTest;
        private System.Windows.Forms.Button StartListerning;
        private System.Windows.Forms.Button testKey;
    }
}

