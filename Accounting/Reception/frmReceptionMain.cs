using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsSerivces;
using Accounting.Hesab;
using EntityCache.Bussines;
using MetroFramework.Forms;
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
                            AddToGrid(item);

                    if (cls.HavaleList != null)
                        foreach (var item in cls.HavaleList)
                            AddToGrid(item);

                    if (cls.CheckList != null)
                        foreach (var item in cls.CheckList)
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
                if ((temp) is ReceptionNaqdBussines)
                {
                    DGrid.Rows.Add(1);
                    DGrid[DGType.Index, DGrid.RowCount - 1].Value = "نقد";
                    DGrid[DGPrice.Index, DGrid.RowCount - 1].Value = ((ReceptionNaqdBussines)temp).Price;
                    DGrid[DgGuid.Index, DGrid.RowCount - 1].Value = ((ReceptionNaqdBussines)temp).Guid;
                    DGrid[DGTafsilGuid.Index, DGrid.RowCount - 1].Value = ((ReceptionNaqdBussines)temp).SandouqTafsilGuid;
                    DGrid[DGDescription.Index, DGrid.RowCount - 1].Value =
                        TafsilBussines.Get(((ReceptionNaqdBussines)temp).SandouqTafsilGuid).Name + " " +
                        ((ReceptionNaqdBussines)temp).Description;
                    DGrid[DG_TempDescription.Index, DGrid.RowCount - 1].Value = ((ReceptionNaqdBussines)temp).Description;
                    DGrid[DGNumber.Index, DGrid.RowCount - 1].Value = ((ReceptionNaqdBussines)temp).Description;
                    DGrid[DGDate.Index, DGrid.RowCount - 1].Value = ((ReceptionNaqdBussines)temp).DateM;
                }
                else if ((temp) is ReceptionHavaleBussines)
                {
                    DGrid.Rows.Add(1);
                    DGrid[DGType.Index, DGrid.RowCount - 1].Value = "حواله";
                    DGrid[DGTafsilGuid.Index, DGrid.RowCount - 1].Value = ((ReceptionHavaleBussines)temp).BankTafsilGuid;
                    DGrid[DGDate.Index, DGrid.RowCount - 1].Value = ((ReceptionHavaleBussines)temp).DateM;
                    DGrid[DGNumber.Index, DGrid.RowCount - 1].Value = ((ReceptionHavaleBussines)temp).PeygiriNumber;
                    DGrid[DGPrice.Index, DGrid.RowCount - 1].Value = ((ReceptionHavaleBussines)temp).Price;
                    DGrid[DGDescription.Index, DGrid.RowCount - 1].Value =
                        "واریز به بانک:" + TafsilBussines.Get(((ReceptionHavaleBussines)temp).BankTafsilGuid).Name +
                        " * " +
                        " درتاریخ:" + Calendar.MiladiToShamsi(((ReceptionHavaleBussines)temp).DateM) + " * " +
                        " شماره : " + ((ReceptionHavaleBussines)temp).PeygiriNumber;
                    DGrid[DG_TempDescription.Index, DGrid.RowCount - 1].Value = ((ReceptionHavaleBussines)temp).Description;
                    DGrid[DgGuid.Index, DGrid.RowCount - 1].Value = ((ReceptionHavaleBussines)temp).Guid;
                }
                else if ((temp) is ReceptionCheckBussines)
                {
                    if (((ReceptionCheckBussines)temp).CheckStatus != EnCheckM.Batel)
                    {
                        DGrid.Rows.Add(1);
                        DGrid[DGType.Index, DGrid.RowCount - 1].Value = "چک";
                        DGrid[DGPrice.Index, DGrid.RowCount - 1].Value = ((ReceptionCheckBussines)temp).Price;
                        DGrid[DGCheckBankName.Index, DGrid.RowCount - 1].Value = ((ReceptionCheckBussines)temp).BankName;
                        DGrid[DGDate.Index, DGrid.RowCount - 1].Value = ((ReceptionCheckBussines)temp).DateM;
                        DGrid[DGDateSarresid.Index, DGrid.RowCount - 1].Value = ((ReceptionCheckBussines)temp).DateSarResid;
                        DGrid[DGCheckStatus.Index, DGrid.RowCount - 1].Value = (int)((ReceptionCheckBussines)temp).CheckStatus;
                        DGrid[DGPoshtNomre.Index, DGrid.RowCount - 1].Value = ((ReceptionCheckBussines)temp).PoshtNomre;
                        DGrid[DGNumber.Index, DGrid.RowCount - 1].Value = ((ReceptionCheckBussines)temp).CheckNumber;
                        DGrid[DG_TempDescription.Index, DGrid.RowCount - 1].Value = ((ReceptionCheckBussines)temp).Description;
                        DGrid[DGDescription.Index, DGrid.RowCount - 1].Value =
                            "تاريخ سررسيد : " + ((ReceptionCheckBussines)temp).DateSarresidSh + " * " +
                            "شماره : " + ((ReceptionCheckBussines)temp).CheckNumber + " * " +
                            "بانک :" + DGrid[DGCheckBankName.Index, DGrid.RowCount - 1].Value + " * " +
                            "شرح: " + ((ReceptionCheckBussines)temp).Description + " * " +
                            "وضعيت در سيستم: " + ((ReceptionCheckBussines)temp).CheckStatus.GetDisplay() + " * " +
                            "محل واگذاری: " + TafsilBussines.Get(((ReceptionCheckBussines)temp).SandouqTafsilGuid)
                                ?.Name;
                        DGrid[DgGuid.Index, DGrid.RowCount - 1].Value = ((ReceptionCheckBussines)temp).Guid;
                        DGrid[DGTafsilGuid.Index, DGrid.RowCount - 1].Value = ((ReceptionCheckBussines)temp).SandouqTafsilGuid;
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

        public frmReceptionMain()
        {
            InitializeComponent();
            cls = new ReceptionBussines();
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
        }
        public frmReceptionMain(Guid guid, bool isShowMode)
        {
            InitializeComponent();
            cls = ReceptionBussines.Get(guid);
            grp.Enabled = !isShowMode;
            btnFinish.Enabled = !isShowMode;
            contextMenu.Enabled = !isShowMode;
        }

        private void mnuAddNaqd_Click(object sender, System.EventArgs e)
        {
            try
            {
                var frm = new frmReceptionNaqd(null);
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
        private async void frmReceptionMain_Load(object sender, EventArgs e) => await SetDataAsync();
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
        private void mnuAddHavale_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new frmReceptionHavale(null);
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
        private void mnuAddCheck_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new frmReceptionCheck(null);
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
        private void mnuEdit_Click(object sender, EventArgs e)
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
                    AddToGrid(frm.cls);
                }
                else if (DGrid[DGType.Index, DGrid.CurrentRow.Index].Value.ToString() == "چک")
                {
                    var str = (ReceptionCheckBussines)GetRowInfo(DGrid.CurrentRow.Index);
                    var frm = new frmReceptionCheck(str);
                    if (frm.ShowDialog(this) != DialogResult.OK) return;
                    DGrid.Rows.RemoveAt(DGrid.CurrentRow.Index);
                    AddToGrid(frm.cls);
                }
                else if (DGrid[DGType.Index, DGrid.CurrentRow.Index].Value.ToString() == "حواله")
                {
                    var str = (ReceptionHavaleBussines)GetRowInfo(DGrid.CurrentRow.Index);
                    var frm = new frmReceptionHavale(str);
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
