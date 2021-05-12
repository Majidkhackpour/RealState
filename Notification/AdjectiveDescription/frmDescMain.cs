using System;
using System.Windows.Forms;
using EntityCache.Bussines;
using MetroFramework.Forms;
using Services;

namespace Notification.AdjectiveDescription
{
    public partial class frmDescMain : MetroForm
    {
        private AdjectiveDescriptionBussines cls;

        private void SetData() => txtDesc.Text = cls?.Description;

        public frmDescMain()
        {
            InitializeComponent();
            cls = new AdjectiveDescriptionBussines();
        }
        public frmDescMain(Guid guid)
        {
            InitializeComponent();
            cls = AdjectiveDescriptionBussines.Get(guid);
        }

        private void frmDescMain_Load(object sender, EventArgs e) => SetData();
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
        private void frmDescMain_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            try
            {
                switch (e.KeyCode)
                {
                    case Keys.Enter:
                        if (!btnFinish.Focused && !btnCancel.Focused)
                            SendKeys.Send("{Tab}");
                        break;
                    case Keys.F5:
                        btnFinish.PerformClick();
                        break;
                    case Keys.Escape:
                        btnCancel.PerformClick();
                        break;
                }
            }
            catch (Exception exception)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(exception);
            }
        }
        private async void btnFinish_Click(object sender, EventArgs e)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                if (cls.Guid == Guid.Empty) cls.Guid = Guid.NewGuid();
                cls.Description = txtDesc.Text;

                res.AddReturnedValue(await cls.SaveAsync());
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }
            finally
            {
                if (!res.HasError)
                {
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
        }
    }
}
