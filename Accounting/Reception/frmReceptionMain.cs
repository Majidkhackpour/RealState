using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsSerivces;
using Accounting.Hesab;
using EntityCache.Bussines;
using MetroFramework.Forms;
using Notification.AdjectiveDescription;
using Services;

namespace Accounting.Reception
{
    public partial class frmReceptionMain : MetroForm
    {
        private ReceptionBussines cls;
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
                    txtNumber.Value = await ReceptionBussines.NextCodeAsync();
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
                            await AddToGridAsync(item);

                    if (cls.HavaleList != null)
                        foreach (var item in cls.HavaleList)
                            await AddToGridAsync(item);

                    if (cls.CheckList != null)
                        foreach (var item in cls.CheckList)
                            await AddToGridAsync(item);
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
        private async Task AddToGridAsync(object temp)
        {
            try
            {
                if (temp is ReceptionNaqdBussines bussines)
                {
                    DGrid.Rows.Add(1);
                    DGrid[DGType.Index, DGrid.RowCount - 1].Value = "نقد";
                    DGrid[DGPrice.Index, DGrid.RowCount - 1].Value = bussines.Price;
                    DGrid[DgGuid.Index, DGrid.RowCount - 1].Value = bussines.Guid;
                    DGrid[DGTafsilGuid.Index, DGrid.RowCount - 1].Value = bussines.SandouqTafsilGuid;
                    DGrid[DGDescription.Index, DGrid.RowCount - 1].Value =
                        (await TafsilBussines.GetAsync(bussines.SandouqTafsilGuid)).Name + " " +
                        bussines.Description;
                    DGrid[DG_TempDescription.Index, DGrid.RowCount - 1].Value = bussines.Description;
                    DGrid[DGNumber.Index, DGrid.RowCount - 1].Value = bussines.Description;
                    DGrid[DGDate.Index, DGrid.RowCount - 1].Value = bussines.DateM;
                }
                else if (temp is ReceptionHavaleBussines havaleBussines)
                {
                    DGrid.Rows.Add(1);
                    DGrid[DGType.Index, DGrid.RowCount - 1].Value = "حواله";
                    DGrid[DGTafsilGuid.Index, DGrid.RowCount - 1].Value = havaleBussines.BankTafsilGuid;
                    DGrid[DGDate.Index, DGrid.RowCount - 1].Value = havaleBussines.DateM;
                    DGrid[DGNumber.Index, DGrid.RowCount - 1].Value = havaleBussines.PeygiriNumber;
                    DGrid[DGPrice.Index, DGrid.RowCount - 1].Value = havaleBussines.Price;
                    DGrid[DGDescription.Index, DGrid.RowCount - 1].Value =
                        "واریز به بانک:" + (await TafsilBussines.GetAsync(havaleBussines.BankTafsilGuid)).Name +
                        " * " +
                        " درتاریخ:" + Calendar.MiladiToShamsi(havaleBussines.DateM) + " * " +
                        " شماره : " + havaleBussines.PeygiriNumber;
                    DGrid[DG_TempDescription.Index, DGrid.RowCount - 1].Value = havaleBussines.Description;
                    DGrid[DgGuid.Index, DGrid.RowCount - 1].Value = havaleBussines.Guid;
                }
                else if (temp is ReceptionCheckBussines checkBussines)
                {
                    if (checkBussines.CheckStatus != EnCheckM.Batel)
                    {
                        DGrid.Rows.Add(1);
                        DGrid[DGType.Index, DGrid.RowCount - 1].Value = "چک";
                        DGrid[DGPrice.Index, DGrid.RowCount - 1].Value = checkBussines.Price;
                        DGrid[DGCheckBankName.Index, DGrid.RowCount - 1].Value = checkBussines.BankName;
                        DGrid[DGDate.Index, DGrid.RowCount - 1].Value = checkBussines.DateM;
                        DGrid[DGDateSarresid.Index, DGrid.RowCount - 1].Value = checkBussines.DateSarResid;
                        DGrid[DGCheckStatus.Index, DGrid.RowCount - 1].Value = (int)checkBussines.CheckStatus;
                        DGrid[DGPoshtNomre.Index, DGrid.RowCount - 1].Value = checkBussines.PoshtNomre;
                        DGrid[DGNumber.Index, DGrid.RowCount - 1].Value = checkBussines.CheckNumber;
                        DGrid[DG_TempDescription.Index, DGrid.RowCount - 1].Value = checkBussines.Description;
                        DGrid[DGDescription.Index, DGrid.RowCount - 1].Value =
                            "تاريخ سررسيد : " + checkBussines.DateSarresidSh + " * " +
                            "شماره : " + checkBussines.CheckNumber + " * " +
                            "بانک :" + DGrid[DGCheckBankName.Index, DGrid.RowCount - 1].Value + " * " +
                            "شرح: " + checkBussines.Description + " * " +
                            "وضعيت در سيستم: " + checkBussines.CheckStatus.GetDisplay() + " * " +
                            "محل واگذاری: " + (await TafsilBussines.GetAsync(checkBussines.SandouqTafsilGuid))
                                ?.Name;
                        DGrid[DgGuid.Index, DGrid.RowCount - 1].Value = checkBussines.Guid;
                        DGrid[DGTafsilGuid.Index, DGrid.RowCount - 1].Value = checkBussines.SandouqTafsilGuid;
                    }
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
                lblSumCheck.Text = cls?.CheckDesc;
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
                cls.ListCheckClear();

                for (var i = 0; i <= DGrid.RowCount - 1; i++)
                {
                    if (ReferenceEquals(DGrid[DGType.Index, i].Value, null))
                        continue;
                    var temp = GetRowInfo(i);
                    if (temp is ReceptionNaqdBussines)
                        cls.AddToDetList((ReceptionNaqdBussines)temp);
                    else if (temp is ReceptionHavaleBussines)
                        cls.AddToDetList((ReceptionHavaleBussines)temp);
                    else if (temp is ReceptionCheckBussines)
                        cls.AddToDetList((ReceptionCheckBussines)temp);
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
                    var temp = new ReceptionNaqdBussines()
                    {
                        Guid = (Guid)(DGrid[DgGuid.Index, index].Value),
                        Price = (DGrid[DGPrice.Index, index].Value.ToString().ParseToDecimal()),
                        SandouqTafsilGuid = (Guid)(DGrid[DGTafsilGuid.Index, index].Value),
                        DateM = (DateTime)(DGrid[DGDate.Index, index].Value),
                        Description = DGrid[DG_TempDescription.Index, index].Value.ToString()
                    };
                    o = temp;
                }
                else if (DGrid[DGType.Index, index].Value.ToString() == "چک")
                {
                    var temp = new ReceptionCheckBussines()
                    {
                        Guid = (Guid)(DGrid[DgGuid.Index, index].Value),
                        Price = (DGrid[DGPrice.Index, index].Value.ToString().ParseToDecimal()),
                        BankName = DGrid[DGCheckBankName.Index, index].Value.ToString(),
                        DateM = (DateTime)(DGrid[DGDate.Index, index].Value),
                        CheckNumber = DGrid[DGNumber.Index, index].Value.ToString(),
                        CheckStatus = (EnCheckM)(DGrid[DGCheckStatus.Index, index].Value),
                        PoshtNomre = DGrid[DGPoshtNomre.Index, index].Value.ToString(),
                        Description = DGrid[DG_TempDescription.Index, index].Value.ToString(),
                        SandouqTafsilGuid = (Guid)(DGrid[DGTafsilGuid.Index, index].Value),
                        DateSarResid = (DateTime)(DGrid[DGDateSarresid.Index, index].Value)
                    };
                    o = temp;
                }
                else if (DGrid[DGType.Index, index].Value.ToString() == "حواله")
                {
                    var temp = new ReceptionHavaleBussines()
                    {
                        Guid = (Guid)(DGrid[DgGuid.Index, index].Value),
                        Price = (DGrid[DGPrice.Index, index].Value.ToString().ParseToDecimal()),
                        BankTafsilGuid = (Guid)(DGrid[DGTafsilGuid.Index, index].Value),
                        DateM = (DateTime)(DGrid[DGDate.Index, index].Value),
                        PeygiriNumber = DGrid[DGNumber.Index, index].Value.ToString(),
                        Description = DGrid[DG_TempDescription.Index, index].Value.ToString(),
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
        private void SetAccess()
        {
            try
            {
                var access = UserBussines.CurrentUser.UserAccess;
                mnuAddCheck.Enabled = access?.Reception.Reception_InsertCheck ?? false;
                mnuAddHavale.Enabled = access?.Reception.Reception_InsertHavale ?? false;
                mnuAddNaqd.Enabled = access?.Reception.Reception_InsertNaqd ?? false;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        public frmReceptionMain(ReceptionBussines obj, bool isShowMode)
        {
            try
            {
                InitializeComponent();
                cls = obj;
                grp.Enabled = !isShowMode;
                btnFinish.Enabled = !isShowMode;
                contextMenu.Enabled = !isShowMode;
                SetAccess();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        public frmReceptionMain(EnOperation op)
        {
            InitializeComponent();
            cls = new ReceptionBussines();
            _isLoaded = true;
            switch (op)
            {
                case EnOperation.CheckM:
                    mnuAddCheck.PerformClick();
                    break;
                case EnOperation.Havale:
                    mnuAddHavale.PerformClick();
                    break;
                case EnOperation.Naqd:
                    mnuAddNaqd.PerformClick();
                    break;
            }
            SetAccess();
        }

        private async void mnuAddNaqd_Click(object sender, System.EventArgs e)
        {
            try
            {
                var frm = new frmReceptionNaqd(null);
                if (frm.ShowDialog(this) != DialogResult.OK) return;
                await AddToGridAsync(frm.cls);
                FetchData();
                SetLables();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async void frmReceptionMain_Load(object sender, EventArgs e) => await SetDataAsync();
        private async void btnTafsilSearch_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new frmSelectTafsil(true);
                if (frm.ShowDialog(this) == DialogResult.OK)
                    await SetTafilAsync(frm.SelectedGuid);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async void mnuAddHavale_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new frmReceptionHavale(null);
                if (frm.ShowDialog(this) != DialogResult.OK) return;
                await AddToGridAsync(frm.cls);
                FetchData();
                SetLables();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async void mnuAddCheck_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new frmReceptionCheck(new ReceptionCheckBussines(), false);
                if (frm.ShowDialog(this) != DialogResult.OK) return;
                await AddToGridAsync(frm.cls);
                FetchData();
                SetLables();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void frmReceptionMain_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                switch (e.KeyCode)
                {
                    case Keys.F1:
                        mnuAddNaqd.PerformClick();
                        break;
                    case Keys.F2:
                        mnuAddCheck.PerformClick();
                        break;
                    case Keys.F3:
                        mnuAddHavale.PerformClick();
                        break;
                    case Keys.F7:
                        mnuEdit.PerformClick();
                        break;
                    case Keys.F5:
                        btnFinish.PerformClick();
                        break;
                    case Keys.F9:
                        var frm = new frmShowDesc();
                        if (frm.ShowDialog() == DialogResult.OK)
                            txtDesc.Text = frm.Description;
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
        private async void mnuEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGrid.RowCount == 0 || DGrid.CurrentRow == null) return;

                if (DGrid[DGType.Index, DGrid.CurrentRow.Index].Value.ToString() == "نقد")
                {
                    var str = (ReceptionNaqdBussines)GetRowInfo(DGrid.CurrentRow.Index);
                    var frm = new frmReceptionNaqd(str);
                    if (frm.ShowDialog(this) != DialogResult.OK) return;
                    DGrid.Rows.RemoveAt(DGrid.CurrentRow.Index);
                    await AddToGridAsync(frm.cls);
                }
                else if (DGrid[DGType.Index, DGrid.CurrentRow.Index].Value.ToString() == "چک")
                {
                    var str = (ReceptionCheckBussines)GetRowInfo(DGrid.CurrentRow.Index);
                    var frm = new frmReceptionCheck(str,false);
                    if (frm.ShowDialog(this) != DialogResult.OK) return;
                    DGrid.Rows.RemoveAt(DGrid.CurrentRow.Index);
                    await AddToGridAsync(frm.cls);
                }
                else if (DGrid[DGType.Index, DGrid.CurrentRow.Index].Value.ToString() == "حواله")
                {
                    var str = (ReceptionHavaleBussines)GetRowInfo(DGrid.CurrentRow.Index);
                    var frm = new frmReceptionHavale(str);
                    if (frm.ShowDialog(this) != DialogResult.OK) return;
                    DGrid.Rows.RemoveAt(DGrid.CurrentRow.Index);
                    await AddToGridAsync(frm.cls);
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
                if (DGrid[DGType.Index, DGrid.CurrentRow.Index].Value.ToString() == "چک")
                {
                    var str = (ReceptionCheckBussines)GetRowInfo(DGrid.CurrentRow.Index);
                    if (str.CheckStatus != EnCheckM.Mojoud)
                    {
                        res.AddError("جهت ابطال چک از صفحه چکها استفاده نمایید .");
                        return;
                    }
                }

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
                if (res.HasError) this.ShowError(res, "خطا در حذف ریز دریافت");
                else
                {
                    FetchData();
                    SetLables();
                }
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
                    cls.DateM = DateTime.Now;
                    cls.UserGuid = UserBussines.CurrentUser.Guid;
                }

                cls.Modified = DateTime.Now;
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
