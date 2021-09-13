using System;
using EntityCache.Bussines;
using Services;
using System.Windows.Forms;

namespace Building
{
    public partial class ucBuildingFeatures : UserControl
    {
        private BuildingBussines _bu;
        public BuildingBussines Building
        {
            get => _bu;
            set
            {
                try
                {
                    _bu = value;
                    if (_bu == null) return;
                    var owner = PeoplesBussines.Get(_bu.OwnerGuid);
                    lblNatCode.Text = $@"کدملی: {owner?.NationalCode}";
                    lblAddress.Text = $@"آدرس: {owner?.Address}";
                    lblDong.Text = $@"تعداد دانگ: {_bu.Dang}";
                    lblTarakom.Text = $@"تراکم: {_bu.Tarakom?.GetDisplay()}";
                    lblAllTabaqe.Text = $@"کل طبقات: {_bu.TedadTabaqe}";
                    lblTabaqeNo.Text = $@"شماره طبقه: {_bu.TabaqeNo}";
                    lblVahedPerTabaqe.Text = $@"واحد در هر طبقه: {_bu.VahedPerTabaqe}";
                    lblBonBast.Text = $@"کوچه بن بست: {(_bu.BonBast ? "بله" : "خیر")}";
                    lblMamarJoda.Text = $@"ورودی جدا: {(_bu.MamarJoda ? "بله" : "خیر")}";
                    lblPicCount.Text = $@"تعداد تصاویر: {_bu.GalleryList?.Count ?? 0}";
                    lblMediaCount.Text = $@"تعداد مدیا: {_bu.MediaList?.Count ?? 0}";
                    lblTelegramCount.Text = $@"ارسال به تلگرام: {_bu.TelegramCount}";
                    lblHitting.Text = $@"گرمایش: {_bu.Hiting}";
                    lblColling.Text = $@"سرمایش: {_bu.Colling}";


                    lblTell1.Text = "";
                    lblTell2.Text = "";
                    lblTell3.Text = "";
                    lblTell4.Text = "";

                    if (owner?.TellList == null || owner.TellList.Count <= 0) return;

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
                catch (Exception ex)
                {
                    WebErrorLog.ErrorInstence.StartErrorLog(ex);
                }
            }
        }
        public ucBuildingFeatures() => InitializeComponent();
    }
}
