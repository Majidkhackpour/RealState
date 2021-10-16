using System;
using System.Windows.Forms;
using EntityCache.Bussines;
using Services;

namespace Building.UserControls
{
    public partial class UcBuildingCode : UserControl
    {
        private Guid _userGuid;
        public string Code
        {
            get => txtCode.Text;
            set => txtCode.Text = string.IsNullOrEmpty(value.RemoveNoNumbers()) ? BuildingBussines.NextCode() : value.RemoveNoNumbers();
        }
        public EnBuildingPriority Pirority
        {
            get => (EnBuildingPriority)cmbPirority.SelectedIndex;
            set
            {
                if ((int) value < 0) return;
                cmbPirority.SelectedIndex = (int) value;
            }
        }
        public DateTime CreateDate { get => Calendar.ShamsiToMiladi(lblDateNow.Text); set => lblDateNow.Text = Calendar.MiladiToShamsi(value); }
        public Guid UserGuid
        {
            get => _userGuid;
            set
            {
                _userGuid = value == Guid.Empty ? UserBussines.CurrentUser.Guid : value;
                lblUserName.Text = UserBussines.Get(_userGuid)?.Name ?? "";
            }
        }
        public UcBuildingCode()
        {
            InitializeComponent();
            FillPriority();
        }
        private void FillPriority()
        {
            try
            {
                cmbPirority.Items.Add(EnBuildingPriority.SoHigh.GetDisplay());
                cmbPirority.Items.Add(EnBuildingPriority.High.GetDisplay());
                cmbPirority.Items.Add(EnBuildingPriority.Medium.GetDisplay());
                cmbPirority.Items.Add(EnBuildingPriority.Low.GetDisplay());
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void txtCode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (!e.Shift) return;
                if (e.KeyCode != Keys.N) return;
                Code = BuildingBussines.NextCode();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
