using System;
using System.Windows.Forms;
using Accounting.Hesab;
using EntityCache.Bussines;
using MetroFramework.Forms;
using Services;

namespace Accounting.Report
{
    public partial class frmFilterTarazHesab : MetroForm
    {
        private DateTime _d1, _d2;
        private long _code1, _code2;

        private void DrawUi()
        {
            try
            {
                if (rbtnToday.Checked || rbtnAll.Checked) txtDate1.Enabled = txtDate2.Enabled = false;
                else txtDate1.Enabled = txtDate2.Enabled = true;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        public frmFilterTarazHesab()
        {
            InitializeComponent();
            ucHeader.Text = "فیلتر تراز حساب ها";
            rbtnToday.Checked = true;
            DrawUi();
        }


        private void rbtnToday_CheckedChanged(object sender, EventArgs e) => DrawUi();
        private void btnSearchTafsil1_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new frmSelectTafsil();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    var tafsil = TafsilBussines.Get(frm.SelectedGuid);
                    if (tafsil == null) return;
                    txtCode1.Value = tafsil.Code.ParseToDecimal();
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void btnSearchTafsil2_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new frmSelectTafsil();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    var tafsil = TafsilBussines.Get(frm.SelectedGuid);
                    if (tafsil == null) return;
                    txtCode2.Value = tafsil.Code.ParseToDecimal();
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void frmFilterTarazHesab_KeyDown(object sender, KeyEventArgs e)
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
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
        private void btnFinish_Click(object sender, EventArgs e)
        {
            try
            {
                if (rbtnToday.Checked)
                {
                    _d1 = DateTime.Now;
                    _d2 = DateTime.Now;
                }
                else if (rbtnAll.Checked)
                {
                    _d1 = new DateTime(1990, 01, 01, 0, 0, 0);
                    _d2 = new DateTime(2030, 01, 01, 0, 0, 0);
                }
                else
                {
                    _d1 = Calendar.ShamsiToMiladi(txtDate1.Text);
                    _d2 = Calendar.ShamsiToMiladi(txtDate2.Text);
                }

                if (txtCode1.Value > 1) _code1 = (long)txtCode1.Value;
                if (txtCode2.Value > 1) _code2 = (long)txtCode2.Value;

                var frm = new frmTarazHesab(_d1, _d2, _code1, _code2);
                frm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void rbtnBetween_CheckedChanged(object sender, EventArgs e) => DrawUi();
        private void rbtnAll_CheckedChanged(object sender, EventArgs e) => DrawUi();
    }
}
