using System;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using EntityCache.Bussines;
using MetroFramework.Forms;
using Notification;
using Services;

namespace Building.BuildingCondition
{
    public partial class frmBuildingConditionMain : MetroForm
    {
        private BuildingConditionBussines cls;
        private CancellationTokenSource _token = new CancellationTokenSource();

        private void SetData() => txtName.Text = cls?.Name;

        public frmBuildingConditionMain()
        {
            InitializeComponent();
            cls = new BuildingConditionBussines();
            ucHeader.Text = "افزودن نوع بنای جدید";
            ucHeader.IsModified = cls.IsModified;
        }
        public frmBuildingConditionMain(Guid guid, bool isShowMode)
        {
            InitializeComponent();
            cls = BuildingConditionBussines.Get(guid);
            ucHeader.Text = !isShowMode ? $"ویرایش نوع بنای {cls.Name}" : $"مشاهده نوع بنای {cls.Name}";
            ucHeader.IsModified = cls.IsModified;
            grp.Enabled = !isShowMode;
            btnFinish.Enabled = !isShowMode;
        }

        private async void frmBuildingConditionMain_Load(object sender, EventArgs e)
        {
            try
            {
                SetData();
                var myCollection = new AutoCompleteStringCollection();
                _token?.Cancel();
                _token = new CancellationTokenSource();
                var list = await BuildingConditionBussines.GetAllAsync(_token.Token);
                foreach (var item in list.ToList())
                    myCollection.Add(item.Name);
                txtName.AutoCompleteCustomSource = myCollection;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void txtName_Enter(object sender, EventArgs e) => txtSetter.Focus(txtName);
        private void txtName_Leave(object sender, EventArgs e) => txtSetter.Follow(txtName);
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
        private void frmBuildingConditionMain_KeyDown(object sender, KeyEventArgs e)
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
                cls.Name = txtName.Text.Trim();

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
                    var frm = new FrmShowErrorMessage(res, "خطا در ثبت وضعیت ملک");
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
