using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityCache.Bussines;
using Services;

namespace RealState.LoginPanel
{
    public partial class frmNewPlash : Form
    {
        public frmNewPlash()
        {
            InitializeComponent();
            lblUserName.Text = $@"{UserBussines.CurrentUser?.Name ?? ""} عزیز";
            _ = Task.Run(RunAsync);
        }

        private async Task RunAsync()
        {
            try
            {
                await Task.Delay(2000);
                Invoke(new MethodInvoker(()=>
                {
                    timer1.Enabled = true;
                    timer1.Start();
                }));
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void timer1_Tick(object sender, System.EventArgs e)
        {
            try
            {
                if (Opacity <= 0)
                {
                    timer1.Stop();
                    Close();
                }
                Opacity -= 0.1;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
