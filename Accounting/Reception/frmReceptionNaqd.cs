using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsSerivces;
using EntityCache.Bussines;
using MetroFramework.Forms;
using Services;
using Services.DefaultCoding;

namespace Accounting.Reception
{
    public partial class frmReceptionNaqd : MetroForm
    {
        private CancellationTokenSource _token = new CancellationTokenSource();

        public ReceptionNaqdBussines cls { get; set; }

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
                _token?.Cancel();
                _token = new CancellationTokenSource();
                var list = await TafsilBussines.GetAllAsync("", _token.Token, HesabType.Sandouq);
                SandouqBindingSource.DataSource = list?.Where(q => q.Status)?.OrderBy(q => q.Name)?.ToList();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        public frmReceptionNaqd(ReceptionNaqdBussines temp)
        {
            InitializeComponent();
            cls = temp ?? new ReceptionNaqdBussines();
            ucHeader.Text = "دریافت نقدی";
        }

        private async void frmReceptionNaqd_Load(object sender, EventArgs e) => await SetDataAsync();
        private void frmReceptionNaqd_KeyDown(object sender, KeyEventArgs e)
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

                if (SandouqBindingSource.Count <= 0) res.AddError("لطفا صندوق مقصد را انتخاب نمایید");
                if (txtPrice.TextDecimal <= 0) res.AddError("لطفا مبلغ را وارد نمایید");

                cls.Modified = DateTime.Now;
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
                    this.ShowError(res, "خطا در ثبت دریافت نقدی");
                else
                {
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
        }
    }
}
