using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using DataBaseUtilities;
using MetroFramework.Forms;
using Notification;
using Services;

namespace Settings.WorkingYear
{
    public partial class frmWorkingYearMain : MetroForm
    {
        private WorkingYear cls;
        private string ConnectionString;

        private void SetData() => txtDbName.Text = cls?.DbName;

        public frmWorkingYearMain()
        {
            InitializeComponent();
            cls = new WorkingYear();
            ucHeader.Text = "افزودن واحد اقتصادی جدید";
        }
        public frmWorkingYearMain(Guid guid)
        {
            InitializeComponent();
            cls = WorkingYear.Get(guid);
            ucHeader.Text = $"ویرایش واحد اقتصادی {cls.DbName}";
            ucHeader.IsModified = true;
        }

        private void btnFinish_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtDbName.Text))
                {
                    frmNotification.PublicInfo.ShowMessage("عنوان سال کاری نمی تواند خالی باشد");
                    txtDbName.Focus();
                    return;
                }

                var cn = "";
                var init = "";

                if (string.IsNullOrEmpty(ConnectionString))
                {
                    ConnectionString =
                        AppSettings.CreateConnectionString(new SqlConnectionStringBuilder(), ".", false, "", "");

                    for (var i = 1; i < 50; i++)
                    {
                        var db = DataBase.CreateDatabase("Arad" + i, ConnectionString);
                        if (!db.Result.HasError)
                        {
                            cn = db.ConnectionString;
                            var connection = new SqlConnection(cn);
                            init = connection.Database;
                            AppSettings.DefaultConnectionString = cn;

                            break;
                        }
                    }
                }

                if (cls.Guid == Guid.Empty) cls.Guid = Guid.NewGuid();
                cls.ConnectionString = cn;
                cls.DbName = txtDbName.Text;
                cls.InitialCatalog = init;

                var res = cls.Save();
                if (res.HasError)
                {
                    frmNotification.PublicInfo.ShowMessage(res.ErrorMessage);
                    return;
                }


                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void frmWorkingYearMain_Load(object sender, EventArgs e) => SetData();
        private void frmWorkingYearMain_KeyDown(object sender, KeyEventArgs e)
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
        private void btnConString_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new FRMInitialSettings();
                if (frm.ShowDialog(this) == DialogResult.OK)
                    ConnectionString = frm.ConnectionString;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
