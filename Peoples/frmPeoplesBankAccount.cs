using System;
using System.Windows.Forms;
using EntityCache.Bussines;
using MetroFramework.Forms;
using Services;

namespace Peoples
{
    public partial class frmPeoplesBankAccount : MetroForm
    {

        private void LoadData(Guid parentGuid, string search = "")
        {
            try
            {
                var list = PeoplesBankAccountBussines.GetAll(parentGuid, search);
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

        private void frmPeoplesBankAccount_Load(object sender, EventArgs e)
        {
            try
            {
                LoadData(ParentGuid);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                LoadData(ParentGuid, txtSearch.Text);
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
                    case Keys.Escape: Close();
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
