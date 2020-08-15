using System.Windows.Forms;
using MetroFramework.Forms;

namespace Building.Building
{
    public partial class frmBuildingAdvanceSearch : MetroForm
    {
        public frmBuildingAdvanceSearch()
        {
            InitializeComponent();
            var a = new UcBuildingSearch.ucBuildingSearch();
            a.Dock = DockStyle.Top;
            var a2 = new UcBuildingSearch.ucBuildingSearch();
            var a3 = new UcBuildingSearch.ucBuildingSearch();
            var a4 = new UcBuildingSearch.ucBuildingSearch();
            var a5 = new UcBuildingSearch.ucBuildingSearch();
            var a6 = new UcBuildingSearch.ucBuildingSearch();
            var a7 = new UcBuildingSearch.ucBuildingSearch();
            var a8 = new UcBuildingSearch.ucBuildingSearch();
            fPnel.Controls.Add(a);
            fPnel.Controls.Add(a2);
            fPnel.Controls.Add(a3);
            fPnel.Controls.Add(a4);
            fPnel.Controls.Add(a5);
            fPnel.Controls.Add(a6);
            fPnel.Controls.Add(a7);
            fPnel.Controls.Add(a8);
        }
    }
}
