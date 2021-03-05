using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityCache.Bussines;
using MetroFramework.Forms;
using Services;

namespace Accounting.Reception
{
    public partial class frmShowReception : MetroForm
    {
        private async Task LoadDataAsync(string search = "")
        {
            try
            {
                var list = await ReceptionBussines.GetAllAsync(search);
                Invoke(new MethodInvoker(() => ReceptionBindingSource.DataSource =
                    list.OrderByDescending(q => q.Number).ToSortableBindingList()));
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        public frmShowReception()
        {
            InitializeComponent();
        }

        private async void mnuAdd_Click(object sender, System.EventArgs e)
        {
            try
            {
                var frm = new frmReceptionMain();
                if (frm.ShowDialog() == DialogResult.OK)
                    await LoadDataAsync();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async void frmShowReception_Load(object sender, EventArgs e) => await LoadDataAsync();
    }
}
