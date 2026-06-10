using System;
using System.Drawing;
using System.Windows.Forms;

namespace DataBaseOrm
{
    public partial class LoginForm : Form
    {
        private Point _dragStart;
        public string Password => txtPassword?.Text ?? "";
        public bool LoginSuccess { get; private set; }

        public LoginForm() { InitializeComponent(); }

        public void SetPasswordError(string msg)
        {
            lblError.Text = msg;
            lblError.Visible = true;
            txtPassword.Text = "";
            txtPassword.Focus();
        }

        private void LoginForm_Paint(object sender, PaintEventArgs e)
        { ControlPaint.DrawBorder(e.Graphics, this.ClientRectangle, Color.FromArgb(200, 200, 200), 1, ButtonBorderStyle.Solid, Color.FromArgb(200, 200, 200), 1, ButtonBorderStyle.Solid, Color.FromArgb(200, 200, 200), 1, ButtonBorderStyle.Solid, Color.FromArgb(200, 200, 200), 1, ButtonBorderStyle.Solid); }

        private void titleBar_MouseDown(object sender, MouseEventArgs e) { if (e.Button == MouseButtons.Left) _dragStart = e.Location; }
        private void titleBar_MouseMove(object sender, MouseEventArgs e) { if (e.Button == MouseButtons.Left) { this.Left += e.X - _dragStart.X; this.Top += e.Y - _dragStart.Y; } }
        private void btnClose_Click(object sender, EventArgs e) { this.DialogResult = DialogResult.Cancel; this.Close(); }
        private void btnOk_Click(object sender, EventArgs e) { this.DialogResult = DialogResult.OK; this.Close(); }
    }
}