using System;
using System.Windows.Forms;
using MetroFramework.Forms;
using PacketParser.Services;
using TMS.Class;
using User;

namespace RealState
{
    public partial class frmMain : MetroForm
    {
        private void SetClock()
        {
            try
            {
                lblHour.Text = DateTime.Now.Hour.ToString();
                if (lblHour.Text.Length == 1) lblHour.Text = "0" + DateTime.Now.Hour;
                lblMinute.Text = DateTime.Now.Minute.ToString();
                if (lblMinute.Text.Length == 1) lblMinute.Text = "0" + DateTime.Now.Minute;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void SetCalendar()
        {
            try
            {
                var prd = new MaftooxCalendar.MaftooxPersianCalendar.DateWork();
                lblDay.Text = prd.GetNumberDayInMonth().ToString();
                lblMounth.Text = prd.GetNameMonth();
                lblYear.Text = prd.GetNumberYear().ToString();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, System.EventArgs e)
        {
            lblSecond.Visible = true;
            pnlSubMenuBase.Visible = false;
            var tt = new ToolTip();
            tt.SetToolTip(picExit, "خروج");
            SetClock();
            SetCalendar();
        }

        private void picExit_Click(object sender, System.EventArgs e)
        {
            Application.Exit();
        }

        private void timerSecond_Tick(object sender, EventArgs e)
        {
            SetClock();
            if (lblSecond.Visible)
                lblSecond.Visible = false;
            else if (!lblSecond.Visible)
                lblSecond.Visible = true;
        }

        private void picBaseInfo_MouseEnter(object sender, EventArgs e)
        {
            try
            {
                picBaseInfo.Image = Properties.Resources.menu_;
                txtSetter.Focus(lblBaseInfo);
                pnlSubMenuBase.Visible = true;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void lblBaseInfo_MouseEnter(object sender, EventArgs e)
        {
            picBaseInfo_MouseEnter(null, null);
        }

        private void picBaseInfo_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                picBaseInfo.Image = Properties.Resources.menu;
                txtSetter.Follow(lblBaseInfo);
                pnlSubMenuBase.Visible = false;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void lblBaseInfo_MouseLeave(object sender, EventArgs e)
        {
            picBaseInfo_MouseLeave(null, null);
        }

        private void picUsers_MouseEnter(object sender, EventArgs e)
        {
            try
            {
                picUsers.Image = Properties.Resources.notification_user_;
                txtSetter.Focus(lblUsers);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void picUsers_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                picUsers.Image = Properties.Resources.notification_user;
                txtSetter.Follow(lblUsers);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void lblUsers_MouseEnter(object sender, EventArgs e)
        {
            picUsers_MouseEnter(null, null);
        }

        private void lblUsers_MouseLeave(object sender, EventArgs e)
        {
            picUsers_MouseLeave(null, null);
        }

        private void picUsers_Click(object sender, EventArgs e)
        {
            try
            {
                new frmShowUsers().ShowDialog();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void lblUsers_Click(object sender, EventArgs e)
        {
            picUsers_Click(null, null);
        }
    }
}
