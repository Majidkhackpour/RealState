using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityCache.Bussines;
using MetroFramework.Forms;
using Services;
using User.AccessLevel;

namespace User
{
    public partial class frmAccessLevel : MetroForm
    {
        Services.Access.AccessLevel CurrentAccessLevel;
        short selectedValue;
        private static bool _firstindexChange;
        public frmAccessLevel()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void LoadGrid()
        {
            try
            {
                var lst = AccessLevelClass.ListInfo(CurrentAccessLevel);
                ClassInfoBindingSource.DataSource = lst.ToSortableBindingList();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

        }

        private async Task LoadUserDataAsync()
        {
            try
            {
                var users = await UserBussines.GetAllAsync();
                UserBindingSource.DataSource = users.Where(p => p.Guid != clsUser.CurrentUser.Guid).ToSortableBindingList();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private async void cmbUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbUser.Items.Count <= 1) return;

                if (!_firstindexChange && MessageBox.Show("مایل به ذخیره تنظیمات هستید ؟", "پیغام سیستم", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign) == DialogResult.Yes)
                {
                    var user = await UserBussines.GetAsync((Guid)cmbUser.SelectedValue);
                    CurrentAccessLevel = user.UserAccess;
                    await save((Guid)cmbUser.SelectedValue);
                    LoadGrid();
                }
                else
                {
                    var user = await UserBussines.GetAsync((Guid)cmbUser.SelectedValue);
                    CurrentAccessLevel = user.UserAccess;
                    LoadGrid();
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async Task save(Guid userGuid)
        {
            try
            {
                var user = await UserBussines.GetAsync(userGuid);
                if (user == null) return;
                user.UserAccess = CurrentAccessLevel;
                var res = await user.SaveAsync(true);
                if (res.HasError)
                {
                    MessageBox.Show(res.ErrorMessage, "خطا", MessageBoxButtons.OK,
                        MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);

                    return;
                }
                MessageBox.Show("سطوح دسترسی کاربر با موفقیت ذخیره شد", "پیغام سیستم", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign);
            }
            catch (Exception exception)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(exception);
            }
        }

        private void DGPart_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (ReferenceEquals(ClassInfoBindingSource.Current, null)) return;
                var temp = ((AccessLevelClass)ClassInfoBindingSource.Current).info;
                PropInfoBindingSource.DataSource = temp.ListInfo.ToSortableBindingList();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private async void btnFinish_Click(object sender, EventArgs e)
        {
            try
            {
                await save((Guid)cmbUser.SelectedValue);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void DGPart_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (ReferenceEquals(ClassInfoBindingSource.Current, null)) return;
                var temp = ((AccessLevelClass)ClassInfoBindingSource.Current).info;
                PropInfoBindingSource.DataSource = temp.ListInfo.ToSortableBindingList();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void DGPart_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DGAccess.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void DGAccess_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void frmAccessLevel_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                switch (e.KeyCode)
                {
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

        private async void frmAccessLevel_Load(object sender, EventArgs e)
        {

            try
            {
                await LoadUserDataAsync();
                cmbUser.SelectedIndex = 0;
                CurrentAccessLevel = UserBussines.Get((Guid)cmbUser.SelectedValue).UserAccess;
                LoadGrid();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

        }
    }
}
