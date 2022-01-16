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
        public Guid? RentalAuthorityGuid => (Guid?)cmbRentalAuthority.SelectedValue;

        public async Task SetRentalAuthorityGuidAsync(Guid? value)
        {
            try
            {
                if (rentalBindingSource.Count <= 0)
                    await FillRentalAuthorityAsync();
                if (value == null) return;
                cmbRentalAuthority.SelectedValue = value;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        public UcRentalAuthority() => InitializeComponent();
        private async Task FillRentalAuthorityAsync()
        {
            try
            {
                var list = await RentalAuthorityBussines.GetAllAsync();
                rentalBindingSource.DataSource = list?.Where(q => q.Status)?.OrderBy(q => q.Name)?.ToList();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
