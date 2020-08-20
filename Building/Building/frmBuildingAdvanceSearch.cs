using System;
using System.Collections.Generic;
using EntityCache.ViewModels;
using MetroFramework.Forms;
using Services;

namespace Building.Building
{
    public partial class frmBuildingAdvanceSearch : MetroForm
    {
        public frmBuildingAdvanceSearch(List<BuildingViewModel> list)
        {
            InitializeComponent();
            SetFiles(list);
        }


        private void SetFiles(List<BuildingViewModel> list)
        {
            try
            {
                foreach (var item in list)
                {
                    var a = new UcBuildingSearch.ucBuildingSearch(item);
                    fPnel.Controls.Add(a);
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }


    }
}
