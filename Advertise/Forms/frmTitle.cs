using System;
using System.Text;
using System.Threading.Tasks;
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
        private async Task SetTextAsync()
        {
            try
            {
                txtTitle.Text = await GetTitleAsync();
                txtContent.Text = await GetContentAsync();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async Task<string> GetTitleAsync()
        {
            try
            {
                var regionName = "";
                var m = bu.Masahat;
                if (m <= 0) m = bu.ZirBana;
                if (bu.RegionGuid != Guid.Empty) 
                    regionName = (await RegionsBussines.GetAsync(bu.RegionGuid))?.Name ?? "";
                return $"{regionName} ** {m} متری {bu.RoomCount} خواب";
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return "";
            }
        }
        private async Task<string> GetContentAsync()
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
                {
                    var obj= await BuildingOptionsBussines.GetAsync(item.BuildingOptionGuid);
                    content.AppendLine(obj?.Name);
                }

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
        private async void frmTitle_Load(object sender, EventArgs e) => await SetTextAsync();
    }
}
