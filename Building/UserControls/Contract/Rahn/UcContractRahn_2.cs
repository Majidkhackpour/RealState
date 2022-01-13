using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Building.Buildings;
using EntityCache.Bussines;
using Services;
using Services.FilterObjects;

namespace Building.UserControls.Contract.Rahn
{
    public partial class UcContractRahn_2 : UserControl
    {
        public event Func<Guid,Task> OnBuildingSelect;
        public float Dong { get => (float)txtDong.Value; set => txtDong.Value = (decimal)value; }
        public string BuildingType { get => txtBuildingType.Text; set => txtBuildingType.Text = value; }
        public string Address { get => txtAddress.Text; set => txtAddress.Text = value; }
        public string BuildingPlack { get => txtBuildingPlack.Text; set => txtBuildingPlack.Text = value; }
        public int TabaqeNo { get => (int)txtTabaqeNo.Value; set => txtTabaqeNo.Value = value; }
        public int VahedNo { get => (int)txtVahedNo.Value; set => txtVahedNo.Value = value; }
        public string Zip { get => txtZip.Text; set => txtZip.Text = value; }
        public string RegistryNo { get => txtRegistryNo.Text; set => txtRegistryNo.Text = value; }
        public string RegistryNoSub { get => txtRegistryNo_Sub.Text; set => txtRegistryNo_Sub.Text = value; }
        public string RegistryNoOrigin { get => txtRegistryNo_Origin.Text; set => txtRegistryNo_Origin.Text = value; }
        public float Masahat { get => (float)txtMasahat.Value; set => txtMasahat.Value = (decimal)value; }
        public string SanadSerial { get => txtSanadSerial.Text; set => txtSanadSerial.Text = value; }
        public int Page { get => (int)txtPage.Value; set => txtPage.Value = value; }
        public string Office { get => txtOffice.Text; set => txtOffice.Text = value; }
        public EnKhadamati Water { get => (EnKhadamati)cmbWater.SelectedIndex; set => cmbWater.SelectedIndex = (int)value; }
        public EnKhadamati Barq { get => (EnKhadamati)cmbBarq.SelectedIndex; set => cmbBarq.SelectedIndex = (int)value; }
        public EnKhadamati Gas { get => (EnKhadamati)cmbGas.SelectedIndex; set => cmbGas.SelectedIndex = (int)value; }
        public string BuildingNumber { get => txtBuildingNumber.Text; set => txtBuildingNumber.Text = value; }
        public int RoomCount { get => (int)txtRoomCount.Value; set => txtRoomCount.Value = value; }
        public int ParkingNo { get => (int)txtParkingNo.Value; set => txtParkingNo.Value = value; }
        public int StoreNo { get => (int)txtStoreNo.Value; set => txtStoreNo.Value = value; }
        public float StoreMasahat { get => (float)txtStoteMasahat.Value; set => txtStoteMasahat.Value = (decimal)value; }
        public int PhoneCount { get => (int)txtPhoneCount.Value; set => txtPhoneCount.Value = value; }
        public string PhoneNumber { get => txtPhoneNumber.Text; set => txtPhoneNumber.Text = value; }
        public Guid OwnerGuid { get; set; }
        public UcContractRahn_2()
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
        private async void btnChooseBuilding_Click(object sender, EventArgs e)
        {
            try
            {
                var filter = new BuildingFilter()
                {
                    Status = true,
                    IsSell = false,
                    IsMosharekat = false,
                    IsPishForoush = false,
                    OwnerGuid = OwnerGuid
                };
                var frm = new frmShowBuildings(true, filter);
                if (frm.ShowDialog(this) != DialogResult.OK) return;
                var bu = await BuildingBussines.GetAsync(frm.SelectedGuid);
                if (bu == null) return;
                RaiseBuildingSelect(frm.SelectedGuid);
                Dong = bu.Dang;
                BuildingType = bu.BuildingTypeName;
                Masahat = bu.Masahat > 0 ? bu.Masahat : bu.ZirBana;
                Address = bu.Address;
                Water = bu.Water ?? EnKhadamati.None;
                Barq = bu.Barq ?? EnKhadamati.None;
                Gas = bu.Gas ?? EnKhadamati.None;
                TabaqeNo = bu.TabaqeNo;
                RoomCount = bu.RoomCount;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
