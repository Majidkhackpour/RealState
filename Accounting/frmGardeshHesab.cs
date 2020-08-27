using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using EntityCache.Bussines;
using MetroFramework.Forms;
using Services;

namespace Accounting
{
    public partial class frmGardeshHesab : MetroForm
    {
        private Guid _hesabGuid;
        private EnAccountingType _type;

        private void LoadData(Guid hesabGuid, string search = "")
        {
            try
            {
                var list = GardeshHesabBussines.GetAll(hesabGuid, search).Where(q => q.Status).ToSortableBindingList();
                gardeshBindingSource.DataSource = list;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void SetLabels()
        {
            try
            {
                if (_type == EnAccountingType.Peoples)
                {
                   var hesab = PeoplesBussines.Get(_hesabGuid);
                   if (hesab == null) return;
                   lblName.Text = hesab.Name;
                   lblAccount.Text = hesab.Account_.ToString("N0");
                   if (hesab.Account == 0)
                   {
                       lblAccount.Text = "بی حساب";
                       lblAccount_.ForeColor = Color.Black;
                   }
                   if (hesab.Account > 0)
                   {
                       lblAccount_.Text = "بدهکار";
                       lblAccount_.ForeColor = Color.Red;
                   }
                   if (hesab.Account < 0)
                   {
                       lblAccount_.Text = "بستانکار";
                       lblAccount_.ForeColor = Color.Green;
                   }
                }
                else if (_type == EnAccountingType.Hazine)
                {
                   var hesab = HazineBussines.Get(_hesabGuid);
                   if (hesab == null) return;
                   lblName.Text = hesab.Name;
                   lblAccount.Text = hesab.Account_.ToString("N0");
                   if (hesab.Account == 0)
                   {
                       lblAccount.Text = "بی حساب";
                       lblAccount_.ForeColor = Color.Black;
                   }
                   if (hesab.Account > 0)
                   {
                       lblAccount_.Text = "بدهکار";
                       lblAccount_.ForeColor = Color.Red;
                   }
                   if (hesab.Account < 0)
                   {
                       lblAccount_.Text = "بستانکار";
                       lblAccount_.ForeColor = Color.Green;
                   }
                }
                else if (_type == EnAccountingType.Users)
                {
                    var hesab = UserBussines.Get(_hesabGuid);
                    if (hesab == null) return;
                    lblName.Text = hesab.Name;
                    lblAccount.Text = hesab.Account_.ToString("N0");
                    if (hesab.Account == 0)
                    {
                        lblAccount.Text = "بی حساب";
                        lblAccount_.ForeColor = Color.Black;
                    }
                    if (hesab.Account > 0)
                    {
                        lblAccount_.Text = "بدهکار";
                        lblAccount_.ForeColor = Color.Red;
                    }
                    if (hesab.Account < 0)
                    {
                        lblAccount_.Text = "بستانکار";
                        lblAccount_.ForeColor = Color.Green;
                    }
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        public frmGardeshHesab(Guid hesabGuid, EnAccountingType type)
        {
            InitializeComponent();
            _hesabGuid = hesabGuid;
            _type = type;
        }

        private void frmGardeshHesab_Load(object sender, EventArgs e)
        {
            SetLabels();
            LoadData(_hesabGuid);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                LoadData(_hesabGuid, txtSearch.Text);
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

        private void frmGardeshHesab_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) Close();
        }
    }
}
