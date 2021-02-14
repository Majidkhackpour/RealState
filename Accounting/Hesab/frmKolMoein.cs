using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityCache.Bussines;
using MetroFramework.Forms;
using Services;

namespace Accounting.Hesab
{
    public partial class frmKolMoein : MetroForm
    {
        private async Task LoadKolAsync(string search = "")
        {
            try
            {
                var list = await KolBussines.GetAllAsync(search);
                KolBindingSource.DataSource = list?.OrderBy(q => q.Code).ToSortableBindingList();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async Task LoadMoeinAsync(string search = "")
        {
            try
            {
                var list = await MoeinBussines.GetAllAsync(search);
                MoeinBindingSource.DataSource = list?.OrderBy(q => q.Code).ToSortableBindingList();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        public frmKolMoein()
        {
            InitializeComponent();
        }

        private async void frmKolMoein_Load(object sender, EventArgs e)
        {
            await LoadKolAsync();
            await LoadMoeinAsync();
        }
    }
}
