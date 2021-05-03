using System;
using System.Windows.Forms;
using EntityCache.Bussines;
using MetroFramework.Forms;
using Notification;
using Services;

namespace Payamak.Panel
{
    public partial class frmPanelMain : MetroForm
    {
        private SmsPanelsBussines cls;

        private void SetData()
        {
            try
            {
                txtName.Text = cls?.Name;
                txtSender.Text = cls?.Sender;
                txtApi.Text = cls?.API;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        public frmPanelMain()
        {
            InitializeComponent();
            cls = new SmsPanelsBussines();
            ucHeader.Text = "افزودن پنل پیامکی جدید";
        }
        public frmPanelMain(Guid guid, bool isShowMode)
        {
            InitializeComponent();
            cls = SmsPanelsBussines.Get(guid);
            ucHeader.Text = !isShowMode ? $"ویرایش پنل پیامکی {cls.Name}" : $"مشاهده پنل پیامکی {cls.Name}";
            ucHeader.IsModified = true;
            grp.Enabled = !isShowMode;
            btnFinish.Enabled = !isShowMode;
        }

        private void frmPanelMain_Load(object sender, EventArgs e) => SetData();
        private void txtName_Enter(object sender, EventArgs e) => txtSetter.Focus(txtName);
        private void txtSender_Enter(object sender, EventArgs e) => txtSetter.Focus(txtSender);
        private void txtApi_Enter(object sender, EventArgs e) => txtSetter.Focus(txtApi);
        private void txtApi_Leave(object sender, EventArgs e) => txtSetter.Follow(txtApi);
        private void txtSender_Leave(object sender, EventArgs e) => txtSetter.Follow(txtSender);
        private void txtName_Leave(object sender, EventArgs e) => txtSetter.Follow(txtName);
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
        private void frmPanelMain_KeyDown(object sender, KeyEventArgs e)
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

                cls.Name = txtName.Text.Trim();
                cls.Sender = txtSender.Text.Trim();
                cls.API = txtApi.Text.Trim();

                res.AddReturnedValue(await cls.SaveAsync());
            }
            catch (Exception exception)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(exception);
                res.AddReturnedValue(exception);
            }
            finally
            {
                if (res.HasError)
                {
                    var frm = new FrmShowErrorMessage(res, "خطا در ثبت پنل ارسال پیامک");
                    frm.ShowDialog(this);
                    frm.Dispose();
                }
                else
                {
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
        }
    }
}
