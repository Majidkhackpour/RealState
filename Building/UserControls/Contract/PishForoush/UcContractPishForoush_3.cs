using System;
using System.Linq;
using System.Windows.Forms;
using Building.Buildings;
using EntityCache.Bussines;
using Services;
using Services.FilterObjects;

namespace Building.UserControls.Contract.PishForoush
{
    public partial class UcContractPishForoush_3 : UserControl
    {
        public event Action<Guid> OnBuildingSelect;
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
        private void FillBuildingAccountType()
        {
            try
            {
                var list = BuildingAccountTypeBussines.GetAll("");
                BuildingAccountTypeBindingSource.DataSource = list.Where(q => q.Status).ToList().OrderBy(q => q.Name);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void FillHitting_Colling()
        {
            try
            {
                var hittingList = BuildingBussines.GetAllHitting();
                var collingList = BuildingBussines.GetAllColling();
                cmbHitting.Items.Clear();
                cmbColling.Items.Clear();
                if (hittingList != null && hittingList.Count > 0)
                    cmbHitting.Items.AddRange(hittingList.ToArray());
                if (collingList != null && collingList.Count > 0)
                    cmbColling.Items.AddRange(collingList.ToArray());
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void FillBuildingView()
        {
            try
            {
                var list = BuildingViewBussines.GetAll();
                BuildingViewBindingSource.DataSource = list.Where(q => q.Status).ToList().OrderBy(q => q.Name);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        public float Masahat { get => (float)txtMasahat.Value; set => txtMasahat.Value = (decimal)value; }
        public float Dong { get => (float)txtDong.Value; set => txtDong.Value = (decimal)value; }
        public int RoomCount { get => (int)txtRoomCount.Value; set => txtRoomCount.Value = value; }
        public int TabaqeNo { get => cmbTabaqeNo.Text.ParseToInt(); set => cmbTabaqeNo.SelectedIndex = value + 3; }
        public int VahedNo { get => (int)txtVahedNo.Value; set => txtVahedNo.Value = value; }
        public int TabaqeCount { get => (int)txtTabaqeCount.Value; set => txtTabaqeCount.Value = value; }
        public int VahedCount { get => (int)txtVahedCount.Value; set => txtVahedCount.Value = value; }
        public EnBuildingSide? Side
        {
            get
            {
                if (cmbSide.SelectedIndex < 0) return null;
                return (EnBuildingSide?)cmbSide.SelectedIndex;
            }
            set
            {
                if (value == null) return;
                cmbSide.SelectedIndex = (int)value;
            }
        }
        public Guid BuildingAccountTypeGuid
        {
            get
            {
                if (cmbAccountType.SelectedValue == null) return Guid.Empty;
                return (Guid)cmbAccountType.SelectedValue;
            }
            set => cmbAccountType.SelectedValue = value;
        }
        public Guid? BuildingViewGuid
        {
            get => (Guid?)cmbBView.SelectedValue;
            set
            {
                if (value == null) return;
                cmbBView.SelectedValue = value;
            }
        }
        public string Consumable { get => txtConsumble.Text; set => txtConsumble.Text = value; }
        public string Hitting { get => cmbHitting.Text; set => cmbHitting.Text = value; }
        public string Colling { get => cmbColling.Text; set => cmbColling.Text = value; }
        public Guid OwnerGuid { get; set; }
        public UcContractPishForoush_3()
        {
            InitializeComponent();
            FillBuildingAccountType();
            FillCmbSide();
            FillHitting_Colling();
            FillBuildingView();
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
        private void btnChooseBuilding_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new frmShowBuildings(true, new BuildingFilter() { Status = true, OwnerGuid = OwnerGuid });
                if (frm.ShowDialog(this) != DialogResult.OK) return;
                var bu = BuildingBussines.Get(frm.SelectedGuid);
                if (bu == null) return;
                RaiseBuildingSelect(frm.SelectedGuid);
                Dong = bu.Dang;
                Masahat = bu.Masahat;
                RoomCount = bu.RoomCount;
                TabaqeNo = bu.TabaqeNo;
                VahedNo = bu.VahedNo;
                TabaqeCount = bu.TedadTabaqe;
                VahedCount = bu.VahedPerTabaqe;
                Side = bu.Side;
                BuildingAccountTypeGuid = bu.BuildingAccountTypeGuid;
                BuildingViewGuid = bu.BuildingViewGuid;
                Hitting = bu.Hiting;
                Colling = bu.Colling;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
