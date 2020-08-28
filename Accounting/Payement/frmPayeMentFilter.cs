using System;
using System.Drawing;
using System.Windows.Forms;
using MetroFramework.Forms;
using Peoples;
using Services;
using User;

namespace Accounting.Payement
{
    public partial class frmPayeMentFilter : MetroForm
    {
        public frmPayeMentFilter()
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

        private void lblUsers_MouseEnter(object sender, System.EventArgs e)
        {
            lblUsers.ForeColor = Color.Red;
        }

        private void lblHazine_MouseEnter(object sender, System.EventArgs e)
        {
            lblHazine.ForeColor = Color.Red;
        }

        private void lblHazine_MouseLeave(object sender, System.EventArgs e)
        {
            lblHazine.ForeColor = Color.Black;
        }

        private void lblUsers_MouseLeave(object sender, System.EventArgs e)
        {
            lblUsers.ForeColor = Color.Black;
        }
        #endregion

        private void Peoples()
        {
            try
            {
                var frm = new frmShowPeoples(true);
                if (frm.ShowDialog() != DialogResult.OK) return;
                var frm1 = new frmShowPardakht(frm.SelectedGuid, EnAccountingType.Peoples);
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
                var frm1 = new frmShowPardakht(frm.SelectedGuid, EnAccountingType.Users);
                frm1.ShowDialog();
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

        private void lblPeoples_Click(object sender, EventArgs e)
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

        private void lblUsers_Click(object sender, EventArgs e)
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
    }
}
