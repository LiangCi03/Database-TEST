namespace DataBaseOrm
{
    partial class ChangePwdForm
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && (components != null)) { components.Dispose(); } base.Dispose(disposing); }

        private void InitializeComponent()
        {
            this.titleBar = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblClose = new System.Windows.Forms.Label();
            this.lblOld = new System.Windows.Forms.Label();
            this.txtOld = new System.Windows.Forms.TextBox();
            this.lblNew = new System.Windows.Forms.Label();
            this.txtNew = new System.Windows.Forms.TextBox();
            this.lblConfirm = new System.Windows.Forms.Label();
            this.txtConfirm = new System.Windows.Forms.TextBox();
            this.lblMsg = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.titleBar.SuspendLayout();
            this.SuspendLayout();

            this.ClientSize = new System.Drawing.Size(380, 280);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.BackColor = System.Drawing.Color.FromArgb(245, 246, 248);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.ChangePwdForm_Paint);
            this.AcceptButton = this.btnSave;

            this.titleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.titleBar.Height = 36;
            this.titleBar.BackColor = System.Drawing.Color.FromArgb(0, 114, 198);
            this.titleBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.titleBar_MouseDown);
            this.titleBar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.titleBar_MouseMove);

            this.lblTitle.Text = "  修改管理员密码";
            this.lblTitle.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(12, 6);

            this.lblClose.Text = "✕";
            this.lblClose.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Bold);
            this.lblClose.ForeColor = System.Drawing.Color.White;
            this.lblClose.AutoSize = true;
            this.lblClose.Location = new System.Drawing.Point(340, 6);
            this.lblClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblClose.Click += new System.EventHandler(this.btnClose_Click);

            this.lblOld.Text = "当前密码";
            this.lblOld.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.lblOld.ForeColor = System.Drawing.Color.FromArgb(60, 60, 60);
            this.lblOld.Location = new System.Drawing.Point(24, 48);
            this.lblOld.AutoSize = true;

            this.txtOld.Location = new System.Drawing.Point(24, 72);
            this.txtOld.Width = 330;
            this.txtOld.PasswordChar = '*';
            this.txtOld.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.txtOld.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            this.lblNew.Text = "新密码";
            this.lblNew.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.lblNew.ForeColor = System.Drawing.Color.FromArgb(60, 60, 60);
            this.lblNew.Location = new System.Drawing.Point(24, 104);
            this.lblNew.AutoSize = true;

            this.txtNew.Location = new System.Drawing.Point(24, 128);
            this.txtNew.Width = 330;
            this.txtNew.PasswordChar = '*';
            this.txtNew.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.txtNew.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            this.lblConfirm.Text = "确认密码";
            this.lblConfirm.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.lblConfirm.ForeColor = System.Drawing.Color.FromArgb(60, 60, 60);
            this.lblConfirm.Location = new System.Drawing.Point(24, 160);
            this.lblConfirm.AutoSize = true;

            this.txtConfirm.Location = new System.Drawing.Point(24, 184);
            this.txtConfirm.Width = 330;
            this.txtConfirm.PasswordChar = '*';
            this.txtConfirm.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.txtConfirm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            this.lblMsg.Location = new System.Drawing.Point(24, 216);
            this.lblMsg.AutoSize = true;
            this.lblMsg.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold);
            this.lblMsg.Visible = false;

            this.btnSave.Text = "保存";
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(0, 114, 198);
            this.btnSave.Size = new System.Drawing.Size(90, 32);
            this.btnSave.Location = new System.Drawing.Point(260, 242);
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatAppearance.BorderSize = 0;

            this.titleBar.Controls.Add(this.lblTitle);
            this.titleBar.Controls.Add(this.lblClose);
            this.Controls.Add(this.txtOld); this.Controls.Add(this.txtNew); this.Controls.Add(this.txtConfirm);
            this.Controls.Add(this.lblOld); this.Controls.Add(this.lblNew); this.Controls.Add(this.lblConfirm);
            this.Controls.Add(this.lblMsg);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.titleBar);

            this.titleBar.ResumeLayout(false); this.titleBar.PerformLayout();
            this.ResumeLayout(false); this.PerformLayout();
        }

        private System.Windows.Forms.Panel titleBar;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblClose;
        private System.Windows.Forms.Label lblOld;
        private System.Windows.Forms.Label lblNew;
        private System.Windows.Forms.Label lblConfirm;
        private System.Windows.Forms.TextBox txtOld;
        private System.Windows.Forms.TextBox txtNew;
        private System.Windows.Forms.TextBox txtConfirm;
        private System.Windows.Forms.Label lblMsg;
        internal System.Windows.Forms.Button btnSave;
    }
}