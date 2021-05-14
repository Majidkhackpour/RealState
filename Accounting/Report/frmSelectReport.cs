using System;
using System.Windows.Forms;
using MetroFramework.Forms;
using Services;

namespace Accounting.Report
{
    public partial class frmSelectReport : MetroForm
    {
        private void Roozname()
        {
            try
            {
                var frm = new frmFilterRoozname();
                frm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void TarazAzmayeshi()
        {
            try
            {
                var frm = new frmTarazAzmayeshi();
                frm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        public frmSelectReport() => InitializeComponent();

        private void lblRoozname_MouseEnter(object sender, System.EventArgs e) => txtSetter.Focus(lblRoozname);
        private void lblAzmayeshi_MouseEnter(object sender, System.EventArgs e) => txtSetter.Focus(lblAzmayeshi);
        private void lblTarazHesab_MouseEnter(object sender, System.EventArgs e) => txtSetter.Focus(lblTarazHesab);
        private void lblSoodZian_MouseEnter(object sender, System.EventArgs e) => txtSetter.Focus(lblSoodZian);
        private void lblTarazname_MouseEnter(object sender, System.EventArgs e) => txtSetter.Focus(lblTarazname);
        private void lblTarazname_MouseLeave(object sender, System.EventArgs e) => txtSetter.Follow(lblTarazname);
        private void lblSoodZian_MouseLeave(object sender, System.EventArgs e) => txtSetter.Follow(lblSoodZian);
        private void lblTarazHesab_MouseLeave(object sender, System.EventArgs e) => txtSetter.Follow(lblTarazHesab);
        private void lblAzmayeshi_MouseLeave(object sender, System.EventArgs e) => txtSetter.Follow(lblAzmayeshi);
        private void lblRoozname_MouseLeave(object sender, System.EventArgs e) => txtSetter.Follow(lblRoozname);
        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
        private void frmSelectReport_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                switch (e.KeyCode)
                {
                    case Keys.Escape: DialogResult = DialogResult.Cancel; Close(); break;
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void picRoozname_Click(object sender, EventArgs e) => Roozname();
        private void lblRoozname_Click(object sender, EventArgs e) => Roozname();
        private void picAzmayeshi_Click(object sender, EventArgs e) => TarazAzmayeshi();
        private void lblAzmayeshi_Click(object sender, EventArgs e) => TarazAzmayeshi();
    }
}
