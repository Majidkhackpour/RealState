using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Building.Buildings;
using Building.UserControls.Objects;
using EntityCache.Bussines;
using Services;

namespace Building.UserControls
{
    public partial class UcBuildingNote : UserControl
    {
        private List<BuildingNoteBussines> _list;
        public List<BuildingNoteBussines> Notes
        {
            get => _list;
            set
            {
                try
                {
                    _list = value;
                    if (_list == null || _list.Count <= 0) return;
                    foreach (var item in _list)
                    {
                        var c = new UcBuildingNoteDetails() { Note = item.Note, Width = fPanel.Width - 30 };
                        fPanel.Controls.Add(c);
                    }
                }
                catch (Exception ex)
                {
                    WebErrorLog.ErrorInstence.StartErrorLog(ex);
                }
            }
        }
        public UcBuildingNote() => InitializeComponent();
        private void picAddNote_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new frmBuildingTelegramText("", "یادداشت");
                if (frm.ShowDialog(this) != DialogResult.OK) return;
                _list.Add(new BuildingNoteBussines()
                {
                    Guid = Guid.NewGuid(),
                    Modified = DateTime.Now,
                    ServerStatus = ServerStatus.None,
                    ServerDeliveryDate = DateTime.Now,
                    Note = frm.TelegramText
                });
                var c = new UcBuildingNoteDetails() { Note = frm.TelegramText, Width = fPanel.Width - 30 };
                fPanel.Controls.Add(c);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
