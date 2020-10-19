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
        private void FillCmbPrice()
        {
            try
            {
                var values = Enum.GetValues(typeof(EnPrice)).Cast<EnPrice>();
                foreach (var item in values)
                    cmbPrice.Items.Add(item.GetDisplay());
                cmbPrice.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void SetDigit()
        {
            try
            {
                var val = (decimal) 0;
                if (cmbPrice.SelectedIndex == 0)
                    val = txtPrice.Value.ToString().ParseToDecimal() * 10000;
                if (cmbPrice.SelectedIndex == 1)
                    val = txtPrice.Value.ToString().ParseToDecimal() * 10000000;
                if (cmbPrice.SelectedIndex == 2)
                    val = txtPrice.Value.ToString().ParseToDecimal() * 10000000000;

                lblDegit.Text = NumberToString.Num2Str(val.ToString()) + " ریال";
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        public frmSanad()
        {
            InitializeComponent();
        }

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

        private void frmSanad_Load(object sender, EventArgs e)
        {
            FillCmbPrice();
        }

        private void txtPrice_ValueChanged(object sender, EventArgs e)
        {
            SetDigit();
        }

        private void cmbPrice_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetDigit();
        }

        private async void btnFinish_Click(object sender, EventArgs e)
        {
            try
            {
                var list = new List<GardeshHesabBussines>();

                if (string.IsNullOrWhiteSpace(lblBedName.Text))
                {
                    frmNotification.PublicInfo.ShowMessage("طرف بدهکار را انتخاب نمایید");
                    btnSearchBed.Focus();
                    return;
                }
                if (string.IsNullOrWhiteSpace(lblBesName.Text))
                {
                    frmNotification.PublicInfo.ShowMessage("طرف بستانکار را انتخاب نمایید");
                    btnSearchBed.Focus();
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtDesc.Text))
                {
                    frmNotification.PublicInfo.ShowMessage("توضیحات مناسب سند را وارد نمایید");
                    txtDesc.Focus();
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtPrice.Text))
                {
                    frmNotification.PublicInfo.ShowMessage("مبلغ را وارد نمایید");
                    txtPrice.Focus();
                    return;
                }

                var val = (decimal)0;
                if (cmbPrice.SelectedIndex == 0)
                    val = txtPrice.Value.ToString().ParseToDecimal() * 10000;
                if (cmbPrice.SelectedIndex == 1)
                    val = txtPrice.Value.ToString().ParseToDecimal() * 10000000;
                if (cmbPrice.SelectedIndex == 2)
                    val = txtPrice.Value.ToString().ParseToDecimal() * 10000000000;

                var parent = Guid.NewGuid();

                list.Add(new GardeshHesabBussines()
                {
                    Guid = Guid.NewGuid(),
                    ParentGuid = parent,
                    Babat = EnAccountBabat.Sanad,
                    PeopleGuid = bedGuid,
                    Price = val,
                    Type = EnAccountType.Bed,
                    Description = txtDesc.Text
                });
                list.Add(new GardeshHesabBussines()
                {
                    Guid = Guid.NewGuid(),
                    ParentGuid = parent,
                    Babat = EnAccountBabat.Sanad,
                    PeopleGuid = besGuid,
                    Price = val,
                    Type = EnAccountType.Bes,
                    Description = txtDesc.Text
                });


                //Set Bedehkar Account
                if (bedType == EnAccountingType.Peoples)
                {
                    var item = PeoplesBussines.Get(bedGuid);
                    if (item == null) return;
                    item.Account += val;
                    await item.SaveAsync();
                }
                else if (bedType == EnAccountingType.Users)
                {
                    var item = UserBussines.Get(bedGuid);
                    if (item == null) return;
                    item.Account += val;
                    await item.SaveAsync(false);
                }
                else if (bedType == EnAccountingType.Hazine)
                {
                    var item = HazineBussines.Get(bedGuid);
                    if (item == null) return;
                    item.Account += val;
                    await item.SaveAsync(false);
                }

                //Set Bestankar Account
                if (besType == EnAccountingType.Peoples)
                {
                    var item = PeoplesBussines.Get(besGuid);
                    if (item == null) return;
                    item.Account -= val;
                    await item.SaveAsync();
                }
                else if (besType == EnAccountingType.Users)
                {
                    var item = UserBussines.Get(besGuid);
                    if (item == null) return;
                    item.Account -= val;
                    await item.SaveAsync(false);
                }


                var res = await GardeshHesabBussines.SaveRangeAsync(list);
                if (res.HasError)
                {
                    frmNotification.PublicInfo.ShowMessage(res.ErrorMessage);
                    return;
                }

                User.UserLog.Save(EnLogAction.Insert, EnLogPart.Sanad);


                DialogResult = DialogResult.OK;
                Close();

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
    }
}
