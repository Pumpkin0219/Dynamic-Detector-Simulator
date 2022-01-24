namespace Dynamic_Detector_Simulator
{
    partial class Dynamic_Detector_Simulator
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
            this.textBox_ListenPort = new System.Windows.Forms.TextBox();
            this.label_Port = new System.Windows.Forms.Label();
            this.button_Start = new System.Windows.Forms.Button();
            this.button_SendHello = new System.Windows.Forms.Button();
            this.button_Clear = new System.Windows.Forms.Button();
            this.label_MinInterval = new System.Windows.Forms.Label();
            this.label_MaxInterval = new System.Windows.Forms.Label();
            this.label_FPS = new System.Windows.Forms.Label();
            this.numericUpDown_MinInterval = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_MaxInterval = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_FPS = new System.Windows.Forms.NumericUpDown();
            this.checkBox_File1 = new System.Windows.Forms.CheckBox();
            this.checkBox_File2 = new System.Windows.Forms.CheckBox();
            this.button_SendData = new System.Windows.Forms.Button();
            this.label_File1 = new System.Windows.Forms.Label();
            this.label_File2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_MinInterval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_MaxInterval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_FPS)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox_Log
            // 
            this.textBox_Log.Location = new System.Drawing.Point(28, 28);
            this.textBox_Log.Multiline = true;
            this.textBox_Log.Name = "textBox_Log";
            this.textBox_Log.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox_Log.Size = new System.Drawing.Size(738, 161);
            this.textBox_Log.TabIndex = 0;
            this.textBox_Log.WordWrap = false;
            // 
            // textBox_ListenPort
            // 
            this.textBox_ListenPort.Location = new System.Drawing.Point(153, 242);
            this.textBox_ListenPort.Name = "textBox_ListenPort";
            this.textBox_ListenPort.Size = new System.Drawing.Size(143, 25);
            this.textBox_ListenPort.TabIndex = 1;
            this.textBox_ListenPort.Text = "22";
            // 
            // label_Port
            // 
            this.label_Port.AutoSize = true;
            this.label_Port.Location = new System.Drawing.Point(34, 247);
            this.label_Port.Name = "label_Port";
            this.label_Port.Size = new System.Drawing.Size(47, 15);
            this.label_Port.TabIndex = 2;
            this.label_Port.Text = "Port:";
            // 
            // button_Start
            // 
            this.button_Start.Location = new System.Drawing.Point(416, 242);
            this.button_Start.Name = "button_Start";
            this.button_Start.Size = new System.Drawing.Size(113, 25);
            this.button_Start.TabIndex = 3;
            this.button_Start.Text = "Start";
            this.button_Start.UseVisualStyleBackColor = true;
            this.button_Start.Click += new System.EventHandler(this.button_Start_Click);
            // 
            // button_SendHello
            // 
            this.button_SendHello.Location = new System.Drawing.Point(23, 531);
            this.button_SendHello.Name = "button_SendHello";
            this.button_SendHello.Size = new System.Drawing.Size(113, 25);
            this.button_SendHello.TabIndex = 4;
            this.button_SendHello.Text = "Send Hello";
            this.button_SendHello.UseVisualStyleBackColor = true;
            this.button_SendHello.Click += new System.EventHandler(this.button_SendHello_Click);
            // 
            // button_Clear
            // 
            this.button_Clear.Location = new System.Drawing.Point(653, 242);
            this.button_Clear.Name = "button_Clear";
            this.button_Clear.Size = new System.Drawing.Size(113, 25);
            this.button_Clear.TabIndex = 5;
            this.button_Clear.Text = "Clear";
            this.button_Clear.UseVisualStyleBackColor = true;
            this.button_Clear.Click += new System.EventHandler(this.button_Clear_Click);
            // 
            // label_MinInterval
            // 
            this.label_MinInterval.AutoSize = true;
            this.label_MinInterval.Location = new System.Drawing.Point(20, 315);
            this.label_MinInterval.Name = "label_MinInterval";
            this.label_MinInterval.Size = new System.Drawing.Size(111, 15);
            this.label_MinInterval.TabIndex = 6;
            this.label_MinInterval.Text = "Min interval:";
            // 
            // label_MaxInterval
            // 
            this.label_MaxInterval.AutoSize = true;
            this.label_MaxInterval.Location = new System.Drawing.Point(20, 371);
            this.label_MaxInterval.Name = "label_MaxInterval";
            this.label_MaxInterval.Size = new System.Drawing.Size(111, 15);
            this.label_MaxInterval.TabIndex = 7;
            this.label_MaxInterval.Text = "Max interval:";
            // 
            // label_FPS
            // 
            this.label_FPS.AutoSize = true;
            this.label_FPS.Location = new System.Drawing.Point(345, 346);
            this.label_FPS.Name = "label_FPS";
            this.label_FPS.Size = new System.Drawing.Size(39, 15);
            this.label_FPS.TabIndex = 8;
            this.label_FPS.Text = "FPS:";
            // 
            // numericUpDown_MinInterval
            // 
            this.numericUpDown_MinInterval.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDown_MinInterval.Location = new System.Drawing.Point(153, 315);
            this.numericUpDown_MinInterval.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown_MinInterval.Name = "numericUpDown_MinInterval";
            this.numericUpDown_MinInterval.Size = new System.Drawing.Size(143, 25);
            this.numericUpDown_MinInterval.TabIndex = 9;
            this.numericUpDown_MinInterval.Value = new decimal(new int[] {
            400,
            0,
            0,
            0});
            // 
            // numericUpDown_MaxInterval
            // 
            this.numericUpDown_MaxInterval.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDown_MaxInterval.Location = new System.Drawing.Point(153, 371);
            this.numericUpDown_MaxInterval.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown_MaxInterval.Name = "numericUpDown_MaxInterval";
            this.numericUpDown_MaxInterval.Size = new System.Drawing.Size(143, 25);
            this.numericUpDown_MaxInterval.TabIndex = 10;
            this.numericUpDown_MaxInterval.Value = new decimal(new int[] {
            600,
            0,
            0,
            0});
            // 
            // numericUpDown_FPS
            // 
            this.numericUpDown_FPS.Location = new System.Drawing.Point(416, 344);
            this.numericUpDown_FPS.Name = "numericUpDown_FPS";
            this.numericUpDown_FPS.Size = new System.Drawing.Size(143, 25);
            this.numericUpDown_FPS.TabIndex = 11;
            this.numericUpDown_FPS.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // checkBox_File1
            // 
            this.checkBox_File1.AutoSize = true;
            this.checkBox_File1.Location = new System.Drawing.Point(28, 441);
            this.checkBox_File1.Name = "checkBox_File1";
            this.checkBox_File1.Size = new System.Drawing.Size(74, 19);
            this.checkBox_File1.TabIndex = 12;
            this.checkBox_File1.Text = "File 1";
            this.checkBox_File1.UseVisualStyleBackColor = true;
            this.checkBox_File1.CheckedChanged += new System.EventHandler(this.checkBox_File1_CheckedChanged);
            // 
            // checkBox_File2
            // 
            this.checkBox_File2.AutoSize = true;
            this.checkBox_File2.Location = new System.Drawing.Point(28, 476);
            this.checkBox_File2.Name = "checkBox_File2";
            this.checkBox_File2.Size = new System.Drawing.Size(74, 19);
            this.checkBox_File2.TabIndex = 13;
            this.checkBox_File2.Text = "File 2";
            this.checkBox_File2.UseVisualStyleBackColor = true;
            this.checkBox_File2.CheckedChanged += new System.EventHandler(this.checkBox_File2_CheckedChanged);
            // 
            // button_SendData
            // 
            this.button_SendData.Location = new System.Drawing.Point(183, 531);
            this.button_SendData.Name = "button_SendData";
            this.button_SendData.Size = new System.Drawing.Size(113, 25);
            this.button_SendData.TabIndex = 14;
            this.button_SendData.Text = "Send Data";
            this.button_SendData.UseVisualStyleBackColor = true;
            this.button_SendData.Click += new System.EventHandler(this.button_SendData_Click);
            // 
            // label_File1
            // 
            this.label_File1.AutoSize = true;
            this.label_File1.Location = new System.Drawing.Point(150, 442);
            this.label_File1.Name = "label_File1";
            this.label_File1.Size = new System.Drawing.Size(95, 15);
            this.label_File1.TabIndex = 15;
            this.label_File1.Text = "File Route:";
            // 
            // label_File2
            // 
            this.label_File2.AutoSize = true;
            this.label_File2.Location = new System.Drawing.Point(150, 480);
            this.label_File2.Name = "label_File2";
            this.label_File2.Size = new System.Drawing.Size(103, 15);
            this.label_File2.TabIndex = 16;
            this.label_File2.Text = "File2 Route:";
            // 
            // Dynamic_Detector_Simulator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 568);
            this.Controls.Add(this.label_File2);
            this.Controls.Add(this.label_File1);
            this.Controls.Add(this.button_SendData);
            this.Controls.Add(this.checkBox_File2);
            this.Controls.Add(this.checkBox_File1);
            this.Controls.Add(this.numericUpDown_FPS);
            this.Controls.Add(this.numericUpDown_MaxInterval);
            this.Controls.Add(this.numericUpDown_MinInterval);
            this.Controls.Add(this.label_FPS);
            this.Controls.Add(this.label_MaxInterval);
            this.Controls.Add(this.label_MinInterval);
            this.Controls.Add(this.button_Clear);
            this.Controls.Add(this.button_SendHello);
            this.Controls.Add(this.button_Start);
            this.Controls.Add(this.label_Port);
            this.Controls.Add(this.textBox_ListenPort);
            this.Controls.Add(this.textBox_Log);
            this.Name = "Dynamic_Detector_Simulator";
            this.Text = "Dynamic Detector Simulator";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_MinInterval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_MaxInterval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_FPS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_Log;
        private System.Windows.Forms.TextBox textBox_ListenPort;
        private System.Windows.Forms.Label label_Port;
        private System.Windows.Forms.Button button_Start;
        private System.Windows.Forms.Button button_SendHello;
        private System.Windows.Forms.Button button_Clear;
        private System.Windows.Forms.Label label_MinInterval;
        private System.Windows.Forms.Label label_MaxInterval;
        private System.Windows.Forms.Label label_FPS;
        private System.Windows.Forms.NumericUpDown numericUpDown_MinInterval;
        private System.Windows.Forms.NumericUpDown numericUpDown_MaxInterval;
        private System.Windows.Forms.NumericUpDown numericUpDown_FPS;
        private System.Windows.Forms.CheckBox checkBox_File1;
        private System.Windows.Forms.CheckBox checkBox_File2;
        private System.Windows.Forms.Button button_SendData;
        private System.Windows.Forms.Label label_File1;
        private System.Windows.Forms.Label label_File2;
    }
}