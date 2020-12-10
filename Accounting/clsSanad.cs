using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using EntityCache.Bussines;
using Services;
using Servicess.Interfaces.Building;
using Settings;

namespace Accounting
{
    public class clsSanad : IGardeshHesab
    {
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public bool Status { get; set; }
        public Guid PeopleGuid { get; set; }
        public decimal Price { get; set; }
        public EnAccountType Type { get; set; }
        public EnAccountBabat Babat { get; set; }
        public string Description { get; set; }
        public Guid ParentGuid { get; set; }


        public static async Task<ReturnedSaveFuncInfo> SaveAsync(Guid bedGuid, Guid besGuid, decimal price, string desc)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                using (var cn = new SqlConnection(AppSettings.DefaultConnectionString))
                {
                    var parent = Guid.NewGuid();
                    var cmd = new SqlCommand("sp_Sanad_Save", cn) {CommandType = CommandType.StoredProcedure};
                    cmd.Parameters.AddWithValue("@parentGuid", parent);
                    cmd.Parameters.AddWithValue("@bedGuid", bedGuid);
                    cmd.Parameters.AddWithValue("@besGuid", besGuid);
                    cmd.Parameters.AddWithValue("@price", price);
                    cmd.Parameters.AddWithValue("@desc", desc);

                    await cn.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    cn.Close();
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
        }
    }
}
