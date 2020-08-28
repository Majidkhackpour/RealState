using System;
using System.Drawing;
using System.Windows.Forms;
using MetroFramework.Forms;
using Peoples;
using Services;
using User;

namespace Accounting.Reception
{
    public partial class frmReceptionFilter : MetroForm
    {
        public frmReceptionFilter()
        {
            InitializeComponent();
        }

        #region LblSetter
        private void lblPeoples_MouseEnter(object sender, System.EventArgs e)
        {
            lblPeoples.ForeColor = Color.Red;
        }

        private void lblPeoples_MouseLeave(object sender, System.EventArgs e)
        {
            lblPeoples.ForeColor = Color.Black;
        }

        private void lblUser_MouseEnter(object sender, System.EventArgs e)
        {
            lblUser.ForeColor = Color.Red;
        }

        private void lblUser_MouseLeave(object sender, System.EventArgs e)
        {
            lblUser.ForeColor = Color.Black;
        }
        #endregion

        private void Peoples()
        {
            try
            {
                var frm = new frmShowPeoples(true);
                if (frm.ShowDialog() != DialogResult.OK) return;
                var frm1 = new frmShowReception(frm.SelectedGuid, EnAccountingType.Peoples);
                frm1.ShowDialog();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void Users()
        {
            try
            {
                var frm = new frmShowUsers(true);
                if (frm.ShowDialog() != DialogResult.OK) return;
                var frm1 = new frmShowReception(frm.SelectedGuid, EnAccountingType.Users);
                frm1.ShowDialog();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void lblPeoples_Click(object sender, System.EventArgs e)
        {
            try
            {
                Peoples();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void picPeoples_Click(object sender, EventArgs e)
        {
            try
            {
                Peoples();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void lblUser_Click(object sender, EventArgs e)
        {
            try
            {
                Users();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void picUsers_Click(object sender, EventArgs e)
        {
            try
            {
                Users();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void frmReceptionFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) Close();
        }
    }
}
