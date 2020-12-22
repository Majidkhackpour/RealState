using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityCache.Bussines;
using MetroFramework.Forms;
using Notification;
using Peoples;
using Print;
using Services;
using User;

namespace Building.Building
{
    public partial class frmBuildingMain : MetroForm
    {
        private BuildingBussines cls;
        private PeoplesBussines owner;
        private string _pictureNameForClick = null;
        private PictureBox _orGpicBox;
        private PictureBox _fakepicBox;
        private string _picNameJari = "";
        readonly List<string> lstList = new List<string>();
        private EnLogAction action;
        private string image;


        private async Task SetDataAsync()
        {
            try
            {
                await LoadUsersAsync();
                LoadOwner();
                FillCmbTarakom();
                FillCmbMetr();
                await FillRentalAuthorityAsync();
                SetTxtPrice();
                SetTxtMetr();
                await FillSanadTypeAsync();
                await FillStateAsync();
                await FillBuildingConditionAsync();
                FillCmbSide();
                await FillBuildingTypeAsync();
                await FillBuildingAccountTypeAsync();
                await FillBuildingViewAsync();
                await FillFloorCoverAsync();
                await FillKitchenServiceAsync();
                FillCmbKhadamt();
                await FillOptionsAsync();
                SetRelatedOptions(cls.Guid);

                lblDateNow.Text = cls?.DateSh;
                txtCode.Text = cls?.Code;
                cmbUser.SelectedValue = cls?.UserGuid;

                cmbRentalAuthority.SelectedValue = cls?.RentalAutorityGuid ?? Guid.Empty;
                chbOwnerHere.Checked = cls?.IsOwnerHere ?? false;
                chbShortRent.Checked = cls?.IsShortTime ?? false;

                cmbSellTarakom.SelectedIndex = (int)(cls?.Tarakom ?? EnTarakom.Min);
                cmbSellSanadType.SelectedValue = cls?.DocumentType ?? Guid.Empty;
                txtDong.Text = (cls?.Dang ?? 0).ToString();

                txtDeliveryDate.Text = Calendar.MiladiToShamsi(cls?.DeliveryDate ?? DateTime.Now);
                txtPishDong.Text = (cls?.Dang ?? 0).ToString();
                cmbPishSanadType.SelectedValue = cls?.DocumentType ?? Guid.Empty;
                txtPishDesc.Text = cls?.PishDesc;

                txtMoavezeDong.Text = (cls?.Dang ?? 0).ToString();
                txtMoavezeDesc.Text = cls?.MoavezeDesc;
                cmbMoavezeSanadType.SelectedValue = cls?.DocumentType ?? Guid.Empty;
                cmbMoavezeTarakom.SelectedIndex = (int)(cls?.Tarakom ?? EnTarakom.Min);

                txtMosharekatDong.Text = (cls?.Dang ?? 0).ToString();
                txtMosharekatDesc.Text = cls?.MosharekatDesc;
                cmbMosharekatSanadType.SelectedValue = cls?.DocumentType ?? Guid.Empty;
                cmbMosharekatTarakom.SelectedIndex = (int)(cls?.Tarakom ?? EnTarakom.Min);

                var city = CitiesBussines.Get(cls?.CityGuid ?? Guid.Empty);
                cmbState.SelectedValue = city?.StateGuid ?? Guid.Empty;
                if (cmbState.SelectedValue != null && (Guid)cmbState.SelectedValue != Guid.Empty)
                    cmbState_SelectedIndexChanged(null, null);
                cmbCity.SelectedValue = cls?.CityGuid;
                if (cmbCity.SelectedValue != null && (Guid)cmbCity.SelectedValue != Guid.Empty)
                    cmbCity_SelectedIndexChanged(null, null);
                cmbRegion.SelectedValue = cls?.RegionGuid;
                txtAddress.Text = cls?.Address;
                cmbBuildingCondition.SelectedValue = cls?.BuildingConditionGuid;
                cmbSide.SelectedIndex = (int)cls?.Side;

                cmbBuildingType.SelectedValue = cls?.BuildingTypeGuid;
                txtShortDesc.Text = cls?.ShortDesc;
                cmbBAccountType.SelectedValue = cls?.BuildingAccountTypeGuid;
                cmbBView.SelectedValue = cls?.BuildingViewGuid;
                cmbBFloorCover.SelectedValue = cls?.FloorCoverGuid;
                cmbKitchenService.SelectedValue = cls?.KitchenServiceGuid;
                cmbWater.SelectedIndex = (int)(cls?.Water ?? EnKhadamati.Mostaqel);
                cmbBarq.SelectedIndex = (int)(cls?.Barq ?? EnKhadamati.Mostaqel);
                cmbGas.SelectedIndex = (int)(cls?.Gas ?? EnKhadamati.Mostaqel);
                cmbTell.SelectedIndex = (int)(cls?.Tell ?? EnKhadamati.Mostaqel);
                txtTedadTabaqe.Text = cls?.TedadTabaqe.ToString();
                txtTedadOtaq.Text = cls?.RoomCount.ToString();
                txtTedadVahed.Text = cls?.VahedPerTabaqe.ToString();
                cmbTabaqeNo.Text = cls?.TabaqeNo.ToString();

                txtMetrazhKouche.Text = cls?.MetrazhKouche.ToString();
                txtErtrfaSaqf.Text = cls?.ErtefaSaqf.ToString();
                txtHashie.Text = cls?.Hashie.ToString();
                txtMetrazhTejari.Text = cls?.MetrazhTejari.ToString();
                chbIsBonBast.Checked = cls?.BonBast ?? false;
                chbIsMamarJoda.Checked = cls?.MamarJoda ?? false;
                txtSaleParvane.Text = cls?.DateParvane;
                txtSerialParvane.Text = cls?.ParvaneSerial;
                txtSaleSakht.Text = cls?.SaleSakht;

                fPanel.Controls.Clear();
                lstList.Clear();
                if (cls.GalleryList != null && cls.GalleryList.Count != 0)
                    foreach (var image in cls.GalleryList)
                    {
                        var a = Path.Combine(Application.StartupPath, "Temp");
                        var b = Path.Combine(a, image.ImageName + ".jpg");
                        lstList.Add(b);
                    }

                Make_Picture_Boxes(lstList);

                chbGoogleMap.Checked = false;
                picGoogle.Visible = true;
                webGoogle.Visible = false;

                if (cls?.Guid == Guid.Empty)
                {
                    await NextCodeAsync();
                    cmbUser.SelectedValue = clsUser.CurrentUser?.Guid;
                    cmbRentalAuthority.SelectedIndex = 0;
                    cmbSellTarakom.SelectedIndex = 0;
                    cmbSellSanadType.SelectedIndex = 0;
                    cmbPishSanadType.SelectedIndex = 0;
                    cmbMoavezeTarakom.SelectedIndex = 0;
                    cmbMoavezeSanadType.SelectedIndex = 0;
                    cmbMosharekatTarakom.SelectedIndex = 0;
                    cmbMosharekatSanadType.SelectedIndex = 0;
                    cmbState.SelectedIndex = 0;
                    cmbBuildingCondition.SelectedIndex = 0;
                    cmbSide.SelectedIndex = 0;
                    cmbBuildingType.SelectedIndex = 0;
                    cmbBAccountType.SelectedIndex = 0;
                    cmbBView.SelectedIndex = 0;
                    cmbBFloorCover.SelectedIndex = 0;
                    cmbKitchenService.SelectedIndex = 0;
                    cmbWater.SelectedIndex = 0;
                    cmbBarq.SelectedIndex = 0;
                    cmbGas.SelectedIndex = 0;
                    cmbTell.SelectedIndex = 0;
                    cmbTabaqeNo.SelectedIndex = 3;
                }

                image = cls?.Image;
                if (!string.IsNullOrEmpty(cls?.Image))
                {
                    var path = Path.Combine(Application.StartupPath + "\\Images", cls.Image);
                    picImage.ImageLocation = path;
                }
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
        private async Task FillRentalAuthorityAsync()
        {
            try
            {
                var list = await RentalAuthorityBussines.GetAllAsync();
                rentalBindingSource.DataSource = list.Where(q => q.Status).OrderBy(q => q.Name).ToList();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async Task FillSanadTypeAsync()
        {
            try
            {
                var list = await DocumentTypeBussines.GetAllAsync();
                sanadTypeBindingSource.DataSource = list.Where(q => q.Status).OrderBy(q => q.Name).ToList();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async Task FillStateAsync()
        {
            try
            {
                var list = await StatesBussines.GetAllAsync();
                StateBindingSource.DataSource = list.Where(q => q.Status).OrderBy(q => q.Name);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async Task FillBuildingConditionAsync()
        {
            try
            {
                var list = await BuildingConditionBussines.GetAllAsync();
                bConditionBindingSource.DataSource = list.Where(q => q.Status).ToList().OrderBy(q => q.Name);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async Task FillBuildingTypeAsync()
        {
            try
            {
                var list = await BuildingTypeBussines.GetAllAsync();
                bTypeBindingSource.DataSource = list.Where(q => q.Status).ToList().OrderBy(q => q.Name);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async Task FillBuildingAccountTypeAsync()
        {
            try
            {
                var list = await BuildingAccountTypeBussines.GetAllAsync();
                batBindingSource.DataSource = list.Where(q => q.Status).ToList().OrderBy(q => q.Name);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async Task FillBuildingViewAsync()
        {
            try
            {
                var list = await BuildingViewBussines.GetAllAsync();
                BuildingViewBindingSource.DataSource = list.Where(q => q.Status).ToList().OrderBy(q => q.Name);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async Task FillFloorCoverAsync()
        {
            try
            {
                var list = await FloorCoverBussines.GetAllAsync();
                FloorCoverBindingSource.DataSource = list.Where(q => q.Status).ToList().OrderBy(q => q.Name);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async Task FillKitchenServiceAsync()
        {
            try
            {
                var list = await KitchenServiceBussines.GetAllAsync();
                KitchenServiceBindingSource.DataSource = list.Where(q => q.Status).ToList().OrderBy(q => q.Name);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void SetTxtPrice()
        {
            try
            {
                txtRahnPrice1.TextDecimal = cls?.RahnPrice1 ?? 0;
                txtRahnPrice2.TextDecimal = cls?.RahnPrice2 ?? 0;
                txtEjarePrice1.TextDecimal = cls?.EjarePrice1 ?? 0;
                txtEjarePrice2.TextDecimal = cls?.EjarePrice2 ?? 0;
                txtSellPrice.TextDecimal = cls?.SellPrice ?? 0;
                txtVamPrice.TextDecimal = cls?.VamPrice ?? 0;
                txtQestPrice.TextDecimal = cls?.QestPrice ?? 0;
                txtPishTotalPrice.TextDecimal = cls?.PishTotalPrice ?? 0;
                txtPishPrice.TextDecimal = cls?.PishPrice ?? 0;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void SetTxtMetr()
        {
            try
            {
                if (cls?.Masahat == 0)
                {
                    txtMasahat.Text = cls?.Masahat.ToString();
                    cmbMasahat.SelectedIndex = 0;
                }
                if (cls?.Masahat != 0)
                {
                    if (cls?.Masahat >= 10000)
                    {
                        txtMasahat.Text = (cls?.Masahat / 10000).ToString();
                        cmbMasahat.SelectedIndex = 1;
                    }
                    if (cls?.Masahat <= 9999)
                    {
                        txtMasahat.Text = cls?.Masahat.ToString();
                        cmbMasahat.SelectedIndex = 0;
                    }
                }


                if (cls?.ZirBana == 0)
                {
                    txtZirBana.Text = cls?.ZirBana.ToString();
                    cmbZirBana.SelectedIndex = 0;
                }
                if (cls?.ZirBana != 0)
                {
                    if (cls?.ZirBana >= 10000)
                    {
                        txtZirBana.Text = (cls?.ZirBana / 10000).ToString();
                        cmbZirBana.SelectedIndex = 1;
                    }
                    if (cls?.ZirBana <= 9999)
                    {
                        txtZirBana.Text = cls?.ZirBana.ToString();
                        cmbZirBana.SelectedIndex = 0;
                    }
                }
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
                {
                    cmbSellTarakom.Items.Add(item.GetDisplay());
                    cmbMoavezeTarakom.Items.Add(item.GetDisplay());
                    cmbMosharekatTarakom.Items.Add(item.GetDisplay());
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void FillCmbSide()
        {
            try
            {
                var values = Enum.GetValues(typeof(EnBuildingSide)).Cast<EnBuildingSide>();
                foreach (var item in values)
                    cmbSide.Items.Add(item.GetDisplay());
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
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void FillCmbKhadamt()
        {
            try
            {
                var values = Enum.GetValues(typeof(EnKhadamati)).Cast<EnKhadamati>();
                foreach (var item in values)
                {
                    cmbWater.Items.Add(item.GetDisplay());
                    cmbGas.Items.Add(item.GetDisplay());
                    cmbBarq.Items.Add(item.GetDisplay());
                    cmbTell.Items.Add(item.GetDisplay());
                }
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
                lblOwnerAddress.Text = owner?.Address;
                lblOwnerDateBirth.Text = owner?.DateBirth;
                lblOwnerFatherName.Text = owner?.FatherName;
                lblOwnerNCode.Text = owner?.NationalCode;
                lblOwnerName.Text = owner?.Name;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async Task LoadUsersAsync()
        {
            try
            {
                var list = await UserBussines.GetAllAsync();
                userBindingSource.DataSource = list.Where(q => q.Status).OrderBy(q => q.Name).ToList();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async Task<ReturnedSaveFuncInfo> SetOptionsAsync(Guid buildingGuid)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                cls.OptionList = new List<BuildingRelatedOptionsBussines>();
                if (buildingGuid == Guid.Empty) return res;
                var list = await BuildingOptionsBussines.GetAllAsync();
                if (list.Count <= 0) return res;
                foreach (var item in list)
                    for (var i = 0; i < DGrid.RowCount; i++)
                        if (item.Guid == ((Guid?)DGrid[dgOptionGuid.Index, i].Value ?? Guid.Empty))
                        {
                            if (!(bool)DGrid[dgChecked.Index, i].Value) continue;
                            cls.OptionList.Add(new BuildingRelatedOptionsBussines()
                            {
                                Guid = Guid.NewGuid(),
                                Status = true,
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
        private async Task FillOptionsAsync(string search = "")
        {
            try
            {
                var list = await BuildingOptionsBussines.GetAllAsync(search);
                BuildingOptionBindingSource.DataSource = list.Where(q => q.Status).OrderBy(q => q.Name).ToList();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void SetRelatedOptions(Guid buildingGuid)
        {
            try
            {
                if (buildingGuid == Guid.Empty) return;
                var op = BuildingRelatedOptionsBussines.GetAll(buildingGuid, true);
                foreach (var item in op)
                    for (var i = 0; i < DGrid.RowCount; i++)
                        if (item.BuildingOptionGuid == ((Guid?)DGrid[dgOptionGuid.Index, i].Value ?? Guid.Empty))
                            DGrid[dgChecked.Index, i].Value = true;
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
        private void SaveImageToTemp()
        {
            try
            {
                var imagePath = Path.Combine(Application.StartupPath, "Temp");
                if (!Directory.Exists(imagePath)) Directory.CreateDirectory(imagePath);
                foreach (var item in cls.GalleryList)
                {
                    var fileName = Path.Combine(imagePath, item.ImageName + ".jpg");
                    try
                    {
                        var path = Path.Combine(Application.StartupPath, "Images");
                        var path_ = "";
                        if (item.ImageName.EndsWith(".jpg")) path_ = Path.Combine(path, item.ImageName);
                        else path_ = Path.Combine(path, item.ImageName + ".jpg");
                        File.Copy(path_, fileName);
                    }
                    catch
                    {
                    }
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async Task<ReturnedSaveFuncInfo> CheckValidationAsync()
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                if (string.IsNullOrWhiteSpace(txtCode.Text))
                {
                    res.AddError("کد ملک نمی تواند خالی باشد");
                    txtCode.Focus();
                }

                if (!await BuildingBussines.CheckCodeAsync(txtCode.Text.Trim(), cls.Guid))
                {
                    res.AddError("کد ملک وارد شده تکراری است");
                    txtCode.Focus();
                }

                if (owner == null)
                {
                    res.AddError("لطفا مالک را انتخاب نمایید");
                    btnSearchOwner.Focus();
                }


                if (txtRahnPrice1.Text == "0" && txtRahnPrice2.Text == "0" && txtEjarePrice1.Text == "0" &&
                    txtEjarePrice2.Text == "0" && txtSellPrice.Text == "0" && txtPishTotalPrice.Text == "0")
                {
                    res.AddError("لطفا یکی از فیلدهای مبلغ را وارد نمایید");
                    btnSearchOwner.Focus();
                }

                if (txtZirBana.Text == "0" && txtMasahat.Text == "0")
                {
                    res.AddError("لطفا مساحت و زیربنا را وارد نمایید");
                    btnSearchOwner.Focus();
                }

                if (cmbRegion.SelectedValue == null)
                {
                    res.AddError("لطفا محدوده ملک را وارد نمایید");
                    btnSearchOwner.Focus();
                }

                if (txtSaleSakht.Text.ParseToInt() > txtSaleParvane.Text.ParseToInt())
                {
                    res.AddError("سال ساخت نمی تواند از سال اخذ پروانه بزرگتر باشد");
                    btnSearchOwner.Focus();
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }
            return res;
        }
        private ReturnedSaveFuncInfo SetData()
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                cls.Code = txtCode.Text;
                cls.OwnerGuid = owner.Guid;
                cls.UserGuid = (Guid)cmbUser.SelectedValue;
                cls.BuildingStatus = EnBuildingStatus.Mojod;
                cls.SellPrice = txtSellPrice.TextDecimal;
                cls.QestPrice = txtQestPrice.TextDecimal;
                cls.VamPrice = txtVamPrice.TextDecimal;
                cls.Dang = txtDong.Text.ParseToInt();
                cls.DocumentType = (Guid)cmbSellSanadType.SelectedValue;
                cls.Tarakom = (EnTarakom)cmbSellTarakom.SelectedIndex;
                cls.RahnPrice1 = txtRahnPrice1.TextDecimal;
                cls.RahnPrice2 = txtRahnPrice2.TextDecimal;
                cls.EjarePrice1 = txtEjarePrice1.TextDecimal;
                cls.EjarePrice2 = txtEjarePrice2.TextDecimal;
                cls.RentalAutorityGuid = (Guid)cmbRentalAuthority.SelectedValue;
                cls.IsShortTime = chbShortRent.Checked;
                cls.IsOwnerHere = chbOwnerHere.Checked;
                cls.PishTotalPrice = txtPishTotalPrice.TextDecimal;
                cls.PishPrice = txtPishPrice.TextDecimal;
                cls.DeliveryDate = Calendar.ShamsiToMiladi(txtDeliveryDate.Text);
                cls.PishDesc = txtPishDesc.Text;
                cls.MoavezeDesc = txtMoavezeDesc.Text;
                cls.MosharekatDesc = txtMosharekatDesc.Text;

                if (cmbMasahat.SelectedIndex == 0)
                    cls.Masahat = txtMasahat.Text.ParseToInt();
                if (cmbMasahat.SelectedIndex == 1)
                    cls.Masahat = txtMasahat.Text.ParseToInt() * 10000;

                if (cmbZirBana.SelectedIndex == 0)
                    cls.ZirBana = txtZirBana.Text.ParseToInt();
                if (cmbZirBana.SelectedIndex == 1)
                    cls.ZirBana = txtZirBana.Text.ParseToInt() * 10000;

                cls.CityGuid = (Guid)cmbCity.SelectedValue;
                cls.RegionGuid = (Guid)cmbRegion.SelectedValue;
                cls.Address = txtAddress.Text;
                cls.BuildingConditionGuid = (Guid)cmbBuildingCondition.SelectedValue;
                cls.Side = (EnBuildingSide)cmbSide.SelectedIndex;
                cls.BuildingTypeGuid = (Guid)cmbBuildingType.SelectedValue;
                cls.ShortDesc = txtShortDesc.Text;
                cls.BuildingAccountTypeGuid = (Guid)cmbBAccountType.SelectedValue;
                cls.MetrazhTejari = txtMetrazhTejari.Text.ParseTofloat();
                cls.BuildingViewGuid = (Guid)cmbBView.SelectedValue;
                cls.FloorCoverGuid = (Guid)cmbBFloorCover.SelectedValue;
                cls.KitchenServiceGuid = (Guid)cmbKitchenService.SelectedValue;
                cls.Water = (EnKhadamati)cmbWater.SelectedIndex;
                cls.Barq = (EnKhadamati)cmbBarq.SelectedIndex;
                cls.Gas = (EnKhadamati)cmbGas.SelectedIndex;
                cls.Tell = (EnKhadamati)cmbTell.SelectedIndex;
                cls.TedadTabaqe = txtTedadTabaqe.Text.ParseToInt();
                cls.TabaqeNo = cmbTabaqeNo.Text.ParseToInt();
                cls.VahedPerTabaqe = txtTedadVahed.Text.ParseToInt();
                cls.MetrazhKouche = txtMetrazhKouche.Text.ParseTofloat();
                cls.Hashie = txtHashie.Text.ParseTofloat();
                cls.ErtefaSaqf = txtErtrfaSaqf.Text.ParseTofloat();
                cls.SaleSakht = txtSaleSakht.Text;
                cls.DateParvane = txtSaleParvane.Text;
                cls.ParvaneSerial = txtSerialParvane.Text;
                cls.BonBast = chbIsBonBast.Checked;
                cls.MamarJoda = chbIsMamarJoda.Checked;
                cls.RoomCount = txtTedadOtaq.Text.ParseToInt();
                cls.Image = image ?? "";
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
        }
        private ReturnedSaveFuncInfo SetImages()
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                var img = Path.Combine(Application.StartupPath, "Images");
                foreach (var item in cls.GalleryList)
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
                        Status = true,
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
        private async Task<ReturnedSaveFuncInfo> ShowMap(string city, string region)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                res.AddReturnedValue(await Utilities.PingHostAsync());
                if (res.HasError) return res;

                var sb = new StringBuilder();
                sb.Append("https://www.google.com/maps/place/");

                sb.Append(city + ", +");
                sb.Append(region);

                webGoogle.Navigate(sb.ToString());
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
        }
        private string LoadFromFile()
        {
            try
            {
                var fd = new OpenFileDialog
                {
                    Multiselect = false,
                    InitialDirectory = Application.StartupPath + "\\Images"
                };

                if (!Directory.Exists(fd.InitialDirectory))
                    Directory.CreateDirectory(fd.InitialDirectory);
                fd.Filter = "*.JPG;*.GIF;*.PNG|*.JPG;*.GIF;*.PNG";
                if (fd.ShowDialog() != DialogResult.OK) return null;
                var aa = new FileInfo(fd.FileName);
                var attache = 1;
                if (Application.StartupPath + "\\Images\\" + aa.Name != aa.FullName)
                {
                    var newName = "";
                    newName = aa.Name;
                    while (File.Exists(Application.StartupPath + "\\Images\\" + newName))
                    {
                        var nameLen = aa.Name.Length.ToString();
                        var extentionLength = aa.Extension.Length;
                        newName = aa.Name.Substring(0, (int)(nameLen.ParseToDouble() - extentionLength));
                        newName = newName + attache + aa.Extension;
                        attache++;
                    }
                    File.Copy(aa.FullName, Application.StartupPath + "\\Images\\" + newName);
                    return newName;
                }
                return aa.Name;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return null;
            }
        }

        public frmBuildingMain()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            cls = new BuildingBussines();
            superTabControl1.SelectedTab = superTabItem1;
            superTabControl2.SelectedTab = superTabItem8;
            action = EnLogAction.Insert;
        }
        public frmBuildingMain(Guid guid, bool isShowMode)
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            cls = BuildingBussines.Get(guid);
            owner = PeoplesBussines.Get(cls.OwnerGuid);
            SaveImageToTemp();
            superTabControl1.SelectedTab = superTabItem1;
            superTabControl2.SelectedTab = superTabItem8;
            superTabControlPanel1.Enabled = !isShowMode;
            superTabControlPanel2.Enabled = !isShowMode;
            superTabControlPanel3.Enabled = !isShowMode;
            superTabControlPanel4.Enabled = !isShowMode;
            superTabControlPanel5.Enabled = !isShowMode;
            superTabControlPanel6.Enabled = !isShowMode;
            btnFinish.Enabled = !isShowMode;
            action = EnLogAction.Update;
        }



        private async void frmBuildingMain_Load(object sender, EventArgs e) => await SetDataAsync();
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
        private async void cmbState_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbState.SelectedValue == null) return;
                var list = await CitiesBussines.GetAllAsync((Guid)cmbState.SelectedValue);
                CityBindingSource.DataSource = list.Where(q => q.Status).OrderBy(q => q.Name).ToList();
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
                var list = await RegionsBussines.GetAllAsync((Guid)cmbCity.SelectedValue);
                RegionBindingSource.DataSource = list.Where(q => q.Status).OrderBy(q => q.Name).ToList();

                if (chbGoogleMap.Checked)
                {
                    var res = await ShowMap(cmbCity.Text, cmbRegion.Text);
                    if (res.HasError)
                        frmNotification.PublicInfo.ShowMessage(res.ErrorMessage);
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                await FillOptionsAsync(txtSearch.Text);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void btnInsImage_Click(object sender, EventArgs e)
        {
            try
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
        private void frmBuildingMain_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                switch (e.KeyCode)
                {
                    case Keys.Enter:
                        if (!btnFinish.Focused && !btnCancel.Focused && !btnPrint.Focused)
                            SendKeys.Send("{Tab}");
                        break;
                    case Keys.F5:
                        btnFinish.PerformClick();
                        break;
                    case Keys.F10:
                        btnPrint.PerformClick();
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
            try
            {
                var isSendSms = false;
                if (cls.Guid == Guid.Empty)
                {
                    cls.Guid = Guid.NewGuid();
                    isSendSms = true;
                }

                res.AddReturnedValue(await CheckValidationAsync());
                if (res.HasError) return;

                res.AddReturnedValue(SetData());
                if (res.HasError) return;
                res.AddReturnedValue(await SetOptionsAsync(cls.Guid));
                if (res.HasError) return;
                for (var i = fPanel.Controls.Count - 1; i >= 0; i--)
                    fPanel.Controls[i].Dispose();

                res.AddReturnedValue(SetImages());
                if (res.HasError) return;
                res.AddReturnedValue(await cls.SaveAsync(true));
                if (res.HasError) return;


                if (!Settings.Classes.Payamak.IsSendToOwner.ParseToBoolean() || !isSendSms) return;
                var tr = await Payamak.FixSms.OwnerSend.SendAsync(cls);
                frmNotification.PublicInfo.ShowMessage(tr.HasError
                    ? tr.ErrorMessage
                    : "ارسال پیامک به مالک با موفقیت انجام شد");
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }
            finally
            {
                if (res.HasError)
                {
                    var frm = new FrmShowErrorMessage(res, "خطا در ذخیره سازی ملک");
                    frm.ShowDialog(this);
                    frm.Dispose();
                }
                else
                {
                    UserLog.Save(action, EnLogPart.Building);
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
        }
        private void txtDong_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                txtPishDong.Value = txtDong.Value;
                txtMoavezeDong.Value = txtDong.Value;
                txtMosharekatDong.Value = txtDong.Value;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void txtPishDong_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                txtDong.Value = txtPishDong.Value;
                txtMoavezeDong.Value = txtPishDong.Value;
                txtMosharekatDong.Value = txtPishDong.Value;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void txtMoavezeDong_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                txtDong.Value = txtMoavezeDong.Value;
                txtPishDong.Value = txtMoavezeDong.Value;
                txtMosharekatDong.Value = txtMoavezeDong.Value;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void txtMosharekatDong_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                txtDong.Value = txtMosharekatDong.Value;
                txtPishDong.Value = txtMosharekatDong.Value;
                txtMoavezeDong.Value = txtMosharekatDong.Value;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void cmbSellTarakom_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cmbMoavezeTarakom.SelectedIndex = cmbSellTarakom.SelectedIndex;
                cmbMosharekatTarakom.SelectedIndex = cmbSellTarakom.SelectedIndex;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void cmbMoavezeTarakom_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cmbSellTarakom.SelectedIndex = cmbMoavezeTarakom.SelectedIndex;
                cmbMosharekatTarakom.SelectedIndex = cmbMoavezeTarakom.SelectedIndex;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void cmbMosharekatTarakom_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cmbMoavezeTarakom.SelectedIndex = cmbMosharekatTarakom.SelectedIndex;
                cmbSellTarakom.SelectedIndex = cmbMosharekatTarakom.SelectedIndex;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void cmbSellSanadType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cmbPishSanadType.SelectedIndex = cmbSellSanadType.SelectedIndex;
                cmbMoavezeSanadType.SelectedIndex = cmbSellSanadType.SelectedIndex;
                cmbMosharekatSanadType.SelectedIndex = cmbSellSanadType.SelectedIndex;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void cmbPishSanadType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cmbSellSanadType.SelectedIndex = cmbPishSanadType.SelectedIndex;
                cmbMoavezeSanadType.SelectedIndex = cmbPishSanadType.SelectedIndex;
                cmbMosharekatSanadType.SelectedIndex = cmbPishSanadType.SelectedIndex;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void cmbMoavezeSanadType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cmbPishSanadType.SelectedIndex = cmbMoavezeSanadType.SelectedIndex;
                cmbSellSanadType.SelectedIndex = cmbMoavezeSanadType.SelectedIndex;
                cmbMosharekatSanadType.SelectedIndex = cmbMoavezeSanadType.SelectedIndex;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void cmbMosharekatSanadType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cmbPishSanadType.SelectedIndex = cmbMosharekatSanadType.SelectedIndex;
                cmbMoavezeSanadType.SelectedIndex = cmbMosharekatSanadType.SelectedIndex;
                cmbSellSanadType.SelectedIndex = cmbMosharekatSanadType.SelectedIndex;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void txtCode_Enter(object sender, EventArgs e)
        {
            txtSetter.Focus(txtCode);
        }
        private void txtSaleSakht_Enter(object sender, EventArgs e)
        {
            txtSetter.Focus(txtSaleSakht);
        }
        private void txtSaleParvane_Enter(object sender, EventArgs e)
        {
            txtSetter.Focus(txtSaleParvane);
        }
        private void txtSerialParvane_Enter(object sender, EventArgs e)
        {
            txtSetter.Focus(txtSerialParvane);
        }
        private void txtSerialParvane_Leave(object sender, EventArgs e)
        {
            txtSetter.Follow(txtSerialParvane);
        }
        private void txtSaleParvane_Leave(object sender, EventArgs e)
        {
            txtSetter.Follow(txtSaleParvane);
        }
        private void txtSaleSakht_Leave(object sender, EventArgs e)
        {
            txtSetter.Follow(txtSaleSakht);
        }
        private void txtCode_Leave(object sender, EventArgs e)
        {
            txtSetter.Follow(txtCode);
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                btnFinish.PerformClick();

                var reg = RegionsBussines.Get(cls.RegionGuid);
                var accType = BuildingAccountTypeBussines.Get(cls.BuildingAccountTypeGuid);
                var type = BuildingTypeBussines.Get(cls.BuildingTypeGuid);
                cls.RegionName = reg?.Name ?? "";
                cls.BuildingAccountTypeName = accType?.Name ?? "";
                cls.BuildingTypeName = type?.Name ?? "";
                var list = new List<object>() { cls };
                var cls_ = new ReportGenerator(StiType.Building_One, EnPrintType.Pdf_A4) { Lst = list };
                cls_.PrintNew();

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async void chbGoogleMap_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chbGoogleMap.Checked)
                {
                    picGoogle.Visible = false;
                    webGoogle.Visible = true;
                    var res = await ShowMap(cmbCity.Text, cmbRegion.Text);
                    if (res.HasError)
                        frmNotification.PublicInfo.ShowMessage(res.ErrorMessage);
                }
                else
                {
                    picGoogle.Visible = true;
                    webGoogle.Visible = false;
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async void cmbRegion_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (chbGoogleMap.Checked)
                {
                    var res = await ShowMap(cmbCity.Text, cmbRegion.Text);
                    if (res.HasError)
                        frmNotification.PublicInfo.ShowMessage(res.ErrorMessage);
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void binImage_Click(object sender, EventArgs e)
        {
            try
            {
                var pic = LoadFromFile();
                var picPath = Path.Combine(Application.StartupPath + "\\Images", pic);
                picImage.ImageLocation = picPath;
                image = pic;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
