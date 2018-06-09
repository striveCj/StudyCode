namespace StudyCode
{
    partial class Form1T22D2
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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.btnReceive = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.tbxPort = new System.Windows.Forms.TextBox();
            this.tbxserverIp = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(38, 112);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(318, 136);
            this.listBox1.TabIndex = 24;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(281, 370);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 23;
            this.btnSend.Text = "发送";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(255, 65);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 22;
            this.button5.Text = "断开连接";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // btnReceive
            // 
            this.btnReceive.Location = new System.Drawing.Point(281, 270);
            this.btnReceive.Name = "btnReceive";
            this.btnReceive.Size = new System.Drawing.Size(75, 23);
            this.btnReceive.TabIndex = 21;
            this.btnReceive.Text = "接受";
            this.btnReceive.UseVisualStyleBackColor = true;
            this.btnReceive.Click += new System.EventHandler(this.btnReceive_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(189, 270);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 20;
            this.btnClear.Text = "清空消息";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(38, 313);
            this.textBox4.Multiline = true;
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(308, 51);
            this.textBox4.TabIndex = 19;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(86, 65);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 17;
            this.btnStart.Text = "链接到服务器";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // tbxPort
            // 
            this.tbxPort.Location = new System.Drawing.Point(246, 24);
            this.tbxPort.Name = "tbxPort";
            this.tbxPort.Size = new System.Drawing.Size(100, 21);
            this.tbxPort.TabIndex = 16;
            // 
            // tbxserverIp
            // 
            this.tbxserverIp.Location = new System.Drawing.Point(71, 24);
            this.tbxserverIp.Name = "tbxserverIp";
            this.tbxserverIp.Size = new System.Drawing.Size(100, 21);
            this.tbxserverIp.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(187, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 14;
            this.label2.Text = "端口号：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 13;
            this.label1.Text = "IP地址：";
            // 
            // Form1T22D2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(386, 425);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.btnReceive);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.tbxPort);
            this.Controls.Add(this.tbxserverIp);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1T22D2";
            this.Text = "Form1T22D2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button btnReceive;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox tbxPort;
        private System.Windows.Forms.TextBox tbxserverIp;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}