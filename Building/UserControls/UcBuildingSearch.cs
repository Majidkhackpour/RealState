using System;
using System.Windows.Forms;
using Building.Building;
using EntityCache.Bussines;
using EntityCache.ViewModels;
using Services;

namespace UcBuildingSearch
{
    public partial class ucBuildingSearch : UserControl
    {
        private BuildingViewModel _bu;
        public ucBuildingSearch(BuildingViewModel bu)
        {
            try
            {
                InitializeComponent();
                _bu = bu;
                if (bu.Type != EnRequestType.Rahn)
                {
                    lblPrice1_.Visible = lblPrice2.Visible = lblPrice2_.Visible = false;
                    lblTabdil.Visible = lblTabdil_.Visible = false;
                }


                lblMobile.Text = bu.Mobile;
                lblAddress.Text = bu.Address;
                lblDesc.Text = bu.Description;
                lblTabdil.Text = bu.Tabdil;
                lblMetrazh.Text = bu.Metrazh + " متر";
                lblParent.Text = bu.Parent;
                lblPrice1.Text = bu.Price1.ToString("N0");
                lblPrice2.Text = bu.Price2 == 0 ? "-" : bu.Price2.ToString("N0");
                lblRegion.Text = bu.Region;
                lblRentalAuthority.Text = bu.RentalAuthority;
                lblRoomCount.Text = bu.RoomCount;
                lblSaleSakht.Text = bu.SaleSakht;
                lblTabaqe.Text = bu.Tabaqe;
                foreach (var item in bu.Options)
                    lblOptions.Text += item + " ,";
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async void lblParent_Click(object sender, System.EventArgs e)
        {
            try
            {
                var bu = await BuildingBussines.GetAsync(_bu.Guid);
                if (bu == null) return;
                var frm = new frmBuildingDetail(bu, false);
                frm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
