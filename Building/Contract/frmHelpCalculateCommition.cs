using System.Windows.Forms;
using MetroFramework.Forms;

namespace Building.Contract
{
    public partial class frmHelpCalculateCommition : MetroForm
    {
        public frmHelpCalculateCommition() => InitializeComponent();

        private void btnAddExcel_Click(object sender, System.EventArgs e) => Close();
        private void frmHelpCalculateCommition_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) Close();
        }
    }
}
