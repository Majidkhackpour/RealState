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
        private string _connectionString, _contextGuid;

        private void SetData() => txtDbName.Text = cls?.DbName;

        public frmCreateWorkingYear(string contextGuid)
        {
            InitializeComponent();
            cls = new WorkingYear();
            _contextGuid = contextGuid;
        }
        public frmCreateWorkingYear(string contextGuid, Guid guid)
        {
            InitializeComponent();
            cls = WorkingYear.Get(guid);
            _connectionString = cls?.ConnectionString;
            _contextGuid = contextGuid;
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

                if (string.IsNullOrEmpty(_connectionString))
                {
                    _connectionString =
                        AppSettings.CreateConnectionString(new SqlConnectionStringBuilder(), ".", false, "", "");

                    for (var i = 1; i < 50; i++)
                    {
                        var db = DataBase.CreateDatabase("Arad" + i, _connectionString);
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
                    frmLoginMain.GetInstance(_contextGuid).CurrentForm = new frmWorkingYear_Login(_contextGuid);
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
                if (frm.ShowDialog() != DialogResult.OK) return;
                _connectionString = frm.ConnectionString;
                cls.ConnectionString = _connectionString;
                var connection = new SqlConnection(_connectionString);
                cls.InitialCatalog = connection.Database;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
