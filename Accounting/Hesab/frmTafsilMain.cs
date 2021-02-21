using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsSerivces;
using EntityCache.Bussines;
using MetroFramework.Forms;
using Notification;
using Services;

namespace Accounting.Hesab
{
    public partial class frmTafsilMain : MetroForm
    {
        private TafsilBussines cls;
        private EnLogAction action;
        private HesabType hType = HesabType.Tafsil;

        private void SetData()
        {
            try
            {
                FillHesabTypes();
                FillCmbPrice();
                SetTxtPrice();
                txtName.Text = cls?.Name;
                txtDesc.Text = cls?.Description;
                if (cls.Guid == Guid.Empty)
                {
                    cmbType.SelectedIndex = ((int)hType) - 1;
                    txtCode.Text = NextCode();
                }
                else
                {
                    cmbType.SelectedIndex = ((int)cls.HesabType) - 1;
                    txtCode.Text = cls?.Code;
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void FillHesabTypes()
        {
            try
            {
                var values = Enum.GetValues(typeof(HesabType)).Cast<HesabType>();
                foreach (var item in values)
                    cmbType.Items.Add(item.GetDisplay());
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private string NextCode()
        {
            var res = "";
            try
            {
                res = TafsilBussines.NextCode((HesabType)cmbType.SelectedIndex + 1);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return res;
        }
        private void FillCmbPrice()
        {
            try
            {
                cmbAccount.Items.Add(EnAccountType.BiHesab.GetDisplay());
                cmbAccount.Items.Add(EnAccountType.Bed.GetDisplay());
                cmbAccount.Items.Add(EnAccountType.Bes.GetDisplay());
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void SetTxtPrice()
        {
            try
            {
                if (cls?.AccountFirst == 0)
                {
                    txtAccount_.TextDecimal = cls?.AccountFirst ?? 0;
                    cmbAccount.SelectedIndex = 0;
                }

                if (cls?.AccountFirst < 0)
                {
                    txtAccount_.TextDecimal = Math.Abs(cls?.AccountFirst ?? 0);
                    cmbAccount.SelectedIndex = 2;
                }

                if (cls?.AccountFirst > 0)
                {
                    txtAccount_.TextDecimal = Math.Abs(cls?.AccountFirst ?? 0);
                    cmbAccount.SelectedIndex = 1;
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        public frmTafsilMain()
        {
            InitializeComponent();
            cls = new TafsilBussines();
            action = EnLogAction.Insert;
        }
        public frmTafsilMain(HesabType hType)
        {
            InitializeComponent();
            cls = new TafsilBussines();
            action = EnLogAction.Insert;
            cmbType.Enabled = false;
            this.hType = hType;
            if (hType == HesabType.Hazine || hType == HesabType.Bank)
                cmbAccount.Enabled = txtAccount_.Enabled = false;
        }
        public frmTafsilMain(Guid guid, bool isShowMode, HesabType? htype = null)
        {
            InitializeComponent();
            cls = TafsilBussines.Get(guid);
            grp.Enabled = !isShowMode;
            btnFinish.Enabled = !isShowMode;
            action = EnLogAction.Update;
            if (htype != null)
            {
                cmbType.Enabled = false;
                this.hType = htype.Value;
                if (hType == HesabType.Hazine || hType == HesabType.Bank)
                    cmbAccount.Enabled = txtAccount_.Enabled = false;
            }
        }

        private async void frmTafsilMain_Load(object sender, EventArgs e)
        {
            try
            {
                SetData();
                var myCollection = new AutoCompleteStringCollection();
                var list = await TafsilBussines.GetAllAsync("", HesabType.Sandouq);
                foreach (var item in list.ToList())
                    myCollection.Add(item.Name);
                txtName.AutoCompleteCustomSource = myCollection;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void txtCode_Enter(object sender, EventArgs e) => txtSetter.Focus(txtCode);
        private void txtName_Enter(object sender, EventArgs e) => txtSetter.Focus(txtName);
        private void txtName_Leave(object sender, EventArgs e) => txtSetter.Follow(txtName);
        private void txtCode_Leave(object sender, EventArgs e) => txtSetter.Follow(txtCode);
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
        private void frmTafsilMain_KeyDown(object sender, KeyEventArgs e)
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
        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtCode.Text = NextCode();
                var t = (HesabType)cmbType.SelectedIndex + 1;
                if (t == HesabType.Hazine || t == HesabType.Bank)
                    cmbAccount.Enabled = txtAccount_.Enabled = false;
                else
                    cmbAccount.Enabled = txtAccount_.Enabled = true;
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
                if (cls.Guid == Guid.Empty)
                {
                    cls.Guid = Guid.NewGuid();
                    cls.DateM = DateTime.Now;
                }
                cls.Modified = DateTime.Now;
                cls.Status = true;
                cls.Name = txtName.Text;
                cls.Code = txtCode.Text;
                cls.Description = txtDesc.Text;
                cls.isSystem = false;
                cls.HesabType = (HesabType)cmbType.SelectedIndex + 1;
                var acc = txtAccount_.TextDecimal;
                if (cmbAccount.SelectedIndex == 0) cls.AccountFirst = 0;
                else
                {
                    if (cmbAccount.SelectedIndex == 1) cls.AccountFirst = acc;
                    else cls.AccountFirst = -acc;
                }

                if (cls.HesabType == HesabType.Bank)
                {
                    res.AddError("لطفا برای تعریف حساب بانکی، از منوی حسابداری، حساب های بانکی اقدام نمایید");
                    return;
                }
                if (cls.HesabType == HesabType.Customer)
                {
                    res.AddError("لطفا برای تعریف اشخاص، از منوی اطلاعات پایه، مدیریت اشخاص اقدام نمایید");
                    return;
                }

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
                    this.ShowError(res, "خطا در ثبت حساب تفصیلی");
                else
                {
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
        }
    }
}
