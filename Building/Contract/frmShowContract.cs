using EntityCache.Bussines;
using EntityCache.Bussines.ReportBussines;
using EntityCache.ViewModels;
using MetroFramework.Forms;
using Notification;
using Print;
using Services;
using Services.FilterObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsSerivces;

namespace Building.Contract
{
    public partial class frmShowContract : MetroForm
    {
        private bool _st = true;
        private List<ContractBussines> list;
        private CancellationTokenSource _token = new CancellationTokenSource();
        private ContractFilter filter;
        private IEnumerable<ContractReportBusiness> _list;

        private async Task LoadDataAsync(string search = "")
        {
            try
            {
                if (filter == null)
                    filter = new ContractFilter()
                    {
                        Status = _st,
                        Date1 = new DateTime(2000, 01, 01, 0, 0, 0),
                        Date2 = new DateTime(2050, 12, 29, 23, 59, 59)
                    };
                _list = await ContractReportBusiness.GetAllAsync(filter);
                Search(search);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void Search(string srach = "")
        {
            try
            {
                var lst = _list;
                _token?.Cancel();
                _token = new CancellationTokenSource();
                var t = _token.Token;
                if (string.IsNullOrEmpty(srach)) srach = "";
                var searchItems = srach.SplitString();
                if (searchItems?.Count > 0)
                    foreach (var item in searchItems)
                    {
                        if (t.IsCancellationRequested) return;
                        if (!string.IsNullOrEmpty(item) && item.Trim() != "")
                        {
                            lst = lst?.Where(x => x.ContractCode.ToString().ToLower().Contains(item.ToLower()) ||
                                                 x.CodeInArchive.ToLower().Contains(item.ToLower()) ||
                                                 x.HologramSerial.ToLower().Contains(item.ToLower()) ||
                                                 x.FirstSideName.ToLower().Contains(item.ToLower()) ||
                                                 x.SecondSideName.ToLower().Contains(item.ToLower()) ||
                                                 x.TypeName.ToLower().Contains(item.ToLower()))
                                ?.ToList();
                        }
                    }

                if (!(lst?.Any() ?? false))
                {
                    this.ShowMessage("داده ای جهت نمایش وجود ندارد");
                    return;
                }

                conBindingSource.DataSource = lst?.OrderByDescending(q => q.CreateDate)?.ToSortableBindingList();
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
                var access = UserBussines.CurrentUser.UserAccess;
                mnuAdd.Enabled = access?.Contract.Contract_Insert ?? false;
                mnuEdit.Enabled = access?.Contract.Contract_Update ?? false;
                mnuDelete.Enabled = access?.Contract.Contract_Delete ?? false;
                mnuView.Enabled = access?.Contract.Contract_View ?? false;
                mnuChangeTemp.Enabled = access?.Contract.Contract_Finish ?? false;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        public frmShowContract(ContractFilter _filter)
        {
            InitializeComponent();
            ucHeader.Text = "نمایش لیست قراردادها";
            SetAccess();
            filter = _filter;
        }

        private async void frmShowContract_Load(object sender, EventArgs e) => await LoadDataAsync();
        private void DGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DGrid.Rows[e.RowIndex].Cells["dgRadif"].Value = e.RowIndex + 1;
        }
        private void txtSearch_TextChanged(object sender, EventArgs e) => Search(txtSearch.Text);
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
                var frm = new frmContractTypeSelector();
                if (frm.ShowDialog(this) == DialogResult.OK)
                    await LoadDataAsync(txtSearch.Text);
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
                var fSide = await PeoplesBussines.GetAsync(contract.FirstSideGuid, building.Guid);
                var sSide = await PeoplesBussines.GetAsync(contract.SecondSideGuid, building.Guid);
                var unitCity = await CitiesBussines.GetAsync(SettingsBussines.Setting.CompanyInfo.EconomyCity);
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
                        UnitAddress = SettingsBussines.Setting.CompanyInfo.ManagerAddress,
                        TotalEjare = (contract?.MinorPrice * contract?.Term) ?? 0,
                        MinorEjare = contract?.MinorPrice ?? 0,
                        Rahn = contract?.TotalPrice ?? 0,
                        CheckNo = contract?.CheckNo,
                        BankName = contract?.BankName,
                        Shobe = contract?.Shobe,
                        //Sarresid = contract?.SarResid,
                        UnitName = SettingsBussines.Setting.CompanyInfo.EconomyName,
                        DischargeDate = Calendar.MiladiToShamsi(contract?.DischargeDate),
                        BuildingAccountType = buildingAccountType?.Name,
                        Sarqofli = contract?.SarQofli ?? 0,
                        UnitCity = unitCity?.Name,
                        Commition = contract?.FirstTotalPrice ?? 0,
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
                        UnitAddress = SettingsBussines.Setting.CompanyInfo.ManagerAddress,
                        TotalPrice = contract?.TotalPrice ?? 0,
                        MinorPrice = (contract?.TotalPrice - contract?.MinorPrice) ?? 0,
                        Beyane = contract?.MinorPrice ?? 0,
                        CheckNo = contract?.CheckNo,
                        BankName = contract?.BankName,
                        Shobe = contract?.Shobe,
                        //Sarresid = contract?.SarResid,
                        UnitName = SettingsBussines.Setting.CompanyInfo.EconomyName,
                        DischargeDate = Calendar.MiladiToShamsi(contract?.DischargeDate),
                        BuildingAccountType = buildingAccountType?.Name,
                        UnitCity = unitCity?.Name,
                        Commition = contract?.FirstTotalPrice ?? 0,
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
                    this.ShowError(res, "خطا در بستن قولنامه");
                else await LoadDataAsync(txtSearch.Text);
            }
        }
        private async void mnuDelete_Click(object sender, EventArgs e)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                if (DGrid.RowCount <= 0) return;
                if (DGrid.CurrentRow == null) return;
                var guid = (Guid)DGrid[dgGuid.Index, DGrid.CurrentRow.Index].Value;
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

                res.AddReturnedValue(await prd.RemoveAsync());
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }
            finally
            {
                if (res.HasError)
                    this.ShowError(res, "خطا در حذف قولنامه");
                else await LoadDataAsync(txtSearch.Text);
            }
        }
        private async void mnuView_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGrid.RowCount <= 0) return;
                if (DGrid.CurrentRow == null) return;
                var guid = (Guid)DGrid[dgGuid.Index, DGrid.CurrentRow.Index].Value;
                var con = await ContractBussines.GetAsync(guid);
                if (con == null) return;
                Form frm_ = null;
                switch (con.Type)
                {
                    case EnRequestType.Forush:
                        frm_ = new frmContractMain_Sell(con, true);
                        break;
                    case EnRequestType.Rahn:
                        frm_ = new frmContractMain_Rahn(con, true);
                        break;
                    case EnRequestType.EjareTamlik:
                        frm_ = new frmContractMain_EjareTamlik(con, true);
                        break;
                    case EnRequestType.Sarqofli:
                        frm_ = new frmContractMain_Sarqofli(con, true);
                        break;
                    case EnRequestType.PishForush:
                        frm_ = new frmContractMain_PishForoush(con, true);
                        break;
                }

                frm_?.ShowDialog(this);
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
                if (DGrid.RowCount <= 0 || DGrid.CurrentRow == null) return;
                var guid = (Guid)DGrid[dgGuid.Index, DGrid.CurrentRow.Index].Value;
                var con = await ContractBussines.GetAsync(guid);
                if (con == null) return;
                if (!con.IsTemp)
                {
                    this.ShowWarning("قراداد جاری نهایی و بسته شده. در این حالت شما فقط مجاز به مشاهده آن می باشید");
                    Form frm_ = null;
                    switch (con.Type)
                    {
                        case EnRequestType.Forush:
                            frm_ = new frmContractMain_Sell(con, true);
                            break;
                        case EnRequestType.Rahn:
                            frm_ = new frmContractMain_Rahn(con, true);
                            break;
                        case EnRequestType.EjareTamlik:
                            frm_ = new frmContractMain_EjareTamlik(con, true);
                            break;
                        case EnRequestType.Sarqofli:
                            frm_ = new frmContractMain_Sarqofli(con, true);
                            break;
                        case EnRequestType.PishForush:
                            frm_ = new frmContractMain_PishForoush(con, true);
                            break;
                    }

                    frm_?.ShowDialog(this);
                    return;
                }

                Form frm = null;
                switch (con.Type)
                {
                    case EnRequestType.Forush:
                        frm = new frmContractMain_Sell(con);
                        break;
                    case EnRequestType.Rahn:
                        frm = new frmContractMain_Rahn(con);
                        break;
                    case EnRequestType.EjareTamlik:
                        frm = new frmContractMain_EjareTamlik(con);
                        break;
                    case EnRequestType.Sarqofli:
                        frm = new frmContractMain_Sarqofli(con);
                        break;
                    case EnRequestType.PishForush:
                        frm = new frmContractMain_PishForoush(con);
                        break;
                }
                if (frm?.ShowDialog(this) == DialogResult.OK)
                    await LoadDataAsync(txtSearch.Text);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async void mnuPrintFirstSide_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGrid.RowCount <= 0 || DGrid.CurrentRow == null) return;
                var guid = (Guid)DGrid[dgGuid.Index, DGrid.CurrentRow.Index].Value;
                var con = await ContractBussines.GetAsync(guid);
                if (con == null) return;
                var customer = await PeoplesBussines.GetAsync(con.FirstSideGuid, null);

                var view = new ContractOrderViewModel()
                {
                    Description = con.Description,
                    Code = con.Code,
                    Price = con.FirstTotalPrice,
                    DateSh = con.DateSh,
                    TotalSum = con.FirstSum - con.FirstDiscount,
                    Avarez = con.FirstAvarez,
                    CustomerAddress = customer.Address,
                    CustomerEconomyCode = customer.IdCode,
                    CustomerName = customer.Name,
                    CustomerNationalCode = customer.NationalCode,
                    CustomerTell = customer.TellList?.FirstOrDefault()?.Tell,
                    CustomerZip = customer.PostalCode,
                    Discount = con.FirstDiscount,
                    Tax = con.FirstTax,
                    SumAfterDiscount = con.FirstTotalPrice - con.FirstDiscount,
                    ServiceName = $"کمیسیون عقد قرارداد {con.Type.GetDisplay()}",
                    SellerAddress = SettingsBussines.Setting.CompanyInfo.ManagerAddress,
                    SellerName = SettingsBussines.Setting.CompanyInfo.ManagerName,
                    SellerNationalCode = SettingsBussines.Setting.SafeBox.NationalCode,
                    SellerTell = SettingsBussines.Setting.CompanyInfo.ManagerTell
                };
                if (!string.IsNullOrEmpty(SettingsBussines.Setting.SafeBox.EconomyCode))
                    view.SellerNationalCode += $" / {SettingsBussines.Setting.SafeBox.EconomyCode}";
                if (!string.IsNullOrEmpty(SettingsBussines.Setting.CompanyInfo.ManagerFax))
                    view.SellerTell += $" / {SettingsBussines.Setting.CompanyInfo.ManagerFax}";

                var lst = new List<object>() { view };
                var cls = new ReportGenerator(StiType.Contract_Rasmi_One, EnPrintType.Pdf_A4) { Lst = lst };
                cls.PrintNew();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async void mnuPrintSecondSide_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGrid.RowCount <= 0 || DGrid.CurrentRow == null) return;
                var guid = (Guid)DGrid[dgGuid.Index, DGrid.CurrentRow.Index].Value;
                var con = await ContractBussines.GetAsync(guid);
                if (con == null) return;
                var customer = await PeoplesBussines.GetAsync(con.SecondSideGuid, null);

                var view = new ContractOrderViewModel()
                {
                    Description = con.Description,
                    Code = con.Code,
                    Price = con.SecondTotalPrice,
                    DateSh = con.DateSh,
                    TotalSum = con.SecondSum - con.SecondDiscount,
                    Avarez = con.SecondAvarez,
                    CustomerAddress = customer.Address,
                    CustomerEconomyCode = customer.IdCode,
                    CustomerName = customer.Name,
                    CustomerNationalCode = customer.NationalCode,
                    CustomerTell = customer.TellList?.FirstOrDefault()?.Tell,
                    CustomerZip = customer.PostalCode,
                    Discount = con.SecondDiscount,
                    Tax = con.SecondTax,
                    SumAfterDiscount = con.SecondTotalPrice - con.SecondDiscount,
                    ServiceName = $"کمیسیون عقد قرارداد {con.Type.GetDisplay()}",
                    SellerAddress = SettingsBussines.Setting.CompanyInfo.ManagerAddress,
                    SellerName = SettingsBussines.Setting.CompanyInfo.ManagerName,
                    SellerNationalCode = SettingsBussines.Setting.SafeBox.NationalCode,
                    SellerTell = SettingsBussines.Setting.CompanyInfo.ManagerTell
                };
                if (!string.IsNullOrEmpty(SettingsBussines.Setting.SafeBox.EconomyCode))
                    view.SellerNationalCode += $" / {SettingsBussines.Setting.SafeBox.EconomyCode}";
                if (!string.IsNullOrEmpty(SettingsBussines.Setting.CompanyInfo.ManagerFax))
                    view.SellerTell += $" / {SettingsBussines.Setting.CompanyInfo.ManagerFax}";
                var lst = new List<object>() { view };
                var cls = new ReportGenerator(StiType.Contract_Rasmi_One, EnPrintType.Pdf_A4) { Lst = lst };
                cls.PrintNew();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
