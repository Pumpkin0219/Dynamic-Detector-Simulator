namespace Client
{
    partial class Client
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
            this.textBox_Log = new System.Windows.Forms.TextBox();
            this.button_Connect = new System.Windows.Forms.Button();
            this.button_Disconnect = new System.Windows.Forms.Button();
            this.button_ChooseRoute = new System.Windows.Forms.Button();
            this.textBox_IP = new System.Windows.Forms.TextBox();
            this.textBox_Port = new System.Windows.Forms.TextBox();
            this.label_IP = new System.Windows.Forms.Label();
            this.label_Port = new System.Windows.Forms.Label();
            this.button_Clear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox_Log
            // 
            this.textBox_Log.Location = new System.Drawing.Point(70, 32);
            this.textBox_Log.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox_Log.Multiline = true;
            this.textBox_Log.Name = "textBox_Log";
            this.textBox_Log.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox_Log.Size = new System.Drawing.Size(792, 197);
            this.textBox_Log.TabIndex = 0;
            this.textBox_Log.WordWrap = false;
            // 
            // button_Connect
            // 
            this.button_Connect.Location = new System.Drawing.Point(372, 483);
            this.button_Connect.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_Connect.Name = "button_Connect";
            this.button_Connect.Size = new System.Drawing.Size(127, 33);
            this.button_Connect.TabIndex = 4;
            this.button_Connect.Text = "Connect";
            this.button_Connect.UseVisualStyleBackColor = true;
            this.button_Connect.Click += new System.EventHandler(this.button_Connect_Click);
            // 
            // button_Disconnect
            // 
            this.button_Disconnect.Location = new System.Drawing.Point(557, 483);
            this.button_Disconnect.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_Disconnect.Name = "button_Disconnect";
            this.button_Disconnect.Size = new System.Drawing.Size(127, 33);
            this.button_Disconnect.TabIndex = 5;
            this.button_Disconnect.Text = "Disconnect";
            this.button_Disconnect.UseVisualStyleBackColor = true;
            this.button_Disconnect.Click += new System.EventHandler(this.button_Disconnect_Click);
            // 
            // button_ChooseRoute
            // 
            this.button_ChooseRoute.Location = new System.Drawing.Point(735, 480);
            this.button_ChooseRoute.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_ChooseRoute.Name = "button_ChooseRoute";
            this.button_ChooseRoute.Size = new System.Drawing.Size(127, 33);
            this.button_ChooseRoute.TabIndex = 6;
            this.button_ChooseRoute.Text = "Choose";
            this.button_ChooseRoute.UseVisualStyleBackColor = true;
            this.button_ChooseRoute.Click += new System.EventHandler(this.button_ChooseRoute_Click);
            // 
            // textBox_IP
            // 
            this.textBox_IP.Location = new System.Drawing.Point(171, 411);
            this.textBox_IP.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox_IP.Multiline = true;
            this.textBox_IP.Name = "textBox_IP";
            this.textBox_IP.Size = new System.Drawing.Size(152, 32);
            this.textBox_IP.TabIndex = 7;
            this.textBox_IP.Text = "10.132.61.57";
            // 
            // textBox_Port
            // 
            this.textBox_Port.Location = new System.Drawing.Point(171, 483);
            this.textBox_Port.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox_Port.Name = "textBox_Port";
            this.textBox_Port.Size = new System.Drawing.Size(152, 26);
            this.textBox_Port.TabIndex = 8;
            this.textBox_Port.Text = "22";
            // 
            // label_IP
            // 
            this.label_IP.AutoSize = true;
            this.label_IP.Location = new System.Drawing.Point(80, 424);
            this.label_IP.Name = "label_IP";
            this.label_IP.Size = new System.Drawing.Size(24, 20);
            this.label_IP.TabIndex = 9;
            this.label_IP.Text = "IP";
            // 
            // label_Port
            // 
            this.label_Port.AutoSize = true;
            this.label_Port.Location = new System.Drawing.Point(80, 493);
            this.label_Port.Name = "label_Port";
            this.label_Port.Size = new System.Drawing.Size(38, 20);
            this.label_Port.TabIndex = 10;
            this.label_Port.Text = "Port";
            // 
            // button_Clear
            // 
            this.button_Clear.Location = new System.Drawing.Point(735, 272);
            this.button_Clear.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_Clear.Name = "button_Clear";
            this.button_Clear.Size = new System.Drawing.Size(127, 33);
            this.button_Clear.TabIndex = 11;
            this.button_Clear.Text = "Clear";
            this.button_Clear.UseVisualStyleBackColor = true;
            this.button_Clear.Click += new System.EventHandler(this.button_Clear_Click);
            // 
            // Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.Controls.Add(this.button_Clear);
            this.Controls.Add(this.label_Port);
            this.Controls.Add(this.label_IP);
            this.Controls.Add(this.textBox_Port);
            this.Controls.Add(this.textBox_IP);
            this.Controls.Add(this.button_ChooseRoute);
            this.Controls.Add(this.button_Disconnect);
            this.Controls.Add(this.button_Connect);
            this.Controls.Add(this.textBox_Log);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Client";
            this.Text = "Client";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_Log;
        private System.Windows.Forms.Button button_Connect;
        private System.Windows.Forms.Button button_Disconnect;
        private System.Windows.Forms.Button button_ChooseRoute;
        private System.Windows.Forms.TextBox textBox_IP;
        private System.Windows.Forms.TextBox textBox_Port;
        private System.Windows.Forms.Label label_IP;
        private System.Windows.Forms.Label label_Port;
        private System.Windows.Forms.Button button_Clear;
    }
}