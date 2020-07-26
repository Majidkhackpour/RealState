using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityCache.Bussines;
using MetroFramework.Forms;
using PacketParser.Services;

namespace Peoples
{
    public partial class frmPeoples : MetroForm
    {
        private PeoplesBussines cls;
        private void SetData()
        {
            try
            {
                LoadGroups();
                LoadTells();
                LoadBanks();

                txtCode.Text = cls?.Code;
                txtNationalCode.Text = cls?.NationalCode;
                txtName.Text = cls?.Name;
                txtIdCode.Text = cls?.IdCode;
                txtFatherName.Text = cls?.FatherName;
                txtPlaceBirth.Text = cls?.PlaceBirth;
                txtIssuesFrom.Text = cls?.IssuedFrom;
                txtPostalCode.Text = cls?.PostalCode;
                txtAddress.Text = cls?.Address;

                if (cls?.Guid == Guid.Empty)
                    NextCode();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void NextCode()
        {
            try
            {
                txtCode.Text = PeoplesBussines.NextCode() ?? "";
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
                var list = PeopleGroupBussines.GetAll().Where(q => q.Status).OrderBy(q => q.Name);
                groupBundingSource.DataSource = list;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void LoadTells()
        {
            try
            {
                phoneBookBindingSource.DataSource = cls?.TellList.ToList();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void LoadBanks()
        {
            try
            {
                bankAccountBindingSource.DataSource = cls?.BankList.ToList();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        public frmPeoples()
        {
            InitializeComponent();
            superTabControl1.SelectedTab = superTabItem1;
            WindowState = FormWindowState.Maximized;
            cls = new PeoplesBussines();
        }
        public frmPeoples(Guid guid, bool isShowMode)
        {
            InitializeComponent();
            cls = PeoplesBussines.Get(guid);
            superTabControl1.Enabled = !isShowMode;
            btnFinish.Enabled = !isShowMode;
        }
        private void frmPeoples_Load(object sender, EventArgs e)
        {
            SetData();
        }

        #region TxtSetter
        private void txtCode_Enter(object sender, EventArgs e)
        {
            txtSetter.Focus(txtCode);
        }

        private void txtNationalCode_Enter(object sender, EventArgs e)
        {
            txtSetter.Focus(txtNationalCode);
        }

        private void txtName_Enter(object sender, EventArgs e)
        {
            txtSetter.Focus(txtName);
        }

        private void txtIdCode_Enter(object sender, EventArgs e)
        {
            txtSetter.Focus(txtIdCode);
        }

        private void txtFatherName_Enter(object sender, EventArgs e)
        {
            txtSetter.Focus(txtFatherName);
        }

        private void txtPlaceBirth_Enter(object sender, EventArgs e)
        {
            txtSetter.Focus(txtPlaceBirth);
        }

        private void txtIssuesFrom_Enter(object sender, EventArgs e)
        {
            txtSetter.Focus(txtIssuesFrom);
        }

        private void txtPostalCode_Enter(object sender, EventArgs e)
        {
            txtSetter.Focus(txtPostalCode);
        }

        private void txtTell_Enter(object sender, EventArgs e)
        {
            txtSetter.Focus(txtTell);
        }

        private void txtBank_Enter(object sender, EventArgs e)
        {
            txtSetter.Focus(txtBank);
        }

        private void txtAccountNumber_Enter(object sender, EventArgs e)
        {
            txtSetter.Focus(txtAccountNumber);
        }

        private void txtShobe_Enter(object sender, EventArgs e)
        {
            txtSetter.Focus(txtShobe);
        }

        private void txtShobe_Leave(object sender, EventArgs e)
        {
            txtSetter.Follow(txtShobe);
        }

        private void txtAccountNumber_Leave(object sender, EventArgs e)
        {
            txtSetter.Follow(txtAccountNumber);
        }

        private void txtBank_Leave(object sender, EventArgs e)
        {
            txtSetter.Follow(txtBank);
        }

        private void txtTell_Leave(object sender, EventArgs e)
        {
            txtSetter.Follow(txtTell);
        }

        private void txtPostalCode_Leave(object sender, EventArgs e)
        {
            txtSetter.Follow(txtPostalCode);
        }

        private void txtIssuesFrom_Leave(object sender, EventArgs e)
        {
            txtSetter.Follow(txtIssuesFrom);
        }

        private void txtPlaceBirth_Leave(object sender, EventArgs e)
        {
            txtSetter.Follow(txtPlaceBirth);
        }

        private void txtFatherName_Leave(object sender, EventArgs e)
        {
            txtSetter.Follow(txtFatherName);
        }

        private void txtIdCode_Leave(object sender, EventArgs e)
        {
            txtSetter.Follow(txtIdCode);
        }

        private void txtCode_Leave(object sender, EventArgs e)
        {
            txtSetter.Follow(txtCode);
        }

        private void txtNationalCode_Leave(object sender, EventArgs e)
        {
            txtSetter.Follow(txtNationalCode);
        }

        private void txtName_Leave(object sender, EventArgs e)
        {
            txtSetter.Follow(txtName);
        }
        #endregion

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void frmPeoples_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                switch (e.KeyCode)
                {
                    case Keys.Enter:
                        if (!btnFinish.Focused && !btnCancel.Focused)
                            SendKeys.Send("{Tab}");
                        break;
                    case Keys.F5:
                        btnFinish.PerformClick();
                        break;
                    case Keys.Escape:
                        btnCancel.PerformClick();
                        break;
                }
            }
            catch (Exception exception)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(exception);
            }
        }
    }
}
