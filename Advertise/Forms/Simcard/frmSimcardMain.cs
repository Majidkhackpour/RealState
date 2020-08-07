using System;
using System.Linq;
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

        private void FillOperator()
        {
            try
            {
                var list = SimcardBussines.GetAll().Select(q => q.Operator).Distinct().ToList();
                cmbOperator.Items.Clear();
                cmbOperator.Items.AddRange(list.ToArray());
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void SetData()
        {
            try
            {
                FillOperator();
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

        private void frmSimcardMain_Load(object sender, EventArgs e)
        {
            SetData();
        }

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
            try
            {
                if (cls.Guid == Guid.Empty)
                    cls.Guid = Guid.NewGuid();

                if (string.IsNullOrWhiteSpace(txtOwner.Text))
                {
                    frmNotification.PublicInfo.ShowMessage("مالک نمی تواند خالی باشد");
                    txtOwner.Focus();
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtNumber.Text))
                {
                    frmNotification.PublicInfo.ShowMessage("شماره نمی تواند خالی باشد");
                    txtNumber.Focus();
                    return;
                }
                if (!await SimcardBussines.CheckNumberAsync(txtNumber.Text.ParseToLong(), cls.Guid))
                {
                    frmNotification.PublicInfo.ShowMessage("شماره وارد شده تکراری می باشد");
                    txtNumber.Focus();
                    return;
                }
               
                if (!CheckPerssonValidation.CheckMobile(txtNumber.Text.Trim()))
                {
                    frmNotification.PublicInfo.ShowMessage("شماره موبایل وارد شده صحیح نمی باشد");
                    txtNumber.Focus();
                    return;
                }


                cls.Owner = txtOwner.Text.Trim();
                cls.Number = txtNumber.Text.FixString().Trim().ParseToLong();
                cls.Operator = cmbOperator.Text;

                var res = await cls.SaveAsync();
                if (res.HasError)
                {
                    frmNotification.PublicInfo.ShowMessage(res.ErrorMessage);
                    return;
                }
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception exception)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(exception);
            }
        }
    }
}
