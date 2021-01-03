using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityCache.Bussines;
using MetroFramework.Forms;
using Notification;
using Services;

namespace Cities.City
{
    public partial class frmCitiesMain : MetroForm
    {
        private CitiesBussines cls;
        private EnLogAction action;
        private async Task SetDataAsync()
        {
            try
            {
                var list = await StatesBussines.GetAllAsync();
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
            action = EnLogAction.Insert;
        }
        public frmCitiesMain(Guid guid, bool isShowMode)
        {
            InitializeComponent();
            cls = CitiesBussines.Get(guid);
            grp.Enabled = !isShowMode;
            btnFinish.Enabled = !isShowMode;
            action = EnLogAction.Update;
        }

        private void txtCity_Enter(object sender, System.EventArgs e) => txtSetter.Focus(txtCity);
        private void txtCity_Leave(object sender, System.EventArgs e) => txtSetter.Follow(txtCity);

        private async void frmCitiesMain_Load(object sender, EventArgs e)
        {
            try
            {
                await SetDataAsync();
                var myCollection = new AutoCompleteStringCollection();
                var list = await CitiesBussines.GetAllAsync();
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
                if (StateBindingSource.Count <= 0)
                {
                    res.AddError("استان نمی تواند خالی باشد");
                    cmbState.Focus();
                }

                if (string.IsNullOrWhiteSpace(txtCity.Text))
                {
                    res.AddError("عنوان شهرستان نمی تواند خالی باشد");
                    txtCity.Focus();
                }

                if (!await CitiesBussines.CheckNameAsync((Guid) cmbState.SelectedValue, txtCity.Text, cls.Guid))
                {
                    res.AddError("عنوان شهرستان در این استان، تکراری است");
                    txtCity.Focus();
                }

                if (res.HasError) return;
                if (cls.Guid == Guid.Empty) cls.Guid = Guid.NewGuid();
                cls.Name = txtCity.Text;
                cls.StateGuid = (Guid) cmbState.SelectedValue;

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
                    var frm = new FrmShowErrorMessage(res, "خطا در درج شهرستان");
                    frm.ShowDialog(this);
                    frm.Dispose();
                }
                else
                {
                    User.UserLog.Save(action, EnLogPart.Cities);
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
        }
    }
}
