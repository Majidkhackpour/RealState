using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsSerivces;
using Accounting.Check.CheckMoshtari;
using EntityCache.Bussines;
using MetroFramework.Forms;
using Notification;
using Services;

namespace Accounting.Pardakht
{
    public partial class frmPardakhtCheckM : MetroForm
    {
        public PardakhtCheckMoshtariBussines cls;
        private ReceptionCheckBussines receptionCheck = null;

        private async Task SetDataAsync()
        {
            try
            {
                await SetCheckDataAsync(cls.CheckGuid);
                txtDesc.Text = cls?.Description;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async Task SetCheckDataAsync(Guid receptionCheckGuid)
        {
            try
            {
                var check = await ReceptionCheckBussines.GetAsync(receptionCheckGuid);
                if (check == null)
                    lblBankName.Text = lblNumber.Text = lblPrice.Text = lblSarresid.Text = "";
                else
                {
                    if (check.CheckStatus != EnCheckM.Mojoud)
                    {
                        frmNotification.PublicInfo.ShowMessage($"شما مجاز به خرج چک {check.StatusName} نمی باشید");
                        return;
                    }
                    receptionCheck = check;
                    lblBankName.Text = check.BankName;
                    lblNumber.Text = check.CheckNumber;
                    lblPrice.Text = check.Price.ToString("N0");
                    lblSarresid.Text = check.DateSarresidSh;
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        public frmPardakhtCheckM(PardakhtCheckMoshtariBussines temp)
        {
            InitializeComponent();
            cls = temp ?? new PardakhtCheckMoshtariBussines();
        }

        private async void frmPardakhtCheckM_Load(object sender, EventArgs e) => await SetDataAsync();
        private async void btnSelect_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new frmShowCheckM(true);
                if (frm.ShowDialog() == DialogResult.OK)
                    await SetCheckDataAsync(frm.SelectedGuid);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void frmPardakhtCheckM_KeyDown(object sender, KeyEventArgs e)
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
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
        private void btnFinish_Click(object sender, EventArgs e)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                if (cls.Guid == Guid.Empty) cls.Guid = Guid.NewGuid();

                if (receptionCheck == null) res.AddError("لطفا چک مورد نظر را انتخاب نمایید");
                if (res.HasError) return;

                cls.Modified = DateTime.Now;
                cls.Status = true;
                cls.Description = txtDesc.Text;
                cls.Price = receptionCheck.Price;
                cls.CheckGuid = receptionCheck.Guid;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }
            finally
            {
                if (res.HasError)
                    this.ShowError(res, "خطا در ثبت پرداخت چک دریافتی");
                else
                {
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
        }
    }
}
