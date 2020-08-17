using System.Windows.Forms;
using EntityCache.ViewModels;

namespace UcBuildingSearch
{
    public partial class ucBuildingSearch: UserControl
    {
        public ucBuildingSearch(BuildingViewModel bu)
        {
            InitializeComponent();
            lblDesc.Text = bu.Description;
            lblEvelator.Text = bu.Evelator.ToString();
            lblMetrazh.Text = bu.Metrazh.ToString();
            lblParcking.Text = bu.Parcking.ToString();
            lblParent.Text = bu.Parent;
            lblPrice1.Text = bu.Price1.ToString();
            lblPrice2.Text = bu.Price2.ToString();
            lblRegion.Text = bu.Region;
            lblRentalAuthority.Text = bu.RentalAuthority;
            lblRoomCount.Text = bu.RoomCount.ToString();
            lblSaleSakht.Text = bu.SaleSakht;
            lblStore.Text = bu.Store.ToString();
            lblTabaqeNo.Text = bu.TabaqeNo.ToString();
            lblTabaqeCount.Text = bu.TabaqeCount.ToString();
        }
    }
}
