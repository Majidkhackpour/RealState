using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityCache.Bussines;
using Services;

namespace Building.UserControls.Objects
{
    public partial class UcRentalAuthority : UserControl
    {
        public Guid? RentalAuthorityGuid
        {
            get => (Guid?)cmbRentalAuthority.SelectedValue;
            set
            {
                if (value == null) return;
                cmbRentalAuthority.SelectedValue = value;
            }
        }
        public UcRentalAuthority()
        {
            InitializeComponent();
            FillRentalAuthority();
        }
        private void FillRentalAuthority()
        {
            try
            {
                var list = RentalAuthorityBussines.GetAll();
                rentalBindingSource.DataSource = list.Where(q => q.Status).OrderBy(q => q.Name).ToList();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
