using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsSerivces;
using EntityCache.Bussines;
using MetroFramework.Forms;
using Services;

namespace Accounting.Check.CheckMoshtari
{
    public partial class frmCheckM_Vagozar : MetroForm
    {
        private TafsilBussines _oldTafsil = null;
        private TafsilBussines _newTafsil = null;
        private ReceptionCheckAvalDoreBussines recAvalDore;
        private ReceptionCheckBussines rec;
        private bool _isAvalDore = false;
        private HesabType _newHesabType;

        private async Task LoadTafsilAsync(HesabType hType)
        {
            try
            {
                var list = await TafsilBussines.GetAllAsync("", hType);
                tafsilBundingSource.DataSource = list.Where(q => q.Status).OrderBy(q => q.Name);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        public frmCheckM_Vagozar(ReceptionCheckBussines cls, HesabType hType)
        {
            InitializeComponent();
            _oldTafsil = TafsilBussines.Get(cls.SandouqTafsilGuid);
            _isAvalDore = false;
            _newHesabType = hType;
            rec = cls;
        }
        public frmCheckM_Vagozar(ReceptionCheckAvalDoreBussines cls, HesabType hType)
        {
            InitializeComponent();
            _oldTafsil = TafsilBussines.Get(cls.SandouqTafsilGuid);
            _isAvalDore = true;
            _newHesabType = hType;
            recAvalDore = cls;
        }

        private async void frmCheckM_Vagozar_Load(object sender, EventArgs e) => await LoadTafsilAsync(_newHesabType);
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
        private void frmCheckM_Vagozar_KeyDown(object sender, KeyEventArgs e)
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
                if (tafsilBundingSource.Count <= 0)
                {
                    res.AddError("لطفا محل واگذاری جدید را انتخاب نمایید");
                    return;
                }
                if (_oldTafsil.Guid == (Guid)cmbGroup.SelectedValue)
                {
                    res.AddError("محل واگذاری قدیم و جدید نمی توانند یکسان باشند");
                    return;
                }

                _newTafsil = await TafsilBussines.GetAsync((Guid) cmbGroup.SelectedValue);
                if (_newTafsil == null)
                {
                    res.AddError("محل واگذاری جدید چک معتبر نمی باشد");
                    return;
                }

                if (_newHesabType == HesabType.Bank)
                {
                    if (_isAvalDore)
                        res.AddReturnedValue(await clsCheckM.VagozarBankAvalDore(recAvalDore, _newTafsil));
                    else
                        res.AddReturnedValue(await clsCheckM.VagozarBank(rec, _newTafsil));
                }
                else if (_newHesabType == HesabType.Sandouq)
                {
                    if (_isAvalDore)
                        res.AddReturnedValue(await clsCheckM.VagozarSandouqAvalDore(recAvalDore, _newTafsil));
                    else
                        res.AddReturnedValue(await clsCheckM.VagozarSandouq(rec, _newTafsil));
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }
            finally
            {
                if (res.HasError) this.ShowError(res, "خطا در واگذارکردن چک دریافتی");
                else
                {
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
        }
    }
}
