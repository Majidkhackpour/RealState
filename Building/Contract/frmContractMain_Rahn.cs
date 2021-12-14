using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityCache.Bussines;
using MetroFramework.Forms;
using Services;

namespace Building.Contract
{
    public partial class frmContractMain_Rahn : MetroForm
    {
        private ContractBussines cls;

        private async Task SetDataAsync()
        {
            try
            {
                ucContractHeader1.Title = "اجــــــاره نــامـه";
                ucContractHeader1.ContractCode = cls.Code;
                ucContractHeader1.CodeInArchive = cls.CodeInArchive;
                ucContractHeader1.RealStateCode = cls.RealStateCode;
                ucContractHeader1.HologramCode = cls.HologramCode;
                ucContractHeader1.ContractDate = cls.DateM;

                ucFSide.Guid = cls.FirstSideGuid;
                ucSecondSide.Guid = cls.SecondSideGuid;

                var bu = await BuildingBussines.GetAsync(cls.BuildingGuid);
                ucContractRahn_21.Dong = bu?.Dang ?? 6;
                ucContractRahn_21.BuildingType = bu?.BuildingTypeName;
                ucContractRahn_21.RegistryNo = cls.BuildingRegistrationNo;
                ucContractRahn_21.RegistryNoSub = cls.BuildingRegistrationNoSub;
                ucContractRahn_21.RegistryNoOrigin = cls.BuildingRegistrationNoOrigin;
                ucContractRahn_21.Masahat = bu?.Masahat ?? 0;
                ucContractRahn_21.ParkingNo = cls.ParkingNo;
                ucContractRahn_21.StoreNo = cls.StoreNo;
                ucContractRahn_21.StoreMasahat = cls.StoreMasahat;
                ucContractRahn_21.SanadSerial = cls.SanadSerial;
                ucContractRahn_21.Page = cls.Page;
                ucContractRahn_21.Office = cls.Office;
                ucContractRahn_21.BuildingNumber = cls.BuildingNumber;
                ucContractRahn_21.Water = bu?.Water ?? EnKhadamati.None;
                ucContractRahn_21.Barq = bu?.Barq ?? EnKhadamati.None;
                ucContractRahn_21.Gas = bu?.Gas ?? EnKhadamati.None;
                ucContractRahn_21.Address = bu?.Address;
                ucContractRahn_21.BuildingPlack = cls.BuildingPlack;
                ucContractRahn_21.PhoneCount = cls.PhoneLineCount;
                ucContractRahn_21.PhoneNumber = cls.BuildingPhoneNumber;
                ucContractRahn_21.RoomCount = bu?.RoomCount ?? 0;

                ucContractRahn_31.DischargeDate = cls.DischargeDate;
                ucContractRahn_31.FromDate = cls.FromDate;
                ucContractRahn_31.Term = cls.Term ?? 12;

                ucContractRahn_41.BankName = cls.BankName;
                ucContractRahn_41.CheckNoFrom = cls.CheckNo;
                ucContractRahn_41.CheckNoTo = cls.CheckNoTo;
                ucContractRahn_41.Ejare = cls.MinorPrice;
                ucContractRahn_41.Rahn = cls.TotalPrice;
                ucContractRahn_41.SarresidFrom = cls.SarResid;
                ucContractRahn_41.SarresidTo = cls.SarResidTo;
                ucContractRahn_41.Shobe = cls.Shobe;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        public frmContractMain_Rahn(ContractBussines _cls, bool isShowMode = false)
        {
            try
            {
                InitializeComponent();
                cls = _cls;
                if (isShowMode)
                {
                    ucContractHeader1.Enabled = false;
                    ucFSide.Enabled = false;
                    ucSecondSide.Enabled = false;
                    ucContractRahn_21.Enabled = false;
                    ucContractRahn_31.Enabled = false;
                    ucContractRahn_41.Enabled = false;
                    //ucContractSell_51.Enabled = false;
                    //ucContractSell_61.Enabled = false;
                    //ucContractDescription1.Enabled = false;
                    //ucContractSell_71.Enabled = false;
                    btnFinish.Enabled = false;
                }
                else
                {
                    ucContractRahn_21.OnBuildingSelect += Uc2OnOnBuildingSelect;
                    ucContractHeader1.OnDateChanged += UcContractHeader1_OnDateChanged;
                    //ucContractSell_41.OnDischargeChanged += UcContractSell_41_OnDischargeChanged;
                    ucFSide.OnChanged += UcFSide_OnChanged;
                    ucContractRahn_31.OnTermChanged += UcContractRahn_31_OnTermChanged;
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void UcContractRahn_31_OnTermChanged(int term) => ucContractRahn_41.Term = term;
        private void UcContractHeader1_OnDateChanged(string date) => ucContractRahn_31.ContractDateSh = date;
        private void UcFSide_OnChanged(Guid guid) => ucContractRahn_21.OwnerGuid = guid;
        private void Uc2OnOnBuildingSelect(Guid buGuid)
        {
            try
            {
                cls.BuildingGuid = buGuid;
                var bu = BuildingBussines.Get(buGuid);
                ucContractRahn_41.Rahn = bu?.RahnPrice1 ?? 0;
                ucContractRahn_41.Ejare = bu?.EjarePrice1 ?? 0;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async void frmContractMain_Rahn_Load(object sender, EventArgs e) => await SetDataAsync();
        private void frmContractMain_Rahn_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
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
        private void btnFinish_Click(object sender, EventArgs e)
        {

        }
        private void buttonX1_Click(object sender, EventArgs e)
        {

        }
    }
}
