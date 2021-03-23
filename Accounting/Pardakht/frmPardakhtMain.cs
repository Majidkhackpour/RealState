using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsSerivces;
using Accounting.Check;
using Accounting.Hesab;
using EntityCache.Bussines;
using MetroFramework.Forms;
using Services;

namespace Accounting.Pardakht
{
    public partial class frmPardakhtMain : MetroForm
    {
        private PardakhtBussines cls;
        private Guid _tafsilGuid = Guid.Empty;
        private bool _isLoaded = false;

        private async Task SetDataAsync()
        {
            try
            {
                await SetTafilAsync(cls?.TafsilGuid ?? Guid.Empty);

                txtDate.Text = cls?.DateSh;
                txtDesc.Text = cls?.Description;

                if (cls.Guid == Guid.Empty)
                {
                    txtNumber.Value = await PardakhtBussines.NextCodeAsync();
                    txtSanadNo.Value = await SanadBussines.NextNumberAsync();
                }
                else
                {
                    txtNumber.Value = cls.Number;
                    txtSanadNo.Value = cls.SanadNumber;
                }

                if (!_isLoaded)
                {
                    if (cls.NaqdList != null)
                        foreach (var item in cls.NaqdList)
                            AddToGrid(item);

                    if (cls.HavaleList != null)
                        foreach (var item in cls.HavaleList)
                            AddToGrid(item);

                    if (cls.CheckMoshtariList != null)
                        foreach (var item in cls.CheckMoshtariList)
                            AddToGrid(item);

                    if (cls.CheckShakhsiList != null)
                        foreach (var item in cls.CheckShakhsiList)
                            AddToGrid(item);
                }

                SetLables();
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
        private void AddToGrid(object temp)
        {
            try
            {
                if ((temp) is PardakhtNaqdBussines)
                {
                    DGrid.Rows.Add(1);
                    DGrid[DGType.Index, DGrid.RowCount - 1].Value = "نقد";
                    DGrid[DGPrice.Index, DGrid.RowCount - 1].Value = ((PardakhtNaqdBussines)temp).Price;
                    DGrid[DgGuid.Index, DGrid.RowCount - 1].Value = ((PardakhtNaqdBussines)temp).Guid;
                    DGrid[DGTafsilGuid.Index, DGrid.RowCount - 1].Value = ((PardakhtNaqdBussines)temp).SandouqTafsilGuid;
                    DGrid[DGDescription.Index, DGrid.RowCount - 1].Value =
                        TafsilBussines.Get(((PardakhtNaqdBussines)temp).SandouqTafsilGuid).Name + " " +
                        ((PardakhtNaqdBussines)temp).Description;
                    DGrid[DG_TempDescription.Index, DGrid.RowCount - 1].Value = ((PardakhtNaqdBussines)temp).Description;
                    DGrid[DGNumber.Index, DGrid.RowCount - 1].Value = ((PardakhtNaqdBussines)temp).Description;
                }
                else if ((temp) is PardakhtHavaleBussines)
                {
                    DGrid.Rows.Add(1);
                    DGrid[DGType.Index, DGrid.RowCount - 1].Value = "حواله";
                    DGrid[DGTafsilGuid.Index, DGrid.RowCount - 1].Value = ((PardakhtHavaleBussines)temp).BankTafsilGuid;
                    DGrid[DGNumber.Index, DGrid.RowCount - 1].Value = ((PardakhtHavaleBussines)temp).Number;
                    DGrid[DGPrice.Index, DGrid.RowCount - 1].Value = ((PardakhtHavaleBussines)temp).Price;
                    DGrid[DGDescription.Index, DGrid.RowCount - 1].Value =
                        "پرداخت از بانک:" + TafsilBussines.Get(((PardakhtHavaleBussines)temp).BankTafsilGuid).Name +
                        " * " +
                        " درتاریخ:" + Calendar.MiladiToShamsi(DateTime.Now) + " * " +
                        " شماره : " + ((PardakhtHavaleBussines)temp).Number;
                    DGrid[DG_TempDescription.Index, DGrid.RowCount - 1].Value = ((PardakhtHavaleBussines)temp).Description;
                    DGrid[DgGuid.Index, DGrid.RowCount - 1].Value = ((PardakhtHavaleBussines)temp).Guid;
                }
                else if ((temp) is PardakhtCheckMoshtariBussines)
                { 
                    DGrid.Rows.Add(1);
                    DGrid[DGType.Index, DGrid.RowCount - 1].Value = "چک دریافتی";
                    DGrid[DGPrice.Index, DGrid.RowCount - 1].Value = ((PardakhtCheckMoshtariBussines)temp).Price;
                    DGrid[DG_TempDescription.Index, DGrid.RowCount - 1].Value = ((PardakhtCheckMoshtariBussines)temp).Description;
                    DGrid[DGDescription.Index, DGrid.RowCount - 1].Value =
                        $"خرج چک دریافتی از مشتری * شرح: {((PardakhtCheckMoshtariBussines) temp).Description}";
                    DGrid[DgGuid.Index, DGrid.RowCount - 1].Value = ((PardakhtCheckMoshtariBussines)temp).Guid;
                    DGrid[dgCheckGuid.Index, DGrid.RowCount - 1].Value = ((PardakhtCheckMoshtariBussines)temp).CheckGuid;
                }
                else if ((temp) is PardakhtCheckShakhsiBussines)
                {
                    DGrid.Rows.Add(1);
                    DGrid[DGType.Index, DGrid.RowCount - 1].Value = "چک شخصی";
                    DGrid[DGPrice.Index, DGrid.RowCount - 1].Value = ((PardakhtCheckShakhsiBussines)temp).Price;
                    DGrid[DG_TempDescription.Index, DGrid.RowCount - 1].Value = ((PardakhtCheckShakhsiBussines)temp).Description;
                    DGrid[DGDescription.Index, DGrid.RowCount - 1].Value =
                        $"پرداخت چک شخصی * شرح: {((PardakhtCheckShakhsiBussines)temp).Description}";
                    DGrid[DgGuid.Index, DGrid.RowCount - 1].Value = ((PardakhtCheckShakhsiBussines)temp).Guid;
                    DGrid[dgCheckGuid.Index, DGrid.RowCount - 1].Value = ((PardakhtCheckShakhsiBussines)temp).CheckPageGuid;
                    DGrid[DGNumber.Index, DGrid.RowCount - 1].Value = ((PardakhtCheckShakhsiBussines)temp).Number;
                    DGrid[DGDateSarresid.Index, DGrid.RowCount - 1].Value = ((PardakhtCheckShakhsiBussines)temp).DateSarResid;
                }
                SetLables();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void SetLables()
        {
            try
            {
                lblSum.Text = cls?.Sum.ToString("N0");
                lblSumCheckSh.Text = cls?.CheckShDesc;
                lblSumCheckM.Text = cls?.CheckMDesc;
                lblSumHavale.Text = cls?.HavaleDesc;
                lblSumNaqdi.Text = cls?.NaqdDesc;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        public void FetchData()
        {
            try
            {
                cls.ListBankClear();
                cls.ListNaghdClear();
                cls.ListCheckMoshtariClear();
                cls.ListCheckShakhsiClear();

                for (var i = 0; i <= DGrid.RowCount - 1; i++)
                {
                    if (ReferenceEquals(DGrid[DGType.Index, i].Value, null))
                        continue;
                    var temp = GetRowInfo(i);
                    if (temp is PardakhtNaqdBussines)
                        cls.AddToDetList((PardakhtNaqdBussines)temp);
                    else if (temp is PardakhtHavaleBussines)
                        cls.AddToDetList((PardakhtHavaleBussines)temp);
                    else if (temp is PardakhtCheckShakhsiBussines)
                        cls.AddToDetList((PardakhtCheckShakhsiBussines)temp);
                    else if (temp is PardakhtCheckMoshtariBussines)
                        cls.AddToDetList((PardakhtCheckMoshtariBussines)temp);
                }

            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private object GetRowInfo(int index)
        {
            try
            {
                var o = new object();
                if (index > DGrid.RowCount - 1) return null;

                if (DGrid[DGType.Index, index].Value.ToString() == "نقد")
                {
                    var temp = new PardakhtNaqdBussines()
                    {
                        Guid = (Guid)(DGrid[DgGuid.Index, index].Value),
                        Price = (DGrid[DGPrice.Index, index].Value.ToString().ParseToDecimal()),
                        SandouqTafsilGuid = (Guid)(DGrid[DGTafsilGuid.Index, index].Value),
                        Description = DGrid[DG_TempDescription.Index, index].Value.ToString()
                    };
                    o = temp;
                }
                else if (DGrid[DGType.Index, index].Value.ToString() == "چک دریافتی")
                {
                    var temp = new PardakhtCheckMoshtariBussines()
                    {
                        Guid = (Guid)(DGrid[DgGuid.Index, index].Value),
                        Price = (DGrid[DGPrice.Index, index].Value.ToString().ParseToDecimal()),
                        Description = DGrid[DG_TempDescription.Index, index].Value.ToString(),
                        CheckGuid = (Guid)(DGrid[dgCheckGuid.Index, index].Value)
                    };
                    o = temp;
                }
                else if (DGrid[DGType.Index, index].Value.ToString() == "حواله")
                {
                    var temp = new PardakhtHavaleBussines()
                    {
                        Guid = (Guid)(DGrid[DgGuid.Index, index].Value),
                        Price = (DGrid[DGPrice.Index, index].Value.ToString().ParseToDecimal()),
                        BankTafsilGuid = (Guid)(DGrid[DGTafsilGuid.Index, index].Value),
                        Number = DGrid[DGNumber.Index, index].Value.ToString(),
                        Description = DGrid[DG_TempDescription.Index, index].Value.ToString()
                    };
                    o = temp;
                }
                else if (DGrid[DGType.Index, index].Value.ToString() == "چک شخصی")
                {
                    var temp = new PardakhtCheckShakhsiBussines()
                    {
                        Guid = (Guid)(DGrid[DgGuid.Index, index].Value),
                        Price = (DGrid[DGPrice.Index, index].Value.ToString().ParseToDecimal()),
                        Description = DGrid[DG_TempDescription.Index, index].Value.ToString(),
                        CheckPageGuid = (Guid)(DGrid[dgCheckGuid.Index, index].Value),
                        Number = DGrid[DGNumber.Index,index].Value.ToString(),
                        DateSarResid = (DateTime)DGrid[DGDateSarresid.Index, index].Value
                    };
                    o = temp;
                }
                return o;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return null;
            }
        }

        public frmPardakhtMain()
        {
            InitializeComponent();
            cls = new PardakhtBussines();
        }
        public frmPardakhtMain(PardakhtBussines temp)
        {
            InitializeComponent();
            cls = temp;
        }
        public frmPardakhtMain(EnOperation op)
        {
            InitializeComponent();
            cls = new PardakhtBussines();
            _isLoaded = true;
            switch (op)
            {
                case EnOperation.CheckM:
                    mnuAddCheckM.PerformClick();
                    break;
                case EnOperation.CheckSh:
                    mnuAddCheckSh.PerformClick();
                    break;
                case EnOperation.Havale:
                    mnuAddHavale.PerformClick();
                    break;
                case EnOperation.Naqd:
                    mnuAddNaqd.PerformClick();
                    break;
            }
        }
        public frmPardakhtMain(Guid guid, bool isShowMode)
        {
            InitializeComponent();
            cls = PardakhtBussines.Get(guid);
            grp.Enabled = !isShowMode;
            btnFinish.Enabled = !isShowMode;
            contextMenu.Enabled = !isShowMode;
        }

        private async void frmPardakhtMain_Load(object sender, EventArgs e) => await SetDataAsync();
        private async void btnTafsilSearch_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new frmSelectTafsil(false);
                if (frm.ShowDialog() == DialogResult.OK)
                    await SetTafilAsync(frm.SelectedGuid);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void frmPardakhtMain_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                switch (e.KeyCode)
                {
                    case Keys.F1:
                        mnuAddNaqd.PerformClick();
                        break;
                    case Keys.F3:
                        mnuAddCheckSh.PerformClick();
                        break;
                    case Keys.F2:
                        mnuAddHavale.PerformClick();
                        break;
                    case Keys.F4:
                        mnuAddCheckM.PerformClick();
                        break;
                    case Keys.F7:
                        mnuEdit.PerformClick();
                        break;
                    case Keys.F5:
                        btnFinish.PerformClick();
                        break;
                    case Keys.Delete:
                        mnuDelete.PerformClick();
                        break;
                    case Keys.Escape:
                        Close();
                        break;
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void DGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
            => DGrid.Rows[e.RowIndex].Cells["dgRadif"].Value = e.RowIndex + 1;
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
        private void mnuAddNaqd_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new frmPardakhtNaqd(null);
                if (frm.ShowDialog(this) != DialogResult.OK) return;
                AddToGrid(frm.cls);
                FetchData();
                SetLables();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void mnuAddHavale_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new frmPardakhtHavale(null);
                if (frm.ShowDialog(this) != DialogResult.OK) return;
                AddToGrid(frm.cls);
                FetchData();
                SetLables();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void mnuAddCheckSh_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new frmPardakhtCheckSh(null);
                if (frm.ShowDialog(this) != DialogResult.OK) return;
                AddToGrid(frm.cls);
                FetchData();
                SetLables();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void mnuAddCheckM_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new frmPardakhtCheckM(null);
                if (frm.ShowDialog(this) != DialogResult.OK) return;
                AddToGrid(frm.cls);
                FetchData();
                SetLables();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void mnuEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGrid.RowCount == 0 || DGrid.CurrentRow == null) return;

                if (DGrid[DGType.Index, DGrid.CurrentRow.Index].Value.ToString() == "نقد")
                {
                    var str = (PardakhtNaqdBussines)GetRowInfo(DGrid.CurrentRow.Index);
                    var frm = new frmPardakhtNaqd(str);
                    if (frm.ShowDialog(this) != DialogResult.OK) return;
                    DGrid.Rows.RemoveAt(DGrid.CurrentRow.Index);
                    AddToGrid(frm.cls);
                }
                else if (DGrid[DGType.Index, DGrid.CurrentRow.Index].Value.ToString() == "چک دریافتی")
                {
                    var str = (PardakhtCheckMoshtariBussines)GetRowInfo(DGrid.CurrentRow.Index);
                    var frm = new frmPardakhtCheckM(str);
                    if (frm.ShowDialog(this) != DialogResult.OK) return;
                    DGrid.Rows.RemoveAt(DGrid.CurrentRow.Index);
                    AddToGrid(frm.cls);
                }
                else if (DGrid[DGType.Index, DGrid.CurrentRow.Index].Value.ToString() == "حواله")
                {
                    var str = (PardakhtHavaleBussines)GetRowInfo(DGrid.CurrentRow.Index);
                    var frm = new frmPardakhtHavale(str);
                    if (frm.ShowDialog(this) != DialogResult.OK) return;
                    DGrid.Rows.RemoveAt(DGrid.CurrentRow.Index);
                    AddToGrid(frm.cls);
                }
                else if (DGrid[DGType.Index, DGrid.CurrentRow.Index].Value.ToString() == "چک شخصی")
                {
                    var str = (PardakhtCheckShakhsiBussines)GetRowInfo(DGrid.CurrentRow.Index);
                    var frm = new frmPardakhtCheckSh(str);
                    if (frm.ShowDialog(this) != DialogResult.OK) return;
                    DGrid.Rows.RemoveAt(DGrid.CurrentRow.Index);
                    AddToGrid(frm.cls);
                }
                FetchData();
                SetLables();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void mnuDelete_Click(object sender, EventArgs e)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                if (DGrid.RowCount <= 0 || DGrid.CurrentRow == null) return;
                if (MessageBox.Show("مایل به حذف سطر جاری هستید ؟", "هشدار", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign) ==
                    DialogResult.No)
                    return;
                DGrid.Rows.RemoveAt(DGrid.CurrentRow.Index);
                DGrid.Focus();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }
            finally
            {
                if (res.HasError) this.ShowError(res, "خطا در حذف ریز پرداخت");
                else
                {
                    FetchData();
                    SetLables();
                }
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
                    cls.UserGuid = User.clsUser.CurrentUser.Guid;
                }

                cls.Modified = DateTime.Now;
                cls.Status = true;
                cls.Number = (long)txtNumber.Value;
                cls.Description = txtDesc.Text;
                cls.TafsilGuid = _tafsilGuid;
                cls.SanadNumber = (long)txtSanadNo.Value;

                res.AddReturnedValue(await cls.SaveAsync());
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }
            finally
            {
                if (res.HasError) this.ShowError(res, "خطا در ثبت برگه دریافت");
                else
                {
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
        }
    }
}
