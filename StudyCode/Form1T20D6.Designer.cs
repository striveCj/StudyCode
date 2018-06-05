namespace StudyCode
{
    partial class Form1T20D6
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
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btmPause = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rtbState = new System.Windows.Forms.TextBox();
            this.btnDownLoad = new System.Windows.Forms.Button();
            this.txbUrl = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(18, 70);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(487, 23);
            this.progressBar1.TabIndex = 29;
            // 
            // btmPause
            // 
            this.btmPause.Location = new System.Drawing.Point(430, 41);
            this.btmPause.Name = "btmPause";
            this.btmPause.Size = new System.Drawing.Size(75, 23);
            this.btmPause.TabIndex = 28;
            this.btmPause.Text = "暂停";
            this.btmPause.UseVisualStyleBackColor = true;
            this.btmPause.Click += new System.EventHandler(this.btmPause_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rtbState);
            this.groupBox1.Location = new System.Drawing.Point(12, 101);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(499, 149);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "状态：";
            // 
            // rtbState
            // 
            this.rtbState.Location = new System.Drawing.Point(6, 20);
            this.rtbState.Multiline = true;
            this.rtbState.Name = "rtbState";
            this.rtbState.Size = new System.Drawing.Size(487, 123);
            this.rtbState.TabIndex = 0;
            // 
            // btnDownLoad
            // 
            this.btnDownLoad.Location = new System.Drawing.Point(330, 41);
            this.btnDownLoad.Name = "btnDownLoad";
            this.btnDownLoad.Size = new System.Drawing.Size(75, 23);
            this.btnDownLoad.TabIndex = 26;
            this.btnDownLoad.Text = "下载";
            this.btnDownLoad.UseVisualStyleBackColor = true;
            this.btnDownLoad.Click += new System.EventHandler(this.btnDownLoad_Click);
            // 
            // txbUrl
            // 
            this.txbUrl.Location = new System.Drawing.Point(82, 14);
            this.txbUrl.Name = "txbUrl";
            this.txbUrl.Size = new System.Drawing.Size(429, 21);
            this.txbUrl.TabIndex = 25;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 24;
            this.label1.Text = "下载地址：";
            // 
            // Form1T20D6
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(527, 262);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btmPause);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnDownLoad);
            this.Controls.Add(this.txbUrl);
            this.Controls.Add(this.label1);
            this.Name = "Form1T20D6";
            this.Text = "Form1T20D6";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button btmPause;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox rtbState;
        private System.Windows.Forms.Button btnDownLoad;
        private System.Windows.Forms.TextBox txbUrl;
        private System.Windows.Forms.Label label1;
    }
}