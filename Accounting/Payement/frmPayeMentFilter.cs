using System;
using System.Drawing;
using System.Windows.Forms;
using Accounting.Hazine;
using MetroFramework.Forms;
using Peoples;
using Services;
using User;

namespace Accounting.Payement
{
    public partial class frmPayeMentFilter : MetroForm
    {
        private EnSanadType type;
        public Guid SelectedGuid { get; set; }
        public EnAccountingType AccountingType { get; set; }
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
                if (frm.ShowDialog(this) != DialogResult.OK) return;
                SelectedGuid = frm.SelectedGuid;
                AccountingType = EnAccountingType.Peoples;
                //if (type == EnSanadType.Auto)
                //{
                //    var frm1 = new frmShowPardakht(frm.SelectedGuid, EnAccountingType.Peoples);
                //    frm1.ShowDialog(this);
                //    return;
                //}

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void Users()
        {
            //try
            //{
            //    var frm = new frmShowUsers(true);
            //    if (frm.ShowDialog(this) != DialogResult.OK) return;
            //    SelectedGuid = frm.SelectedGuid;
            //    AccountingType = EnAccountingType.Users;
            //    if (type == EnSanadType.Auto)
            //    {
            //        var frm1 = new frmShowPardakht(frm.SelectedGuid, EnAccountingType.Users);
            //        frm1.ShowDialog(this);
            //        return;
            //    }
            //    DialogResult = DialogResult.OK;
            //    Close();
            //}
            //catch (Exception ex)
            //{
            //    WebErrorLog.ErrorInstence.StartErrorLog(ex);
            //}
        }

        private void Hazine()
        {
            try
            {
                //var frm = new frmShowHazine();
                //if (frm.ShowDialog(this) != DialogResult.OK) return;
                //SelectedGuid = frm.SelectedGuid;
                //AccountingType = EnAccountingType.Hazine;
                //if (type == EnSanadType.Auto)
                //{
                //    var frm1 = new frmShowPardakht(frm.SelectedGuid, EnAccountingType.Hazine);
                //    frm1.ShowDialog(this);
                //}
                //DialogResult = DialogResult.OK;
                //Close();
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

        private void frmPayeMentFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) Close();
        }

        private void picHazine_Click(object sender, EventArgs e)
        {
            try
            {
                Hazine();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void lblHazine_Click(object sender, EventArgs e)
        {
            try
            {
                Hazine();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
