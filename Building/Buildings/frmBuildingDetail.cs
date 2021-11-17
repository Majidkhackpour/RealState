using EntityCache.Bussines;
using MetroFramework.Forms;
using Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsSerivces;
using Building.UserControls.Other;
using Building.UserControls.Rahn;
using Building.UserControls.Sell;

namespace Building.Buildings
{
    public partial class frmBuildingDetail : MetroForm
    {
        private BuildingBussines bu;
        readonly List<string> lstList = new List<string>();
        private bool _loadForCustomer = false, _isAddLog = true;

        private async Task SetDataAsync()
        {
            try
            {
                panel1.Focus();
                if (bu == null)
                {
                    this.ShowWarning("ملک موردنظر معتبر نمی باشد");
                    Close();
                    return;
                }

                lblCode.Text = $@"کد: {bu.Code}";

                if (bu.SellPrice > 0)
                {
                    lblPrice1.Text = $@"قیمت کل: {bu.SellPrice:N0} ** {NumberToString.Num2Str(((double)bu.SellPrice).ToString())} **";
                    if (bu.Masahat > 0)
                    {
                        var m = Math.Truncate(bu.SellPrice / bu.Masahat);
                        lblPrice2.Text = $@"قیمت هر متر زمین: {m:N0}";
                    }
                    else if (bu.ZirBana > 0)
                    {
                        var m = Math.Truncate(bu.SellPrice / bu.ZirBana);
                        lblPrice2.Text = $@"قیمت هر متر بنا: {m:N0}";
                    }
                }
                else if (bu.RahnPrice1 > 0 || bu.EjarePrice1 > 0)
                {
                    lblPrice1.Text = $@"ودیعه: {bu.RahnPrice1:N0} ** {NumberToString.Num2Str(((double)bu.RahnPrice1).ToString())} **";
                    lblPrice2.Text = $@"اجاره: {bu.EjarePrice1:N0} ** {NumberToString.Num2Str(((double)bu.EjarePrice1).ToString())} **";
                }
                else if (bu.PishPrice > 0)
                {
                    lblPrice1.Text = $@"قیمت کل: {bu.PishTotalPrice:N0} ** {NumberToString.Num2Str(((double)bu.PishTotalPrice).ToString())} **";
                    lblPrice2.Text = $@"پیش پرداخت: {bu.PishPrice:N0} ** {NumberToString.Num2Str(((double)bu.PishPrice).ToString())} **";
                }

                lblTitle.Text = bu?.Parent?.GetDisplay();

                GetContent();
                BuildingOptionBindingSource.DataSource = bu?.OptionList;
                var desc = $"کد ملک:( {bu.Code} ) ** محدوده:( {bu.RegionName} ) ** آدرس:( {bu.Address} )";
                if (!_loadForCustomer && _isAddLog)
                {
                    await UserLogBussines.SaveBuildingLogAsync(EnLogAction.ManagerView, bu.Guid, desc);
                    var city = await CitiesBussines.GetAsync(bu.CityGuid);
                    lblAddress.Text = $@"{city.Name} - {bu.RegionName} - {bu.Address}";
                }
                else if (_loadForCustomer && _isAddLog)
                    await UserLogBussines.SaveBuildingLogAsync(EnLogAction.CustomerView, bu.Guid, desc);

                if (!_loadForCustomer)
                {
                    grpOwner.Visible = true;
                    var owner = await PeoplesBussines.GetAsync(bu.OwnerGuid, bu?.Guid);
                    if (owner != null)
                    {
                        lblOwnerName.Text = owner.Name;
                        lblOwnerAddress.Text = owner.Address;

                        if (owner?.TellList?.Count >= 1)
                        {
                            var title1 = owner?.TellList[0]?.Title ?? "";
                            var number1 = owner?.TellList[0]?.Tell ?? "";
                            lblTell1.Text = $@"{title1}: {number1}";
                        }

                        if (owner?.TellList?.Count >= 2)
                        {
                            var title2 = owner?.TellList[1]?.Title ?? "";
                            var number2 = owner?.TellList[1]?.Tell ?? "";
                            lblTell2.Text = $@"{title2}: {number2}";
                        }

                        if (owner?.TellList?.Count >= 3)
                        {
                            var title3 = owner?.TellList[2]?.Title ?? "";
                            var number3 = owner?.TellList[2]?.Tell ?? "";
                            lblTell3.Text = $@"{title3}: {number3}";
                        }

                        if (owner?.TellList?.Count >= 4)
                        {
                            var title4 = owner?.TellList[3]?.Title ?? "";
                            var number4 = owner?.TellList[3]?.Tell ?? "";
                            lblTell4.Text = $@"{title4}: {number4}";
                        }
                    }
                }
                else grpOwner.Visible = false;

                txtShortDesc.Text = bu.ShortDesc;

                if (!string.IsNullOrEmpty(bu.Image))
                {
                    var picPath = Path.Combine(Application.StartupPath + "\\Images", bu.Image);
                    picBox.ImageLocation = picPath;
                }

                if (bu.GalleryList != null && bu.GalleryList.Count > 0)
                {
                    fPanel.Controls.Clear();
                    lstList.Clear();
                    foreach (var image in bu.GalleryList)
                    {
                        var a = Path.Combine(Application.StartupPath, "Images");
                        var b = "";
                        b = !image.ImageName.EndsWith(".jpg")
                            ? Path.Combine(a, image.ImageName + ".jpg")
                            : Path.Combine(a, image.ImageName);
                        lstList.Add(b);
                    }

                    if (!string.IsNullOrEmpty(bu.Image))
                        lstList.Add(Path.Combine(Application.StartupPath + "\\Images", bu.Image));

                    Make_Picture_Boxes(lstList);
                }
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
                UserControl uc = null;
                switch (bu.Parent)
                {
                    case EnBuildingParent.SellAprtment:
                        uc = new UcBuildingSell_Appartment() { Building = bu };
                        break;
                    case EnBuildingParent.SellHome:
                        uc = new UcBuildingSell_Home() { Building = bu };
                        break;
                    case EnBuildingParent.SellLand:
                        uc = new UcBuildingSell_Land() { Building = bu };
                        break;
                    case EnBuildingParent.SellVilla:
                        uc = new UcBuildingSell_Villa() { Building = bu };
                        break;
                    case EnBuildingParent.SellStore:
                        uc = new UcBuildingSell_Store() { Building = bu };
                        break;
                    case EnBuildingParent.SellOffice:
                        uc = new UcBuildingSell_Office() { Building = bu };
                        break;
                    case EnBuildingParent.SellGarden:
                        uc = new UcBuildingSell_Garden() { Building = bu };
                        break;
                    case EnBuildingParent.SellOldHouse:
                        uc = new UcBuildingSell_OldHouse() { Building = bu };
                        break;
                    case EnBuildingParent.RentAprtment:
                        uc = new UcBuildingRahn_Appartment() { IsFullRahn = false, Building = bu };
                        break;
                    case EnBuildingParent.RentHome:
                        uc = new UcBuildingRahn_Home() { IsFullRahn = false, Building = bu };
                        break;
                    case EnBuildingParent.RentStore:
                        uc = new UcBuildingRahn_Store() { IsFullRahn = false, Building = bu };
                        break;
                    case EnBuildingParent.RentOffice:
                        uc = new UcBuildingRahn_Office() { IsFullRahn = false, Building = bu };
                        break;
                    case EnBuildingParent.FullRentAprtment:
                        uc = new UcBuildingRahn_Appartment() { IsFullRahn = true, Building = bu };
                        break;
                    case EnBuildingParent.FullRentHome:
                        uc = new UcBuildingRahn_Home() { IsFullRahn = true, Building = bu };
                        break;
                    case EnBuildingParent.FullRentStore:
                        uc = new UcBuildingRahn_Store() { IsFullRahn = true, Building = bu };
                        break;
                    case EnBuildingParent.FullRentOffice:
                        uc = new UcBuildingRahn_Office() { IsFullRahn = true, Building = bu };
                        break;
                    case EnBuildingParent.PreSellAprtment:
                        uc = new UcBuildingOther_Appartment() { IsPishForoush = true, Building = bu };
                        break;
                    case EnBuildingParent.PreSellHome:
                        uc = new UcBuildingOther_Home() { IsPishForoush = true, Building = bu };
                        break;
                    case EnBuildingParent.PreSellStore:
                        uc = new UcBuildingOther_Store() { IsPishForoush = true, Building = bu };
                        break;
                    case EnBuildingParent.PreSellOffice:
                        uc = new UcBuildingOther_Office() { IsPishForoush = true, Building = bu };
                        break;
                    case EnBuildingParent.MoavezeAprtment:
                        uc = new UcBuildingOther_Appartment() { IsPishForoush = false, Building = bu };
                        break;
                    case EnBuildingParent.MoavezeHome:
                        uc = new UcBuildingOther_Home() { IsPishForoush = false, Building = bu };
                        break;
                    case EnBuildingParent.MoavezeStore:
                        uc = new UcBuildingOther_Store() { IsPishForoush = false, Building = bu };
                        break;
                    case EnBuildingParent.MoavezeOffice:
                        uc = new UcBuildingOther_Office() { IsPishForoush = true, Building = bu };
                        break;
                    case EnBuildingParent.MosharekatAprtment:
                        uc = new UcBuildingOther_Appartment() { IsPishForoush = false, Building = bu };
                        break;
                    case EnBuildingParent.MosharekatHome:
                        uc = new UcBuildingOther_Home() { IsPishForoush = false, Building = bu };
                        break;
                }

                if (uc != null) LoadContent(uc);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void LoadContent(UserControl uc)
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
                        picbox.Name = lst[i];
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
        private void picbox_Click(object sender, EventArgs e)
        {
            try
            {
                picBox.ImageLocation = ((PictureBox)sender).Name;
            }
            catch (Exception exception)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(exception);
            }
        }
        public frmBuildingDetail(BuildingBussines _bu, bool loadForCustomer, bool isAddLog = true)
        {
            InitializeComponent();
            exPanel.Expanded = false;
            bu = _bu;
            _loadForCustomer = loadForCustomer;
            _isAddLog = isAddLog;
        }
        private async void frmBuildingDetail_Load(object sender, System.EventArgs e) => await SetDataAsync();
        private void frmBuildingDetail_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) Close();
        }
    }
}
