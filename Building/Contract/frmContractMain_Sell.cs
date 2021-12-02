using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityCache.Bussines;
using MetroFramework.Forms;
using Services;

namespace Building.Contract
{
    public partial class frmContractMain_Sell : MetroForm
    {
        private ContractBussines cls;
        private async Task SetDataAsync()
        {
            try
            {
                ucContractHeader1.Title = "مبایعه نامه";
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
                uc2.PhoneCount = bu?.PhoneLineCount ?? 0;
                uc2.PhoneNumber = bu?.PhoneNumber;

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
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        public frmContractMain_Sell(ContractBussines _cls)
        {
            InitializeComponent();
            cls = _cls;
            uc2.OnBuildingSelect += Uc2OnOnBuildingSelect;
            ucContractHeader1.OnDateChanged += UcContractHeader1_OnDateChanged;
        }
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
                    case Keys.Escape:
                        DialogResult = DialogResult.Cancel;
                        Close();
                        break;
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
