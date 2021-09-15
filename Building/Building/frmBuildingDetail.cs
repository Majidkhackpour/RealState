using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsSerivces;
using EntityCache.Bussines;
using MetroFramework.Forms;
using Services;

namespace Building.Building
{
    public partial class frmBuildingDetail : MetroForm
    {
        private BuildingBussines bu;
        readonly List<string> lstList = new List<string>();

        private async Task SetDataAsync()
        {
            try
            {
                if (bu == null)
                {
                    this.ShowWarning("ملک موردنظر معتبر نمی باشد");
                    Close();
                    return;
                }

                pnlPishForoush.Visible = pnlRahnInfo.Visible = pnlSellInfo.Visible = false;

                lblCode.Text = $@"کد: {bu.Code}";

                var type = "رهن و اجاره";
                if (bu.SellPrice > 0)
                {
                    type = "فروش";
                    lblPrice1.Text = $@"قیمت کل: {bu.SellPrice:N0}";
                    lblPrice2.Text = $@"قیمت هر متر زمین: {(bu.SellPrice / bu.Masahat):N0}";
                    pnlSellInfo.Visible = true;
                    lblTarakom.Text = bu.Tarakom?.GetDisplay();
                    lblVamPrice.Text = bu.VamPrice.ToString("N0");
                    lblQestPrice.Text = bu.QestPrice.ToString("N0");
                }
                else if (bu.RahnPrice1 > 0 || bu.EjarePrice1 > 0)
                {
                    type = "رهن و اجاره";
                    lblPrice1.Text = $@"ودیعه: {bu.RahnPrice1:N0}";
                    lblPrice2.Text = $@"اجاره: {bu.EjarePrice1:N0}";
                    pnlRahnInfo.Visible = true;
                    lblShortTime.Text = (bu.IsShortTime ?? false) ? "بله" : "خیر";
                    lblOwnerHere.Text = (bu.IsOwnerHere ?? false) ? "بله" : "خیر";
                    lblRental.Text = bu.RentalAuthorityName;
                }
                else if (bu.PishPrice > 0)
                {
                    type = "پیش فروش";
                    lblPrice1.Text = $@"قیمت کل: {bu.PishTotalPrice:N0}";
                    lblPrice2.Text = $@"پیش پرداخت: {bu.PishPrice:N0}";
                    pnlPishForoush.Visible = true;
                    lblPishPrice.Text = bu.PishPrice.ToString("N0");
                    lblPishTotalPrice.Text = bu.PishTotalPrice.ToString("N0");
                    lblDeliveryDate.Text = Calendar.MiladiToShamsi(bu.DeliveryDate);
                }
                lblTitle.Text = $@"{type} {bu.BuildingTypeName}";

                var city = await CitiesBussines.GetAsync(bu.CityGuid);
                lblAddress.Text = $@"{city.Name} - {bu.RegionName} - {bu.Address}";

                lblZirBana.Text = $@"{bu.ZirBana} متر";
                lblMasahat.Text = $@"{bu.Masahat} متر";
                lblTabaqeNo.Text = bu.TabaqeNo.ToString();
                lblVahedPerTabaqe.Text = $@"{bu.VahedPerTabaqe} واحد";
                lblTabaqeCount.Text = bu.TedadTabaqe.ToString();
                lblRoomCount.Text = $@"{bu.RoomCount} خوابه";
                lblDocumentType.Text = bu.DocumentTypeName;
                lblSide.Text = bu.Side.GetDisplay();
                lblView.Text = bu.BuildingViewName;
                lblFloorCover.Text = bu.FloorCoverName;
                lblKitchenService.Text = bu.KitchenServiceName;
                lblHitting.Text = bu.Hiting;
                lblColling.Text = bu.Colling;
                lblCondition.Text = bu.BuildingConditionName;
                lblAccountType.Text = bu.BuildingAccountTypeName;

                var owner = await PeoplesBussines.GetAsync(bu.OwnerGuid);
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

                lblDescription.Text = bu.ShortDesc;

                var year1 = Calendar.GetYearOfDateSh(Calendar.MiladiToShamsi(DateTime.Now));
                var year2 = bu.SaleSakht.Length > 4
                    ? Calendar.GetYearOfDateSh(bu.SaleSakht)
                    : bu.SaleSakht.ParseToInt();
                var dis = year1 - year2;
                lblSaleSakht.Text = dis <= 0 ? "نوساز" : $@"{dis} سال ساخت";

                if (bu.OptionList != null && bu.OptionList.Count > 0)
                {
                    if (bu.OptionList?.Count >= 1)
                        lblOption1.Text = bu.OptionList[0].OptionName;
                    if (bu.OptionList?.Count >= 2)
                        lblOption2.Text = bu.OptionList[1].OptionName;
                    if (bu.OptionList?.Count >= 3)
                        lblOption3.Text = bu.OptionList[2].OptionName;
                    if (bu.OptionList?.Count >= 4)
                        lblOption4.Text = bu.OptionList[3].OptionName;
                    if (bu.OptionList?.Count >= 5)
                        lblOption5.Text = bu.OptionList[4].OptionName;
                    if (bu.OptionList?.Count >= 6)
                        lblOption6.Text = bu.OptionList[5].OptionName;
                    if (bu.OptionList?.Count >= 7)
                        lblOption7.Text = bu.OptionList[6].OptionName;
                    if (bu.OptionList?.Count >= 8)
                        lblOption8.Text = bu.OptionList[7].OptionName;
                    if (bu.OptionList?.Count >= 9)
                        lblOption9.Text = bu.OptionList[8].OptionName;
                    if (bu.OptionList?.Count >= 10)
                        lblOption10.Text = bu.OptionList[9].OptionName;
                    if (bu.OptionList?.Count >= 11)
                        lblOption11.Text = bu.OptionList[10].OptionName;
                    if (bu.OptionList?.Count >= 12)
                        lblOption12.Text = bu.OptionList[11].OptionName;
                }

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
                        var b = Path.Combine(a, image.ImageName + ".jpg");
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
        public frmBuildingDetail(BuildingBussines _bu)
        {
            InitializeComponent();
            exPanel.Expanded = false;
            bu = _bu;
        }
        private async void frmBuildingDetail_Load(object sender, System.EventArgs e) => await SetDataAsync();
        private void frmBuildingDetail_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) Close();
        }
    }
}
