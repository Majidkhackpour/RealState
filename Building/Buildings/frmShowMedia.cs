using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using EntityCache.Bussines;
using MetroFramework.Forms;
using Services;

namespace Building.Buildings
{
    public partial class frmShowMedia : MetroForm
    {
        private BuildingBussines _cls;

        private void ShowMedia(string mediaName)
        {
            try
            {
                var path = Path.Combine(Application.StartupPath, "Media");
                var file = Path.Combine(path, mediaName);
                if (!File.Exists(file)) return;
                Player.URL = file;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        public frmShowMedia(BuildingBussines bu)
        {
            try
            {
                InitializeComponent();
                _cls = bu;
                DGrid.Anchor = ((((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Right)));
                Player.Anchor = ((((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Right | AnchorStyles.Left)));
                WindowState = FormWindowState.Maximized;
                MediaBindingSource.DataSource = bu.MediaList?.ToList();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void DGrid_DoubleClick(object sender, System.EventArgs e)
        {
            try
            {
                if (DGrid.RowCount <= 0 || DGrid.CurrentRow == null) return;
                var guid = (Guid)DGrid[dgGuid.Index, DGrid.CurrentRow.Index].Value;
                var fileName = _cls.MediaList?.FirstOrDefault(q => q.Guid == guid)?.MediaName;
                if (string.IsNullOrEmpty(fileName)) return;
                ShowMedia(fileName);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void frmShowMedia_FormClosing(object sender, FormClosingEventArgs e)
        {
            Player.URL = null;
        }
    }
}
