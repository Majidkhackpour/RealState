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
                //uc2.Dong = bu?.Dang ?? 6;
                //uc2.BuildingType = bu?.BuildingTypeName;
                //uc2.RegistryNo = cls.BuildingRegistrationNo;
                //uc2.RegistryNoSub = cls.BuildingRegistrationNoSub;
                //uc2.RegistryNoOrigin = cls.BuildingRegistrationNoOrigin;
                //uc2.Masahat = bu?.Masahat ?? 0;
                //uc2.ParkingNo = cls.ParkingNo;
                //uc2.StoreNo = cls.StoreNo;
                //uc2.StoreMasahat = cls.StoreMasahat;
                //uc2.SanadSerial = cls.SanadSerial;
                //uc2.Page = cls.Page;
                //uc2.Office = cls.Office;
                //uc2.BuildingNumber = cls.BuildingNumber;
                //uc2.Water = bu?.Water ?? EnKhadamati.None;
                //uc2.Barq = bu?.Barq ?? EnKhadamati.None;
                //uc2.Gas = bu?.Gas ?? EnKhadamati.None;
                //uc2.Address = bu?.Address;
                //uc2.PhoneCount = cls.PhoneLineCount;
                //uc2.PhoneNumber = cls.BuildingPhoneNumber;
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
                    //uc2.Enabled = false;
                    //uc3.Enabled = false;
                    //ucContractSell_41.Enabled = false;
                    //ucContractSell_51.Enabled = false;
                    //ucContractSell_61.Enabled = false;
                    //ucContractDescription1.Enabled = false;
                    //ucContractSell_71.Enabled = false;
                    btnFinish.Enabled = false;
                }
                else
                {
                    //uc2.OnBuildingSelect += Uc2OnOnBuildingSelect;
                    //ucContractHeader1.OnDateChanged += UcContractHeader1_OnDateChanged;
                    //ucContractSell_41.OnDischargeChanged += UcContractSell_41_OnDischargeChanged;
                    //ucFSide.OnChanged += UcFSide_OnChanged;
                }
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
