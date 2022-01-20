using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityCache.Bussines;
using MetroFramework.Forms;
using Services;

namespace Peoples
{
    public partial class frmPeoplesBankAccount : MetroForm
    {
        private PeoplesBussines pe = null;
        private void LoadData(string search = "")
        {
            try
            {
                if (string.IsNullOrEmpty(search))
                    search = "";
                var res = pe?.BankList;
                var searchItems = search.SplitString();
                if (searchItems?.Count > 0)
                    foreach (var item in searchItems)
                    {
                        if (!string.IsNullOrEmpty(item) && item.Trim() != "")
                        {
                            res = res?.Where(x => x.BankName.ToLower().Contains(item.ToLower()) ||
                                                 x.Shobe.ToLower().Contains(item.ToLower()) ||
                                                 x.AccountNumber.ToLower().Contains(item.ToLower()))
                                ?.ToList();
                        }
                    }

                res = res?.OrderBy(o => o.BankName)?.ToList();
                peoplesAccountBindingSourcr.DataSource = res;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        public frmPeoplesBankAccount(PeoplesBussines obj)
        {
            InitializeComponent();
            pe = obj;
            ucHeader.Text = $"نمایش لیست حساب های بانکی {obj?.Name ?? ""}";
        }

        private void frmPeoplesBankAccount_Load(object sender, EventArgs e) => LoadData();
        private void txtSearch_TextChanged(object sender, EventArgs e) => LoadData(txtSearch.Text);
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
