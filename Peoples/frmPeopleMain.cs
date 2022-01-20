using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using Services;

namespace Peoples
{
    public partial class frmPeopleMain : MetroForm
    {
        public frmPeopleMain()
        {
            InitializeComponent();
        }

        private async Task ucAccept_OnClick(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async Task ucCancel_OnClick(object sender, EventArgs e)
        {

        }
    }
}
