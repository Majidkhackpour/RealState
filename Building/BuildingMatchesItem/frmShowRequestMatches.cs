using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Windows.Forms;
using EntityCache.Bussines;
using EntityCache.ViewModels;
using MetroFramework.Forms;
using Services;

namespace Building.BuildingMatchesItem
{
    public partial class frmShowRequestMatches : MetroForm
    {
        private List<BuildingRequestViewModel> matchesList;
        private ConcurrentDictionary<Guid, List<BuildingRequestBussines>> _dic =
            new ConcurrentDictionary<Guid, List<BuildingRequestBussines>>();

        public frmShowRequestMatches(List<BuildingRequestViewModel> list)
        {
            InitializeComponent();
            ucHeader.Text = "نمایش املاک و درخواست های مورد تطبیق";
            matchesList = list;
        }

        private void frmShowRequestMatches_Load(object sender, EventArgs e)
        {
            try
            {
                foreach (var model in matchesList) _dic.TryAdd(model.BuildingGuid, model.RequestList);
                MatchesBindingSource.DataSource = matchesList;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void frmShowRequestMatches_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Escape) Close();
                if (e.KeyCode == Keys.Enter)
                {
                    if (DGrid.RowCount <= 0 || DGrid.CurrentRow == null) return;
                    var guid = (Guid)DGrid[dgBuildingGuid.Index, DGrid.CurrentRow.Index].Value;
                    _dic.TryGetValue(guid, out var reqList);
                    if (reqList == null || reqList.Count <= 0) return;
                    new frmShowMatchesRequester(reqList).ShowDialog();
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
