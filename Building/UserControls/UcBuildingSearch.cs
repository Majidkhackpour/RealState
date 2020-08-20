using System.Windows.Forms;
using EntityCache.ViewModels;
using Services;

namespace UcBuildingSearch
{
    public partial class ucBuildingSearch : UserControl
    {
        public ucBuildingSearch(BuildingViewModel bu)
        {
            InitializeComponent();

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
            lblPrice1.Text = bu.Price1.ToString("N0") + " ریال";
            if (bu.Price2 == 0) lblPrice2.Text = "-";
            else lblPrice2.Text = bu.Price2.ToString("N0") + " ریال";
            lblRegion.Text = bu.Region;
            lblRentalAuthority.Text = bu.RentalAuthority;
            lblRoomCount.Text = bu.RoomCount.ToString();
            lblSaleSakht.Text = bu.SaleSakht;
            lblTabaqeNo.Text = bu.TabaqeNo.ToString();
            lblTabaqeCount.Text = bu.TabaqeCount.ToString();
            foreach (var item in bu.Options)
                lblOptions.Text += item + " ,";
        }
    }
}
