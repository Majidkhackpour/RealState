using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using DataBaseUtilities;
using Notification;
using Services;
using Settings;
using Settings.WorkingYear;

namespace RealState.LoginPanel.FormsInPanel
{
    public partial class frmCreateWorkingYear : Form
    {
        private WorkingYear cls;
        private string ConnectionString;

        private void SetData() => txtDbName.Text = cls?.DbName;

        public frmCreateWorkingYear()
        {
            InitializeComponent();
            cls = new WorkingYear();
        }
        public frmCreateWorkingYear(Guid guid)
        {
            InitializeComponent();
            cls = WorkingYear.Get(guid);
            ConnectionString = cls?.ConnectionString;
        }

        private void lblOk_Click(object sender, System.EventArgs e)
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
                        if (db.Result.HasError) continue;
                        cn = db.ConnectionString;
                        var connection = new SqlConnection(cn);
                        init = connection.Database;
                        AppSettings.DefaultConnectionString = cn;
                        break;
                    }
                    cls.ConnectionString = cn;
                    cls.InitialCatalog = init;
                }

                if (cls.Guid == Guid.Empty) cls.Guid = Guid.NewGuid();
                cls.DbName = txtDbName.Text;

                var res = cls.Save();
                if (!res.HasError)
                {
                    frmLoginMain.Instance.CurrentForm = new frmWorkingYear_Login();
                    return;
                }
                frmNotification.PublicInfo.ShowMessage(res.ErrorMessage);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void frmCreateWorkingYear_Load(object sender, EventArgs e) => SetData();
        private void lblExit_Click(object sender, EventArgs e)
        {

        }
        private void lblConString_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new FRMInitialSettings();
                if (frm.ShowDialog() == DialogResult.OK)
                    ConnectionString = frm.ConnectionString;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
