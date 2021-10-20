using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Services;

namespace Building.UserControls.Objects
{
    public partial class UcBuildingNoteDetails : UserControl
    {
        public event Func<string, Task> OnEdited;
        public event Func<string, Task> OnDeleted;
        private void RaiseEditEvent()
        {
            try
            {
                var handler = OnEdited;
                if (handler != null) OnEdited?.Invoke(Note);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void RaiseDeleteEvent()
        {
            try
            {
                var handler = OnDeleted;
                if (handler != null) OnDeleted?.Invoke(Note);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        public string Note { get => lblDesc.Text; set => lblDesc.Text = value; }
        public UcBuildingNoteDetails() => InitializeComponent();
        private void picEdit_Click(object sender, EventArgs e) => RaiseEditEvent();
        private void picDelete_Click(object sender, EventArgs e) => RaiseDeleteEvent();
    }
}
