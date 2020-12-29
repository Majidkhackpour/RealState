using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityCache.Bussines;
using MetroFramework.Forms;
using Services;

namespace Payamak.PhoneBook
{
    public partial class frmPhoneBookSearch : MetroForm
    {
        public List<string> SelectedNumber { get; set; } = new List<string>();
        private Guid parentGuid = Guid.Empty;
        private List<PhoneBookBussines> list = new List<PhoneBookBussines>();
        private async Task LoadDataAsync(string search = "")
        {
            try
            {
                if (list.Count <= 0)
                    list = await PhoneBookBussines.GetAllAsync(parentGuid, search,
                        (EnPhoneBookGroup) cmbGroup.SelectedIndex);
                list = list.Where(q => q.Status).ToList();
                LoadData_(parentGuid, search, (EnPhoneBookGroup)cmbGroup.SelectedIndex);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void LoadData_(Guid parentGuid, string search, EnPhoneBookGroup group)
        {
            try
            {

                if (string.IsNullOrEmpty(search)) search = "";
                var res = list;
                if (parentGuid != Guid.Empty)
                    res = list.Where(q => q.ParentGuid == parentGuid).ToList();
                if (group != EnPhoneBookGroup.All)
                    res = res.Where(q => q.Group == group).ToList();

                var searchItems = search.SplitString();
                if (searchItems?.Count > 0)
                    foreach (var item in searchItems)
                    {
                        if (!string.IsNullOrEmpty(item) && item.Trim() != "")
                        {
                            res = res.Where(x => x.Name.ToLower().Contains(item.ToLower()) ||
                                                 (!string.IsNullOrEmpty(x.Tell) &&
                                                  x.Tell.ToLower().Contains(item.ToLower())) ||
                                                 x.GroupName.ToLower().Contains(item.ToLower()))
                                ?.ToList();
                        }
                    }

                res = res?.OrderBy(o => o.Name).ToList();

                phoneBookBindingSource.DataSource = res.ToSortableBindingList();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void LoadGroups()
        {
            try
            {
                cmbGroup.Items.Add(EnPhoneBookGroup.All.GetDisplay());
                cmbGroup.Items.Add(EnPhoneBookGroup.Peoples.GetDisplay());
                cmbGroup.Items.Add(EnPhoneBookGroup.Users.GetDisplay());
                cmbGroup.Items.Add(EnPhoneBookGroup.Divar.GetDisplay());
                cmbGroup.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        public frmPhoneBookSearch(Guid _parentGuid)
        {
            InitializeComponent();
            parentGuid = _parentGuid;
        }

        private async void frmPhoneBookSearch_Load(object sender, EventArgs e)
        {
            LoadGroups();
            await LoadDataAsync();
        }

        private void DGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
        }

        private async void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                await LoadDataAsync(txtSearch.Text);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void frmPhoneBookSearch_KeyDown(object sender, KeyEventArgs e)
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
                    case Keys.F:
                        if (e.Control) txtSearch.Focus();
                        break;
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private async void cmbGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                await LoadDataAsync(txtSearch.Text);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGrid.RowCount <= 0) return;
                if (DGrid.CurrentRow == null) return;
                for (var i = 0; i < DGrid.RowCount; i++)
                {
                    if ((bool)DGrid[dgIsChecked.Index, i].Value)
                        SelectedNumber.Add(DGrid[dgNumber.Index, i].Value.ToString());
                }
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void DGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (DGrid.RowCount <= 0) return;
                if (e.ColumnIndex == dgIsChecked.Index)
                {
                    if (DGrid.CurrentRow != null)
                    {
                        DGrid[dgIsChecked.Index, DGrid.CurrentRow.Index].Value =
                            !(bool)DGrid[dgIsChecked.Index, DGrid.CurrentRow.Index].Value;


                        var phonebook = list.Find(q =>
                            q.Guid == (Guid) DGrid[dgGuid.Index, DGrid.CurrentRow.Index].Value);
                        phonebook.IsChecked = true;

                    }
                }
            }
            catch (Exception exception)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(exception);
            }
        }
    }
}
