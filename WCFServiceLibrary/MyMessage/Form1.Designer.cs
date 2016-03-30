namespace MyMessage
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
            this.txtAllMessage = new System.Windows.Forms.TextBox();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.txtReceived = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_ip = new System.Windows.Forms.TextBox();
            this.la_ip = new System.Windows.Forms.Label();
            this.bt_connect = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtAllMessage
            // 
            this.txtAllMessage.Location = new System.Drawing.Point(12, 136);
            this.txtAllMessage.Multiline = true;
            this.txtAllMessage.Name = "txtAllMessage";
            this.txtAllMessage.ReadOnly = true;
            this.txtAllMessage.Size = new System.Drawing.Size(363, 346);
            this.txtAllMessage.TabIndex = 0;
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(12, 85);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(282, 20);
            this.txtMessage.TabIndex = 1;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(300, 84);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 2;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // txtReceived
            // 
            this.txtReceived.Location = new System.Drawing.Point(440, 25);
            this.txtReceived.Multiline = true;
            this.txtReceived.Name = "txtReceived";
            this.txtReceived.ReadOnly = true;
            this.txtReceived.Size = new System.Drawing.Size(335, 457);
            this.txtReceived.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 117);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Válasz";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(437, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Érkezett";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // tb_ip
            // 
            this.tb_ip.Location = new System.Drawing.Point(12, 30);
            this.tb_ip.Name = "tb_ip";
            this.tb_ip.Size = new System.Drawing.Size(100, 20);
            this.tb_ip.TabIndex = 6;
            // 
            // la_ip
            // 
            this.la_ip.AutoSize = true;
            this.la_ip.Location = new System.Drawing.Point(9, 14);
            this.la_ip.Name = "la_ip";
            this.la_ip.Size = new System.Drawing.Size(77, 13);
            this.la_ip.TabIndex = 7;
            this.la_ip.Text = "Connection IP:";
            // 
            // bt_connect
            // 
            this.bt_connect.Location = new System.Drawing.Point(12, 56);
            this.bt_connect.Name = "bt_connect";
            this.bt_connect.Size = new System.Drawing.Size(100, 23);
            this.bt_connect.TabIndex = 8;
            this.bt_connect.Text = "Connection";
            this.bt_connect.UseVisualStyleBackColor = true;
            this.bt_connect.Click += new System.EventHandler(this.bt_connect_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(787, 494);
            this.Controls.Add(this.bt_connect);
            this.Controls.Add(this.la_ip);
            this.Controls.Add(this.tb_ip);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtReceived);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.txtAllMessage);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtAllMessage;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox txtReceived;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_ip;
        private System.Windows.Forms.Label la_ip;
        private System.Windows.Forms.Button bt_connect;
    }
}

