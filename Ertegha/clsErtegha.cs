using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;
using Nito.AsyncEx;
using Services;

namespace Ertegha
{
    public class clsErtegha
    {
        public static async Task<ReturnedSaveFuncInfo> StartErteghaAsync(string connectionString, IWin32Window owner)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                var cn = new SqlConnection(connectionString);
                res.AddReturnedValue(await DataBaseUtilities.RunScript.RunAsync(owner, Properties.Resources.Ertegha, cn));
                if (res.HasError) return res;
                res.AddReturnedValue(await clsFixBuilding.FixBuildingImage());
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
        }

        public static void StartErtegha(string connectionString, IWin32Window owner) =>
            Task.Run(() => StartErteghaAsync(connectionString, owner));
    }
}
