using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Accounting.Payement;
using Accounting.Reception;
using EntityCache.Bussines;
using MetroFramework.Forms;
using Notification;
using Services;

namespace Accounting
{
    public partial class frmSanad : MetroForm
    {
        private Guid bedGuid;
        private Guid besGuid;
        private EnAccountingType bedType;
        private EnAccountingType besType;
        private void SetDigit()
        {
            try
            {
                decimal val = 0;
                val = txtPrice.TextDecimal;
                lblDegit.Text = NumberToString.Num2Str(val.ToString()) + " ریال";
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        public frmSanad() => InitializeComponent();

        private void btnSearchBed_Click(object sender, System.EventArgs e)
        {
            try
            {
                var frm = new frmPayeMentFilter(EnSanadType.Dasti);
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    bedGuid = frm.SelectedGuid;
                    bedType = frm.AccountingType;

                    if (bedType == EnAccountingType.Peoples)
                    {
                        var item = PeoplesBussines.Get(bedGuid);
                        if (item == null) return;
                        lblBedName.Text = item.Name;
                        lblBedAccount.Text = item.Account.ToString("N0");
                    }
                    else if (bedType == EnAccountingType.Users)
                    {
                        var item = UserBussines.Get(bedGuid);
                        if (item == null) return;
                        lblBedName.Text = item.Name;
                        lblBedAccount.Text = item.Account.ToString("N0");
                    }
                    else if (bedType == EnAccountingType.Hazine)
                    {
                        var item = HazineBussines.Get(bedGuid);
                        if (item == null) return;
                        lblBedName.Text = item.Name;
                        lblBedAccount.Text = item.Account.ToString("N0");
                    }
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void btnSearchBes_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new frmReceptionFilter(EnSanadType.Dasti);
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    besGuid = frm.SelectedGuid;
                    besType = frm.AccountingType;
                    if (besType == EnAccountingType.Peoples)
                    {
                        var item = PeoplesBussines.Get(besGuid);
                        if (item == null) return;
                        lblBesName.Text = item.Name;
                        lblBesAccount.Text = item.Account.ToString("N0");
                    }
                    else if (besType == EnAccountingType.Users)
                    {
                        var item = UserBussines.Get(besGuid);
                        if (item == null) return;
                        lblBesName.Text = item.Name;
                        lblBesAccount.Text = item.Account.ToString("N0");
                    }
                }
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
                if (string.IsNullOrWhiteSpace(lblBedName.Text))
                {
                    res.AddError("طرف بدهکار را انتخاب نمایید");
                    btnSearchBed.Focus();
                }

                if (string.IsNullOrWhiteSpace(lblBesName.Text))
                {
                    res.AddError("طرف بستانکار را انتخاب نمایید");
                    btnSearchBed.Focus();
                }

                if (string.IsNullOrWhiteSpace(txtDesc.Text))
                {
                    res.AddError("توضیحات مناسب سند را وارد نمایید");
                    txtDesc.Focus();
                }

                if (txtPrice.TextDecimal <= 0)
                {
                    res.AddError("مبلغ را وارد نمایید");
                    txtPrice.Focus();
                }

                if (bedGuid == besGuid)
                {
                    res.AddError("هر دو طرف سند نمی تواند برابر باشد");
                    txtPrice.Focus();
                }

                if (res.HasError) return; 
                res.AddReturnedValue(await clsSanad.SaveAsync(bedGuid, besGuid, txtPrice.TextDecimal, txtDesc.Text));
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
                    var frm = new FrmShowErrorMessage(res, "خطا در ثبت سند حسابداری تک سطری");
                    frm.ShowDialog(this);
                    frm.Dispose();
                }
                else
                {
                    User.UserLog.Save(EnLogAction.Insert, EnLogPart.Sanad);
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
        private void frmSanad_KeyDown(object sender, KeyEventArgs e)
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
        private void txtPrice_OnTextChanged() => SetDigit();
    }
}
