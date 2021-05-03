using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsSerivces;
using Accounting.Hesab;
using EntityCache.Bussines;
using MetroFramework.Forms;
using Services;

namespace Accounting.Check.CheckMoshtari
{
    public partial class frmCheckM_AvalDore : MetroForm
    {
        private CancellationTokenSource _token = new CancellationTokenSource();
        private Guid _tafsilGuid = Guid.Empty;

        public ReceptionCheckAvalDoreBussines cls { get; set; }
        
        private async Task SetDataAsync()
        {
            try
            {
                await FillSandouqAsync();
                await SetTafilAsync(cls?.TafsilGuid ?? Guid.Empty);

                txtPrice.TextDecimal = cls?.Price ?? 0;
                txtDesc.Text = cls?.Description;
                txtDate.Text = cls?.DateSarresidSh;
                txtBankName.Text = cls?.BankName;
                txtCheckNo.Text = cls?.CheckNumber;
                txtPoshtNomre.Text = cls?.PoshtNomre;

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
                var list = await TafsilBussines.GetAllAsync("", _token.Token,HesabType.Sandouq);
                SandouqBindingSource.DataSource = list?.Where(q => q.Status)?.OrderBy(q => q.Name)?.ToList();
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


        public frmCheckM_AvalDore()
        {
            InitializeComponent();
            cls = new ReceptionCheckAvalDoreBussines();
            ucHeader.Text = "افزودن چک دریافتی اول دوره جدید";
        }
        public frmCheckM_AvalDore(Guid guid, bool isShowMode)
        {
            InitializeComponent();
            cls = ReceptionCheckAvalDoreBussines.Get(guid);
            ucHeader.Text = !isShowMode ? $"ویرایش چک دریافتی اول دوره" : $"مشاهده چک دریافتی اول دوره";
            ucHeader.IsModified = true;
            grp.Enabled = !isShowMode;
            btnFinish.Enabled = !isShowMode;
        }


        private async void frmCheckM_AvalDore_Load(object sender, EventArgs e)
        {
            try
            {
                await SetDataAsync();

                var myCollection = new AutoCompleteStringCollection();
                var list = await BankSegestBussines.GetAllAsync();
                foreach (var item in list.ToList())
                    myCollection.Add(item.BankName);
                txtBankName.AutoCompleteCustomSource = myCollection;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void frmCheckM_AvalDore_KeyDown(object sender, KeyEventArgs e)
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
        private void txtBankName_Enter(object sender, EventArgs e) => txtSetter.Focus(txtBankName);
        private void txtCheckNo_Enter(object sender, EventArgs e) => txtSetter.Focus(txtCheckNo);
        private void txtPoshtNomre_Enter(object sender, EventArgs e) => txtSetter.Focus(txtPoshtNomre);
        private void txtPoshtNomre_Leave(object sender, EventArgs e) => txtSetter.Follow(txtPoshtNomre);
        private void txtCheckNo_Leave(object sender, EventArgs e) => txtSetter.Follow(txtCheckNo);
        private void txtBankName_Leave(object sender, EventArgs e) => txtSetter.Follow(txtBankName);
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
        private async void btnTafsilSearch_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new frmSelectTafsil(true);
                if (frm.ShowDialog() == DialogResult.OK)
                    await SetTafilAsync(frm.SelectedGuid);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async void btnFinish_Click(object sender, EventArgs e)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                if (cls.Guid == Guid.Empty)
                {
                    cls.Guid = Guid.NewGuid();
                    cls.DateM = DateTime.Now;
                    cls.UserGuid = UserBussines.CurrentUser.Guid;
                }


                cls.Modified = DateTime.Now;
                cls.BankName = txtBankName.Text;
                cls.DateSarResid = Calendar.ShamsiToMiladi(txtDate.Text);
                cls.Description = txtDesc.Text;
                cls.CheckNumber = txtCheckNo.Text;
                cls.PoshtNomre = txtPoshtNomre.Text;
                cls.Price = txtPrice.TextDecimal;
                cls.CheckStatus = EnCheckM.Mojoud;
                cls.SandouqTafsilGuid = (Guid)cmbSandouq.SelectedValue;
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
                    this.ShowError(res, "خطا در ثبت دریافت چک اول دوره");
                else
                {
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
        }
    }
}
