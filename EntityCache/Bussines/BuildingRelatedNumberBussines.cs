using EntityCache.Assistence;
using Persistence;
using Services;
using Services.Interfaces.Building;
using System;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace EntityCache.Bussines
{
    public class BuildingRelatedNumberBussines : IBuildingRelatedNumber
    {
        public Guid BuildingGuid { get; set; }
        public string Number { get; set; }


        public static async Task<BuildingRelatedNumberBussines> GetAsync(Guid buildingGuid) => await UnitOfWork.BuildingRelatedNumber.GetAsync(Cache.ConnectionString, buildingGuid);
        public async Task<ReturnedSaveFuncInfo> SaveAsync(SqlTransaction tr = null)
        {
            var res = new ReturnedSaveFuncInfo();
            var autoTran = tr == null;
            SqlConnection cn = null;
            try
            {
                if (autoTran)
                {
                    cn = new SqlConnection(Cache.ConnectionString);
                    await cn.OpenAsync();
                    tr = cn.BeginTransaction();
                }

                res.AddReturnedValue(await UnitOfWork.BuildingRelatedNumber.SaveAsync(this, tr));
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }
            finally
            {
                if (autoTran)
                {
                    res.AddReturnedValue(tr.TransactionDestiny(res.HasError));
                    res.AddReturnedValue(cn.CloseConnection());
                }
            }
            return res;
        }
    }
}
