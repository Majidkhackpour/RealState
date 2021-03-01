using Accounting.Hesab;
using EntityCache.Bussines;
using MetroFramework.Forms;
using Services;
using System;
using System.Linq;
using System.Windows.Forms;
using User;
using WindowsSerivces;

namespace Accounting.Sanad
{
    public partial class frmSanadMain : MetroForm
    {
        private Guid _tafsilGuid = Guid.Empty;
        private Guid _moeinGuid = Guid.Empty;
        private SanadBussines cls;
        private void SetData()
        {
            try
            {
                FillTypes();
                FillDetails();

                txtDesc.Text = cls?.Description;
                txtNumber.Value = cls?.Number ?? 0;
                txtDate.Text = cls?.DateSh;
                cmbType.SelectedIndex = (int)cls?.SanadType;

                if (cls.Guid == Guid.Empty)
                {
                    txtNumber.Value = NextNumber();
                    cmbType.SelectedIndex = 0;
                }

                SetLables();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void FillDetails()
        {
            try
            {
                SanadBindingSource.DataSource = cls?.Details?.OrderBy(q => q.Credit)?.ToList();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void FillTypes()
        {
            try
            {
                var values = Enum.GetValues(typeof(EnSanadType)).Cast<EnSanadType>();
                foreach (var item in values)
                    cmbType.Items.Add(item.GetDisplay());
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private long NextNumber()
        {
            long res = 0;
            try
            {
                res = SanadBussines.NextNumber();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return res;
        }
        private void SetLables()
        {
            try
            {
                lblSumCredit.Text = (cls?.SumCredit.ToString("N0") ?? "0") + " ریال";
                lblSumDebit.Text = (cls?.SumDebit.ToString("N0") ?? "0") + " ریال";
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void SetTafsil()
        {
            try
            {
                var frm = new frmSelectTafsil();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    var tafsil = TafsilBussines.Get(frm.SelectedGuid);
                    if (tafsil != null)
                    {
                        txtTafsilName.Text = tafsil.Name;
                        _tafsilGuid = tafsil.Guid;
                    }
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void SetMoein()
        {
            try
            {
                var frm = new frmKolMoein(true);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    var moein = MoeinBussines.Get(frm.SelectedMoeinGuid);
                    if (moein != null)
                    {
                        txtMoeinName.Text = moein.Name;
                        _moeinGuid = moein.Guid;
                    }
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void ClearArticle()
        {
            try
            {
                _tafsilGuid = _moeinGuid = Guid.Empty;
                txtTafsilName.Text = txtMoeinName.Text = "";
                txtRowDesc.Text = "";
                txtDebit.TextDecimal = 0;
                txtCredit.TextDecimal = 0;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private SanadDetailBussines GenerateDet()
        {
            try
            {
                var tafsil = TafsilBussines.Get(_tafsilGuid);
                var moein = MoeinBussines.Get(_moeinGuid);
                var res = new SanadDetailBussines
                {
                    Guid = Guid.NewGuid(),
                    Modified = DateTime.Now,
                    Description = txtRowDesc.Text,
                    Status = true,
                    Debit = txtDebit.TextDecimal,
                    Credit = txtCredit.TextDecimal,
                    TafsilGuid = (tafsil?.Guid ?? Guid.Empty),
                    MoeinGuid = (moein?.Guid ?? Guid.Empty),
                    MoeinCode = moein?.Code,
                    MoeinName = moein?.Name,
                    TafsilCode = tafsil?.Code,
                    TafsilName = tafsil?.Name
                };
                return res;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return null;
            }
        }

        public frmSanadMain()
        {
            InitializeComponent();
            cls = new SanadBussines();
        }
        public frmSanadMain(Guid guid, bool isShowMode)
        {
            InitializeComponent();
            cls = SanadBussines.Get(guid);
            grp.Enabled = !isShowMode;
            panelEx1.Enabled = !isShowMode;
            panelEx3.Enabled = !isShowMode;
            btnFinish.Enabled = !isShowMode;
        }

        private void frmSanadMain_Load(object sender, EventArgs e) => SetData();
        private void frmSanadMain_KeyDown(object sender, KeyEventArgs e)
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
                    case Keys.F1:
                        btnSaveArticle.PerformClick();
                        break;
                    case Keys.Escape:
                        btnCancel.PerformClick();
                        break;
                    case Keys.F7:
                        mnuEdit.PerformClick();
                        break;
                    case Keys.Delete:
                        mnuDelete.PerformClick();
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
        private void DGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
            => DGrid.Rows[e.RowIndex].Cells["dgRadif"].Value = e.RowIndex + 1;
        private void btnTafsilSearch_Click(object sender, EventArgs e) => SetTafsil();
        private void btnSaveArticle_Click(object sender, EventArgs e)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                mnuDelete.PerformClick();
                res.AddReturnedValue(cls.AddToListSanad(GenerateDet()));
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }
            finally
            {
                if (res.HasError) this.ShowError(res, "خطا در ثبت اقلام سند");
                else
                {
                    ClearArticle();
                    FillDetails();
                    SetLables();
                }
            }
        }
        private void btnMoeinSearch_Click(object sender, EventArgs e) => SetMoein();
        private async void btnFinish_Click(object sender, EventArgs e)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                if (cls.Guid == Guid.Empty)
                {
                    cls.Guid = Guid.NewGuid();
                    cls.DateM = DateTime.Now;
                    cls.UserGuid = clsUser.CurrentUser.Guid;
                }

                cls.Description = txtDesc.Text;
                cls.Number = (long)txtNumber.Value;
                cls.SanadStatus = EnSanadStatus.Temporary;
                cls.SanadType = (EnSanadType)cmbType.SelectedIndex;

                res.AddReturnedValue(await cls.SaveAsync());
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }
            finally
            {
                if (res.HasError) this.ShowError(res, "خطا در ثبت سند");
                else
                {
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
        }
        private void mnuEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGrid.RowCount <= 0 || DGrid.CurrentRow == null) return;
                var guid = (Guid)DGrid[dgGuid.Index, DGrid.CurrentRow.Index].Value;
                if (guid == Guid.Empty) return;
                var det = cls?.Details?.FirstOrDefault(q => q.Guid == guid);
                if (det == null) return;

                _moeinGuid = det.MoeinGuid;
                _tafsilGuid = det.TafsilGuid;
                txtMoeinName.Text = det.MoeinName;
                txtTafsilName.Text = det.TafsilName;
                txtRowDesc.Text = det.Description;
                txtDebit.TextDecimal = det.Debit;
                txtCredit.TextDecimal = det.Credit;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void mnuDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGrid.RowCount <= 0 || DGrid.CurrentRow == null) return;
                var guid = (Guid)DGrid[dgGuid.Index, DGrid.CurrentRow.Index].Value;
                if (guid == Guid.Empty) return;
                var det = cls?.Details?.FirstOrDefault(q => q.Guid == guid);
                if (det == null) return;
                cls?.Details?.Remove(det);
                FillDetails();
                SetLables();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
