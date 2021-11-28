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
                uc2.PhoneCount = bu?.PhoneLineCount??0;
                uc2.PhoneNumber = bu?.PhoneNumber;
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
        }

        private void Uc2OnOnBuildingSelect(Guid buGuid) => cls.BuildingGuid = buGuid;
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
