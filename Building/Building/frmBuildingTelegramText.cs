using System.Windows.Forms;
using MetroFramework.Forms;

namespace Building.Building
{
    public partial class frmBuildingTelegramText : MetroForm
    {
        public string TelegramText { get => txtText.Text; set => txtText.Text = value; }
        public frmBuildingTelegramText(string text)
        {
            InitializeComponent();
            TelegramText = text;
        }
        private void btnFinish_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
        private void frmBuildingTelegramText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5) btnFinish.PerformClick();
            if (e.KeyCode == Keys.Escape) btnCancel.PerformClick();
        }
    }
}
