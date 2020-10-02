using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityCache.Bussines;
using MetroFramework.Forms;
using Notification;
using Services;

namespace Peoples
{
    public partial class frmPropleGroup : MetroForm
    {
        private PeopleGroupBussines cls;
        private async Task SetDataAsync()
        {
            try
            {
                var list = await PeopleGroupBussines.GetAllAsync();
                var a = new PeopleGroupBussines()
                {
                    Guid = Guid.Empty,
                    Name = "[هیچکدام]",
                    ParentGuid = Guid.Empty
                };
                list.Add(a);
                GroupBindingSource.DataSource =
                    list.Where(q => q.ParentGuid == Guid.Empty).OrderBy(q => q.Name).ToList();
                txtName.Text = cls?.Name;
                if (cls?.Guid == Guid.Empty) cmbGroup.SelectedIndex = 0;
                else cmbGroup.SelectedValue = (Guid)cls?.ParentGuid;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        public frmPropleGroup()
        {
            InitializeComponent();
            cls = new PeopleGroupBussines();
        }
        public frmPropleGroup(Guid guid)
        {
            InitializeComponent();
            cls = PeopleGroupBussines.Get(guid);
        }

        private async void frmPropleGroup_Load(object sender, EventArgs e)
        {
            try
            {
                await SetDataAsync();
                var myCollection = new AutoCompleteStringCollection();
                var list = await PeopleGroupBussines.GetAllAsync();
                foreach (var item in list.ToList())
                    myCollection.Add(item.Name);
                txtName.AutoCompleteCustomSource = myCollection;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void txtCity_Enter(object sender, EventArgs e)
        {
            txtSetter.Focus(txtName);
        }

        private void txtCity_Leave(object sender, EventArgs e)
        {
            txtSetter.Follow(txtName);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void frmPropleGroup_KeyDown(object sender, KeyEventArgs e)
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

        private async void btnFinish_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtName.Text))
                {
                    frmNotification.PublicInfo.ShowMessage("عنوان گروه نمی تواند خالی باشد");
                    txtName.Focus();
                    return;
                }

                if (!await PeopleGroupBussines.CheckNameAsync(txtName.Text, cls.Guid))
                {
                    var pg = await PeopleGroupBussines.GetAsync(txtName.Text);
                    if (pg.Status)
                    {
                        frmNotification.PublicInfo.ShowMessage("عنوان گروه تکراری است");
                        txtName.Focus();
                    }
                    else
                    {
                        pg.ParentGuid = (Guid)cmbGroup.SelectedValue;
                        pg.Status = true;
                        var res2 = await cls.SaveAsync();
                        if (!res2.HasError) return;
                        frmNotification.PublicInfo.ShowMessage(res2.ErrorMessage);
                        return;
                    }
                    return;
                }

                if (cls.Guid == Guid.Empty) cls.Guid = Guid.NewGuid();
                cls.Name = txtName.Text;
                cls.ParentGuid = (Guid)cmbGroup.SelectedValue;

                var res = await cls.SaveAsync();
                if (res.HasError)
                {
                    frmNotification.PublicInfo.ShowMessage(res.ErrorMessage);
                    return;
                }
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
