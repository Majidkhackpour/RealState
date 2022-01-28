using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsSerivces;
using EntityCache.Bussines;
using EntityCache.Bussines.ReportBussines;
using MetroFramework.Forms;
using Services;

namespace Building.Contract
{
    public partial class frmContractMain_Sarqofli : MetroForm
    {
        private ContractBussines cls;
        private bool _isShow = false;

        private async Task SetDataAsync()
        {
            try
            {
                ucContractHeader1.Title = "انتــــــقـــــــال ســــرقــــفـــــلــــی";
                await ucContractHeader1.SetContractCode(cls.Code);
                ucContractHeader1.CodeInArchive = cls.CodeInArchive;
                ucContractHeader1.RealStateCode = cls.RealStateCode;
                ucContractHeader1.HologramCode = cls.HologramCode;
                ucContractHeader1.ContractDate = cls.DateM;

                await ucFSide.SetGuidAsync(cls.FirstSideGuid);
                ucFSide.Title = "مشخصات انتقال دهنده";
                await ucSecondSide.SetGuidAsync(cls.SecondSideGuid);
                ucSecondSide.Title = "مشخصات انتقال گیرنده";

                var bu = await BuildingReportBussines.GetAsync(cls.BuildingGuid);
                ucContractSarqofli_21.BuildingType = bu?.BuildingTypeName;
                ucContractSarqofli_21.RegistryNo = cls?.BuildingRegistrationNo;
                ucContractSarqofli_21.RegistryNoSub = cls.BuildingRegistrationNoSub;
                ucContractSarqofli_21.RegistryNoOrigin = cls?.BuildingRegistrationNoOrigin;
                ucContractSarqofli_21.Masahat = bu?.Masahat ?? 0;
                ucContractSarqofli_21.PartNo = cls?.PartNo ?? 0;
                ucContractSarqofli_21.SanadSerial = cls?.SanadSerial;
                ucContractSarqofli_21.Page = cls?.Page ?? 0;
                ucContractSarqofli_21.Office = cls?.Office;
                ucContractSarqofli_21.PayankarNo = cls?.PayankarNo;
                ucContractSarqofli_21.PayankarDate = cls?.PayankarDate;
                ucContractSarqofli_21.Water = bu?.Water ?? EnKhadamati.None;
                ucContractSarqofli_21.Barq = bu?.Barq ?? EnKhadamati.None;
                ucContractSarqofli_21.Gas = bu?.Gas ?? EnKhadamati.None;
                ucContractSarqofli_21.ParkingNo = cls?.ParkingNo ?? 0;
                ucContractSarqofli_21.ParkingMasahat = cls?.ParkingMasahat ?? 0;
                ucContractSarqofli_21.StoreNo = cls?.StoreNo ?? 0;
                ucContractSarqofli_21.StoreMasahat = cls?.StoreMasahat ?? 0;
                ucContractSarqofli_21.PhoneCount = cls?.PhoneLineCount ?? 0;
                ucContractSarqofli_21.PhoneNumber = cls?.BuildingPhoneNumber;

                ucContractSarqofli_31.Price = cls?.TotalPrice ?? 0;
                ucContractSarqofli_31.Naqd = cls?.MinorPrice ?? 0;
                ucContractSarqofli_31.CheckPrice = cls?.CheckPrice1 ?? 0;
                ucContractSarqofli_31.BankName = cls?.BankName;
                ucContractSarqofli_31.CheckNo = cls?.CheckNo;
                ucContractSarqofli_31.Shobe = cls?.Shobe;
                ucContractSarqofli_31.Sarresid = cls?.SarResid;

                ucContractSarqofli_41.SetDocDate = cls?.SetDocDate;
                ucContractSarqofli_41.SetDocNo = cls?.SetDocNo ?? 0;
                ucContractSarqofli_41.SetDocPlace = cls?.SetDocPlace;

                ucContractSarqofli_51.DischargeDate = cls?.DischargeDate;
                ucContractSarqofli_51.Delay = cls?.FirstSideDelay ?? 0;

                ucContractSarqofli_61.AmountOfRent = cls?.AmountOfRent ?? 0;
                ucContractSarqofli_61.GulidType = cls?.GulidType;

                ucContractSarqofli_111.TaxPercent = SettingsBussines.Setting.SafeBox.ArzeshAfzoude;

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

                cls.Type = EnRequestType.Sarqofli;
                cls.Code = ucContractHeader1.ContractCode;
                cls.CodeInArchive = ucContractHeader1.CodeInArchive;
                cls.RealStateCode = ucContractHeader1.RealStateCode;
                cls.HologramCode = ucContractHeader1.HologramCode;
                cls.DateM = ucContractHeader1.ContractDate;

                cls.FirstSideGuid = ucFSide.Guid;
                cls.SecondSideGuid = ucSecondSide.Guid;

                cls.BuildingRegistrationNo = ucContractSarqofli_21.RegistryNo;
                cls.BuildingRegistrationNoSub = ucContractSarqofli_21.RegistryNoSub;
                cls.BuildingRegistrationNoOrigin = ucContractSarqofli_21.RegistryNoOrigin;
                cls.PartNo = ucContractSarqofli_21.PartNo;
                cls.SanadSerial = ucContractSarqofli_21.SanadSerial;
                cls.Page = ucContractSarqofli_21.Page;
                cls.Office = ucContractSarqofli_21.Office;
                cls.PayankarNo = ucContractSarqofli_21.PayankarNo;
                cls.PayankarDate = ucContractSarqofli_21.PayankarDate;
                cls.ParkingNo = ucContractSarqofli_21.ParkingNo;
                cls.ParkingMasahat = ucContractSarqofli_21.ParkingMasahat;
                cls.StoreNo = ucContractSarqofli_21.StoreNo;
                cls.StoreMasahat = ucContractSarqofli_21.StoreMasahat;
                cls.PhoneLineCount = ucContractSarqofli_21.PhoneCount;
                cls.BuildingPhoneNumber = ucContractSarqofli_21.PhoneNumber;

                cls.TotalPrice = ucContractSarqofli_31.Price;
                cls.MinorPrice = ucContractSarqofli_31.Naqd;
                cls.CheckPrice1 = ucContractSarqofli_31.CheckPrice;
                cls.BankName = ucContractSarqofli_31.BankName;
                cls.CheckNo = ucContractSarqofli_31.CheckNo;
                cls.Shobe = ucContractSarqofli_31.Shobe;
                cls.SarResid = ucContractSarqofli_31.Sarresid;

                cls.SetDocDate = ucContractSarqofli_41.SetDocDate;
                cls.SetDocNo = ucContractSarqofli_41.SetDocNo;
                cls.SetDocPlace = ucContractSarqofli_41.SetDocPlace;

                cls.DischargeDate = ucContractSarqofli_51.DischargeDate;
                cls.FirstSideDelay = ucContractSarqofli_51.Delay;

                cls.AmountOfRent = ucContractSarqofli_61.AmountOfRent;
                cls.GulidType = ucContractSarqofli_61.GulidType;

                cls.Description = ucContractDescription1.Description;
                cls.Witness1 = ucContractDescription1.Witness1;
                cls.Witness2 = ucContractDescription1.Witness2;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        public frmContractMain_Sarqofli(ContractBussines _cls, bool isShowMode = false)
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
                    ucContractSarqofli_21.Enabled = false;
                    ucContractSarqofli_31.Enabled = false;
                    ucContractSarqofli_41.Enabled = false;
                    ucContractSarqofli_51.Enabled = false;
                    ucContractSarqofli_61.Enabled = false;
                    ucContractSarqofli_71.Enabled = false;
                    ucContractSarqofli_81.Enabled = false;
                    ucContractSarqofli_91.Enabled = false;
                    ucContractSarqofli_101.Enabled = false;
                    ucContractDescription1.Enabled = false;
                    ucContractSarqofli_111.Enabled = false;
                    btnFinish.Enabled = false;
                    ucContractSarqofli_Notice1.Enabled = false;
                }
                else
                {
                    ucContractSarqofli_21.OnBuildingSelect += Uc2OnOnBuildingSelect;
                    ucFSide.OnChanged += UcFSide_OnChanged;
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private async Task Uc2OnOnBuildingSelect(Guid buGuid)
        {
            try
            {
                cls.BuildingGuid = buGuid;
                var bu = await BuildingBussines.GetAsync(buGuid);
                ucContractSarqofli_31.Price = bu?.SellPrice ?? 0;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void UcFSide_OnChanged(Guid guid) => ucContractSarqofli_21.OwnerGuid = guid;
        private async void frmContractMain_Sarqofli_Load(object sender, System.EventArgs e) => await SetDataAsync();
        private void frmContractMain_Sarqofli_KeyDown(object sender, KeyEventArgs e)
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
        private async void btnCommition_Click(object sender, System.EventArgs e)
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
        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
