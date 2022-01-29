using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsSerivces;
using EntityCache.Bussines;
using MetroFramework.Forms;
using Notification;
using Services;

namespace Building.BuildingAccountType
{
    public partial class frmBuildingAccountType : MetroForm
    {
        private BuildingAccountTypeBussines cls;

        private void SetData() => txtName.Text = cls?.Name;

        public frmBuildingAccountType(BuildingAccountTypeBussines obj, bool isShowMode)
        {
            try
            {
                InitializeComponent();
                cls = obj;
                if (!cls.IsModified)
                    ucHeader.Text = "افزودن کاربری جدید";
                else
                    ucHeader.Text = !isShowMode ? $"ویرایش کاربری {cls.Name}" : $"مشاهده کاربری {cls.Name}";
                ucHeader.IsModified = cls.IsModified;
                grp.Enabled = !isShowMode;
                ucAccept.Enabled = !isShowMode;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void txtName_Enter(object sender, EventArgs e) => txtSetter.Focus(txtName);
        private void txtName_Leave(object sender, EventArgs e) => txtSetter.Follow(txtName);
        private async void frmBuildingAccountType_Load(object sender, EventArgs e)
        {
            try
            {
                SetData();
                var myCollection = new AutoCompleteStringCollection();
                var list = await BuildingAccountTypeBussines.GetAllAsync(new CancellationToken());
                foreach (var item in list.ToList())
                    myCollection.Add(item.Name);
                txtName.AutoCompleteCustomSource = myCollection;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void frmBuildingAccountType_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                switch (e.KeyCode)
                {
                    case Keys.Enter:
                        if (!ucAccept.Focused && !ucCancel.Focused)
                            SendKeys.Send("{Tab}");
                        break;
                    case Keys.F5:
                        ucAccept.PerformClick();
                        break;
                    case Keys.Escape:
                        ucCancel.PerformClick();
                        break;
                }
            }
            catch (Exception exception)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(exception);
            }
        }
        private async Task ucAccept_OnClick(object arg1, EventArgs arg2)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {

                if (cls.Guid == Guid.Empty) cls.Guid = Guid.NewGuid();
                cls.Name = txtName.Text.Trim();
                cls.Modified = DateTime.Now;
                cls.ServerStatus = ServerStatus.None;

                res.AddReturnedValue(await cls.SaveAsync());
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }
            finally
            {
                if (res.HasError)
                    this.ShowError(res, "خطا در ثبت نوع کاربری ملک");
                else
                {
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
        }
        private async Task ucCancel_OnClick(object arg1, EventArgs arg2)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
