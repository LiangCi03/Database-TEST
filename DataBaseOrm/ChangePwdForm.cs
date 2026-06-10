using System;
using System.Drawing;
using System.Windows.Forms;

namespace DataBaseOrm
{
    public partial class ChangePwdForm : Form
    {
        private Point _dragStart;
        public string OldPassword => txtOld?.Text ?? "";
        public string NewPassword => txtNew?.Text ?? "";
        public string ConfirmPassword => txtConfirm?.Text ?? "";

        public ChangePwdForm() { InitializeComponent(); }

        public void ShowError(string msg)
        {
            lblMsg.Text = msg;
            lblMsg.ForeColor = Color.FromArgb(220, 50, 50);
            lblMsg.Visible = true;
        }

        public void ShowSuccess(string msg)
        {
            lblMsg.Text = msg;
            lblMsg.ForeColor = Color.FromArgb(0, 130, 60);
            lblMsg.Visible = true;
        }

        private void ChangePwdForm_Paint(object sender, PaintEventArgs e)
        { ControlPaint.DrawBorder(e.Graphics, this.ClientRectangle, Color.FromArgb(200, 200, 200), 1, ButtonBorderStyle.Solid, Color.FromArgb(200, 200, 200), 1, ButtonBorderStyle.Solid, Color.FromArgb(200, 200, 200), 1, ButtonBorderStyle.Solid, Color.FromArgb(200, 200, 200), 1, ButtonBorderStyle.Solid); }

        private void titleBar_MouseDown(object sender, MouseEventArgs e) { if (e.Button == MouseButtons.Left) _dragStart = e.Location; }
        private void titleBar_MouseMove(object sender, MouseEventArgs e) { if (e.Button == MouseButtons.Left) { this.Left += e.X - _dragStart.X; this.Top += e.Y - _dragStart.Y; } }
        private void btnClose_Click(object sender, EventArgs e) { this.Close(); }
    }
}