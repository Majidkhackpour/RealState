using EntityCache.Bussines;
using Services;
using System.Windows.Forms;

namespace Building.UserControls
{
    public partial class ucBuildingFeatures : UserControl
    {
        private BuildingBussines _bu;
        public BuildingBussines Building
        {
            get => _bu;
            set
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
                lblMamarJoda.Text = $@"تعداد مدیا: {_bu.MediaList?.Count ?? 0}";
                if (owner?.TellList == null || owner.TellList.Count <= 0) return;
                var title1 = owner?.TellList[0]?.Title ?? "";
                var title2 = owner?.TellList[1]?.Title ?? "";
                var title3 = owner?.TellList[2]?.Title ?? "";
                var title4 = owner?.TellList[3]?.Title ?? "";

                var number1 = owner?.TellList[0]?.Name ?? "";
                var number2 = owner?.TellList[1]?.Name ?? "";
                var number3 = owner?.TellList[2]?.Name ?? "";
                var number4 = owner?.TellList[3]?.Name ?? "";

                lblTell1.Text = $@"{title1} {number1}";
                lblTell2.Text = $@"{title2} {number2}";
                lblTell3.Text = $@"{title3} {number3}";
                lblTell4.Text = $@"{title4} {number4}";
            }
        }
        public ucBuildingFeatures() => InitializeComponent();
    }
}
