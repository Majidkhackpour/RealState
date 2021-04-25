using System;
using System.Linq;
using System.Threading.Tasks;
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
        private async Task SetDataAsync()
        {
            try
            {
                var list = await StatesBussines.GetAllAsync();
                StateBindingSource.DataSource = list.OrderBy(q => q.Name).ToList();

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
        }
        public frmRegionMain(Guid guid, bool isShowMode)
        {
            InitializeComponent();
            cls = RegionsBussines.Get(guid);
            grp.Enabled = !isShowMode;
            btnFinish.Enabled = !isShowMode;
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
                await SetDataAsync();
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
                CitiesBindingSource.DataSource = list.OrderBy(q => q.Name).ToList();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private async void btnFinish_Click(object sender, EventArgs e)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                if (StateBindingSource.Count <= 0)
                {
                    res.AddError("استان نمی تواند خالی باشد");
                    cmbState.Focus();
                }

                if (CitiesBindingSource.Count <= 0)
                {
                    res.AddError("شهرستان نمی تواند خالی باشد");
                    cmbCity.Focus();
                }

                if (string.IsNullOrWhiteSpace(txtRegion.Text))
                {
                    res.AddError("عنوان منطقه نمی تواند خالی باشد");
                    txtRegion.Focus();
                }

                if (res.HasError) return;

                if (cls.Guid == Guid.Empty) cls.Guid = Guid.NewGuid();
                cls.Name = txtRegion.Text;
                cls.CityGuid = (Guid)cmbCity.SelectedValue;

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
                {
                    var frm = new FrmShowErrorMessage(res, "خطا در درج منطقه");
                    frm.ShowDialog(this);
                    frm.Dispose();
                }
                else
                {
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
        }
    }
}
