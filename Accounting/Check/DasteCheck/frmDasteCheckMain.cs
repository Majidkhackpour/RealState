using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WindowsSerivces;
using Accounting.Hesab;
using EntityCache.Bussines;
using MetroFramework.Forms;
using Services;

namespace Accounting.Check.DasteCheck
{
    public partial class frmDasteCheckMain : MetroForm
    {
        private DasteCheckBussines cls;
        private Guid _bankGuid = Guid.Empty;
        private void SetData()
        {
            try
            {
                txtSerial.Text = cls?.SerialNumber;
                txtDesc.Text = cls?.Description;
                txtFromNumber.Value = cls?.FromNumber ?? 0;
                txtToNumber.Value = cls?.ToNumber ?? 0;
                txtBankName.Text = TafsilBussines.Get(cls.BankGuid)?.Name;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private List<CheckPageBussines> MakePagesList(Guid checkGuid)
        {
            var list = new List<CheckPageBussines>();
            try
            {
                for (var i = txtFromNumber.Value; i <= txtToNumber.Value; i++)
                {
                    list.Add(new CheckPageBussines()
                    {
                        Guid = Guid.NewGuid(),
                        Modified = DateTime.Now,
                        Description = "",
                        Price = 0,
                        Number = (long)i,
                        DateSarresid = null,
                        CheckStatus = EnCheckSh.Mojoud,
                        ReceptorGuid = null,
                        CheckGuid = checkGuid,
                        DatePardakht = null
                    });
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return list;
        }

        public frmDasteCheckMain(DasteCheckBussines obj, bool isShowMode)
        {
            try
            {
                InitializeComponent();
                cls = obj;
                if (cls.Guid != Guid.Empty)
                {
                    ucHeader.Text = !isShowMode ? $"ویرایش دسته چک سریال {cls.SerialNumber}" : $"مشاهده دسته چک سریال {cls.SerialNumber}";
                    ucHeader.IsModified = true;
                }
                else
                {
                    ucHeader.Text = "افزودن دسته چک جدید";
                    ucHeader.IsModified = false;
                }
                _bankGuid = cls.BankGuid;
                grp.Enabled = !isShowMode;
                btnFinish.Enabled = !isShowMode;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void frmDasteCheckMain_Load(object sender, EventArgs e) => SetData();
        private void txtSerial_Enter(object sender, EventArgs e) => txtSetter.Focus(txtSerial);
        private void txtSerial_Leave(object sender, EventArgs e) => txtSetter.Follow(txtSerial);
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
        private void frmDasteCheckMain_KeyDown(object sender, KeyEventArgs e)
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
                cls.Modified = DateTime.Now;
                cls.Status = true;
                cls.Description = txtDesc.Text;
                cls.BankGuid = _bankGuid;
                cls.FromNumber = (long)txtFromNumber.Value;
                cls.ToNumber = (long)txtToNumber.Value;
                cls.SerialNumber = txtSerial.Text;
                cls.CheckPages = MakePagesList(cls.Guid);

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
        private void btnRegion_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new frmSelectTafsil(HesabType.Bank);
                if (frm.ShowDialog(this) != DialogResult.OK) return;
                _bankGuid = frm.SelectedGuid;
                txtBankName.Text = TafsilBussines.Get(_bankGuid)?.Name;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
