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
    public partial class frmPardakhtNaqd : MetroForm
    {
        public PardakhtNaqdBussines cls { get; set; }
        private async Task SetDataAsync()
        {
            try
            {
                await FillSandouqAsync();

                txtPrice.TextDecimal = cls?.Price ?? 0;
                txtDesc.Text = cls?.Description;
                if (cls.Guid == Guid.Empty && SandouqBindingSource.Count > 0) cmbSandouq.SelectedIndex = 0;
                else cmbSandouq.SelectedValue = cls.SandouqTafsilGuid;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async Task FillSandouqAsync()
        {
            try
            {
                var list = await TafsilBussines.GetAllAsync("", HesabType.Sandouq);
                SandouqBindingSource.DataSource = list?.Where(q => q.Status)?.OrderBy(q => q.Name)?.ToList();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        public frmPardakhtNaqd(PardakhtNaqdBussines temp)
        {
            InitializeComponent();
            cls = temp ?? new PardakhtNaqdBussines();
        }

        private async void frmPardakhtNaqd_Load(object sender, EventArgs e) => await SetDataAsync();
        private void frmPardakhtNaqd_KeyDown(object sender, KeyEventArgs e)
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
                    cls.Guid = Guid.NewGuid();

                if (SandouqBindingSource.Count <= 0) res.AddError("لطفا صندوق مبدا را انتخاب نمایید");
                if (txtPrice.TextDecimal <= 0) res.AddError("لطفا مبلغ را وارد نمایید");

                cls.Modified = DateTime.Now;
                cls.Status = true;
                cls.Description = txtDesc.Text;
                cls.SandouqTafsilGuid = (Guid)cmbSandouq.SelectedValue;
                cls.Price = txtPrice.TextDecimal;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }
            finally
            {
                if (res.HasError)
                    this.ShowError(res, "خطا در ثبت پرداخت نقدی");
                else
                {
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
        }
    }
}
