using Persistence;
using Services;
using System;
using System.Data.Entity.Migrations;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace EntityCache.Assistence
{
    public static class ClsCache
    {
        public static void Init(string connectionString, string hardSerial)
        {
            try
            {
                Cache.ConnectionString = connectionString;
                Cache.HardSerial = hardSerial;
                if (!CheckConnectionString(Cache.ConnectionString)) return;
                UpdateMigration();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private static void UpdateMigration()
        {
            try
            {
                var migratorConfig = new Persistence.Migrations.Configuration();
                var dbMigrator = new DbMigrator(migratorConfig);
                dbMigrator.Update();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private static bool CheckConnectionString(string con)
        {
            try
            {
                var cn = new SqlConnection(con);
                cn.Open();
                cn.Close();
                return true;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return false;
            }
        }
        public static async Task InserDefultsAsync()
        {
            try
            {
                await AddDefaults.InsertDefaultDataAsync();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        public static ReturnedSaveFuncInfo TransactionDestiny(this SqlTransaction tr, bool isRollBack)
        {
            var ret = new ReturnedSaveFuncInfo();
            try
            {
                ret.AddReturnedValue(isRollBack ? RollBackTran(tr) : CommitTran(tr));
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                ret.AddReturnedValue(ex);
            }
            return ret;
        }
        private static ReturnedSaveFuncInfo CommitTran(this SqlTransaction tr, SqlConnection cn = null)
        {
            var ret = new ReturnedSaveFuncInfo();
            try
            {
                tr?.Commit();
            }
            catch (Exception ex)
            {
                ret.AddReturnedValue(ex);
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
            finally
            {
                ret.AddReturnedValue(CloseConnection(cn));
            }
            return ret;
        }
        private static ReturnedSaveFuncInfo RollBackTran(this SqlTransaction tr, SqlConnection cn = null)
        {
            var ret = new ReturnedSaveFuncInfo();
            try
            {
                tr?.Rollback();
            }
            catch (Exception ex)
            {
                ret.AddReturnedValue(ex);
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
            finally
            {
                ret.AddReturnedValue(CloseConnection(cn));
            }
            return ret;
        }
        public static ReturnedSaveFuncInfo CloseConnection(this SqlConnection cn)
        {
            var ret = new ReturnedSaveFuncInfo();
            try
            {
                if (cn == null) return ret;
                if (cn.State == System.Data.ConnectionState.Open) return ret;
                cn?.Close();
            }
            catch (Exception ex)
            {
                ret.AddReturnedValue(ex);
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
            return ret;
        }
    }
}
