using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityCache.Bussines;
using Services;

namespace Notification
{
    public partial class frmNaqz : Form
    {
        private int _startPosX;
        private int _startPosY;
        private List<NoteBussines> lstNotes;

        private async Task SetNotes()
        {
            try
            {
                if (lstNotes == null || lstNotes.Count <= 0) return;
                foreach (var item in lstNotes)
                {
                    Invoke(new MethodInvoker(() =>
                    {
                        var c = new UcNote() { Note = item, Width = fPanel.Width - 30 };
                        fPanel.Controls.Add(c);
                    }));
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        public frmNaqz(List<NoteBussines> notes)
        {
            InitializeComponent();
            lstNotes = notes;
            var workingArea = Screen.GetWorkingArea(this);
            Location = new Point(workingArea.Right - Size.Width, workingArea.Bottom - Size.Height);
            TopMost = true;
            _startPosY = Screen.PrimaryScreen.WorkingArea.Height;
        }

        private void ClosingTimer_Tick(object sender, System.EventArgs e) => Close();
        private void frmNaqz_Load(object sender, System.EventArgs e)
        {
            try
            {
                Styler.Start();
                ClosingTimer.Start();
                _startPosX = Screen.PrimaryScreen.WorkingArea.Width - Width;
                _startPosY = Screen.PrimaryScreen.WorkingArea.Height;
                Invoke(new MethodInvoker(() => SetDesktopLocation(_startPosX, _startPosY)));
                _ = Task.Run(SetNotes);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void Styler_Tick(object sender, EventArgs e)
        {
            try
            {
                _startPosY -= 5;

                if (_startPosY <= Screen.PrimaryScreen.WorkingArea.Height - Height)
                    Styler?.Stop();
                else
                    SetDesktopLocation(_startPosX, _startPosY);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void frmNaqz_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) Close();
        }
    }
}
