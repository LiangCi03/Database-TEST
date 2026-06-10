namespace DataBaseOrm
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && (components != null)) { components.Dispose(); } base.Dispose(disposing); }

        private void InitializeComponent()
        {
            this.titleBar = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblClose = new System.Windows.Forms.Label();
            this.lblPrompt = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblError = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.titleBar.SuspendLayout();
            this.SuspendLayout();

            this.ClientSize = new System.Drawing.Size(360, 200);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.BackColor = System.Drawing.Color.FromArgb(245, 246, 248);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.LoginForm_Paint);
            this.AcceptButton = this.btnOk;

            this.titleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.titleBar.Height = 36;
            this.titleBar.BackColor = System.Drawing.Color.FromArgb(0, 114, 198);
            this.titleBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.titleBar_MouseDown);
            this.titleBar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.titleBar_MouseMove);

            this.lblTitle.Text = "  权限验证";
            this.lblTitle.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(12, 6);

            this.lblClose.Text = "✕";
            this.lblClose.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Bold);
            this.lblClose.ForeColor = System.Drawing.Color.White;
            this.lblClose.AutoSize = true;
            this.lblClose.Location = new System.Drawing.Point(320, 6);
            this.lblClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblClose.Click += new System.EventHandler(this.btnClose_Click);

            this.lblPrompt.Text = "请输入管理员密码";
            this.lblPrompt.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.lblPrompt.ForeColor = System.Drawing.Color.FromArgb(60, 60, 60);
            this.lblPrompt.Location = new System.Drawing.Point(24, 50);
            this.lblPrompt.AutoSize = true;

            this.txtPassword.Location = new System.Drawing.Point(24, 78);
            this.txtPassword.Width = 310;
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPassword.BackColor = System.Drawing.Color.White;

            this.lblError.Location = new System.Drawing.Point(24, 110);
            this.lblError.AutoSize = true;
            this.lblError.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold);
            this.lblError.ForeColor = System.Drawing.Color.FromArgb(220, 50, 50);
            this.lblError.Visible = false;

            this.btnOk.Text = "确认";
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOk.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            this.btnOk.ForeColor = System.Drawing.Color.White;
            this.btnOk.BackColor = System.Drawing.Color.FromArgb(0, 114, 198);
            this.btnOk.Size = new System.Drawing.Size(90, 32);
            this.btnOk.Location = new System.Drawing.Point(130, 140);
            this.btnOk.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOk.FlatAppearance.BorderSize = 0;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);

            this.titleBar.Controls.Add(this.lblTitle);
            this.titleBar.Controls.Add(this.lblClose);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.lblPrompt);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.titleBar);

            this.titleBar.ResumeLayout(false); this.titleBar.PerformLayout();
            this.ResumeLayout(false); this.PerformLayout();
        }

        private System.Windows.Forms.Panel titleBar;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblClose;
        private System.Windows.Forms.Label lblPrompt;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Button btnOk;
    }
}