using EntityCache.Bussines;
using Services;
using System;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace Building.UserControls.Objects
{
    public partial class UcDocumentType : UserControl
    {
        public Guid? SanadTypeGuid { get => (Guid?)cmbSellSanadType.SelectedValue; set => cmbSellSanadType.SelectedValue = value; }
        public UcDocumentType()
        {
            InitializeComponent();
            FillSanadType();
        }
        private void FillSanadType()
        {
            try
            {
                var list = DocumentTypeBussines.GetAll();
                sanadTypeBindingSource.DataSource = list.Where(q => q.Status).OrderBy(q => q.Name).ToList();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
