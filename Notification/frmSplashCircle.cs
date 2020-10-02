using System.Windows.Forms;

namespace Notification
{
    public partial class frmSplashCircle : Form
    {
        public frmSplashCircle() => InitializeComponent();
        private void timer1_Tick(object sender, System.EventArgs e) => Close();
        private void frmSplashCircle_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) Close();
        }
    }
}
