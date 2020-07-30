using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityCache.Bussines;
using MetroFramework.Forms;
using PacketParser;
using PacketParser.Services;

namespace Payamak.PhoneBook
{
    public partial class frmShowPhoneBook : MetroForm
    {
        public Guid ParentGuid { get; set; }
        private bool _st = true;
        private void LoadData(bool status, string search = "")
        {
            try
            {
                var list = PhoneBookBussines.GetAll(ParentGuid, search, (EnPhoneBookGroup) cmbGroup.SelectedIndex)
                    .Where(q => q.Status == status).ToList();
                phoneBookBindingSource.DataSource =
                    list.OrderBy(q => q.Name).ToSortableBindingList();
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
        public bool ST
        {
            get => _st;
            set
            {
                _st = value;
                if (_st)
                {
                    btnChangeStatus.Text = "غیرفعال (Ctrl+S)";
                    LoadData(ST, txtSearch.Text);
                    btnDelete.Text = "حذف (Del)";
                }
                else
                {
                    btnChangeStatus.Text = "فعال (Ctrl+S)";
                    LoadData(ST, txtSearch.Text);
                    btnDelete.Text = "فعال کردن";
                }
            }
        }
        public frmShowPhoneBook(Guid guid)
        {
            InitializeComponent();
            ParentGuid = guid;
            line1.Visible = false;
            btnDelete.Visible = false;
            btnChangeStatus.Visible = false;
            btnEdit.Visible = false;
            btnInsert.Visible = false;
            btnView.Visible = false;
            cmbGroup.Enabled = false;
        }

        public frmShowPhoneBook()
        {
            InitializeComponent();
            ParentGuid = Guid.Empty;
        }

        private void frmShowPhoneBook_Load(object sender, EventArgs e)
        {
            LoadGroups();
            LoadData(ST);
        }

        private void DGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DGrid.Rows[e.RowIndex].Cells["dgRadif"].Value = e.RowIndex + 1;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                LoadData(ST, txtSearch.Text);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void frmShowPhoneBook_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                switch (e.KeyCode)
                {
                    case Keys.Insert:
                        btnInsert.PerformClick();
                        break;
                    case Keys.F7:
                        btnEdit.PerformClick();
                        break;
                    case Keys.Delete:
                        btnDelete.PerformClick();
                        break;
                    case Keys.F12:
                        btnView.PerformClick();
                        break;
                    case Keys.S:
                        if (e.Control) ST = !ST;
                        break;
                    case Keys.Escape:
                        Close();
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

        private void btnChangeStatus_Click(object sender, EventArgs e)
        {
            ST = !ST;
        }
    }
}
