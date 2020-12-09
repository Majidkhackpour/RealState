using System;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Services;

namespace Notification
{
    public partial class frmShowErrorDetails : Form
    {
        public frmShowErrorDetails(string text, FormWindowState state)
        {
            InitializeComponent();
            textBox1.Text = text;
            this.WindowState = state;
        }

        private void ShowUrl(string msg)
        {
            try
            {
                if (!msg.Contains("http")) return;
                var urlRx = new
                    Regex(
                        @"(http|ftp|https)://([\w+?\.\w+])+([a-zA-Z0-9\~\!\@\#\$\%\^\&\*\(\)_\-\=\+\\\/\?\.\:\;\'\,]*)?",
                        RegexOptions.IgnoreCase);
                var matches = urlRx.Matches(msg);
                var url = "";
                foreach (Match match in matches)
                    url = match.Value;
                if (MessageBox.Show(this, $"آیا مایلید صفحه {url} را باز کنید؟", $"{url}", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) == DialogResult.Yes)
                    Process.Start(url);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            ShowUrl(textBox1.Text);
        }

        private void frmShowErrorDetails_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) Close();
        }
    }
}
