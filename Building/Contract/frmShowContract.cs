using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityCache.Bussines;
using EntityCache.ViewModels;
using MetroFramework.Forms;
using Notification;
using Print;
using Services;
using User;

namespace Building.Contract
{
    public partial class frmShowContract : MetroForm
    {
        private bool _st = true;
        private List<ContractBussines> list;
        private async Task LoadDataAsync(bool status, string search = "")
        {
            try
            {
                list = await ContractBussines.GetAllAsync(search);
                Invoke(new MethodInvoker(() => conBindingSource.DataSource =
                    list.Where(q => q.Status == status).OrderByDescending(q => q.Modified).ToSortableBindingList()));
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void SetAccess()
        {
            try
            {
                var access = clsUser.CurrentUser.UserAccess;
                mnuAdd.Enabled = access?.Contract.Contract_Insert ?? false;
                mnuEdit.Enabled = access?.Contract.Contract_Update ?? false;
                mnuDelete.Enabled = access?.Contract.Contract_Delete ?? false;
                mnuStatus.Enabled = access?.Contract.Contract_Disable ?? false;
                mnuView.Enabled = access?.Contract.Contract_View ?? false;
                mnuChangeTemp.Enabled = access?.Contract.Contract_Finish ?? false;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        public bool ST
        {
            get => _st;
            set
            {
                _st = value;
                if (_st)
                {
                    mnuStatus.Text = "غیرفعال (Ctrl+S)";
                    Task.Run(() => LoadDataAsync(ST, txtSearch.Text));
                    mnuDelete.Text = "حذف (Del)";
                }
                else
                {
                    mnuStatus.Text = "فعال (Ctrl+S)";
                    Task.Run(() => LoadDataAsync(ST, txtSearch.Text));
                    mnuDelete.Text = "فعال کردن";
                }
            }
        }

        public frmShowContract()
        {
            InitializeComponent();
            SetAccess();
        }

        private async void frmShowContract_Load(object sender, EventArgs e)
        {
            await LoadDataAsync(ST);
        }
        private void DGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DGrid.Rows[e.RowIndex].Cells["dgRadif"].Value = e.RowIndex + 1;
        }
        private async void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                await LoadDataAsync(ST, txtSearch.Text);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void frmShowContract_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                switch (e.KeyCode)
                {
                    case Keys.Insert:
                        mnuAdd.PerformClick();
                        break;
                    case Keys.F7:
                        mnuEdit.PerformClick();
                        break;
                    case Keys.Delete:
                        mnuDelete.PerformClick();
                        break;
                    case Keys.F12:
                        mnuView.PerformClick();
                        break;
                    case Keys.S:
                        if (e.Control) ST = !ST;
                        break;
                    case Keys.Escape:
                        if (!string.IsNullOrEmpty(txtSearch.Text))
                        {
                            txtSearch.Text = "";
                            return;
                        }
                        Close();
                        break;
                    case Keys.Down:
                        if (txtSearch.Focused)
                            DGrid.Focus();
                        break;
                    case Keys.F:
                        if (e.Control) txtSearch.Focus();
                        break;
                    case Keys.Enter:
                        mnuEdit.PerformClick();
                        break;
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async void mnuAdd_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new frmContractMain();
                if (frm.ShowDialog(this) == DialogResult.OK)
                    await LoadDataAsync(ST, txtSearch.Text);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void mnuPrint_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new frmSetPrintSize();
                if (frm.ShowDialog(this) != DialogResult.OK) return;

                if (frm._PrintType != EnPrintType.Excel)
                {
                    var cls = new ReportGenerator(StiType.Contract_List, frm._PrintType) { Lst = new List<object>(list) };
                    cls.PrintNew();
                }

                ExportToExcel.ExportContract(list, this);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async void mnuShowStandard_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGrid.RowCount <= 0) return;
                if (DGrid.CurrentRow == null) return;
                var guid = (Guid)DGrid[dgGuid.Index, DGrid.CurrentRow.Index].Value;
                var contract = await ContractBussines.GetAsync(guid);
                if (contract == null) return;
                var building = await BuildingBussines.GetAsync(contract.BuildingGuid);
                var buildingAccountType = await BuildingAccountTypeBussines.GetAsync(building.BuildingAccountTypeGuid);
                var fSide = await PeoplesBussines.GetAsync(contract.FirstSideGuid);
                var sSide = await PeoplesBussines.GetAsync(contract.SecondSideGuid);
                var unitCity = await CitiesBussines.GetAsync(Guid.Parse(Settings.Classes.clsEconomyUnit.EconomyCity));
                if (contract.Type == EnRequestType.Rahn)
                {
                    var view = new RahnViewModel
                    {
                        fName = fSide?.Name,
                        fFatherName = fSide?.FatherName,
                        fIdCode = fSide?.IdCode,
                        fIssuedFrom = fSide?.IssuedFrom,
                        fDateBirth = fSide?.DateBirth,
                        fNationalCode = fSide?.NationalCode,
                        fAddress = fSide?.Address,
                        sName = sSide?.Name,
                        sFatherName = sSide?.FatherName,
                        sIdCode = sSide?.IdCode,
                        sIssuedFrom = sSide?.IssuedFrom,
                        sDateBirth = sSide?.DateBirth,
                        sNationalCode = sSide?.NationalCode,
                        sAddress = sSide?.Address,
                        ContractDesc = contract?.Description,
                        DongCount = 6,
                        BuildingAddress = building?.Address,
                        Masahat = building?.Masahat ?? 0,
                        RoomCount = building?.RoomCount ?? 0,
                        ContractTerm = contract?.Term ?? 0,
                        ContractfDate = Calendar.MiladiToShamsi(contract?.FromDate),
                        ContractsDate = Calendar.MiladiToShamsi((contract?.FromDate ?? DateTime.Now).AddMonths((int)contract?.Term)),
                        UnitAddress = Settings.Classes.clsEconomyUnit.ManagerAddress,
                        TotalEjare = (contract?.MinorPrice * contract?.Term) ?? 0,
                        MinorEjare = contract?.MinorPrice ?? 0,
                        Rahn = contract?.TotalPrice ?? 0,
                        CheckNo = contract?.CheckNo,
                        BankName = contract?.BankName,
                        Shobe = contract?.Shobe,
                        Sarresid = contract?.SarResid,
                        UnitName = Settings.Classes.clsEconomyUnit.EconomyName,
                        DischargeDate = Calendar.MiladiToShamsi(contract?.DischargeDate),
                        BuildingAccountType = buildingAccountType?.Name,
                        Sarqofli = contract?.SarQofli ?? 0,
                        Delay = contract?.Delay ?? 0,
                        UnitCity = unitCity?.Name,
                        Commition = contract?.Finance?.FirstTotalPrice ?? 0,
                        ContractDate = contract?.DateSh,
                        ContractTime = contract?.DateM.ToShortTimeString()
                    };
                    var lst = new List<object>() { view };
                    var cls = new ReportGenerator(StiType.Contract_One, EnPrintType.Pdf_A4)
                    { Lst = lst, SanadId = (int)contract?.Code };
                    cls.PrintNew();
                }
                else if (contract.Type == EnRequestType.Forush)
                {
                    var view = new ForoshViewModel()
                    {
                        fName = fSide?.Name,
                        fFatherName = fSide?.FatherName,
                        fIdCode = fSide?.IdCode,
                        fIssuedFrom = fSide?.IssuedFrom,
                        fDateBirth = fSide?.DateBirth,
                        fNationalCode = fSide?.NationalCode,
                        fAddress = fSide?.Address,
                        sName = sSide?.Name,
                        sFatherName = sSide?.FatherName,
                        sIdCode = sSide?.IdCode,
                        sIssuedFrom = sSide?.IssuedFrom,
                        sDateBirth = sSide?.DateBirth,
                        sNationalCode = sSide?.NationalCode,
                        sAddress = sSide?.Address,
                        ContractDesc = contract?.Description,
                        DongCount = building?.Dang ?? 0,
                        BuildingAddress = building?.Address,
                        Masahat = building?.Masahat ?? 0,
                        UnitAddress = Settings.Classes.clsEconomyUnit.ManagerAddress,
                        TotalPrice = contract?.TotalPrice ?? 0,
                        MinorPrice = (contract?.TotalPrice - contract?.MinorPrice) ?? 0,
                        Beyane = contract?.MinorPrice ?? 0,
                        CheckNo = contract?.CheckNo,
                        BankName = contract?.BankName,
                        Shobe = contract?.Shobe,
                        Sarresid = contract?.SarResid,
                        UnitName = Settings.Classes.clsEconomyUnit.EconomyName,
                        DischargeDate = Calendar.MiladiToShamsi(contract?.DischargeDate),
                        BuildingAccountType = buildingAccountType?.Name,
                        Delay = contract?.Delay ?? 0,
                        UnitCity = unitCity?.Name,
                        Commition = contract?.Finance?.FirstTotalPrice ?? 0,
                        ContractDate = contract?.DateSh,
                        ContractTime = contract?.DateM.ToShortTimeString()
                    };
                    var lst = new List<object>() { view };
                    var cls = new ReportGenerator(StiType.Contract_One, EnPrintType.Pdf_A5)
                    { Lst = lst, SanadId = (int)contract?.Code };
                    cls.PrintNew();
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async void mnuChangeTemp_Click(object sender, EventArgs e)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                if (DGrid.RowCount <= 0) return;
                if (DGrid.CurrentRow == null) return;
                var guid = (Guid)DGrid[dgGuid.Index, DGrid.CurrentRow.Index].Value;
                var bu = await ContractBussines.GetAsync(guid);
                if (bu == null) return;
                if (!bu.IsTemp)
                {
                    frmNotification.PublicInfo.ShowMessage(
                        "وضعیت قرارداد هم اکنون بسته شده می باشد");
                    return;
                }

                if (MessageBox.Show(this,
                        $@"آیا از اعمال تغییرات اطمینان دارید؟", "تغییر وضعیت قرارداد",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) == DialogResult.No) return;

                bu.IsTemp = false;
                res.AddReturnedValue(await bu.SaveAsync());
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }
            finally
            {
                if (res.HasError)
                {
                    var frm = new FrmShowErrorMessage(res, "خطا در بستن قولنامه");
                    frm.ShowDialog(this);
                    frm.Dispose();
                }
                else await LoadDataAsync(ST, txtSearch.Text);
            }
        }
        private void mnuStatus_Click(object sender, EventArgs e) => ST = !ST;
        private async void mnuDelete_Click(object sender, EventArgs e)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                if (DGrid.RowCount <= 0) return;
                if (DGrid.CurrentRow == null) return;
                var guid = (Guid)DGrid[dgGuid.Index, DGrid.CurrentRow.Index].Value;
                if (ST)
                {
                    if (MessageBox.Show(this,
                            $@"آیا از حذف قرارداد اطمینان دارید؟", "حذف",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question) == DialogResult.No) return;
                    var prd = await ContractBussines.GetAsync(guid);
                    if (!prd.IsTemp)
                    {
                        frmNotification.PublicInfo.ShowMessage(
                            "شما مجاز به حذف داده نهایی شده نمی باشید");
                        return;
                    }

                    res.AddReturnedValue(await prd.ChangeStatusAsync(false));
                    if (res.HasError) return;
                    UserLog.Save(EnLogAction.Delete, EnLogPart.Contracts);
                }
                else
                {
                    if (MessageBox.Show(this,
                            $@"آیا از فعال کردن سند پرداخت اطمینان دارید؟", "حذف",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question) == DialogResult.No) return;
                    var prd = await ContractBussines.GetAsync(guid);


                    res.AddReturnedValue(await prd.ChangeStatusAsync(true));
                    if (res.HasError) return;
                    UserLog.Save(EnLogAction.Enable, EnLogPart.Contracts);
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }
            finally
            {
                if (res.HasError)
                {
                    var frm = new FrmShowErrorMessage(res, "خطا در تغییر وضعیت قولنامه");
                    frm.ShowDialog(this);
                    frm.Dispose();
                }
                else await LoadDataAsync(ST, txtSearch.Text);
            }
        }
        private void mnuView_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGrid.RowCount <= 0) return;
                if (DGrid.CurrentRow == null) return;
                var guid = (Guid)DGrid[dgGuid.Index, DGrid.CurrentRow.Index].Value;
                var frm = new frmContractMain(guid, true);
                frm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async void mnuEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGrid.RowCount <= 0) return;
                if (DGrid.CurrentRow == null) return;
                if (!ST)
                {
                    frmNotification.PublicInfo.ShowMessage(
                        "شما مجاز به ویرایش داده حذف شده نمی باشید \r\n برای این منظور، ابتدا فیلد موردنظر را از حالت حذف شده به فعال، تغییر وضعیت دهید");
                    return;
                }
                var guid = (Guid)DGrid[dgGuid.Index, DGrid.CurrentRow.Index].Value;
                var con = ContractBussines.Get(guid);
                if (con == null) return;
                if (!con.IsTemp)
                {
                    frmNotification.PublicInfo.ShowMessage(
                        "شما مجاز به ویرایش داده نهایی شده نمی باشید");
                    return;
                }
                var frm = new frmContractMain(guid, false);
                if (frm.ShowDialog(this) == DialogResult.OK)
                    await LoadDataAsync(ST, txtSearch.Text);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
