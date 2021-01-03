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
        private EnLogAction action;
        private void SetData()
        {
            try
            {
                SetReceptor();
                SetTotal();
                lblDateNow.Text = cls?.DateSh;
                txtFishNo.Text = cls?.FishNo;
                txtCheckNo.Text = cls?.CheckNo;
                txtSarResid.Text = cls?.SarResid;
                txtBankName.Text = cls?.BankName;
                txtDesc.Text = cls?.Description;
                txtCheckPrice.TextDecimal = cls?.Check ?? 0;
                txtNaqdPrice.TextDecimal = cls?.NaqdPrice ?? 0;
                txtBankPrice.TextDecimal = cls?.BankPrice ?? 0;
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

                total += txtNaqdPrice.TextDecimal;
                total += txtBankPrice.TextDecimal;
                total += txtCheckPrice.TextDecimal;

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
            var res = new ReturnedSaveFuncInfo();
            try
            {
                if (string.IsNullOrWhiteSpace(txtName.Text))
                {
                    res.AddError("طرف حساب نمی تواند خالی باشد");
                    txtName.Focus();
                }

                if (txtNaqdPrice.TextDecimal == 0 && txtBankPrice.TextDecimal == 0 && txtCheckPrice.TextDecimal == 0)
                {
                    res.AddError("لطفا یکی از فیلدهای مبلغ را وارد نمایید");
                    return;
                }

                if (res.HasError) return;

                if (cls.Guid == Guid.Empty) cls.Guid = Guid.NewGuid();
                cls.Receptor = _receptorGuid;
                cls.BankName = txtBankName.Text;
                cls.CheckNo = txtCheckNo.Text;
                cls.Description = txtDesc.Text;
                cls.FishNo = txtFishNo.Text;
                cls.SarResid = txtSarResid.Text;
                cls.NaqdPrice = txtNaqdPrice.TextDecimal;
                cls.BankPrice = txtBankPrice.TextDecimal;
                cls.Check = txtCheckPrice.TextDecimal;


                res.AddReturnedValue(await cls.SaveAsync());
                if (res.HasError) return;


                if (txtCheckPrice.TextDecimal > 0)
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
                            $"سررسید چک دریافتنی به شماره {cls.CheckNo} به مبلغ {cls.Check:N0} ریال به {txtName.Text}";
                    }

                    res.AddReturnedValue(await note.SaveAsync());
                }
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
                    var frm = new FrmShowErrorMessage(res, "خطا در ثبت پرداخت");
                    frm.ShowDialog(this);
                    frm.Dispose();
                }
                else
                {
                    User.UserLog.Save(action, EnLogPart.Reception);
                    DialogResult = DialogResult.OK;
                    Close();
                }
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
        private void txtNaqdPrice_OnTextChanged() => SetTotal();
        private void txtBankPrice_OnTextChanged() => SetTotal();
        private void txtCheckPrice_OnTextChanged() => SetTotal();
    }
}
