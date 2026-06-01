namespace CommonUI.CustomControl
{
    partial class EthernetCtl
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
            this.grpEthernet = new System.Windows.Forms.GroupBox();
            this.cmbIP = new System.Windows.Forms.ComboBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.label48 = new System.Windows.Forms.Label();
            this.label47 = new System.Windows.Forms.Label();
            this.server1bulid = new System.Windows.Forms.CheckBox();
            this.grpEthernet.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpEthernet
            // 
            this.grpEthernet.Controls.Add(this.cmbIP);
            this.grpEthernet.Controls.Add(this.txtPort);
            this.grpEthernet.Controls.Add(this.label48);
            this.grpEthernet.Controls.Add(this.label47);
            this.grpEthernet.Controls.Add(this.server1bulid);
            this.grpEthernet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpEthernet.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.grpEthernet.Location = new System.Drawing.Point(0, 0);
            this.grpEthernet.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.grpEthernet.Name = "grpEthernet";
            this.grpEthernet.Padding = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.grpEthernet.Size = new System.Drawing.Size(651, 69);
            this.grpEthernet.TabIndex = 11;
            this.grpEthernet.TabStop = false;
            this.grpEthernet.Text = "TCP配置1";
            // 
            // cmbIP
            // 
            this.cmbIP.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbIP.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbIP.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.cmbIP.FormattingEnabled = true;
            this.cmbIP.Items.AddRange(new object[] {
            "192.168.1.1",
            "Any"});
            this.cmbIP.Location = new System.Drawing.Point(105, 29);
            this.cmbIP.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.cmbIP.MaxDropDownItems = 10;
            this.cmbIP.Name = "cmbIP";
            this.cmbIP.Size = new System.Drawing.Size(184, 26);
            this.cmbIP.TabIndex = 3;
            this.cmbIP.Text = "Any";
            // 
            // txtPort
            // 
            this.txtPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtPort.Location = new System.Drawing.Point(369, 30);
            this.txtPort.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(107, 24);
            this.txtPort.TabIndex = 2;
            this.txtPort.Text = "5000";
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label48.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label48.Location = new System.Drawing.Point(317, 32);
            this.label48.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(51, 18);
            this.label48.TabIndex = 1;
            this.label48.Text = "Port：";
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label47.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label47.Location = new System.Drawing.Point(29, 32);
            this.label47.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(70, 18);
            this.label47.TabIndex = 1;
            this.label47.Text = "TCP/IP：";
            // 
            // server1bulid
            // 
            this.server1bulid.Appearance = System.Windows.Forms.Appearance.Button;
            this.server1bulid.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.server1bulid.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.server1bulid.Location = new System.Drawing.Point(515, 22);
            this.server1bulid.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.server1bulid.Name = "server1bulid";
            this.server1bulid.Size = new System.Drawing.Size(93, 35);
            this.server1bulid.TabIndex = 0;
            this.server1bulid.Text = "打开";
            this.server1bulid.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.server1bulid.UseVisualStyleBackColor = true;
            // 
            // EthernetCtl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpEthernet);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "EthernetCtl";
            this.Size = new System.Drawing.Size(651, 69);
            this.grpEthernet.ResumeLayout(false);
            this.grpEthernet.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpEthernet;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Label label48;
        private System.Windows.Forms.Label label47;
        private System.Windows.Forms.CheckBox server1bulid;
        private System.Windows.Forms.ComboBox cmbIP;
    }
}
