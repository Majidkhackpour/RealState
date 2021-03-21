using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsSerivces;
using EntityCache.Bussines;
using MetroFramework.Forms;
using Services;

namespace Accounting.Pardakht
{
    public partial class frmPardakhtCheckSh : MetroForm
    {
        public PardakhtCheckShakhsiBussines cls { get; set; }
        private async Task SetDataAsync()
        {
            try
            {
                await FillDasteCheckAsync();

                txtPrice.TextDecimal = cls?.Price ?? 0;
                txtDesc.Text = cls?.Description;
                txtDate.Text = cls?.DateSarresidSh;

                if (cls.Guid == Guid.Empty && CheckBookBindingSource.Count > 0)
                {
                    cmbCheckBook.SelectedIndex = 0;
                    cmbCheckBook_SelectedIndexChanged(null, null);
                }
                else
                {
                    var checkPage = await CheckPageBussines.GetAsync(cls.CheckPageGuid);
                    if (checkPage == null) return;
                    var check = await DasteCheckBussines.GetAsync(checkPage.CheckGuid);
                    if (check == null) return;
                    cmbCheckBook.SelectedValue = check.Guid;
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async Task FillDasteCheckAsync()
        {
            try
            {
                var list = await DasteCheckBussines.GetAllAsync();
                CheckBookBindingSource.DataSource = list?.Where(q => q.Status)?.OrderBy(q => q.Name)?.ToList();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        public frmPardakhtCheckSh(PardakhtCheckShakhsiBussines temp)
        {
            InitializeComponent();
            cls = temp ?? new PardakhtCheckShakhsiBussines();
        }

        private async void frmPardakhtCheckSh_Load(object sender, EventArgs e) => await SetDataAsync();
        private async void cmbCheckBook_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (CheckBookBindingSource.Count <= 0 || cmbCheckBook.SelectedValue == null) return;
                var list = await CheckPageBussines.GetAllAsync((Guid)cmbCheckBook.SelectedValue);
                CheckPageBindingSource.DataSource = list?.ToList();
                if (cls.Guid != Guid.Empty) cmbCheckPage.SelectedValue = cls.CheckPageGuid;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void frmPardakhtCheckSh_KeyDown(object sender, KeyEventArgs e)
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
                if (cls.Guid == Guid.Empty)
                {
                    cls.Guid = Guid.NewGuid();
                    cls.DateM = DateTime.Now;
                }

                if (CheckBookBindingSource.Count <= 0) res.AddError("لطفا دسته چک را انتخاب نمایید");
                if (CheckPageBindingSource.Count <= 0) res.AddError("لطفا برگه چک را انتخاب نمایید");
                if (string.IsNullOrEmpty(txtDate.Text)) res.AddError("لطفا تاریخ سررسید چک را وارد نمایید");
                if (txtPrice.TextDecimal <= 0) res.AddError("لطفا مبلغ را وارد نمایید");

                cls.Modified = DateTime.Now;
                cls.Status = true;
                cls.Description = txtDesc.Text;
                cls.Price = txtPrice.TextDecimal;
                cls.DateSarResid = Calendar.ShamsiToMiladi(txtDate.Text);
                cls.Number = cmbCheckPage.Text;
                cls.CheckPageGuid = (Guid) cmbCheckPage.SelectedValue;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }
            finally
            {
                if (res.HasError)
                    this.ShowError(res, "خطا در ثبت پرداخت چک شخصی");
                else
                {
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
        }
    }
}
