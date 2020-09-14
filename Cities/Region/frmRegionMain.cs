using System;
using System.Linq;
using System.Windows.Forms;
using EntityCache.Bussines;
using MetroFramework.Forms;
using Notification;
using Services;

namespace Cities.Region
{
    public partial class frmRegionMain : MetroForm
    {
        private RegionsBussines cls;
        private EnLogAction action;
        private void SetData()
        {
            try
            {
                var list = StatesBussines.GetAll().OrderBy(q => q.Name);
                StateBindingSource.DataSource = list.ToList();

                txtRegion.Text = cls?.Name;
                if (cls?.Guid == Guid.Empty) cmbState.SelectedIndex = 0;
                else
                {
                    cmbState.SelectedValue = (Guid)cls?.City.StateGuid;
                    cmbCity.SelectedValue = cls?.CityGuid;
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        public frmRegionMain()
        {
            InitializeComponent();
            cls = new RegionsBussines();
            action = EnLogAction.Insert;
        }

        public frmRegionMain(Guid guid, bool isShowMode)
        {
            InitializeComponent();
            cls = RegionsBussines.Get(guid);
            grp.Enabled = !isShowMode;
            btnFinish.Enabled = !isShowMode;
            action = EnLogAction.Update;
        }

        private void txtRegion_Enter(object sender, EventArgs e)
        {
            txtSetter.Focus(txtRegion);
        }

        private void txtRegion_Leave(object sender, EventArgs e)
        {
            txtSetter.Follow(txtRegion);
        }

        private async void frmRegionMain_Load(object sender, EventArgs e)
        {
            try
            {
                SetData();
                var myCollection = new AutoCompleteStringCollection();
                var list = await RegionsBussines.GetAllAsync();
                foreach (var item in list.ToList())
                    myCollection.Add(item.Name);
                txtRegion.AutoCompleteCustomSource = myCollection;
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

        private void frmRegionMain_KeyDown(object sender, KeyEventArgs e)
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

        private async void cmbState_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbState.SelectedValue == null) return;
                var list = await CitiesBussines.GetAllAsync((Guid)cmbState.SelectedValue);
                CitiesBindingSource.DataSource = list.OrderBy(q=>q.Name).ToList();
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
                if (StateBindingSource.Count <= 0)
                {
                    frmNotification.PublicInfo.ShowMessage("استان نمی تواند خالی باشد");
                    cmbState.Focus();
                    return;
                }

                if (CitiesBindingSource.Count <= 0)
                {
                    frmNotification.PublicInfo.ShowMessage("شهرستان نمی تواند خالی باشد");
                    cmbCity.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtRegion.Text))
                {
                    frmNotification.PublicInfo.ShowMessage("عنوان منطقه نمی تواند خالی باشد");
                    txtRegion.Focus();
                    return;
                }


                if (cls.Guid == Guid.Empty) cls.Guid = Guid.NewGuid();
                cls.Name = txtRegion.Text;
                cls.CityGuid = (Guid)cmbCity.SelectedValue;

                var res = await cls.SaveAsync();
                if (res.HasError)
                {
                    frmNotification.PublicInfo.ShowMessage(res.ErrorMessage);
                    return;
                }

                User.UserLog.Save(action, EnLogPart.Regions);

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
