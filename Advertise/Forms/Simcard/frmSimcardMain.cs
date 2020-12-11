using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityCache.Bussines;
using MetroFramework.Forms;
using Notification;
using Services;

namespace Advertise.Forms.Simcard
{
    public partial class frmSimcardMain : MetroForm
    {
        private SimcardBussines cls;

        private async Task FillOperatorAsync()
        {
            try
            {
                var list = await SimcardBussines.GetAllAsync();
                cmbOperator.Items.Clear();
                cmbOperator.Items.AddRange(list.Select(q => q.Operator).Distinct().ToArray());
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async Task SetDataAsync()
        {
            try
            {
                await FillOperatorAsync();
                txtOwner.Text = cls?.Owner;
                txtNumber.Text = cls?.Number.ToString();
                if (cls?.Guid == Guid.Empty && cmbOperator.Items.Count > 0) cmbOperator.SelectedIndex = 0;
                else cmbOperator.Text = cls?.Operator;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        public frmSimcardMain()
        {
            InitializeComponent();
            cls = new SimcardBussines();
        }
        public frmSimcardMain(Guid guid, bool isShowMode)
        {
            InitializeComponent();
            cls = SimcardBussines.Get(guid);
            grp.Enabled = !isShowMode;
            btnFinish.Enabled = !isShowMode;
        }

        #region TxtSetter
        private void txtOwner_Enter(object sender, EventArgs e)
        {
            txtSetter.Focus(txtOwner);
        }

        private void txtNumber_Enter(object sender, EventArgs e)
        {
            txtSetter.Focus(txtNumber);
        }

        private void txtNumber_Leave(object sender, EventArgs e)
        {
            txtSetter.Follow(txtNumber);
        }

        private void txtOwner_Leave(object sender, EventArgs e)
        {
            txtSetter.Follow(txtOwner);
        }


        #endregion

        private async void frmSimcardMain_Load(object sender, EventArgs e) => await SetDataAsync();

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void frmSimcardMain_KeyDown(object sender, KeyEventArgs e)
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

                if (string.IsNullOrWhiteSpace(txtOwner.Text))
                {
                    res.AddError("مالک نمی تواند خالی باشد");
                    txtOwner.Focus();
                }

                if (string.IsNullOrWhiteSpace(txtNumber.Text))
                {
                    res.AddError("شماره نمی تواند خالی باشد");
                    txtNumber.Focus();
                }

                if (!await SimcardBussines.CheckNumberAsync(txtNumber.Text.ParseToLong(), cls.Guid))
                {
                    res.AddError("شماره وارد شده تکراری می باشد");
                    txtNumber.Focus();
                }

                if (!CheckPerssonValidation.CheckMobile(txtNumber.Text.Trim()))
                {
                    res.AddError("شماره موبایل وارد شده صحیح نمی باشد");
                    txtNumber.Focus();
                }

                if (res.HasError) return;

                cls.Owner = txtOwner.Text.Trim();
                cls.Number = txtNumber.Text.FixString().Trim().ParseToLong();
                cls.Operator = cmbOperator.Text;

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
                    var frm = new FrmShowErrorMessage(res, "خطا در ثبت سیمکارت");
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
