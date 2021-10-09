using EntityCache.Bussines;
using Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace Building.UserControls
{
    public partial class UcBuildingMedia : UserControl
    {
        private List<BuildingMediaBussines> lstMedia = new List<BuildingMediaBussines>();
        public List<BuildingMediaBussines> MediaList
        {
            get
            {
                try
                {
                    var img = Path.Combine(Application.StartupPath, "Media");
                    if (!Directory.Exists(img)) Directory.CreateDirectory(img);

                    lstMedia = new List<BuildingMediaBussines>();
                    foreach (var item in lstMedia)
                    {
                        var extention = Path.GetExtension(item.MediaName);
                        var newName = Guid.NewGuid() + $"{extention}";
                        var fileName = Path.Combine(img, newName);
                        try
                        {
                            if (!File.Exists(fileName))
                                File.Copy(item.MediaName, fileName);
                        }
                        catch { }

                        var a = new BuildingMediaBussines()
                        {
                            Guid = Guid.NewGuid(),
                            MediaName = newName
                        };
                        lstMedia.Add(a);
                    }
                }
                catch (Exception ex)
                {
                    WebErrorLog.ErrorInstence.StartErrorLog(ex);
                }
                return lstMedia;
            }
            set
            {
                try
                {
                    lstMedia = value;
                    if (lstMedia != null && lstMedia.Count != 0)
                        foreach (var item in lstMedia)
                        {
                            var a = Path.Combine(Application.StartupPath, "Media");
                            var b = Path.Combine(a, item.MediaName);
                            lstMedia.Add(new BuildingMediaBussines()
                            {
                                Guid = item.Guid,
                                MediaName = b
                            });
                        }
                    MediaBindingSource.DataSource = lstMedia?.ToList();
                }
                catch (Exception ex)
                {
                    WebErrorLog.ErrorInstence.StartErrorLog(ex);
                }
            }
        }
        public UcBuildingMedia() => InitializeComponent();
        private void btnAddMedia_Click(object sender, EventArgs e)
        {
            try
            {
                if (InvokeRequired)
                {
                    var t = new Thread(() =>
                    {
                        var ofd = new OpenFileDialog { Multiselect = true, RestoreDirectory = true };
                        if (ofd.ShowDialog(this) != DialogResult.OK) return;
                        foreach (var name in ofd.FileNames)
                            lstMedia.Add(new BuildingMediaBussines()
                            {
                                Guid = Guid.NewGuid(),
                                MediaName = name
                            });
                    });

                    t.SetApartmentState(ApartmentState.STA);
                    t.Start();
                    t.Join();
                }
                else
                {
                    var ofd = new OpenFileDialog { Multiselect = true, RestoreDirectory = true };
                    if (ofd.ShowDialog(this) != DialogResult.OK) return;
                    foreach (var name in ofd.FileNames)
                        lstMedia.Add(new BuildingMediaBussines()
                        {
                            Guid = Guid.NewGuid(),
                            MediaName = name
                        });
                }

                MediaBindingSource.DataSource = lstMedia?.ToList();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void btnRemoveMedia_Click(object sender, EventArgs e)
        {
            try
            {
                if (DgridMedia.RowCount <= 0 || DgridMedia.CurrentRow == null) return;
                var name = DgridMedia[mediaNameDataGridViewTextBoxColumn.Index, DgridMedia.CurrentRow.Index]?.Value?.ToString();
                if (string.IsNullOrEmpty(name)) return;
                var index = lstMedia.FirstOrDefault(q => q.MediaName == name);
                if (index == null) return;
                lstMedia.Remove(index);
                MediaBindingSource.DataSource = lstMedia?.ToList();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
