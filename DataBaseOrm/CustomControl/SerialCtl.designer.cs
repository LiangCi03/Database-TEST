namespace CommonUI.CustomControl
{
    partial class SerialCtl
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.grpSerial = new System.Windows.Forms.GroupBox();
            this.cmbParity = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbStopbits = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbDatabits = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbBaudRate = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbPortName = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.comopen1 = new System.Windows.Forms.CheckBox();
            this.grpSerial.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpSerial
            // 
            this.grpSerial.Controls.Add(this.cmbParity);
            this.grpSerial.Controls.Add(this.label7);
            this.grpSerial.Controls.Add(this.cmbStopbits);
            this.grpSerial.Controls.Add(this.label8);
            this.grpSerial.Controls.Add(this.cmbDatabits);
            this.grpSerial.Controls.Add(this.label9);
            this.grpSerial.Controls.Add(this.cmbBaudRate);
            this.grpSerial.Controls.Add(this.label10);
            this.grpSerial.Controls.Add(this.cmbPortName);
            this.grpSerial.Controls.Add(this.label11);
            this.grpSerial.Controls.Add(this.comopen1);
            this.grpSerial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpSerial.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.grpSerial.Location = new System.Drawing.Point(0, 0);
            this.grpSerial.Margin = new System.Windows.Forms.Padding(4);
            this.grpSerial.Name = "grpSerial";
            this.grpSerial.Padding = new System.Windows.Forms.Padding(4);
            this.grpSerial.Size = new System.Drawing.Size(915, 111);
            this.grpSerial.TabIndex = 10;
            this.grpSerial.TabStop = false;
            this.grpSerial.Text = "串口1";
            // 
            // cmbParity
            // 
            this.cmbParity.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbParity.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbParity.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.cmbParity.FormattingEnabled = true;
            this.cmbParity.Items.AddRange(new object[] {
            "无",
            "奇校验",
            "偶校验",
            "校验位为1",
            "校验位为0"});
            this.cmbParity.Location = new System.Drawing.Point(603, 57);
            this.cmbParity.Margin = new System.Windows.Forms.Padding(4);
            this.cmbParity.MaxDropDownItems = 10;
            this.cmbParity.Name = "cmbParity";
            this.cmbParity.Size = new System.Drawing.Size(112, 30);
            this.cmbParity.TabIndex = 2;
            this.cmbParity.Text = "无";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(615, 28);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 22);
            this.label7.TabIndex = 1;
            this.label7.Text = "奇偶校验：";
            // 
            // cmbStopbits
            // 
            this.cmbStopbits.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbStopbits.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbStopbits.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.cmbStopbits.FormattingEnabled = true;
            this.cmbStopbits.Items.AddRange(new object[] {
            "0",
            "1",
            "1.5",
            "2"});
            this.cmbStopbits.Location = new System.Drawing.Point(480, 57);
            this.cmbStopbits.Margin = new System.Windows.Forms.Padding(4);
            this.cmbStopbits.MaxDropDownItems = 10;
            this.cmbStopbits.Name = "cmbStopbits";
            this.cmbStopbits.Size = new System.Drawing.Size(112, 30);
            this.cmbStopbits.TabIndex = 2;
            this.cmbStopbits.Text = "1";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label8.Location = new System.Drawing.Point(492, 28);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(82, 22);
            this.label8.TabIndex = 1;
            this.label8.Text = "停止位：";
            // 
            // cmbDatabits
            // 
            this.cmbDatabits.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbDatabits.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbDatabits.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.cmbDatabits.FormattingEnabled = true;
            this.cmbDatabits.Items.AddRange(new object[] {
            "7",
            "8"});
            this.cmbDatabits.Location = new System.Drawing.Point(333, 57);
            this.cmbDatabits.Margin = new System.Windows.Forms.Padding(4);
            this.cmbDatabits.MaxDropDownItems = 10;
            this.cmbDatabits.Name = "cmbDatabits";
            this.cmbDatabits.Size = new System.Drawing.Size(112, 30);
            this.cmbDatabits.TabIndex = 2;
            this.cmbDatabits.Text = "8";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label9.Location = new System.Drawing.Point(345, 28);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(82, 22);
            this.label9.TabIndex = 1;
            this.label9.Text = "数据位：";
            // 
            // cmbBaudRate
            // 
            this.cmbBaudRate.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbBaudRate.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbBaudRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.cmbBaudRate.FormattingEnabled = true;
            this.cmbBaudRate.Items.AddRange(new object[] {
            "4800",
            "9600",
            "14400",
            "19200",
            "38400",
            "57600",
            "115200"});
            this.cmbBaudRate.Location = new System.Drawing.Point(182, 57);
            this.cmbBaudRate.Margin = new System.Windows.Forms.Padding(4);
            this.cmbBaudRate.MaxDropDownItems = 10;
            this.cmbBaudRate.Name = "cmbBaudRate";
            this.cmbBaudRate.Size = new System.Drawing.Size(112, 30);
            this.cmbBaudRate.TabIndex = 2;
            this.cmbBaudRate.Text = "9600";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label10.Location = new System.Drawing.Point(194, 28);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(82, 22);
            this.label10.TabIndex = 1;
            this.label10.Text = "波特率：";
            // 
            // cmbPortName
            // 
            this.cmbPortName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbPortName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbPortName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.cmbPortName.FormattingEnabled = true;
            this.cmbPortName.Items.AddRange(new object[] {
            "COM1",
            "COM2",
            "COM3",
            "COM4",
            "COM5",
            "COM6",
            "COM7",
            "COM8",
            "COM9",
            "COM10"});
            this.cmbPortName.Location = new System.Drawing.Point(36, 57);
            this.cmbPortName.Margin = new System.Windows.Forms.Padding(4);
            this.cmbPortName.MaxDropDownItems = 10;
            this.cmbPortName.Name = "cmbPortName";
            this.cmbPortName.Size = new System.Drawing.Size(112, 30);
            this.cmbPortName.TabIndex = 2;
            this.cmbPortName.Text = "COM1";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label11.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label11.Location = new System.Drawing.Point(51, 28);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(82, 22);
            this.label11.TabIndex = 1;
            this.label11.Text = "串口名：";
            // 
            // comopen1
            // 
            this.comopen1.Appearance = System.Windows.Forms.Appearance.Button;
            this.comopen1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.comopen1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.comopen1.Location = new System.Drawing.Point(753, 46);
            this.comopen1.Margin = new System.Windows.Forms.Padding(4);
            this.comopen1.Name = "comopen1";
            this.comopen1.Size = new System.Drawing.Size(132, 50);
            this.comopen1.TabIndex = 0;
            this.comopen1.Text = "打开";
            this.comopen1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.comopen1.UseVisualStyleBackColor = true;
            // 
            // SerialCtl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpSerial);
            this.Name = "SerialCtl";
            this.Size = new System.Drawing.Size(915, 111);
            this.grpSerial.ResumeLayout(false);
            this.grpSerial.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpSerial;
        private System.Windows.Forms.ComboBox cmbParity;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbStopbits;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbDatabits;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbBaudRate;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cmbPortName;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.CheckBox comopen1;
    }
}
