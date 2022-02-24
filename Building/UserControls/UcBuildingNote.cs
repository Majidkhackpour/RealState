using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            get
            {
                try
                {
                    _list?.Clear();
                    var controls = fPanel.Controls;
                    foreach (Control c in controls)
                        if (c is UcBuildingNoteDetails item)
                        {
                            if (_list == null) _list = new List<BuildingNoteBussines>();
                            _list.Add(new BuildingNoteBussines()
                            {
                                Guid = Guid.NewGuid(),
                                Modified = DateTime.Now,
                                Note = item.Note
                            });
                        }
                }
                catch (Exception ex)
                {
                    WebErrorLog.ErrorInstence.StartErrorLog(ex);
                }
                return _list;
            }
            set
            {
                try
                {
                    _list = value;
                    if (_list == null || _list.Count <= 0)
                    {
                        fPanel.Controls.Clear();
                        return;
                    }
                    fPanel.Controls.Clear();
                    foreach (var item in _list)
                    {
                        var c = new UcBuildingNoteDetails() { Note = item.Note, Width = fPanel.Width - 30 };
                        c.OnEdited += COnOnEdited;
                        c.OnDeleted += COnOnDeleted;
                        fPanel.Controls.Add(c);
                    }
                }
                catch (Exception ex)
                {
                    WebErrorLog.ErrorInstence.StartErrorLog(ex);
                }
            }
        }
        private Task COnOnDeleted(string note)
        {
            try
            {
                var n = Notes.FirstOrDefault(q => q.Note == note);
                if (n == null) return Task.CompletedTask;
                _list.Remove(n);
                Notes = _list;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
            return Task.CompletedTask;
        }
        private Task COnOnEdited(string note)
        {
            try
            {
                var n = Notes.FirstOrDefault(q => q.Note == note);
                if (n == null) return Task.CompletedTask;
                var frm = new frmBuildingTelegramText(note, "یادداشت");
                if (frm.ShowDialog(this) != DialogResult.OK) return Task.CompletedTask;
                _list.Remove(n);
                _list.Add(new BuildingNoteBussines()
                {
                    Guid = Guid.NewGuid(),
                    Modified = DateTime.Now,
                    Note = frm.TelegramText
                });
                Notes = _list;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
            return Task.CompletedTask;
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
                    Note = frm.TelegramText
                });
                Notes = _list;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
