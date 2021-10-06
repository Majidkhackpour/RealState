using EntityCache.Bussines;
using Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Building.UserControls
{
    public partial class UcBuildingOptions : UserControl
    {
        private List<BuildingRelatedOptionsBussines> _opList;
        public List<BuildingRelatedOptionsBussines> OptionList
        {
            get
            {
                var res = new List<BuildingRelatedOptionsBussines>();
                try
                {
                    var list = BuildingOptionsBussines.GetAll();
                    if (list.Count <= 0) return null;
                    foreach (var item in list)
                        for (var i = 0; i < DGrid.RowCount; i++)
                            if (item.Guid == ((Guid?)DGrid[dgOptionGuid.Index, i].Value ?? Guid.Empty))
                            {
                                if (!(bool)DGrid[dgChecked.Index, i].Value) continue;
                                res.Add(new BuildingRelatedOptionsBussines()
                                {
                                    Guid = Guid.NewGuid(),
                                    BuildingOptionGuid = item.Guid,
                                    Modified = DateTime.Now
                                });
                            }
                }
                catch (Exception ex)
                {
                    WebErrorLog.ErrorInstence.StartErrorLog(ex);
                }

                return res;
            }
            set
            {
                try
                {
                    if (value == null || value.Count <= 0) return;
                    _opList = value;
                    foreach (var item in value)
                        for (var i = 0; i < DGrid.RowCount; i++)
                            if (item.BuildingOptionGuid == ((Guid?)DGrid[dgOptionGuid.Index, i].Value ?? Guid.Empty))
                                DGrid[dgChecked.Index, i].Value = true;
                }
                catch (Exception ex)
                {
                    WebErrorLog.ErrorInstence.StartErrorLog(ex);
                }
            }
        }
        public UcBuildingOptions()
        {
            InitializeComponent();
            FillOptions();
        }
        private void FillOptions(string search = "")
        {
            try
            {
                var list = BuildingOptionsBussines.GetAll(search);
                BuildingOptionBindingSource.DataSource = list.Where(q => q.Status).OrderBy(q => q.Name).ToList();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void txtSearch_TextChanged(object sender, EventArgs e) => FillOptions(txtSearch.Text);
        private void LoadFullOption()
        {
            try
            {
                for (var i = 0; i < DGrid.RowCount; i++)
                {
                    var val = DGrid[dgIsFullOption.Index, i].Value;
                    if (val != null && (bool) val)
                    {
                        DGrid[dgChecked.Index, i].Value = true;
                        DGrid.Rows[i].DefaultCellStyle.BackColor = Color.Khaki;
                    }
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void chbFullOption_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chbFullOption.Checked) LoadFullOption();
                else OptionList = _opList;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
