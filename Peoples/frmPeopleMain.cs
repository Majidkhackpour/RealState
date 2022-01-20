using MetroFramework.Forms;
using Services;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityCache.Bussines;

namespace Peoples
{
    public partial class frmPeopleMain : MetroForm
    {
        private PeoplesBussines cls;

        public frmPeopleMain(PeoplesBussines obj, bool isShowMode)
        {
            try
            {
                InitializeComponent();
                cls = obj;
                if (!cls.IsModified)
                    ucHeader.Text = "افزودن شخص جدید";
                else
                    ucHeader.Text = !isShowMode ? $"ویرایش {cls.Name}" : $"مشاهده {cls.Name}";
                ucHeader.IsModified = cls.IsModified;
                ucPablic.Enabled = !isShowMode;
                ucTell.Enabled = !isShowMode;
                ucBank.Enabled = !isShowMode;
                ucAccept.Enabled = !isShowMode;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
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
        private async void frmPeopleMain_Load(object sender, EventArgs e)
        {
            try
            {
                ucPablic.SetAccess(VersionAccess.Accounting);
                await ucBank.InitAsync();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
