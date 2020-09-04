using System;
using System.Drawing;
using System.Media;
using System.Windows.Forms;
using Notification.Properties;
using Services;

namespace Notification
{
    public partial class frmNaqz : Form
    {
        private int x = 1;
        public frmNaqz(string text)
        {
            InitializeComponent();
            lblNaqz.Text = text;
            TopMost = true;
        }

        private void ClosingTimer_Tick(object sender, System.EventArgs e)
        {
            Close();
        }

        private void frmNaqz_Load(object sender, System.EventArgs e)
        {
            try
            {
                Styler.Start();
                ClosingTimer.Start();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void Styler_Tick(object sender, EventArgs e)
        {
            try
            {
                x += 20;
                var workingArea = Screen.GetWorkingArea(this);
                Location = new Point(workingArea.Right - x, workingArea.Bottom - Size.Height - 10);
                if (Location.X == workingArea.Right - Size.Width
                    || Location.X < workingArea.Right - Size.Width)
                    Styler.Stop();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void lblNaqz_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmNaqz_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) Close();
        }
    }
}
