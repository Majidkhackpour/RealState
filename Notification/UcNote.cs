using System.Windows.Forms;
using EntityCache.Bussines;

namespace Notification
{
    public partial class UcNote : UserControl
    {
        private NoteBussines _note;
        public NoteBussines Note
        {
            get => _note;
            set
            {
                _note = value;
                if (_note == null) return;
                lblTile.Text = _note.Title;
                lblContent.Text = _note.Description;
            }
        }
        public UcNote()=>InitializeComponent();
    }
}
