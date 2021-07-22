using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsSerivces;
using EntityCache.Bussines;
using MetroFramework.Forms;
using Nito.AsyncEx;
using Notification;
using Services;

namespace Cities.Region
{
    public partial class frmRegionMain : MetroForm
    {
        private RegionsBussines cls;
        private CancellationTokenSource _token = new CancellationTokenSource();

        private async Task SetDataAsync()
        {
            try
            {
                _token?.Cancel();
                _token = new CancellationTokenSource();
                var list = await StatesBussines.GetAllAsync(_token.Token);
                StateBindingSource.DataSource = list.OrderBy(q => q.Name).ToList();

                txtRegion.Text = cls?.Name;
                if (cls?.Guid == Guid.Empty) cmbState.SelectedIndex = 0;
                else
                {
                    cmbState.SelectedValue = (Guid)cls?.StateGuid;
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
            ucHeader.Text = "افزودن منطقه جدید";
            ucHeader.IsModified = cls.IsModified;
        }
        public frmRegionMain(Guid guid, bool isShowMode)
        {
            InitializeComponent();
            cls = RegionsBussines.Get(guid);
            ucHeader.Text = !isShowMode ? $"ویرایش منطقه {cls.Name}" : $"مشاهده منطقه {cls.Name}";
            ucHeader.IsModified = cls.IsModified;
            grp.Enabled = !isShowMode;
            btnFinish.Enabled = !isShowMode;
        }

        private void txtRegion_Enter(object sender, EventArgs e) => txtSetter.Focus(txtRegion);
        private void txtRegion_Leave(object sender, EventArgs e) => txtSetter.Follow(txtRegion);
        private void frmRegionMain_Load(object sender, EventArgs e)
        {
            try
            {
                AsyncContext.Run(SetDataAsync);
                var myCollection = new AutoCompleteStringCollection();
                var list = AsyncContext.Run(() => RegionsBussines.GetAllAsync(new CancellationToken()));
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
                _token?.Cancel();
                _token = new CancellationTokenSource();
                var list = await CitiesBussines.GetAllAsync((Guid)cmbState.SelectedValue, _token.Token);
                CitiesBindingSource.DataSource = list?.OrderBy(q => q.Name).ToList();
                if (cls.Guid != Guid.Empty) cmbCity.SelectedValue = cls.CityGuid;
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
                if (cls.Guid == Guid.Empty) cls.Guid = Guid.NewGuid();
                cls.Name = txtRegion.Text;
                cls.CityGuid = (Guid)cmbCity.SelectedValue;
                cls.Modified = DateTime.Now;

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
                    this.ShowError(res, "خطا در درج منطقه");
                else
                {
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
        }
    }
}
