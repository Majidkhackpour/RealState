using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using EntityCache.Bussines;
using EntityCache.ViewModels;
using MetroFramework.Forms;
using Notification;
using Print;
using Services;

namespace Accounting.Reception
{
    public partial class frmReceptionMain : MetroForm
    {
        private Guid _receptorGuid;
        private EnAccountingType type;
        private ReceptionBussines cls;
        private decimal fPrice;
        private EnLogAction action;
        private void SetData()
        {
            try
            {
                SetReceptor();
                FillCmbPrice();
                SetTxtPrice();
                SetTotal();
                lblDateNow.Text = cls?.DateSh;
                txtFishNo.Text = cls?.FishNo;
                txtCheckNo.Text = cls?.CheckNo;
                txtSarResid.Text = cls?.SarResid;
                txtBankName.Text = cls?.BankName;
                txtDesc.Text = cls?.Description;
                fPrice = cls?.TotalPrice ?? 0;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void FillCmbPrice()
        {
            try
            {
                var values = Enum.GetValues(typeof(EnPrice)).Cast<EnPrice>();
                foreach (var item in values)
                {
                    cmbBank.Items.Add(item.GetDisplay());
                    cmbCheck.Items.Add(item.GetDisplay());
                    cmbNaqd.Items.Add(item.GetDisplay());
                }
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
                if (cls?.NaqdPrice == 0)
                {
                    txtNaqdPrice.Text = cls?.NaqdPrice.ToString();
                    cmbNaqd.SelectedIndex = 0;
                }
                if (cls?.NaqdPrice != 0)
                {
                    if (cls?.NaqdPrice >= 10000 && cls?.NaqdPrice >= 9999)
                    {
                        txtNaqdPrice.Text = (cls?.NaqdPrice / 10000).ToString();
                        cmbNaqd.SelectedIndex = 0;
                    }
                    if (cls?.NaqdPrice >= 10000000 && cls?.NaqdPrice >= 9999999)
                    {
                        txtNaqdPrice.Text = (cls?.NaqdPrice / 10000000).ToString();
                        cmbNaqd.SelectedIndex = 1;
                    }
                    if (cls?.NaqdPrice >= 10000000000 && cls?.NaqdPrice >= 9999999999)
                    {
                        txtNaqdPrice.Text = (cls?.NaqdPrice / 10000000000).ToString();
                        cmbNaqd.SelectedIndex = 2;
                    }
                }


                if (cls?.BankPrice == 0)
                {
                    txtBankPrice.Text = cls?.BankPrice.ToString();
                    cmbBank.SelectedIndex = 0;
                }
                if (cls?.BankPrice != 0)
                {
                    if (cls?.BankPrice >= 10000 && cls?.BankPrice >= 9999)
                    {
                        txtBankPrice.Text = (cls?.BankPrice / 10000).ToString();
                        cmbBank.SelectedIndex = 0;
                    }
                    if (cls?.BankPrice >= 10000000 && cls?.BankPrice >= 9999999)
                    {
                        txtBankPrice.Text = (cls?.BankPrice / 10000000).ToString();
                        cmbBank.SelectedIndex = 1;
                    }
                    if (cls?.BankPrice >= 10000000000 && cls?.BankPrice >= 9999999999)
                    {
                        txtBankPrice.Text = (cls?.BankPrice / 10000000000).ToString();
                        cmbBank.SelectedIndex = 2;
                    }
                }



                if (cls?.Check == 0)
                {
                    txtCheckPrice.Text = cls?.Check.ToString();
                    cmbCheck.SelectedIndex = 0;
                }
                if (cls?.Check != 0)
                {
                    if (cls?.Check >= 10000 && cls?.Check >= 9999)
                    {
                        txtCheckPrice.Text = (cls?.Check / 10000).ToString();
                        cmbCheck.SelectedIndex = 0;
                    }
                    if (cls?.Check >= 10000000 && cls?.Check >= 9999999)
                    {
                        txtCheckPrice.Text = (cls?.Check / 10000000).ToString();
                        cmbCheck.SelectedIndex = 1;
                    }
                    if (cls?.Check >= 10000000000 && cls?.Check >= 9999999999)
                    {
                        txtCheckPrice.Text = (cls?.Check / 10000000000).ToString();
                        cmbCheck.SelectedIndex = 2;
                    }
                }


            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void SetTotal()
        {
            try
            {
                var total = (decimal)0;

                if (cmbNaqd.SelectedIndex == 0)
                    total += txtNaqdPrice.Value * 10000;
                if (cmbNaqd.SelectedIndex == 1)
                    total += txtNaqdPrice.Value * 10000000;
                if (cmbNaqd.SelectedIndex == 2)
                    total += txtNaqdPrice.Value * 10000000000;

                if (cmbBank.SelectedIndex == 0)
                    total += txtBankPrice.Value * 10000;
                if (cmbBank.SelectedIndex == 1)
                    total += txtBankPrice.Value * 10000000;
                if (cmbBank.SelectedIndex == 2)
                    total += txtBankPrice.Value * 10000000000;

                if (cmbCheck.SelectedIndex == 0)
                    total += txtCheckPrice.Value * 10000;
                if (cmbCheck.SelectedIndex == 1)
                    total += txtCheckPrice.Value * 10000000;
                if (cmbCheck.SelectedIndex == 2)
                    total += txtCheckPrice.Value * 10000000000;

                lblTotalPrice.Text = total.ToString("N0");
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        public frmReceptionMain(Guid receptorGuid, EnAccountingType _type)
        {
            InitializeComponent();
            _receptorGuid = receptorGuid;
            type = _type;
            cls = new ReceptionBussines();
            action = EnLogAction.Insert;
        }
        public frmReceptionMain(Guid guid, bool isShowMode, EnAccountingType _type)
        {
            InitializeComponent();
            cls = ReceptionBussines.Get(guid);
            _receptorGuid = cls.Receptor;
            type = _type;
            grp1.Enabled = !isShowMode;
            grp2.Enabled = !isShowMode;
            grp3.Enabled = !isShowMode;
            txtDesc.Enabled = !isShowMode;
            btnFinish.Enabled = !isShowMode;
            action = EnLogAction.Update;
        }

        private void SetReceptor()
        {
            try
            {
                if (type == EnAccountingType.Peoples)
                {
                    var hesab = PeoplesBussines.Get(_receptorGuid);
                    if (hesab == null) return;
                    txtName.Text = hesab.Name;
                }
                else if (type == EnAccountingType.Users)
                {
                    var hesab = UserBussines.Get(_receptorGuid);
                    if (hesab == null) return;
                    txtName.Text = hesab.Name;
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private async void frmReceptionMain_Load(object sender, EventArgs e)
        {
            SetData();
            var myCollection = new AutoCompleteStringCollection();
            var list = await ReceptionBussines.GetAllAsync();
            foreach (var item in list.ToList())
                myCollection.Add(item.BankName);
            txtBankName.AutoCompleteCustomSource = myCollection;
        }

        #region TxtSetter
        private void txtFishNo_Enter(object sender, EventArgs e)
        {
            txtSetter.Focus(txtFishNo);
        }

        private void txtCheckNo_Enter(object sender, EventArgs e)
        {
            txtSetter.Focus(txtCheckNo);
        }

        private void txtBankName_Enter(object sender, EventArgs e)
        {
            txtSetter.Focus(txtBankName);
        }

        private void txtBankName_Leave(object sender, EventArgs e)
        {
            txtSetter.Follow(txtBankName);
        }

        private void txtCheckNo_Leave(object sender, EventArgs e)
        {
            txtSetter.Follow(txtCheckNo);
        }

        private void txtFishNo_Leave(object sender, EventArgs e)
        {
            txtSetter.Follow(txtFishNo);
        }
        #endregion

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void frmReceptionMain_KeyDown(object sender, KeyEventArgs e)
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
                    case Keys.F10:
                        btnPrint.PerformClick();
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
                if (string.IsNullOrWhiteSpace(txtName.Text))
                {
                    frmNotification.PublicInfo.ShowMessage("طرف حساب نمی تواند خالی باشد");
                    txtName.Focus();
                    return;
                }

                if (txtNaqdPrice.Text == "0" && txtBankPrice.Text == "0" && txtCheckPrice.Text == "0")
                {
                    frmNotification.PublicInfo.ShowMessage("لطفا یکی از فیلدهای مبلغ را وارد نمایید");
                    return;
                }

                if (cls.Guid == Guid.Empty) cls.Guid = Guid.NewGuid();
                cls.Receptor = _receptorGuid;
                cls.BankName = txtBankName.Text;
                cls.CheckNo = txtCheckNo.Text;
                cls.Description = txtDesc.Text;
                cls.FishNo = txtFishNo.Text;
                cls.SarResid = txtSarResid.Text;

                if (cmbNaqd.SelectedIndex == 0)
                    cls.NaqdPrice = txtNaqdPrice.Text.ParseToDecimal() * 10000;
                if (cmbNaqd.SelectedIndex == 1)
                    cls.NaqdPrice = txtNaqdPrice.Text.ParseToDecimal() * 10000000;
                if (cmbNaqd.SelectedIndex == 2)
                    cls.NaqdPrice = txtNaqdPrice.Text.ParseToDecimal() * 10000000000;

                if (cmbBank.SelectedIndex == 0)
                    cls.BankPrice = txtBankPrice.Text.ParseToDecimal() * 10000;
                if (cmbBank.SelectedIndex == 1)
                    cls.BankPrice = txtBankPrice.Text.ParseToDecimal() * 10000000;
                if (cmbBank.SelectedIndex == 2)
                    cls.BankPrice = txtBankPrice.Text.ParseToDecimal() * 10000000000;

                if (cmbCheck.SelectedIndex == 0)
                    cls.Check = txtCheckPrice.Text.ParseToDecimal() * 10000;
                if (cmbCheck.SelectedIndex == 1)
                    cls.Check = txtCheckPrice.Text.ParseToDecimal() * 10000000;
                if (cmbCheck.SelectedIndex == 2)
                    cls.Check = txtCheckPrice.Text.ParseToDecimal() * 10000000000;


                if (type == EnAccountingType.Peoples)
                {
                    var pe = await PeoplesBussines.GetAsync(_receptorGuid);
                    if (pe != null)
                    {
                        pe.Account += fPrice;
                        pe.Account -= cls.TotalPrice;
                        await pe.SaveAsync();
                    }
                }
                else if (type == EnAccountingType.Users)
                {
                    var user = await UserBussines.GetAsync(_receptorGuid);
                    if (user != null)
                    {
                        user.Account += fPrice;
                        user.Account -= cls.TotalPrice;
                        await user.SaveAsync(false);
                    }
                }


                var res = await cls.SaveAsync(type);
                if (res.HasError)
                {
                    frmNotification.PublicInfo.ShowMessage(res.ErrorMessage);
                    return;
                }


                if (txtCheckPrice.Value > 0)
                {
                    var note = await NoteBussines.GetAsync(cls.Guid);
                    if (note == null)
                    {
                        note = new NoteBussines()
                        {
                            Guid = cls.Guid,
                            DateSarresid = Calendar.ShamsiToMiladi(txtSarResid.Text),
                            Modified = DateTime.Now,
                            Status = true,
                            DateSabt = DateTime.Now,
                            NoteStatus = EnNoteStatus.Unread,
                            Priority = EnNotePriority.Mamoli,
                            UserGuid = User.clsUser.CurrentUser.Guid,
                            Description =
                                $"سررسید چک دریافتنی از شماره {cls.CheckNo} به مبلغ {cls.Check:N0} ریال به {txtName.Text}",
                            Title = "سررسید چک دریافتنی"
                        };
                    }
                    else
                    {
                        note.Description =
                            $"سررسید چک پرداختنی به شماره {cls.CheckNo} به مبلغ {cls.Check:N0} ریال به {txtName.Text}";
                    }

                    await note.SaveAsync();
                }


                User.UserLog.Save(action, EnLogPart.Reception);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void txtNaqdPrice_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                SetTotal();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void cmbNaqd_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                SetTotal();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void txtBankPrice_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                SetTotal();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void cmbBank_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                SetTotal();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void txtCheckPrice_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                SetTotal();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void cmbCheck_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                SetTotal();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                btnFinish.PerformClick();

                var view = new Reception_PardakhtViewModel()
                {
                    TotalPrice = cls?.TotalPrice ?? 0,
                    NaqdPrice = cls?.NaqdPrice ?? 0,
                    BankPrice = cls?.BankPrice ?? 0,
                    BankName = cls?.BankName,
                    CheckNo = cls?.CheckNo,
                    DateSh = cls?.DateSh,
                    Sarresid = cls?.SarResid,
                    Time = cls?.Time,
                    CheckPrice = cls?.Check ?? 0,
                    ResidNo = cls?.FishNo,
                    SideName = txtName.Text
                };
                var list = new List<object>() { view };

                var cls_ = new ReportGenerator(StiType.Reception_One, EnPrintType.Pdf_A4) { Lst = list };
                cls_.PrintNew();

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
