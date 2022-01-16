using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsSerivces;
using Building.UserControls.Contract.PishForoush;
using EntityCache.Bussines;
using MetroFramework.Forms;
using Services;

namespace Building.Contract
{
    public partial class frmContractMain_PishForoush : MetroForm
    {
        private ContractBussines cls;
        private bool _isShow = false;

        private async Task SetDataAsync()
        {
            try
            {
                ucContractHeader1.Title = "پـــــیـــــش فـــــــــــروش";
                await ucContractHeader1.SetContractCode(cls.Code);
                ucContractHeader1.CodeInArchive = cls.CodeInArchive;
                ucContractHeader1.RealStateCode = cls.RealStateCode;
                ucContractHeader1.HologramCode = cls.HologramCode;
                ucContractHeader1.ContractDate = cls.DateM;

                await ucFSide.SetGuidAsync(cls.FirstSideGuid);
                ucFSide.Title = "مشخصات پیش فروشنده";
                await ucSecondSide.SetGuidAsync(cls.SecondSideGuid);
                ucSecondSide.Title = "مشخصات پیش خریدار";

                var bu = await BuildingBussines.GetAsync(cls.BuildingGuid);
                ucContractPishForoush_31.Dong = bu?.Dang ?? 6;
                ucContractPishForoush_31.Masahat = bu?.Masahat ?? 0;
                ucContractPishForoush_31.RoomCount = bu?.RoomCount ?? 0;
                ucContractPishForoush_31.TabaqeNo = bu?.TabaqeNo ?? 0;
                ucContractPishForoush_31.TabaqeCount = bu?.TedadTabaqe ?? 0;
                ucContractPishForoush_31.VahedNo = bu?.VahedNo ?? 0;
                ucContractPishForoush_31.VahedCount = bu?.VahedPerTabaqe ?? 0;
                ucContractPishForoush_31.Side = bu?.Side;
                await ucContractPishForoush_31.SetBuildingAccountTypeGuidAsync(bu?.BuildingAccountTypeGuid ?? Guid.Empty);
                await ucContractPishForoush_31.SetBuildingViewGuidAsync(bu?.BuildingViewGuid);
                ucContractPishForoush_31.Consumable = cls.BuildingCosumable;
                await ucContractPishForoush_31.SetHittingAsync(bu?.Hiting);
                await ucContractPishForoush_31.SetCollingAsync(bu?.Colling);

                ucContractPishForoush_41.TotalPrice = cls.TotalPrice;
                ucContractPishForoush_41.NaqdPrice = cls.MinorPrice;

                ucContractPishForoush_51.DischargeDate = cls.DischargeDate;
                ucContractPishForoush_51.SetDocDate = cls.SetDocDate;
                ucContractPishForoush_51.SetDocNo = cls.SetDocNo;
                ucContractPishForoush_51.SetDocPlace = cls.SetDocPlace;

                ucContractPishForoush_61.FirstDelay = cls.FirstSideDelay;
                ucContractPishForoush_61.ManufacturingLicenseDate = cls.ManufacturingLicenseDate;
                ucContractPishForoush_61.ManufacturingLicensePlace = cls.ManufacturingLicensePlace;
                ucContractPishForoush_61.SecondDelay = cls.SecondSideDelay;

                ucContractPishForoush_81.DocumentAdjustment = cls.DocumentAdjust;

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

                cls.Type = EnRequestType.PishForush;
                cls.Code = ucContractHeader1.ContractCode;
                cls.CodeInArchive = ucContractHeader1.CodeInArchive;
                cls.RealStateCode = ucContractHeader1.RealStateCode;
                cls.HologramCode = ucContractHeader1.HologramCode;
                cls.DateM = ucContractHeader1.ContractDate;

                cls.FirstSideGuid = ucFSide.Guid;
                cls.SecondSideGuid = ucSecondSide.Guid;


                cls.BuildingCosumable = ucContractPishForoush_31.Consumable;

                cls.TotalPrice = ucContractPishForoush_41.TotalPrice;
                cls.MinorPrice = ucContractPishForoush_41.NaqdPrice;

                cls.DischargeDate = ucContractPishForoush_51.DischargeDate;
                cls.SetDocDate = ucContractPishForoush_51.SetDocDate;
                cls.SetDocNo = ucContractPishForoush_51.SetDocNo;
                cls.SetDocPlace = ucContractPishForoush_51.SetDocPlace;

                cls.FirstSideDelay = ucContractPishForoush_61.FirstDelay;
                cls.ManufacturingLicenseDate = ucContractPishForoush_61.ManufacturingLicenseDate;
                cls.ManufacturingLicensePlace = ucContractPishForoush_61.ManufacturingLicensePlace;
                cls.SecondSideDelay = ucContractPishForoush_61.SecondDelay;

                cls.DocumentAdjust = ucContractPishForoush_81.DocumentAdjustment;

                cls.Description = ucContractDescription1.Description;
                cls.Witness1 = ucContractDescription1.Witness1;
                cls.Witness2 = ucContractDescription1.Witness2;
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
                _isShow = isShowMode;
                if (isShowMode)
                {
                    ucContractHeader1.Enabled = false;
                    ucFSide.Enabled = false;
                    ucSecondSide.Enabled = false;
                    ucContractPishForoush_21.Enabled = false;
                    ucContractPishForoush_31.Enabled = false;
                    ucContractPishForoush_41.Enabled = false;
                    ucContractPishForoush_51.Enabled = false;
                    ucContractPishForoush_61.Enabled = false;
                    ucContractDescription1.Enabled = false;
                    ucContractPishForoush_71.Enabled = false;
                    btnFinish.Enabled = false;
                    ucContractPishForoush_81.Enabled = false;
                    ucContractPishForoush_91.Enabled = false;
                    ucContractPishForoush_101.Enabled = false;
                    ucContractPishForoush_111.Enabled = false;
                    ucContractPishForoush_Notice1.Enabled = false;
                }
                else
                {
                    ucContractPishForoush_31.OnBuildingSelect += Uc2OnOnBuildingSelect;
                    ucFSide.OnChanged += UcFSide_OnChanged;
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void UcFSide_OnChanged(Guid guid) => ucContractPishForoush_31.OwnerGuid = guid;
        private async Task Uc2OnOnBuildingSelect(Guid buGuid)
        {
            try
            {
                cls.BuildingGuid = buGuid;
                var bu = await BuildingBussines.GetAsync(buGuid);
                ucContractPishForoush_41.TotalPrice = bu?.PishPrice ?? 0;
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
