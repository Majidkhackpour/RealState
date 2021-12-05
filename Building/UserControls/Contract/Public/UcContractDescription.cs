using System.Windows.Forms;

namespace Building.UserControls.Contract.Public
{
    public partial class UcContractDescription : UserControl
    {
        public string Description { get => txtDesc.Text; set => txtDesc.Text = value; }
        public string Witness1 { get => txtWitness1.Text; set => txtWitness1.Text = value; }
        public string Witness2 { get => txtWitness2.Text; set => txtWitness2.Text = value; }
        public UcContractDescription() => InitializeComponent();
    }
}
