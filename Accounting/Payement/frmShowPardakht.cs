using System;
using System.Windows.Forms;
using MetroFramework.Forms;
using Services;

namespace Accounting.Payement
{
    public partial class frmShowPardakht : MetroForm
    {
        public frmShowPardakht(Guid receptorGuid, EnAccountingType _type)
        {
            InitializeComponent();
        }
    }
}
