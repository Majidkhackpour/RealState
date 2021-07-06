using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using MetroFramework.Forms;
using Notification;
using Services;

namespace RealState.Advance
{
    public partial class frmRunScript : MetroForm
    {
        public frmRunScript()
        {
            InitializeComponent();
            ucHeader.Text = "اجرای کوئری SQL";
        }

        private async void btnQuery_Click(object sender, System.EventArgs e)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                if (string.IsNullOrEmpty(txtQuery.Text))
                {
                    res.AddError("لطفا کوئری موردنظر را وارد نمایید");
                    return;
                }

                res.AddReturnedValue(await DataBaseUtilities.RunScript.RunAsync(true,this, txtQuery.Text,
                    new SqlConnection(Settings.AppSettings.DefaultConnectionString)));

                if (!res.HasError) res.AddInformation("اجرای کوئری با موفقیت انجام شد");
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
            finally
            {
                var frm = new FrmShowErrorMessage(res, "خطا در درج شهرستان");
                frm.ShowDialog(this);
                frm.Dispose();
            }
        }
        private void frmRunScript_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) Close();
        }
    }
}
