using System;
using System.Text;
using System.Windows.Forms;
using EntityCache.Bussines;
using MetroFramework.Forms;
using Services;

namespace Advertise.Forms
{
    public partial class frmTitle : MetroForm
    {
        private BuildingBussines bu;
        public string AdvTitle => txtTitle.Text;
        public string AdvContent => txtContent.Text;
        private void SetText()
        {
            try
            {
                txtTitle.Text = Title();
                txtContent.Text = Content();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private string Title()
        {
            try
            {
                var regionName = "";
                if (bu.RegionGuid != Guid.Empty) regionName = RegionsBussines.Get(bu.RegionGuid)?.Name ?? "";
                return $"{regionName} ** {bu.Masahat} متری {bu.RoomCount} خواب";
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return "";
            }
        }
        private string Content()
        {
            try
            {
                var content = new StringBuilder();

                content.AppendLine($"محدوده: {bu.RegionName}");
                content.AppendLine($"متراژ: {bu.Masahat}");
                content.AppendLine($"سال ساخت: {bu.SaleSakht}");
                content.AppendLine($"زیربنا: {bu.ZirBana}");
                content.AppendLine($"کفپوش: {bu.FloorCoverName}");
                content.AppendLine($"آشپزخانه: {bu.KitchenServiceName}");

                if (bu.OptionList.Count <= 0) return content.ToString();

                content.AppendLine("امکانات ملک: ");
                foreach (var item in bu.OptionList)
                    content.AppendLine(item.OptionName);

                return content.ToString();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return "";
            }
        }
        public frmTitle(BuildingBussines _bu)
        {
            InitializeComponent();
            bu = _bu;
            SetText();
        }
        private void btnFinish_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
