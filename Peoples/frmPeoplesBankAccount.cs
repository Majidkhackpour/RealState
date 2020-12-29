using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityCache.Bussines;
using MetroFramework.Forms;
using Services;

namespace Peoples
{
    public partial class frmPeoplesBankAccount : MetroForm
    {

        private async Task LoadDataAsync(Guid parentGuid, string search = "")
        {
            try
            {
                var list = await PeoplesBankAccountBussines.GetAllAsync(parentGuid, search);
                peoplesAccountBindingSourcr.DataSource = list.ToSortableBindingList();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        public Guid ParentGuid { get; set; }
        public frmPeoplesBankAccount(Guid guid)
        {
            InitializeComponent();
            ParentGuid = guid;
        }

        private async void frmPeoplesBankAccount_Load(object sender, EventArgs e)
        {
            try
            {
                await LoadDataAsync(ParentGuid);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private async void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                await LoadDataAsync(ParentGuid, txtSearch.Text);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void frmPeoplesBankAccount_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                switch (e.KeyCode)
                {
                    case Keys.Escape:
                        if (!string.IsNullOrEmpty(txtSearch.Text))
                        {
                            txtSearch.Text = "";
                            return;
                        }
                        Close();
                        break;
                    case Keys.Down:
                        if (txtSearch.Focused)
                            DGrid.Focus();
                        break;
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void DGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DGrid.Rows[e.RowIndex].Cells["dgRadif"].Value = e.RowIndex + 1;
        }
    }
}
