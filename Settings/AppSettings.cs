using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using Services;

namespace Settings
{
    public class AppSettings
    {
        private static string _defCn = "";
        public static string DefaultConnectionString
        {
            get
            {
                var res = clsRegistery.GetConnectionRegistery("BuildingCn");
                _defCn = string.IsNullOrEmpty(res.value)
                    ? "data source=.;initial catalog=Arad1;integrated security=True;MultipleActiveResultSets=True;MultipleActiveResultSets = True;"
                    : res.value;
                return _defCn;
            }
            set => _defCn = value;
        }

        public static string CreateConnectionString(SqlConnectionStringBuilder _builder, string serverName, bool isSqlDetect, string userName, string pass)
        {
            try
            {
                _builder.DataSource = serverName;
                if (isSqlDetect)
                {
                    _builder.UserID = userName;
                    _builder.Password = pass;
                    _builder.IntegratedSecurity = false;
                }
                else
                {
                    _builder.UserID = "";
                    _builder.Password = "";
                    _builder.IntegratedSecurity = true;
                }

                _builder.AsynchronousProcessing = true;
                _builder.MultipleActiveResultSets = true;
                var con = new SqlConnection { ConnectionString = _builder.ConnectionString };
                con.Open();

                DataBaseUtilities.Settings.ServerConnectionsString = _builder.ConnectionString;
                con.Close();

                return _builder.ConnectionString;

            }
            catch (Exception)
            {
                return "";
            }
        }
    }
}
