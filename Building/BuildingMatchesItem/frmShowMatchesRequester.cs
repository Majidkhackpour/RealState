using System.Collections.Generic;
using System.Windows.Forms;
using EntityCache.Bussines;
using MetroFramework.Forms;

namespace Building.BuildingMatchesItem
{
    public partial class frmShowMatchesRequester : MetroForm
    {
        private List<BuildingRequestBussines> reqList;
        public frmShowMatchesRequester(List<BuildingRequestBussines>list)
        {
            InitializeComponent();
            reqList = list;
            reqBindingSource.DataSource = list;
        }
        private void frmShowMatchesRequester_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) Close();
        }
    }
}
