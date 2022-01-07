using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsSerivces;
using EntityCache.Bussines;
using MetroFramework.Forms;
using Services;

namespace Building.Contract
{
    public partial class frmContractMain_Sell : MetroForm
    {
        private ContractBussines cls;
        private bool _isShow = false;

        private async Task SetDataAsync()
        {
            try
            {
                ucContractHeader1.Title = "مـبــایـعـه نــامـه";
                ucContractHeader1.ContractCode = cls.Code;
                ucContractHeader1.CodeInArchive = cls.CodeInArchive;
                ucContractHeader1.RealStateCode = cls.RealStateCode;
                ucContractHeader1.HologramCode = cls.HologramCode;
                ucContractHeader1.ContractDate = cls.DateM;

                ucFSide.Guid = cls.FirstSideGuid;
                ucSecondSide.Guid = cls.SecondSideGuid;

                var bu = await BuildingBussines.GetAsync(cls.BuildingGuid);
                uc2.Dong = bu?.Dang ?? 6;
                uc2.BuildingType = bu?.BuildingTypeName;
                uc2.RegistryNo = cls.BuildingRegistrationNo;
                uc2.RegistryNoSub = cls.BuildingRegistrationNoSub;
                uc2.RegistryNoOrigin = cls.BuildingRegistrationNoOrigin;
                uc2.Masahat = bu?.Masahat ?? 0;
                uc2.ParkingNo = cls.ParkingNo;
                uc2.StoreNo = cls.StoreNo;
                uc2.StoreMasahat = cls.StoreMasahat;
                uc2.SanadSerial = cls.SanadSerial;
                uc2.Page = cls.Page;
                uc2.Office = cls.Office;
                uc2.BuildingNumber = cls.BuildingNumber;
                uc2.Water = bu?.Water ?? EnKhadamati.None;
                uc2.Barq = bu?.Barq ?? EnKhadamati.None;
                uc2.Gas = bu?.Gas ?? EnKhadamati.None;
                uc2.Address = bu?.Address;
                uc2.PhoneCount = cls.PhoneLineCount;
                uc2.PhoneNumber = cls.BuildingPhoneNumber;

                uc3.Price = cls.TotalPrice;
                uc3.Naqd = cls.MinorPrice;
                uc3.BankName1 = cls.BankName;
                uc3.BankName2 = cls.BankNameEjare;
                uc3.CheckNo1 = cls.CheckNo;
                uc3.CheckNo2 = cls.CheckNoTo;
                uc3.Sarresid1 = cls.SarResid;
                uc3.Sarresid2 = cls.SarResidTo;
                uc3.Shobe1 = cls.Shobe;
                uc3.Shobe2 = cls.ShobeEjare;
                uc3.CheckPrice1 = cls.CheckPrice1;
                uc3.CheckPrice2 = cls.CheckPrice2;

                ucContractSell_41.SetDocDate = cls.SetDocDate;
                ucContractSell_41.SetDocNo = cls.SetDocNo;
                ucContractSell_41.SetDocPlace = cls.SetDocPlace;
                ucContractSell_41.DischargeDate = cls.DischargeDate;

                ucContractSell_51.AmountOfRent = cls.AmountOfRent;

                ucContractSell_61.FirstDelay = cls.FirstSideDelay;
                ucContractSell_61.SecondDelay = cls.SecondSideDelay;

                ucContractDescription1.Description = cls.Description;
                ucContractDescription1.Witness1 = cls.Witness1;
                ucContractDescription1.Witness2 = cls.Witness2;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async Task GetDataAsync()
        {
            try
            {
                if (cls.Guid == Guid.Empty)
                {
                    cls.Guid = Guid.NewGuid();
                    cls.SanadNumber = await SanadBussines.NextNumberAsync();
                    cls.UserGuid = UserBussines.CurrentUser.Guid;
                    cls.Modified = DateTime.Now;
                    cls.IsTemp = true;
                }

                cls.Type = EnRequestType.Forush;
                cls.Code = ucContractHeader1.ContractCode;
                cls.CodeInArchive = ucContractHeader1.CodeInArchive;
                cls.RealStateCode = ucContractHeader1.RealStateCode;
                cls.HologramCode = ucContractHeader1.HologramCode;
                cls.DateM = ucContractHeader1.ContractDate;

                cls.FirstSideGuid = ucFSide.Guid;
                cls.SecondSideGuid = ucSecondSide.Guid;

                cls.BuildingRegistrationNo = uc2.RegistryNo;
                cls.BuildingRegistrationNoSub = uc2.RegistryNoSub;
                cls.BuildingRegistrationNoOrigin = uc2.RegistryNoOrigin;
                cls.ParkingNo = uc2.ParkingNo;
                cls.StoreNo = uc2.StoreNo;
                cls.StoreMasahat = uc2.StoreMasahat;
                cls.SanadSerial = uc2.SanadSerial;
                cls.Page = uc2.Page;
                cls.Office = uc2.Office;
                cls.BuildingNumber = uc2.BuildingNumber;
                cls.PhoneLineCount = uc2.PhoneCount;
                cls.BuildingPhoneNumber = uc2.PhoneNumber;

                cls.TotalPrice = uc3.Price;
                cls.MinorPrice = uc3.Naqd;
                cls.BankName = uc3.BankName1;
                cls.BankNameEjare = uc3.BankName2;
                cls.CheckNo = uc3.CheckNo1;
                cls.CheckNoTo = uc3.CheckNo2;
                cls.SarResid = uc3.Sarresid1;
                cls.SarResidTo = uc3.Sarresid2;
                cls.Shobe = uc3.Shobe1;
                cls.ShobeEjare = uc3.Shobe2;
                cls.CheckPrice1 = uc3.CheckPrice1;
                cls.CheckPrice2 = uc3.CheckPrice2;

                cls.SetDocDate = ucContractSell_41.SetDocDate;
                cls.SetDocNo = ucContractSell_41.SetDocNo;
                cls.SetDocPlace = ucContractSell_41.SetDocPlace;
                cls.DischargeDate = ucContractSell_41.DischargeDate ?? DateTime.Now.AddYears(1);

                cls.AmountOfRent = ucContractSell_51.AmountOfRent;

                cls.FirstSideDelay = ucContractSell_61.FirstDelay;
                cls.SecondSideDelay = ucContractSell_61.SecondDelay;

                cls.Description = ucContractDescription1.Description;
                cls.Witness1 = ucContractDescription1.Witness1;
                cls.Witness2 = ucContractDescription1.Witness2;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        public frmContractMain_Sell(ContractBussines _cls, bool isShowMode = false)
        {
            try
            {
                InitializeComponent();
                cls = _cls;
                _isShow = isShowMode;
                if (isShowMode)
                {
                    ucContractHeader1.Enabled = false;
                    ucFSide.Enabled = false;
                    ucSecondSide.Enabled = false;
                    uc2.Enabled = false;
                    uc3.Enabled = false;
                    ucContractSell_41.Enabled = false;
                    ucContractSell_51.Enabled = false;
                    ucContractSell_61.Enabled = false;
                    ucContractDescription1.Enabled = false;
                    ucContractSell_71.Enabled = false;
                    btnFinish.Enabled = false;
                }
                else
                {
                    uc2.OnBuildingSelect += Uc2OnOnBuildingSelect;
                    ucContractHeader1.OnDateChanged += UcContractHeader1_OnDateChanged;
                    ucContractSell_41.OnDischargeChanged += UcContractSell_41_OnDischargeChanged;
                    ucFSide.OnChanged += UcFSide_OnChanged;
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void UcFSide_OnChanged(Guid guid) => uc2.OwnerGuid = guid;
        private void UcContractSell_41_OnDischargeChanged(string date) => ucContractSell_51.DischargeDateSh = date;
        private void UcContractHeader1_OnDateChanged(string date) => ucContractSell_41.ContractDateSh = date;
        private void Uc2OnOnBuildingSelect(Guid buGuid)
        {
            try
            {
                cls.BuildingGuid = buGuid;
                var bu = BuildingBussines.Get(buGuid);
                uc3.Price = bu?.SellPrice ?? 0;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async void frmContractMain_Sell_Load(object sender, System.EventArgs e) => await SetDataAsync();
        private void frmContractMain_Sell_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                switch (e.KeyCode)
                {
                    case Keys.Escape: btnCancel.PerformClick(); break;
                    case Keys.F8: btnCommition.PerformClick(); break;
                    case Keys.F5: btnFinish.PerformClick(); break;
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
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
                btnFinish.Enabled = false;
                await GetDataAsync();
                res.AddReturnedValue(await cls.SaveAsync());
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }
            finally
            {
                btnFinish.Enabled = true;
                if (res.HasError) this.ShowError(res);
                else
                {
                    if (res.HasWarning) this.ShowError(res);
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
        }
        private async void buttonX1_Click(object sender, EventArgs e)
        {
            try
            {
                await GetDataAsync();
                var frm = new frmCommition(cls, _isShow);
                frm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
