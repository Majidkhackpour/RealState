using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Building.Buildings;
using EntityCache.Bussines;
using EntityCache.Bussines.ReportBussines;
using Services;
using Services.FilterObjects;

namespace Building.UserControls.Contract.Sell
{
    public partial class UcContractSell_2 : UserControl
    {
        public event Func<Guid,Task> OnBuildingSelect;
        public float Dong { get => (float)txtDong.Value; set => txtDong.Value = (decimal)value; }
        public string BuildingType { get => txtBuildingType.Text; set => txtBuildingType.Text = value; }
        public string RegistryNo { get => txtRegistryNo.Text; set => txtRegistryNo.Text = value; }
        public string RegistryNoSub { get => txtRegistryNo_Sub.Text; set => txtRegistryNo_Sub.Text = value; }
        public string RegistryNoOrigin { get => txtRegistryNo_Origin.Text; set => txtRegistryNo_Origin.Text = value; }
        public int PartNo { get => (int)txtPartNo.Value; set => txtPartNo.Value = value; }
        public float Masahat { get => (float)txtMasahat.Value; set => txtMasahat.Value = (decimal)value; }
        public int ParkingNo { get => (int)txtParkingNo.Value; set => txtParkingNo.Value = value; }
        public int StoreNo { get => (int)txtStoreNo.Value; set => txtStoreNo.Value = value; }
        public float StoreMasahat { get => (float)txtStoteMasahat.Value; set => txtStoteMasahat.Value = (decimal)value; }
        public string BuildingNumber { get => txtBuildingNumber.Text; set => txtBuildingNumber.Text = value; }
        public string SanadSerial { get => txtSanadSerial.Text; set => txtSanadSerial.Text = value; }
        public int Page { get => (int)txtPage.Value; set => txtPage.Value = value; }
        public string Office { get => txtOffice.Text; set => txtOffice.Text = value; }
        public EnKhadamati Water { get => (EnKhadamati)cmbWater.SelectedIndex; set => cmbWater.SelectedIndex = (int)value; }
        public EnKhadamati Barq { get => (EnKhadamati)cmbBarq.SelectedIndex; set => cmbBarq.SelectedIndex = (int)value; }
        public EnKhadamati Gas { get => (EnKhadamati)cmbGas.SelectedIndex; set => cmbGas.SelectedIndex = (int)value; }
        public string Address { get => txtAddress.Text; set => txtAddress.Text = value; }
        public int PhoneCount { get => (int)txtPhoneCount.Value; set => txtPhoneCount.Value = value; }
        public string PhoneNumber { get => txtPhoneNumber.Text; set => txtPhoneNumber.Text = value; }
        public string Zip { get => txtZip.Text; set => txtZip.Text = value; }
        public Guid OwnerGuid { get; set; }
        public UcContractSell_2()
        {
            InitializeComponent();
            FillCmbKhadamt();
        }
        private void RaiseBuildingSelect(Guid guid)
        {
            try
            {
                var handler = OnBuildingSelect;
                if (handler != null) OnBuildingSelect?.Invoke(guid);
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
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async void btnChooseBuilding_Click(object sender, System.EventArgs e)
        {
            try
            {
                var frm = new frmShowBuildings(true, new BuildingFilter() { Status = true, IsSell = true, OwnerGuid = OwnerGuid });
                if (frm.ShowDialog(this) != DialogResult.OK) return;
                var bu =await BuildingReportBussines.GetAsync(frm.SelectedGuid);
                if (bu == null) return;
                RaiseBuildingSelect(frm.SelectedGuid);
                Dong = (float) bu.Dang;
                BuildingType = bu.BuildingTypeName;
                Masahat = bu.Masahat > 0 ? bu.Masahat : bu.ZirBana;
                Address = bu.Address;
                Water = bu.Water ?? EnKhadamati.None;
                Barq = bu.Barq ?? EnKhadamati.None;
                Gas = bu.Gas ?? EnKhadamati.None;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
