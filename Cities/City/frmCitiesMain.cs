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

namespace Cities.City
{
    public partial class frmCitiesMain : MetroForm
    {
        private CitiesBussines cls;
        private CancellationTokenSource token = new CancellationTokenSource();

        private async Task SetDataAsync()
        {
            try
            {
                token?.Cancel();
                token = new CancellationTokenSource();
                var list = await StatesBussines.GetAllAsync(token.Token);
                StateBindingSource.DataSource = list.OrderBy(q => q.Name).ToList();
                txtCity.Text = cls?.Name;
                if (cls?.Guid == Guid.Empty) cmbState.SelectedIndex = 0;
                else cmbState.SelectedValue = (Guid)cls?.StateGuid;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        public frmCitiesMain()
        {
            InitializeComponent();
            cls = new CitiesBussines();
            ucHeader.Text = "افزودن شهر جدید";
            ucHeader.IsModified = cls.IsModified;
        }
        public frmCitiesMain(Guid guid, bool isShowMode)
        {
            InitializeComponent();
            cls = CitiesBussines.Get(guid);
            ucHeader.Text = !isShowMode ? $"ویرایش شهر {cls.Name}" : $"مشاهده شهر {cls.Name}";
            ucHeader.IsModified = cls.IsModified;
            grp.Enabled = !isShowMode;
            btnFinish.Enabled = !isShowMode;
        }

        private void txtCity_Enter(object sender, System.EventArgs e) => txtSetter.Focus(txtCity);
        private void txtCity_Leave(object sender, System.EventArgs e) => txtSetter.Follow(txtCity);
        private void frmCitiesMain_Load(object sender, EventArgs e)
        {
            try
            {
                AsyncContext.Run(SetDataAsync);
                var myCollection = new AutoCompleteStringCollection();
                token?.Cancel();
                token = new CancellationTokenSource();
                var list = AsyncContext.Run(() => CitiesBussines.GetAllAsync(token.Token));
                foreach (var item in list.ToList())
                    myCollection.Add(item.Name);
                txtCity.AutoCompleteCustomSource = myCollection;
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
        private void frmCitiesMain_KeyDown(object sender, KeyEventArgs e)
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
            var res = new ReturnedSaveFuncInfo();
            try
            {
                if (cls.Guid == Guid.Empty) cls.Guid = Guid.NewGuid();
                cls.Name = txtCity.Text;
                cls.StateGuid = (Guid)cmbState.SelectedValue;
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
                    this.ShowError(res, "خطا در درج شهرستان");
                else
                {
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
        }
    }
}
