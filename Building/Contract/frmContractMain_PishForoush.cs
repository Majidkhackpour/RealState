using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsSerivces;
using EntityCache.Bussines;
using MetroFramework.Forms;
using Services;

namespace Building.Contract
{
    public partial class frmContractMain_PishForoush : MetroForm
    {
        private ContractBussines cls;

        private async Task SetDataAsync()
        {
            try
            {
                ucContractHeader1.Title = "پـــــیـــــش فـــــــــــروش";
                ucContractHeader1.ContractCode = cls.Code;
                ucContractHeader1.CodeInArchive = cls.CodeInArchive;
                ucContractHeader1.RealStateCode = cls.RealStateCode;
                ucContractHeader1.HologramCode = cls.HologramCode;
                ucContractHeader1.ContractDate = cls.DateM;

                ucFSide.Guid = cls.FirstSideGuid;
                ucFSide.Title = "مشخصات پیش فروشنده";
                ucSecondSide.Guid = cls.SecondSideGuid;
                ucSecondSide.Title = "مشخصات پیش خریدار";

                //var bu = await BuildingBussines.GetAsync(cls.BuildingGuid);
                //ucContractEjareTamlik_21.Dong = bu?.Dang ?? 6;
                //ucContractEjareTamlik_21.BuildingType = bu?.BuildingTypeName;
                //ucContractEjareTamlik_21.RegistryNo = cls.BuildingRegistrationNo;
                //ucContractEjareTamlik_21.RegistryNoSub = cls.BuildingRegistrationNoSub;
                //ucContractEjareTamlik_21.RegistryNoOrigin = cls.BuildingRegistrationNoOrigin;
                //ucContractEjareTamlik_21.ParkingNo = cls.ParkingNo;
                //ucContractEjareTamlik_21.StoreNo = cls.StoreNo;
                //ucContractEjareTamlik_21.StoreMasahat = cls.StoreMasahat;
                //ucContractEjareTamlik_21.ParkingMasahat = cls.ParkingMasahat;
                //ucContractEjareTamlik_21.SanadSerial = cls.SanadSerial;
                //ucContractEjareTamlik_21.Page = cls.Page;
                //ucContractEjareTamlik_21.Office = cls.Office;
                //ucContractEjareTamlik_21.Water = bu?.Water ?? EnKhadamati.None;
                //ucContractEjareTamlik_21.Barq = bu?.Barq ?? EnKhadamati.None;
                //ucContractEjareTamlik_21.Gas = bu?.Gas ?? EnKhadamati.None;
                //ucContractEjareTamlik_21.PhoneCount = cls.PhoneLineCount;
                //ucContractEjareTamlik_21.PhoneNumber = cls.BuildingPhoneNumber;
                //ucContractEjareTamlik_21.Masahat = bu?.Masahat ?? 0;
                //ucContractEjareTamlik_21.PartNo = cls.PartNo;
                //ucContractEjareTamlik_21.PayankarDate = cls.PayankarDate;
                //ucContractEjareTamlik_21.PayankarNo = cls.PayankarNo;

                //ucContractRahn_31.DischargeDate = cls.DischargeDate;
                //ucContractRahn_31.FromDate = cls.FromDate;
                //ucContractRahn_31.Term = cls.Term ?? 12;
                //ucContractRahn_31.ContractDateSh = cls.DateSh;

                //ucContractEjareTamlik_41.BankName = cls.BankName;
                //ucContractEjareTamlik_41.CheckNo = cls.CheckNo;
                //ucContractEjareTamlik_41.PishPrice = cls.PishPrice;
                //ucContractEjareTamlik_41.TotalEjare = cls.TotalPrice;
                //ucContractEjareTamlik_41.Shobe = cls.Shobe;

                //ucContractEjareTamlik_51.Delay = cls.FirstSideDelay;
                //ucContractEjareTamlik_51.DocumentAsjust = cls.DocumentAdjust;
                //ucContractEjareTamlik_51.SetDocDate = cls.SetDocDate;
                //ucContractEjareTamlik_51.SetDocNo = cls.SetDocNo;
                //ucContractEjareTamlik_51.SetDocPlace = cls.SetDocPlace;


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

                cls.Type = EnRequestType.EjareTamlik;
                cls.Code = ucContractHeader1.ContractCode;
                cls.CodeInArchive = ucContractHeader1.CodeInArchive;
                cls.RealStateCode = ucContractHeader1.RealStateCode;
                cls.HologramCode = ucContractHeader1.HologramCode;
                cls.DateM = ucContractHeader1.ContractDate;

                cls.FirstSideGuid = ucFSide.Guid;
                cls.SecondSideGuid = ucSecondSide.Guid;

                //cls.BuildingRegistrationNo = ucContractEjareTamlik_21.RegistryNo;
                //cls.BuildingRegistrationNoSub = ucContractEjareTamlik_21.RegistryNoSub;
                //cls.BuildingRegistrationNoOrigin = ucContractEjareTamlik_21.RegistryNoOrigin;
                //cls.ParkingNo = ucContractEjareTamlik_21.ParkingNo;
                //cls.StoreNo = ucContractEjareTamlik_21.StoreNo;
                //cls.StoreMasahat = ucContractEjareTamlik_21.StoreMasahat;
                //cls.ParkingMasahat = ucContractEjareTamlik_21.ParkingMasahat;
                //cls.SanadSerial = ucContractEjareTamlik_21.SanadSerial;
                //cls.Page = ucContractEjareTamlik_21.Page;
                //cls.Office = ucContractEjareTamlik_21.Office;
                //cls.PhoneLineCount = ucContractEjareTamlik_21.PhoneCount;
                //cls.BuildingPhoneNumber = ucContractEjareTamlik_21.PhoneNumber;
                //cls.PartNo = ucContractEjareTamlik_21.PartNo;
                //cls.PayankarDate = ucContractEjareTamlik_21.PayankarDate;
                //cls.PayankarNo = ucContractEjareTamlik_21.PayankarNo;

                //cls.DischargeDate = ucContractRahn_31.DischargeDate;
                //cls.FromDate = ucContractRahn_31.FromDate;
                //cls.Term = ucContractRahn_31.Term;

                //cls.BankName = ucContractEjareTamlik_41.BankName;
                //cls.CheckNo = ucContractEjareTamlik_41.CheckNo;
                //cls.PishPrice = ucContractEjareTamlik_41.PishPrice;
                //cls.Shobe = ucContractEjareTamlik_41.Shobe;
                //cls.TotalPrice = ucContractEjareTamlik_41.TotalEjare;

                //cls.FirstSideDelay = ucContractEjareTamlik_51.Delay;
                //cls.DocumentAdjust = ucContractEjareTamlik_51.DocumentAsjust;
                //cls.SetDocDate = ucContractEjareTamlik_51.SetDocDate;
                //cls.SetDocNo = ucContractEjareTamlik_51.SetDocNo;
                //cls.SetDocPlace = ucContractEjareTamlik_51.SetDocPlace;

                //cls.Description = ucContractDescription1.Description;
                //cls.Witness1 = ucContractDescription1.Witness1;
                //cls.Witness2 = ucContractDescription1.Witness2;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        public frmContractMain_PishForoush(ContractBussines _cls, bool isShowMode = false)
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
                    //ucContractEjareTamlik_21.Enabled = false;
                    //ucContractRahn_31.Enabled = false;
                    //ucContractEjareTamlik_41.Enabled = false;
                    //ucContractEjareTamlik_51.Enabled = false;
                    //ucContractEjareTamlik_61.Enabled = false;
                    //ucContractDescription1.Enabled = false;
                    //ucContractEjareTamlik_71.Enabled = false;
                    //btnFinish.Enabled = false;
                    //ucContractEjareTamlik_Notice1.Enabled = false;
                }
                else
                {
                    //ucContractEjareTamlik_21.OnBuildingSelect += Uc2OnOnBuildingSelect;
                    //ucContractHeader1.OnDateChanged += UcContractHeader1_OnDateChanged;
                    //ucFSide.OnChanged += UcFSide_OnChanged;
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private async void frmContractMain_PishForoush_Load(object sender, System.EventArgs e) => await SetDataAsync();
        private async void btnFinish_Click(object sender, System.EventArgs e)
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
        private async void buttonX1_Click(object sender, System.EventArgs e)
        {
            try
            {
                await GetDataAsync();
                var frm = new frmCommition(cls);
                frm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
        private void frmContractMain_PishForoush_KeyDown(object sender, KeyEventArgs e)
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
    }
}
