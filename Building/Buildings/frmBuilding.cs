using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsSerivces;
using Building.BuildingMatchesItem;
using Building.UserControls.Other;
using Building.UserControls.Rahn;
using Building.UserControls.Sell;
using EntityCache.Bussines;
using EntityCache.ViewModels;
using MetroFramework.Forms;
using Notification;
using Services;

namespace Building.Buildings
{
    public partial class frmBuilding : MetroForm
    {
        private BuildingBussines cls;
        private clsBuildingColtrols uc;
        private bool isSendSms = false;
        private CancellationTokenSource _token = new CancellationTokenSource();


        private async Task SetDataAsync()
        {
            try
            {
                Width = 930;
                Height = Screen.FromControl(this).Bounds.Height - 80;
                if (cls.Parent != null)
                {
                    var val = cls.Parent.Value;
                    lblTitle.Text = val.GetDisplay();
                }

                UcPeople.Guid = cls.OwnerGuid;

                var city = await CitiesBussines.GetAsync(cls.CityGuid);
                if (city != null)
                    UcCity.StateGuid = city.StateGuid;
                UcCity.CityGuid = cls.CityGuid;
                UcCity.RegionGuid = cls.RegionGuid;
                UcCity.Address = cls.Address;

                UcCode.Code = cls.Code;
                UcCode.CreateDate = cls.CreateDate;
                UcCode.Pirority = cls.Priority;
                UcCode.UserGuid = cls.UserGuid;

                UcHitting_Colling.Barq = cls.Barq;
                UcHitting_Colling.Water = cls.Water;
                UcHitting_Colling.Gas = cls.Gas;
                UcHitting_Colling.Tell = cls.Tell;
                UcHitting_Colling.Hitting = cls.Hiting;
                UcHitting_Colling.Colling = cls.Colling;

                UcOptions.OptionList = cls.OptionList;
                txtShortDesc.Text = cls.ShortDesc;
                ucBuildingHitting1.GalleryList = cls.GalleryList;
                groupPanel3.MediaList = cls.MediaList;

                GetContent();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void GetContent()
        {
            try
            {
                switch (cls.Parent)
                {
                    case EnBuildingParent.SellAprtment:
                        uc = new UcBuildingSell_Appartment() { Building = cls };
                        break;
                    case EnBuildingParent.SellHome:
                        uc = new UcBuildingSell_Home() { Building = cls };
                        break;
                    case EnBuildingParent.SellLand:
                        uc = new UcBuildingSell_Land() { Building = cls };
                        break;
                    case EnBuildingParent.SellVilla:
                        uc = new UcBuildingSell_Villa() { Building = cls };
                        break;
                    case EnBuildingParent.SellStore:
                        uc = new UcBuildingSell_Store() { Building = cls };
                        break;
                    case EnBuildingParent.SellOffice:
                        uc = new UcBuildingSell_Office() { Building = cls };
                        break;
                    case EnBuildingParent.SellGarden:
                        uc = new UcBuildingSell_Garden() { Building = cls };
                        break;
                    case EnBuildingParent.SellOldHouse:
                        uc = new UcBuildingSell_OldHouse() { Building = cls };
                        break;
                    case EnBuildingParent.RentAprtment:
                        uc = new UcBuildingRahn_Appartment() { IsFullRahn = false, Building = cls };
                        break;
                    case EnBuildingParent.RentHome:
                        uc = new UcBuildingRahn_Home() { IsFullRahn = false, Building = cls };
                        break;
                    case EnBuildingParent.RentStore:
                        uc = new UcBuildingRahn_Store() { IsFullRahn = false, Building = cls };
                        break;
                    case EnBuildingParent.RentOffice:
                        uc = new UcBuildingRahn_Office() { IsFullRahn = false, Building = cls };
                        break;
                    case EnBuildingParent.FullRentAprtment:
                        uc = new UcBuildingRahn_Appartment() { IsFullRahn = true, Building = cls };
                        break;
                    case EnBuildingParent.FullRentHome:
                        uc = new UcBuildingRahn_Home() { IsFullRahn = true, Building = cls };
                        break;
                    case EnBuildingParent.FullRentStore:
                        uc = new UcBuildingRahn_Store() { IsFullRahn = true, Building = cls };
                        break;
                    case EnBuildingParent.FullRentOffice:
                        uc = new UcBuildingRahn_Office() { IsFullRahn = true, Building = cls };
                        break;
                    case EnBuildingParent.PreSellAprtment:
                        uc = new UcBuildingOther_Appartment() { IsPishForoush = true, Building = cls };
                        break;
                    case EnBuildingParent.PreSellHome:
                        uc = new UcBuildingOther_Home() { IsPishForoush = true, Building = cls };
                        break;
                    case EnBuildingParent.PreSellStore:
                        uc = new UcBuildingOther_Store() { IsPishForoush = true, Building = cls };
                        break;
                    case EnBuildingParent.PreSellOffice:
                        uc = new UcBuildingOther_Office() { IsPishForoush = true, Building = cls };
                        break;
                    case EnBuildingParent.MoavezeAprtment:
                        uc = new UcBuildingOther_Appartment() { IsPishForoush = false, Building = cls };
                        break;
                    case EnBuildingParent.MoavezeHome:
                        uc = new UcBuildingOther_Home() { IsPishForoush = false, Building = cls };
                        break;
                    case EnBuildingParent.MoavezeStore:
                        uc = new UcBuildingOther_Store() { IsPishForoush = false, Building = cls };
                        break;
                    case EnBuildingParent.MoavezeOffice:
                        uc = new UcBuildingOther_Office() { IsPishForoush = true, Building = cls };
                        break;
                    case EnBuildingParent.MosharekatAprtment:
                        uc = new UcBuildingOther_Appartment() { IsPishForoush = false, Building = cls };
                        break;
                    case EnBuildingParent.MosharekatHome:
                        uc = new UcBuildingOther_Home() { IsPishForoush = false, Building = cls };
                        break;
                }

                if (uc != null) LoadContent();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void LoadContent()
        {
            try
            {
                pnlContent.AutoScroll = true;
                for (var i = pnlContent.Controls.Count - 1; i >= 0; i--)
                    pnlContent.Controls[i].Dispose();

                Controls.Add(uc);
                uc.Dock = DockStyle.Fill;
                pnlContent.Controls.Add(uc);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async Task SetType_AccTypeAsync()
        {
            try
            {
                switch (cls.Parent)
                {
                    case EnBuildingParent.SellAprtment:
                        cls.BuildingAccountTypeGuid = await BuildingAccountTypeBussines.GetDefultGuidAsync("آپارتمان");
                        cls.BuildingTypeGuid = await BuildingTypeBussines.GetDefultGuidAsync("مسکونی");
                        break;
                    case EnBuildingParent.SellHome:
                        cls.BuildingAccountTypeGuid = await BuildingAccountTypeBussines.GetDefultGuidAsync("منزل مسکونی");
                        cls.BuildingTypeGuid = await BuildingTypeBussines.GetDefultGuidAsync("مسکونی");
                        break;
                    case EnBuildingParent.SellLand:
                        cls.BuildingAccountTypeGuid = await BuildingAccountTypeBussines.GetDefultGuidAsync("مسکونی");
                        cls.BuildingTypeGuid = await BuildingTypeBussines.GetDefultGuidAsync("زمین مسکونی");
                        break;
                    case EnBuildingParent.SellVilla:
                        cls.BuildingAccountTypeGuid = await BuildingAccountTypeBussines.GetDefultGuidAsync("مسکونی");
                        cls.BuildingTypeGuid = await BuildingTypeBussines.GetDefultGuidAsync("ویلا");
                        break;
                    case EnBuildingParent.SellStore:
                        cls.BuildingAccountTypeGuid = await BuildingAccountTypeBussines.GetDefultGuidAsync("مشاغل تجاری");
                        cls.BuildingTypeGuid = await BuildingTypeBussines.GetDefultGuidAsync("واحد تجاری");
                        break;
                    case EnBuildingParent.SellOffice:
                        cls.BuildingAccountTypeGuid = await BuildingAccountTypeBussines.GetDefultGuidAsync("دفترکار");
                        cls.BuildingTypeGuid = await BuildingTypeBussines.GetDefultGuidAsync("واحد اداری");
                        break;
                    case EnBuildingParent.SellGarden:
                        cls.BuildingAccountTypeGuid = await BuildingAccountTypeBussines.GetDefultGuidAsync("زراعی");
                        cls.BuildingTypeGuid = await BuildingTypeBussines.GetDefultGuidAsync("باغ");
                        break;
                    case EnBuildingParent.SellOldHouse:
                        cls.BuildingAccountTypeGuid = await BuildingAccountTypeBussines.GetDefultGuidAsync("");
                        cls.BuildingTypeGuid = await BuildingTypeBussines.GetDefultGuidAsync("زمین و کلنگی");
                        break;
                    case EnBuildingParent.RentAprtment:
                        cls.BuildingAccountTypeGuid = await BuildingAccountTypeBussines.GetDefultGuidAsync("آپارتمان");
                        cls.BuildingTypeGuid = await BuildingTypeBussines.GetDefultGuidAsync("مسکونی");
                        break;
                    case EnBuildingParent.RentHome:
                        cls.BuildingAccountTypeGuid = await BuildingAccountTypeBussines.GetDefultGuidAsync("منزل مسکونی");
                        cls.BuildingTypeGuid = await BuildingTypeBussines.GetDefultGuidAsync("مسکونی");
                        break;
                    case EnBuildingParent.RentStore:
                        cls.BuildingAccountTypeGuid = await BuildingAccountTypeBussines.GetDefultGuidAsync("مشاغل تجاری");
                        cls.BuildingTypeGuid = await BuildingTypeBussines.GetDefultGuidAsync("واحد تجاری");
                        break;
                    case EnBuildingParent.RentOffice:
                        cls.BuildingAccountTypeGuid = await BuildingAccountTypeBussines.GetDefultGuidAsync("دفترکار");
                        cls.BuildingTypeGuid = await BuildingTypeBussines.GetDefultGuidAsync("واحد اداری");
                        break;
                    case EnBuildingParent.FullRentAprtment:
                        cls.BuildingAccountTypeGuid = await BuildingAccountTypeBussines.GetDefultGuidAsync("آپارتمان");
                        cls.BuildingTypeGuid = await BuildingTypeBussines.GetDefultGuidAsync("مسکونی");
                        break;
                    case EnBuildingParent.FullRentHome:
                        cls.BuildingAccountTypeGuid = await BuildingAccountTypeBussines.GetDefultGuidAsync("منزل مسکونی");
                        cls.BuildingTypeGuid = await BuildingTypeBussines.GetDefultGuidAsync("مسکونی");
                        break;
                    case EnBuildingParent.FullRentStore:
                        cls.BuildingAccountTypeGuid = await BuildingAccountTypeBussines.GetDefultGuidAsync("مشاغل تجاری");
                        cls.BuildingTypeGuid = await BuildingTypeBussines.GetDefultGuidAsync("واحد تجاری");
                        break;
                    case EnBuildingParent.FullRentOffice:
                        cls.BuildingAccountTypeGuid = await BuildingAccountTypeBussines.GetDefultGuidAsync("دفترکار");
                        cls.BuildingTypeGuid = await BuildingTypeBussines.GetDefultGuidAsync("واحد اداری");
                        break;
                    case EnBuildingParent.PreSellAprtment:
                        cls.BuildingAccountTypeGuid = await BuildingAccountTypeBussines.GetDefultGuidAsync("آپارتمان");
                        cls.BuildingTypeGuid = await BuildingTypeBussines.GetDefultGuidAsync("مسکونی");
                        break;
                    case EnBuildingParent.PreSellHome:
                        cls.BuildingAccountTypeGuid = await BuildingAccountTypeBussines.GetDefultGuidAsync("منزل مسکونی");
                        cls.BuildingTypeGuid = await BuildingTypeBussines.GetDefultGuidAsync("مسکونی");
                        break;
                    case EnBuildingParent.PreSellStore:
                        cls.BuildingAccountTypeGuid = await BuildingAccountTypeBussines.GetDefultGuidAsync("مشاغل تجاری");
                        cls.BuildingTypeGuid = await BuildingTypeBussines.GetDefultGuidAsync("واحد تجاری");
                        break;
                    case EnBuildingParent.PreSellOffice:
                        cls.BuildingAccountTypeGuid = await BuildingAccountTypeBussines.GetDefultGuidAsync("دفترکار");
                        cls.BuildingTypeGuid = await BuildingTypeBussines.GetDefultGuidAsync("واحد اداری");
                        break;
                    case EnBuildingParent.MoavezeAprtment:
                        cls.BuildingAccountTypeGuid = await BuildingAccountTypeBussines.GetDefultGuidAsync("آپارتمان");
                        cls.BuildingTypeGuid = await BuildingTypeBussines.GetDefultGuidAsync("مسکونی");
                        break;
                    case EnBuildingParent.MoavezeHome:
                        cls.BuildingAccountTypeGuid = await BuildingAccountTypeBussines.GetDefultGuidAsync("منزل مسکونی");
                        cls.BuildingTypeGuid = await BuildingTypeBussines.GetDefultGuidAsync("مسکونی");
                        break;
                    case EnBuildingParent.MoavezeStore:
                        cls.BuildingAccountTypeGuid = await BuildingAccountTypeBussines.GetDefultGuidAsync("مشاغل تجاری");
                        cls.BuildingTypeGuid = await BuildingTypeBussines.GetDefultGuidAsync("واحد تجاری");
                        break;
                    case EnBuildingParent.MoavezeOffice:
                        cls.BuildingAccountTypeGuid = await BuildingAccountTypeBussines.GetDefultGuidAsync("دفترکار");
                        cls.BuildingTypeGuid = await BuildingTypeBussines.GetDefultGuidAsync("واحد اداری");
                        break;
                    case EnBuildingParent.MosharekatAprtment:
                        cls.BuildingAccountTypeGuid = await BuildingAccountTypeBussines.GetDefultGuidAsync("آپارتمان");
                        cls.BuildingTypeGuid = await BuildingTypeBussines.GetDefultGuidAsync("مسکونی");
                        break;
                    case EnBuildingParent.MosharekatHome:
                        cls.BuildingAccountTypeGuid = await BuildingAccountTypeBussines.GetDefultGuidAsync("منزل مسکونی");
                        cls.BuildingTypeGuid = await BuildingTypeBussines.GetDefultGuidAsync("مسکونی");
                        break;
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        public frmBuilding(BuildingBussines bu)
        {
            InitializeComponent();
            cls = bu;
        }

        private async void frmBuilding_Load(object sender, EventArgs e) => await SetDataAsync();
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
        private void frmBuilding_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                switch (e.KeyCode)
                {
                    case Keys.Enter:
                        if (!btnFinish.Focused && !btnCancel.Focused && !txtShortDesc.Focused)
                            SendKeys.Send("{Tab}");
                        break;
                    case Keys.F5:
                        btnFinish.PerformClick();
                        break;
                    case Keys.Escape:
                        btnCancel.PerformClick();
                        break;
                        //case Keys.F8:
                        //    if (_orGpicBox != null)
                        //    {
                        //        ShowBigSizePic(_orGpicBox);
                        //        _fakepicBox = _orGpicBox;
                        //        _orGpicBox = null;
                        //    }
                        //    else
                        //    {
                        //        ShowNormalSizePic(_fakepicBox);
                        //        _orGpicBox = _fakepicBox;
                        //    }

                        //    break;
                }
            }
            catch (Exception exception)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(exception);
            }
        }
        private async void btnFinish_Click(object sender, EventArgs e)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                if (cls.Guid == Guid.Empty)
                {
                    uc.Building.Guid = Guid.NewGuid();
                    isSendSms = true;
                }
                else uc.Building.Guid = cls.Guid;
                cls = uc.Building;

                cls.OwnerGuid = UcPeople.Guid;
                cls.CityGuid = UcCity.CityGuid;
                cls.RegionGuid = UcCity.RegionGuid;
                cls.Address = UcCity.Address;
                cls.Code = UcCode.Code;
                cls.Priority = UcCode.Pirority;
                cls.CreateDate = UcCode.CreateDate;
                cls.UserGuid = UcCode.UserGuid;
                cls.Hiting = UcHitting_Colling.Hitting;
                cls.Colling = UcHitting_Colling.Colling;
                cls.Water = UcHitting_Colling.Water;
                cls.Barq = UcHitting_Colling.Barq;
                cls.Gas = UcHitting_Colling.Gas;
                cls.Tell = UcHitting_Colling.Tell;

                cls.OptionList = UcOptions.OptionList;
                cls.ShortDesc = txtShortDesc.Text;
                cls.GalleryList = ucBuildingHitting1.GalleryList;
                cls.MediaList = groupPanel3.MediaList;

                await SetType_AccTypeAsync();

                res.AddReturnedValue(await clsBuildingValidator.CheckValidationAsync(cls));
                if (res.HasError) return;

                res.AddReturnedValue(await cls.SaveAsync());
                if (res.HasError) return;

                if (Settings.Classes.Payamak.IsSendToOwner.ParseToBoolean() && isSendSms)
                {
                    var tr = await Payamak.FixSms.OwnerSend.SendAsync(cls);
                    frmNotification.PublicInfo.ShowMessage(tr.HasError
                        ? tr.ErrorMessage
                        : "ارسال پیامک به مالک با موفقیت انجام شد");
                }

                if (MessageBox.Show("آیا مایلید تقاضاهای مطابق با این ملک را مشاهده نمایید؟", "تطبیق املاک با تقاضا",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
                    return;
                _token?.Cancel();
                _token = new CancellationTokenSource();
                var list = await BuildingRequestViewModel.GetAllMatchesItemsAsync(cls, _token.Token);
                if (list.Count <= 0)
                {
                    this.ShowMessage("فایل مطابقی جهت نمایش وجود ندارد");
                    return;
                }

                new frmShowRequestMatches(list).ShowDialog(this);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }
            finally
            {
                if (res.HasError) this.ShowError(res);
                else
                {
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
        }
    }
}
