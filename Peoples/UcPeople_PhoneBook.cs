using EntityCache.Bussines;
using Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Peoples
{
    public partial class UcPeople_PhoneBook : UserControl
    {
        private List<PhoneBookBussines> _master;
        public List<PhoneBookBussines> PhoneBookList
        {
            get => _master ?? new List<PhoneBookBussines>();
            set
            {
                _master = value;
                LoadTells();
            }
        }
        private void LoadTells()
        {
            try
            {
                txtTell.Text = "";
                cmbTitles.Text = "";
                phoneBookBindingSource.DataSource = PhoneBookList?.ToSortableBindingList();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        public UcPeople_PhoneBook() => InitializeComponent();
        private async Task FillPhoneBookTitleAsync()
        {
            try
            {
                var list = await PhoneBookBussines.GetAllTitlesAsync();
                cmbTitles.Items.Clear();
                if (list == null || list.Count <= 0) return;
                cmbTitles.Items.AddRange(list.ToArray());
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async void btnInsTell_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtTell.Text)) return;
                if (PhoneBookList.Count <= 0) return;
                foreach (var item in PhoneBookList)
                    if (txtTell.Text.Trim() == item.Tell)
                        return;
                PhoneBookList.Add(new PhoneBookBussines()
                {
                    Guid = Guid.NewGuid(),
                    Modified = DateTime.Now,
                    Tell = txtTell.Text,
                    Group = EnPhoneBookGroup.Peoples,
                    Title = cmbTitles.Text
                });
                LoadTells();
                await FillPhoneBookTitleAsync();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void btnDelTell_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGridTell.RowCount <= 0) return;
                if (DGridTell.CurrentRow == null) return;
                var tagGuid = (Guid)DGridTell[dgTellGuid.Index, DGridTell.CurrentRow.Index].Value;
                var index = PhoneBookList.FindIndex(q => q.Guid == tagGuid);
                PhoneBookList.RemoveAt(index);
                LoadTells();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void DGridTell_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DGridTell.Rows[e.RowIndex].Cells["tRadif"].Value = e.RowIndex + 1;
        }
        private void txtTell_Enter(object sender, EventArgs e) => txtSetter.Focus(txtTell);
        private void txtTell_Leave(object sender, EventArgs e) => txtSetter.Follow(txtTell);
    }
}
