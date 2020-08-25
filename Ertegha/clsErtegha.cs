using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Nito.AsyncEx;
using Services;

namespace Ertegha
{
    public class clsErtegha
    {
        public static async Task<ReturnedSaveFuncInfo> StartErteghaAsync()
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                var cn = new SqlConnection(Settings.AppSettings.DefaultConnectionString);
                res.AddReturnedValue(await DataBaseUtilities.RunScript.RunAsync(Properties.Resources.Ertegha, cn));
                res.ThrowExceptionIfError();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
        }

        public static ReturnedSaveFuncInfo StartErtegha() => AsyncContext.Run(StartErteghaAsync);
    }
}
