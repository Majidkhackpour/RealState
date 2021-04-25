using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsSerivces;
using Accounting.Hesab;
using EntityCache.Bussines;
using MetroFramework.Forms;
using Services;
using User;

namespace Accounting.Check.CheckShakhsi
{
    public partial class frmPardakhtCheckAvalDore : MetroForm
    {
        private Guid _tafsilGuid = Guid.Empty;
        public PardakhtCheckAvalDoreBussines cls { get; set; }

        private async Task SetDataAsync()
        {
            try
            {
                await FillDasteCheckAsync();
                await SetTafilAsync(cls?.TafsilGuid ?? Guid.Empty);

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
                    cmbCheckBook_SelectedIndexChanged(null, null);
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
        private async Task SetTafilAsync(Guid guid)
        {
            try
            {
                if (guid == Guid.Empty) return;
                var tf = await TafsilBussines.GetAsync(guid);
                if (tf == null) return;

                _tafsilGuid = tf.Guid;
                txtTafsilName.Text = tf.Name;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        public frmPardakhtCheckAvalDore()
        {
            InitializeComponent();
            cls = new PardakhtCheckAvalDoreBussines();
        }
        public frmPardakhtCheckAvalDore(Guid guid, bool isShowMode)
        {
            InitializeComponent();
            cls = PardakhtCheckAvalDoreBussines.Get(guid);
            grp.Enabled = !isShowMode;
            btnFinish.Enabled = !isShowMode;
        }

        private async void btnTafsilSearch_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new frmSelectTafsil();
                if (frm.ShowDialog() == DialogResult.OK)
                    await SetTafilAsync(frm.SelectedGuid);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private async void cmbCheckBook_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (CheckBookBindingSource.Count <= 0 || cmbCheckBook.SelectedValue == null) return;
                var list = await CheckPageBussines.GetAllAsync((Guid)cmbCheckBook.SelectedValue);
                CheckPageBindingSource.DataSource = list?.OrderBy(q => q.Number).ToList();
                if (cls.Guid != Guid.Empty) cmbCheckPage.SelectedValue = cls.CheckPageGuid;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async void frmPardakhtCheckAvalDore_Load(object sender, EventArgs e) => await SetDataAsync();
        private void frmPardakhtCheckAvalDore_KeyDown(object sender, KeyEventArgs e)
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
        private async void btnFinish_Click(object sender, EventArgs e)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                if (cls.Guid == Guid.Empty)
                {
                    cls.Guid = Guid.NewGuid();
                    cls.UserGuid = UserBussines.CurrentUser.Guid;
                }


                cls.Modified = DateTime.Now;
                cls.DasteCheckName = cmbCheckBook.Text;
                cls.Description = txtDesc.Text;
                cls.Price = txtPrice.TextDecimal;
                cls.DateSarresid = Calendar.ShamsiToMiladi(txtDate.Text);
                cls.Number = cmbCheckPage.Text;
                cls.CheckPageGuid = (Guid)cmbCheckPage.SelectedValue;
                cls.TafsilGuid = _tafsilGuid;

                res.AddReturnedValue(await cls.SaveAsync(true));
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }
            finally
            {
                if (res.HasError)
                    this.ShowError(res, "خطا در ثبت پرداخت چک شخصی اول دوره");
                else
                {
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
        }
    }
}
