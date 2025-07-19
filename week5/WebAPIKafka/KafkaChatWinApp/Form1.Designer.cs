namespace KafkaChatWinApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            label1 = new Label();
            panel1 = new Panel();
            label4 = new Label();
            label3 = new Label();
            btnRecieve = new Button();
            btnSend = new Button();
            txtMessage = new TextBox();
            ChatBox = new ListBox();
            label2 = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            timer2 = new System.Windows.Forms.Timer(components);
            label5 = new Label();
            label6 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(100, 23);
            label1.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(btnRecieve);
            panel1.Controls.Add(btnSend);
            panel1.Controls.Add(txtMessage);
            panel1.Controls.Add(ChatBox);
            panel1.Controls.Add(label2);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(767, 491);
            panel1.TabIndex = 1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(37, 265);
            label4.Name = "label4";
            label4.Size = new Size(103, 25);
            label4.TabIndex = 8;
            label4.Text = "Type Here...";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.Desktop;
            label3.Location = new Point(210, 19);
            label3.Name = "label3";
            label3.Size = new Size(314, 38);
            label3.TabIndex = 7;
            label3.Text = "CHAT APPLICATION UI";
            // 
            // btnRecieve
            // 
            btnRecieve.Location = new Point(505, 375);
            btnRecieve.Name = "btnRecieve";
            btnRecieve.Size = new Size(161, 73);
            btnRecieve.TabIndex = 4;
            btnRecieve.Text = "Recieve";
            btnRecieve.UseVisualStyleBackColor = true;
            btnRecieve.Click += btnRecieve_Click;
            // 
            // btnSend
            // 
            btnSend.Location = new Point(102, 375);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(161, 73);
            btnSend.TabIndex = 5;
            btnSend.Text = "Send";
            btnSend.Click += btnSend_Click_1;
            // 
            // txtMessage
            // 
            txtMessage.Location = new Point(37, 306);
            txtMessage.Name = "txtMessage";
            txtMessage.Size = new Size(695, 31);
            txtMessage.TabIndex = 2;
            // 
            // ChatBox
            // 
            ChatBox.FormattingEnabled = true;
            ChatBox.ItemHeight = 25;
            ChatBox.Location = new Point(37, 91);
            ChatBox.Name = "ChatBox";
            ChatBox.Size = new Size(695, 129);
            ChatBox.TabIndex = 1;
            // 
            // label2
            // 
            label2.Location = new Point(0, 0);
            label2.Name = "label2";
            label2.Size = new Size(100, 23);
            label2.TabIndex = 6;
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 2000;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(37, 451);
            label5.Name = "label5";
            label5.Size = new Size(311, 25);
            label5.TabIndex = 9;
            label5.Text = "Click here if you are simulating sender";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(414, 451);
            label6.Name = "label6";
            label6.Size = new Size(318, 25);
            label6.TabIndex = 10;
            label6.Text = "Click here if you are simulating reciever";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(813, 553);
            Controls.Add(panel1);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Panel panel1;
        private Label label2;
        private Button btnSend;
        private TextBox txtMessage;
        private ListBox ChatBox;
        private System.Windows.Forms.Timer timer1;
        private Button btnRecieve;
        private Label label3;
        private System.Windows.Forms.Timer timer2;
        private Label label4;
        private Label label6;
        private Label label5;
    }
}
