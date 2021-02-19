using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityCache.Bussines;
using MetroFramework.Forms;
using Services;

namespace Accounting.Check.DasteCheck
{
    public partial class frmShowCheckPages : MetroForm
    {
        public frmShowCheckPages(DasteCheckBussines parent)
        {
            InitializeComponent();
            lblBankName.Text = parent?.BankName;
            CheckPagesBindingSource.DataSource = parent?.CheckPages?.OrderBy(q => q.Number)?.ToSortableBindingList();
        }

        private void frmShowCheckPages_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) Close();
        }
    }
}
