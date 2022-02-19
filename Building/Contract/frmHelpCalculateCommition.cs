using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;

namespace Building.Contract
{
    public partial class frmHelpCalculateCommition : MetroForm
    {
        public frmHelpCalculateCommition() => InitializeComponent();

        private void frmHelpCalculateCommition_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) Close();
        }
        private Task ucCancel_OnClick(object arg1, System.EventArgs arg2)
        {
            Close();
            return Task.CompletedTask;
        }
    }
}
