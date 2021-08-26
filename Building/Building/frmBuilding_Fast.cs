using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsSerivces;
using Building.BuildingMatchesItem;
using EntityCache.Bussines;
using EntityCache.ViewModels;
using MetroFramework.Forms;
using Nito.AsyncEx;
using Notification;
using Peoples;
using Services;
using Settings.Classes;

namespace Building.Building
{
    public partial class frmBuilding_Fast : MetroForm
    {
        private BuildingBussines cls;
        private PeoplesBussines owner;
        private CancellationTokenSource _token = new CancellationTokenSource();
        private string _picNameJari = "";
        private string _pictureNameForClick = null;
        private PictureBox _orGpicBox;
        private PictureBox _fakepicBox;
        readonly List<string> lstList = new List<string>();


        private async Task SetDataAsync()
        {
            try
            {
                _token?.Cancel();
                _token = new CancellationTokenSource();
                await LoadUsersAsync(_token.Token);
                LoadOwner();
                FillCmbTarakom();
                FillCmbMetr();
                await FillRentalAuthorityAsync(_token.Token);
                await FillSanadTypeAsync(_token.Token);
                await FillStateAsync(_token.Token);
                await FillBuildingConditionAsync(_token.Token);
                await FillBuildingTypeAsync(_token.Token);
                await FillBuildingAccountTypeAsync(_token.Token);
                await FillOptionsAsync(_token.Token);
                await NextCodeAsync();

                lblDateNow.Text = Calendar.MiladiToShamsi(DateTime.Now);
                cmbRentalAuthority.SelectedIndex = 0;

                cmbSellTarakom.SelectedIndex = 0;
                cmbSellSanadType.SelectedIndex = 0;
                txtDong.Value = 6;

                cmbState.SelectedIndex = 0;
                if (cmbState.SelectedValue != null && (Guid)cmbState.SelectedValue != Guid.Empty)
                    cmbState_SelectedIndexChanged(null, null);
                if (CityBindingSource.Count > 0) cmbCity.SelectedIndex = 0;
                if (cmbCity.SelectedValue != null && (Guid)cmbCity.SelectedValue != Guid.Empty)
                    cmbCity_SelectedIndexChanged(null, null);
                if (RegionBindingSource.Count > 0)
                    cmbRegion.SelectedIndex = 0;

                cmbBuildingCondition.SelectedIndex = 0;

                cmbBuildingType.SelectedIndex = 0;
                txtShortDesc.Text = cls?.ShortDesc;
                cmbBAccountType.SelectedIndex = 0;
                txtTedadOtaq.Value = 0;

                txtRahnPrice1.TextDecimal = 0;
                txtEjarePrice1.TextDecimal = 0;
                txtSellPrice.TextDecimal = 0;
                txtVamPrice.TextDecimal = 0;
                txtQestPrice.TextDecimal = 0;
                txtMasahat.Value = 0;
                txtZirBana.Value = 0;
                cmbSaleSakht.SelectedIndex = 0;

                if (string.IsNullOrEmpty(clsEconomyUnit.EconomyState))
                    cmbState.SelectedIndex = 0;
                else
                    cmbState.SelectedValue = Guid.Parse(clsEconomyUnit.EconomyState);
                if (!string.IsNullOrEmpty(clsEconomyUnit.EconomyCity))
                    cmbCity.SelectedValue = Guid.Parse(clsEconomyUnit.EconomyCity);
                if (!string.IsNullOrEmpty(clsEconomyUnit.ManagerRegion))
                    cmbRegion.SelectedValue = Guid.Parse(clsEconomyUnit.ManagerRegion);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async Task NextCodeAsync()
        {
            try
            {
                txtCode.Text = await BuildingBussines.NextCodeAsync() ?? "";
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async Task LoadUsersAsync(CancellationToken token)
        {
            try
            {
                var list = await UserBussines.GetAllAsync(token);
                userBindingSource.DataSource = list.Where(q => q.Status).OrderBy(q => q.Name).ToList();
                if (userBindingSource.Count > 0 && UserBussines.CurrentUser != null)
                    cmbUser.SelectedValue = UserBussines.CurrentUser.Guid;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void LoadOwner()
        {
            try
            {
                txttxtOwnerCode.Text = owner?.Code;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void FillCmbTarakom()
        {
            try
            {
                var values = Enum.GetValues(typeof(EnTarakom)).Cast<EnTarakom>();
                foreach (var item in values)
                    cmbSellTarakom.Items.Add(item.GetDisplay());
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void FillCmbMetr()
        {
            try
            {
                var values = Enum.GetValues(typeof(EnMetr)).Cast<EnMetr>();
                foreach (var item in values)
                {
                    cmbMasahat.Items.Add(item.GetDisplay());
                    cmbZirBana.Items.Add(item.GetDisplay());
                }

                cmbMasahat.SelectedIndex = 0;
                cmbZirBana.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async Task FillRentalAuthorityAsync(CancellationToken token)
        {
            try
            {
                var list = await RentalAuthorityBussines.GetAllAsync(token);
                rentalBindingSource.DataSource = list.Where(q => q.Status).OrderBy(q => q.Name).ToList();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async Task FillSanadTypeAsync(CancellationToken token)
        {
            try
            {
                var list = await DocumentTypeBussines.GetAllAsync(token);
                sanadTypeBindingSource.DataSource = list.Where(q => q.Status).OrderBy(q => q.Name).ToList();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async Task FillStateAsync(CancellationToken token)
        {
            try
            {
                var list = await StatesBussines.GetAllAsync(token);
                StateBindingSource.DataSource = list.Where(q => q.Status).OrderBy(q => q.Name);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async Task FillBuildingConditionAsync(CancellationToken token)
        {
            try
            {
                var list = await BuildingConditionBussines.GetAllAsync(token);
                bConditionBindingSource.DataSource = list.Where(q => q.Status).ToList().OrderBy(q => q.Name);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async Task FillBuildingTypeAsync(CancellationToken token)
        {
            try
            {
                var list = await BuildingTypeBussines.GetAllAsync(token);
                bTypeBindingSource.DataSource = list.Where(q => q.Status).ToList().OrderBy(q => q.Name);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async Task FillBuildingAccountTypeAsync(CancellationToken token)
        {
            try
            {
                var list = await BuildingAccountTypeBussines.GetAllAsync(token);
                batBindingSource.DataSource = list.Where(q => q.Status).ToList().OrderBy(q => q.Name);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async Task FillOptionsAsync(CancellationToken token)
        {
            try
            {
                var list = await BuildingOptionsBussines.GetAllAsync(token);
                BuildingOptionBindingSource.DataSource = list.Where(q => q.Status).OrderBy(q => q.Name).ToList();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private ReturnedSaveFuncInfo CheckValidation()
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                if (owner == null) res.AddError("لطفا مالک را انتخاب و یا تعریف نمایید");
                if (cmbUser.SelectedValue == null)
                    res.AddError("لطفا کاربر ثبت کننده ملک را وارد نمایید");
                if (string.IsNullOrWhiteSpace(txtCode.Text) || txtCode.Text.ParseToLong() <= 0)
                    res.AddError("کد ملک نمی تواند خالی باشد");
                if (txtRahnPrice1.TextDecimal == 0 && txtEjarePrice1.TextDecimal == 0 && txtSellPrice.TextDecimal == 0)
                    res.AddError("لطفا یکی از فیلدهای مبلغ را وارد نمایید");
                if (txtMasahat.Value <= 0 && txtZirBana.Value <= 0)
                    res.AddError("لطفا مساحت و زیربنا را وارد نمایید");
                if (cmbState.SelectedValue == null)
                    res.AddError("لطفا استان را انتخاب نمایید");
                if (cmbCity.SelectedValue == null)
                    res.AddError("لطفا شهرستان را انتخاب نمایید");
                if (cmbRegion.SelectedValue == null)
                    res.AddError("لطفا محدوده را انتخاب نمایید");
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
        }
        private async Task<ReturnedSaveFuncInfo> SetObjectAsync()
        {
            var line = 1;
            var res = new ReturnedSaveFuncInfo();
            try
            {
                line = 2;
                cls.Code = txtCode.Text;
                cls.Modified = DateTime.Now;
                line = 3;
                cls.OwnerGuid = owner.Guid;
                line = 4;
                cls.UserGuid = (Guid)cmbUser.SelectedValue;
                cls.Priority = EnBuildingPriority.Medium;
                cls.IsArchive = false;
                line = 5;
                cls.SellPrice = txtSellPrice.TextDecimal;
                line = 6;
                cls.QestPrice = txtQestPrice.TextDecimal;
                line = 7;
                cls.VamPrice = txtVamPrice.TextDecimal;
                line = 8;
                cls.Dang = txtDong.Text.ParseToInt();
                line = 9;
                cls.DocumentType = (Guid)cmbSellSanadType.SelectedValue;
                line = 10;
                cls.Tarakom = (EnTarakom)cmbSellTarakom.SelectedIndex;
                line = 11;
                cls.RahnPrice1 = txtRahnPrice1.TextDecimal;
                cls.RahnPrice2 = 0;
                line = 12;
                cls.EjarePrice1 = txtEjarePrice1.TextDecimal;
                cls.EjarePrice2 = 0;
                line = 13;
                cls.RentalAutorityGuid = (Guid)cmbRentalAuthority.SelectedValue;
                cls.IsShortTime = false;
                cls.IsOwnerHere = false;
                cls.PishTotalPrice = 0;
                cls.PishPrice = 0;
                cls.DeliveryDate = null;
                line = 14;
                if (cmbMasahat.SelectedIndex == 0)
                    cls.Masahat = txtMasahat.Text.ParseToInt();
                line = 15;
                if (cmbMasahat.SelectedIndex == 1)
                    cls.Masahat = txtMasahat.Text.ParseToInt() * 10000;
                line = 16;
                if (cmbZirBana.SelectedIndex == 0)
                    cls.ZirBana = txtZirBana.Text.ParseToInt();
                line = 17;
                if (cmbZirBana.SelectedIndex == 1)
                    cls.ZirBana = txtZirBana.Text.ParseToInt() * 10000;
                line = 18;
                cls.CityGuid = (Guid)cmbCity.SelectedValue;
                line = 19;
                cls.RegionGuid = (Guid)cmbRegion.SelectedValue;
                line = 20;
                cls.Address = txtAddress.Text;
                line = 21;
                cls.BuildingConditionGuid = (Guid)cmbBuildingCondition.SelectedValue;
                cls.Side = EnBuildingSide.One;
                line = 22;
                cls.BuildingTypeGuid = (Guid)cmbBuildingType.SelectedValue;
                cls.ShortDesc = txtShortDesc.Text;
                line = 23;
                cls.BuildingAccountTypeGuid = (Guid)cmbBAccountType.SelectedValue;
                cls.MetrazhTejari = 0;
                _token?.Cancel();
                _token = new CancellationTokenSource();
                var views = await BuildingViewBussines.GetAllAsync(_token.Token);
                line = 24;
                if (views.Count > 0)
                    cls.BuildingViewGuid = views[0].Guid;
                _token?.Cancel();
                _token = new CancellationTokenSource();
                var fCover = await FloorCoverBussines.GetAllAsync(_token.Token);
                line = 25;
                if (fCover.Count > 0)
                    cls.FloorCoverGuid = fCover[0].Guid;
                _token?.Cancel();
                _token = new CancellationTokenSource();
                var kService = await KitchenServiceBussines.GetAllAsync(_token.Token);
                line = 26;
                if (kService.Count > 0)
                    cls.KitchenServiceGuid = kService[0].Guid;
                cls.Water = EnKhadamati.Mostaqel;
                cls.Barq = EnKhadamati.Mostaqel;
                cls.Gas = EnKhadamati.Mostaqel;
                cls.Tell = EnKhadamati.Mostaqel;
                cls.TedadTabaqe = 0;
                cls.TabaqeNo = 0;
                cls.VahedPerTabaqe = 0;
                cls.MetrazhKouche = 0;
                cls.Hashie = 0;
                cls.ErtefaSaqf = 3;
                var oldDate = DateTime.Now.AddYears(-cmbSaleSakht.SelectedIndex);
                cls.SaleSakht = Calendar.MiladiToShamsi(oldDate);
                cls.BonBast = false;
                cls.MamarJoda = true;
                line = 27;
                cls.RoomCount = txtTedadOtaq.Text.ParseToInt();
                cls.Image = "";
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex, $"Error in Line:{line}");
                res.AddReturnedValue(ex);
            }

            return res;
        }
        private async Task<ReturnedSaveFuncInfo> SetOptionsAsync(Guid buildingGuid)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                cls.OptionList = new List<BuildingRelatedOptionsBussines>();
                if (buildingGuid == Guid.Empty) return res;
                _token?.Cancel();
                _token = new CancellationTokenSource();
                var list = await BuildingOptionsBussines.GetAllAsync(_token.Token);
                if (list.Count <= 0) return res;
                foreach (var item in list)
                    for (var i = 0; i < DGrid.RowCount; i++)
                        if (item.Guid == ((Guid?)DGrid[dgOptionGuid.Index, i].Value ?? Guid.Empty))
                        {
                            if (!(bool)DGrid[dgChecked.Index, i].Value) continue;
                            cls.OptionList.Add(new BuildingRelatedOptionsBussines()
                            {
                                Guid = Guid.NewGuid(),
                                BuildingOptionGuid = item.Guid,
                                Modified = DateTime.Now,
                                BuildinGuid = cls.Guid
                            });
                        }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
        }
        private void CalculateSellPrice()
        {
            try
            {
                decimal masahat = 0, zirbana = 0;

                if (cmbMasahat.SelectedIndex == 0)
                    masahat = txtMasahat.Value;
                else
                    masahat = txtMasahat.Value * 10000;

                if (cmbZirBana.SelectedIndex == 0)
                    zirbana = txtZirBana.Value;
                else
                    zirbana = txtZirBana.Value * 10000;

                if (txtSellPrice.TextDecimal == 0)
                {
                    lblPricePerZirBana.Text = "0";
                    lblPricePerMetr.Text = "0";
                    return;
                }
                if (masahat > 0)
                    lblPricePerMetr.Text = (txtSellPrice.TextDecimal / masahat).ToString("N0") + " ریال";
                if (zirbana > 0)
                    lblPricePerZirBana.Text = (txtSellPrice.TextDecimal / zirbana).ToString("N0") + " ریال";
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void Make_Picture_Boxes(List<string> lst)
        {
            try
            {
                if (lst == null || lst.Count == 0) return;
                fPanel.AutoScroll = true;
                for (var i = fPanel.Controls.Count - 1; i >= 0; i--)
                    fPanel.Controls[i].Dispose();
                for (var i = 0; i < lst.Count; i++)
                {
                    try
                    {
                        var picbox = new PictureBox();
                        Controls.Add(picbox);
                        picbox.Size = new Size(62, 63);
                        picbox.Load(lst[i]);
                        picbox.Name = "pic" + i;
                        picbox.Cursor = Cursors.Hand;
                        picbox.SizeMode = PictureBoxSizeMode.StretchImage;
                        picbox.Click += picbox_Click;
                        fPanel.Controls.Add(picbox);
                    }
                    catch (Exception)
                    {
                        lst.RemoveAt(i);
                    }
                }
            }
            catch (Exception exception)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(exception);
            }
        }
        private static void ShowBigSizePic(PictureBox pic)
        {
            try
            {
                pic.Size = new Size(190, 212);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private static void ShowNormalSizePic(PictureBox pic)
        {
            try
            {
                pic.Size = new Size(62, 63);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private ReturnedSaveFuncInfo SetImages()
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                var img = Path.Combine(Application.StartupPath, "Images");
                foreach (var item in cls.GalleryList ?? new List<BuildingGalleryBussines>())
                {
                    var path = Path.Combine(img, item.ImageName + ".jpg");
                    try
                    {
                        File.Delete(path);
                    }
                    catch
                    {
                    }
                }

                cls.GalleryList = new List<BuildingGalleryBussines>();

                foreach (var item in lstList)
                {
                    var imagePath = Path.Combine(Application.StartupPath, "Temp");
                    if (!Directory.Exists(imagePath)) Directory.CreateDirectory(imagePath);
                    var name = Guid.NewGuid().ToString();
                    var fileName = Path.Combine(imagePath, name + ".jpg");
                    try
                    {
                        File.Copy(item, fileName);
                    }
                    catch
                    {
                    }


                    var imagePath_ = Path.Combine(Application.StartupPath, "Images");
                    if (!Directory.Exists(imagePath_)) Directory.CreateDirectory(imagePath_);

                    var fileName_ = Path.Combine(imagePath_, name + ".jpg");
                    try
                    {
                        File.Copy(item, fileName_);
                    }
                    catch
                    {
                    }


                    var a = new BuildingGalleryBussines()
                    {
                        Guid = Guid.NewGuid(),
                        ImageName = name,
                        BuildingGuid = cls.Guid,
                        Modified = DateTime.Now
                    };
                    cls.GalleryList.Add(a);
                }

                try
                {
                    var imagePath = Path.Combine(Application.StartupPath, "Temp");
                    Directory.Delete(imagePath, true);
                }
                catch
                {
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }
            return res;
        }


        public frmBuilding_Fast()
        {
            try
            {
                InitializeComponent();
                WindowState = FormWindowState.Maximized;
                cls = new BuildingBussines();
                ucHeader.Text = "افزودن ملک جدید";
                ucHeader.IsModified = cls.IsModified;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private async void cmbState_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbState.SelectedValue == null) return;
                _token?.Cancel();
                _token = new CancellationTokenSource();
                var list = await CitiesBussines.GetAllAsync((Guid)cmbState.SelectedValue, _token.Token);
                CityBindingSource.DataSource = list?.Where(q => q.Status).OrderBy(q => q.Name).ToList();
                if (!string.IsNullOrEmpty(clsEconomyUnit.EconomyCity))
                    cmbCity.SelectedValue = Guid.Parse(clsEconomyUnit.EconomyCity);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async void cmbCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbCity.SelectedValue == null) return;
                _token?.Cancel();
                _token = new CancellationTokenSource();
                var list = await RegionsBussines.GetAllAsync((Guid)cmbCity.SelectedValue, _token.Token);
                RegionBindingSource.DataSource = list.Where(q => q.Status).OrderBy(q => q.Name).ToList();
                if (!string.IsNullOrEmpty(clsEconomyUnit.ManagerRegion))
                    cmbRegion.SelectedValue = Guid.Parse(clsEconomyUnit.ManagerRegion);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void frmBuilding_Fast_Load(object sender, EventArgs e) => AsyncContext.Run(SetDataAsync);
        private void btnSearchOwner_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new frmShowPeoples(true);
                if (frm.ShowDialog(this) != DialogResult.OK) return;
                owner = PeoplesBussines.Get(frm.SelectedGuid);
                LoadOwner();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void btnCreateOwner_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new frmPeoples();
                if (frm.ShowDialog(this) != DialogResult.OK) return;
                owner = PeoplesBussines.Get(frm.SelectedGuid);
                LoadOwner();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void frmBuilding_Fast_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                switch (e.KeyCode)
                {
                    case Keys.Enter:
                        if (!btnFinish.Focused && !btnCancel.Focused &&
                            !txtAddress.Focused && !txtShortDesc.Focused)
                            SendKeys.Send("{Tab}");
                        break;
                    case Keys.F5:
                        btnFinish.PerformClick();
                        break;
                    case Keys.Escape:
                        btnCancel.PerformClick();
                        break;
                    case Keys.F8:
                        if (_orGpicBox != null)
                        {
                            ShowBigSizePic(_orGpicBox);
                            _fakepicBox = _orGpicBox;
                            _orGpicBox = null;
                        }
                        else
                        {
                            ShowNormalSizePic(_fakepicBox);
                            _orGpicBox = _fakepicBox;
                        }

                        break;
                }
            }
            catch (Exception exception)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(exception);
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
            btnFinish.Enabled = false;
            try
            {
                var isSendSms = false;
                if (cls.Guid == Guid.Empty)
                {
                    cls.Guid = Guid.NewGuid();
                    isSendSms = true;
                }

                res.AddReturnedValue(CheckValidation());
                if (res.HasError) return;

                res.AddReturnedValue(await SetObjectAsync());
                if (res.HasError) return;

                res.AddReturnedValue(await SetOptionsAsync(cls.Guid));
                if (res.HasError) return;

                res.AddReturnedValue(SetImages());
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

                if (res.HasError) return;

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
                btnFinish.Enabled = true;
                if (res.HasError)
                    this.ShowError(res, "خطا در ذخیره سازی ملک");
                else
                {
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
        }
        private void txtMasahat_ValueChanged(object sender, EventArgs e) => CalculateSellPrice();
        private void txtZirBana_ValueChanged(object sender, EventArgs e) => CalculateSellPrice();
        private void cmbMasahat_SelectedIndexChanged(object sender, EventArgs e) => CalculateSellPrice();
        private void cmbZirBana_SelectedIndexChanged(object sender, EventArgs e) => CalculateSellPrice();
        private void txtSellPrice_OnTextChanged() => CalculateSellPrice();
        private void btnInsImage_Click(object sender, EventArgs e)
        {
            try
            {
                if (InvokeRequired)
                {
                    var t = new Thread(() =>
                    {
                        var ofd = new OpenFileDialog { Multiselect = true, RestoreDirectory = true };
                        if (ofd.ShowDialog(this) != DialogResult.OK) return;
                        foreach (var name in ofd.FileNames)
                            lstList.Add(name);
                    });

                    t.SetApartmentState(ApartmentState.STA);
                    t.Start();
                    t.Join();
                }
                else
                {
                    var ofd = new OpenFileDialog { Multiselect = true, RestoreDirectory = true };
                    if (ofd.ShowDialog(this) != DialogResult.OK) return;
                    foreach (var name in ofd.FileNames)
                        lstList.Add(name);
                }
                Make_Picture_Boxes(lstList);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void btnDelImage_Click(object sender, EventArgs e)
        {
            try
            {
                Make_Picture_Boxes(lstList);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void picbox_Click(object sender, EventArgs e)
        {
            try
            {
                var imageLocation = ((PictureBox)sender).ImageLocation;
                _picNameJari = ((PictureBox)sender).Name;
                if (_picNameJari == _pictureNameForClick)
                {
                    ((PictureBox)sender).BackColor = Color.Transparent;
                    ((PictureBox)sender).Padding = new Padding(-1);
                    _pictureNameForClick = null;
                    lstList.Add(imageLocation);
                    _orGpicBox = null;
                    return;
                }

                ((PictureBox)sender).BackColor = Color.Red;
                ((PictureBox)sender).Padding = new Padding(1);
                _pictureNameForClick = ((PictureBox)sender).Name;
                lstList.Remove(imageLocation);
                _orGpicBox = (PictureBox)sender;
            }
            catch (Exception exception)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(exception);
            }
        }
    }
}
