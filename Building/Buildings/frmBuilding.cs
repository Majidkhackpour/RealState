using Building.BuildingMatchesItem;
using Building.UserControls.Other;
using Building.UserControls.Rahn;
using Building.UserControls.Sell;
using EntityCache.Bussines;
using EntityCache.ViewModels;
using MetroFramework.Forms;
using Notification;
using Payamak.PhoneBook;
using Services;
using Services.FilterObjects;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsSerivces;

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

                await UcPeople.SetGuidAsync(cls.OwnerGuid);

                var city = await CitiesBussines.GetAsync(cls.CityGuid);
                if (city != null)
                    await UcCity.SetStateGuidAsync(city.StateGuid);
                UcCity.CityGuid = cls.CityGuid;
                UcCity.RegionGuid = cls.RegionGuid;
                UcCity.Address = cls.Address;

                await UcCode.SetCodeAsync(cls.Code);
                UcCode.CreateDate = cls.CreateDate;
                UcCode.Pirority = cls.Priority;
                await UcCode.SetUserGuidAsync(cls.UserGuid);

                UcHitting_Colling.Barq = cls.Barq;
                UcHitting_Colling.Water = cls.Water;
                UcHitting_Colling.Gas = cls.Gas;
                UcHitting_Colling.Tell = cls.Tell;
                await UcHitting_Colling.SetHittingAsync(cls.Hiting);
                await UcHitting_Colling.SetCollingAsync(cls.Colling);

                await UcOptions.SetOptionListAsync(cls.OptionList);
                txtShortDesc.Text = cls.ShortDesc;
                ucBuildingHitting1.GalleryList = cls.GalleryList;
                groupPanel3.MediaList = cls.MediaList;

                await GetContentAsync();

                if (cls.Guid == Guid.Empty) await SetType_AccTypeAsync();

                await ucType.SetBuildingAccountTypeGuidAsync(cls.BuildingAccountTypeGuid);
                await ucType.SetBuildingTypeGuidAsync(cls.BuildingTypeGuid);
                await ucType.SetBuildingWindowGuidAsync(cls.WindowGuid);

                UcNotes.Notes = cls.NoteList;

                if (cls.AdvertiseType == null || cls.AdvertiseType == AdvertiseType.None)
                    btnSavePersonal.Visible = false;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async Task GetContentAsync()
        {
            try
            {
                switch (cls.Parent)
                {
                    case EnBuildingParent.SellAprtment:
                        ucType.IsShowWindow = true;
                        uc = new UcBuildingSell_Appartment();
                        await uc.SetBuildingAsync(cls);
                        break;
                    case EnBuildingParent.SellHome:
                        ucType.IsShowWindow = true;
                        uc = new UcBuildingSell_Home();
                        await uc.SetBuildingAsync(cls);
                        break;
                    case EnBuildingParent.SellLand:
                        ucType.IsShowWindow = false;
                        uc = new UcBuildingSell_Land();
                        await uc.SetBuildingAsync(cls);
                        break;
                    case EnBuildingParent.SellVilla:
                        ucType.IsShowWindow = true;
                        uc = new UcBuildingSell_Villa();
                        await uc.SetBuildingAsync(cls);
                        break;
                    case EnBuildingParent.SellStore:
                        ucType.IsShowWindow = false;
                        uc = new UcBuildingSell_Store();
                        await uc.SetBuildingAsync(cls);
                        break;
                    case EnBuildingParent.SellOffice:
                        ucType.IsShowWindow = false;
                        uc = new UcBuildingSell_Office();
                        await uc.SetBuildingAsync(cls);
                        break;
                    case EnBuildingParent.SellGarden:
                        ucType.IsShowWindow = false;
                        uc = new UcBuildingSell_Garden();
                        await uc.SetBuildingAsync(cls);
                        break;
                    case EnBuildingParent.SellOldHouse:
                        ucType.IsShowWindow = true;
                        uc = new UcBuildingSell_OldHouse();
                        await uc.SetBuildingAsync(cls);
                        break;
                    case EnBuildingParent.RentAprtment:
                        ucType.IsShowWindow = true;
                        uc = new UcBuildingRahn_Appartment() { IsFullRahn = false };
                        await uc.SetBuildingAsync(cls);
                        break;
                    case EnBuildingParent.RentHome:
                        ucType.IsShowWindow = true;
                        uc = new UcBuildingRahn_Home() { IsFullRahn = false };
                        await uc.SetBuildingAsync(cls);
                        break;
                    case EnBuildingParent.RentStore:
                        ucType.IsShowWindow = false;
                        uc = new UcBuildingRahn_Store() { IsFullRahn = false };
                        await uc.SetBuildingAsync(cls);
                        break;
                    case EnBuildingParent.RentOffice:
                        ucType.IsShowWindow = false;
                        uc = new UcBuildingRahn_Office() { IsFullRahn = false };
                        await uc.SetBuildingAsync(cls);
                        break;
                    case EnBuildingParent.FullRentAprtment:
                        ucType.IsShowWindow = true;
                        uc = new UcBuildingRahn_Appartment() { IsFullRahn = true };
                        await uc.SetBuildingAsync(cls);
                        break;
                    case EnBuildingParent.FullRentHome:
                        ucType.IsShowWindow = true;
                        uc = new UcBuildingRahn_Home() { IsFullRahn = true };
                        await uc.SetBuildingAsync(cls);
                        break;
                    case EnBuildingParent.FullRentStore:
                        ucType.IsShowWindow = false;
                        uc = new UcBuildingRahn_Store() { IsFullRahn = true };
                        await uc.SetBuildingAsync(cls);
                        break;
                    case EnBuildingParent.FullRentOffice:
                        ucType.IsShowWindow = false;
                        uc = new UcBuildingRahn_Office() { IsFullRahn = true };
                        await uc.SetBuildingAsync(cls);
                        break;
                    case EnBuildingParent.PreSellAprtment:
                        ucType.IsShowWindow = true;
                        uc = new UcBuildingOther_Appartment() { IsPishForoush = true };
                        await uc.SetBuildingAsync(cls);
                        break;
                    case EnBuildingParent.PreSellHome:
                        ucType.IsShowWindow = true;
                        uc = new UcBuildingOther_Home() { IsPishForoush = true };
                        await uc.SetBuildingAsync(cls);
                        break;
                    case EnBuildingParent.PreSellStore:
                        ucType.IsShowWindow = false;
                        uc = new UcBuildingOther_Store() { IsPishForoush = true };
                        await uc.SetBuildingAsync(cls);
                        break;
                    case EnBuildingParent.PreSellOffice:
                        ucType.IsShowWindow = false;
                        uc = new UcBuildingOther_Office() { IsPishForoush = true };
                        await uc.SetBuildingAsync(cls);
                        break;
                    case EnBuildingParent.MoavezeAprtment:
                        ucType.IsShowWindow = true;
                        uc = new UcBuildingOther_Appartment() { IsPishForoush = false };
                        await uc.SetBuildingAsync(cls);
                        break;
                    case EnBuildingParent.MoavezeHome:
                        ucType.IsShowWindow = true;
                        uc = new UcBuildingOther_Home() { IsPishForoush = false };
                        await uc.SetBuildingAsync(cls);
                        break;
                    case EnBuildingParent.MoavezeStore:
                        ucType.IsShowWindow = false;
                        uc = new UcBuildingOther_Store() { IsPishForoush = false };
                        await uc.SetBuildingAsync(cls);
                        break;
                    case EnBuildingParent.MoavezeOffice:
                        ucType.IsShowWindow = false;
                        uc = new UcBuildingOther_Office() { IsPishForoush = true };
                        await uc.SetBuildingAsync(cls);
                        break;
                    case EnBuildingParent.MosharekatAprtment:
                        ucType.IsShowWindow = true;
                        uc = new UcBuildingOther_Appartment() { IsPishForoush = false };
                        await uc.SetBuildingAsync(cls);
                        break;
                    case EnBuildingParent.MosharekatHome:
                        ucType.IsShowWindow = true;
                        uc = new UcBuildingOther_Home() { IsPishForoush = false };
                        await uc.SetBuildingAsync(cls);
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
        private async Task<ReturnedSaveFuncInfo> SaveAsync(AdvertiseType? advType)
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

                cls.OptionList = await UcOptions.GetOptionListAsync();
                cls.ShortDesc = txtShortDesc.Text;
                cls.GalleryList = ucBuildingHitting1.GalleryList;
                cls.MediaList = groupPanel3.MediaList;

                cls.BuildingAccountTypeGuid = ucType.BuildingAccountTypeGuid;
                cls.BuildingTypeGuid = ucType.BuildingTypeGuid;
                cls.WindowGuid = ucType.BuildingWindowGuid;
                cls.AdvertiseType = advType;
                cls.NoteList = UcNotes.Notes;
                cls.ServerStatus = ServerStatus.None;
                res.AddReturnedValue(await clsBuildingValidator.CheckValidationAsync(cls));
                if (res.HasError) return res;

                if (cls.OwnerGuid != (await PeoplesBussines.GetDefaultPeopleAsync())?.Guid)
                {
                    var count = await cls.CheckAsync();
                    if (count > 0)
                    {
                        var msg = $"تعداد {count} فایل دیگر دقیقا مشابه با فایل وارد شده وجود دارد. \r\n" +
                                  $"توجه داشته باشید که ممکن است در صورت ثبت، فایل تکراری ثبت کرده باشید \r\n" +
                                  $"آیا ادامه می دهید؟";
                        if (MessageBox.Show(msg, "هشدار", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                        {
                            res.AddError("فایل مورد نظر ثبت نشد لطفا پس از تغییر مقادیر مجددا تلاش نمایید");
                            return res;
                        }
                    }
                }

                if (advType == null && btnSavePersonal.Visible)
                {
                    var reg = await RegionsBussines.GetAsync(cls.RegionGuid);
                    var desc = $"کد ملک:( {cls.Code} ) ** محدوده:( {reg?.Name} ) ** آدرس:( {cls.Address} )";
                    await UserLogBussines.SaveBuildingLogAsync(EnLogAction.AddToPersonalFiles, cls.Guid, desc);
                    res.AddReturnedValue(await cls.SaveAsync(false));
                }
                else
                    res.AddReturnedValue(await cls.SaveAsync(true));
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
        }
        private async Task SaveAsync_(AdvertiseType? advType)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                btnFinish.Enabled = false;
                btnSavePersonal.Enabled = false;
                res.AddReturnedValue(await SaveAsync(advType));
                if (res.HasError || res.HasWarning) return;

                if (SettingsBussines.Setting.Sms.IsSendToOwner && isSendSms)
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
                var list = await BuildingRequestViewModel.GetAllMatchesItemsAsync(cls.Guid, _token.Token);
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
                btnFinish.Enabled = true;
                btnSavePersonal.Enabled = true;
                if (res.HasError) this.ShowError(res);
                else
                {
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
        }

        public frmBuilding(BuildingBussines bu, bool isShowMode,bool isShortDetail=false)
        {
            try
            {
                InitializeComponent();
                cls = bu;
                if (isShowMode)
                {
                    UcPeople.Enabled = false;
                    UcCity.Enabled = false;
                    UcCode.Enabled = false;
                    UcHitting_Colling.Enabled = false;
                    UcOptions.Enabled = false;
                    txtShortDesc.Enabled = false;
                    ucBuildingHitting1.Enabled = false;
                    groupPanel3.Enabled = false;
                    pnlContent.Enabled = false;
                    ucType.Enabled = false;
                    UcNotes.Enabled = false;
                    btnFinish.Enabled = false;
                    btnSavePersonal.Enabled = false;
                }
                else
                {
                    UcPeople.OnShowNumbers += UcPeople_OnShowNumbers;
                    UcPeople.OnShowFiles += UcPeople_OnShowFiles;
                }

                UcCity.IsShowAddress = !isShortDetail;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
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
        private async void btnFinish_Click(object sender, EventArgs e) => await SaveAsync_(cls.AdvertiseType);
        private async Task UcPeople_OnShowNumbers(Guid guid)
        {
            try
            {
                var owner = await PeoplesBussines.GetAsync(UcPeople.Guid, cls?.Guid);
                if (owner?.TellList == null || owner.TellList.Count <= 0)
                {
                    this.ShowWarning($"برای {owner?.Name} شماره ای ثبت نشده است");
                    return;
                }

                var frm = new frmShowPhoneBook(owner.TellList);
                frm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async void btnSavePersonal_Click(object sender, EventArgs e) => await SaveAsync_(null);
        private async Task UcPeople_OnShowFiles(Guid guid)
        {
            try
            {
                var owner = await PeoplesBussines.GetAsync(UcPeople.Guid, cls?.Guid);
                if (owner == null)
                {
                    this.ShowWarning("برایمالک مورد نظر شناسایی نشد");
                    return;
                }
                var filter = new BuildingFilter()
                {
                    Status = true,
                    OwnerGuid = owner.Guid
                };

                var frm = new frmShowBuildings(true, filter);
                frm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
