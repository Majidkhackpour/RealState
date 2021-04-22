using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using EntityCache.Assistence;
using Nito.AsyncEx;
using Persistence;
using Services;
using Servicess.Interfaces.Building;
using WebHesabBussines;

namespace EntityCache.Bussines
{
    public class PeopleGroupBussines : IPeopleGroup
    {
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; } = DateTime.Now;
        public ServerStatus ServerStatus { get; set; } = ServerStatus.None;
        public DateTime ServerDeliveryDate { get; set; } = DateTime.Now;
        public bool Status { get; set; } = true;
        public string Name { get; set; }
        public Guid ParentGuid { get; set; }
        public string HardSerial => Cache.HardSerial;


        public static async Task<List<PeopleGroupBussines>> GetAllAsync() => await UnitOfWork.PeopleGroup.GetAllAsync(Cache.ConnectionString);
        public static async Task<ReturnedSaveFuncInfo> SaveRangeAsync(List<PeopleGroupBussines> list, SqlTransaction tr = null)
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

                res.AddReturnedValue(await UnitOfWork.PeopleGroup.SaveRangeAsync(list, tr));
                if (res.HasError) return res;

                if (Cache.IsSendToServer)
                    _ = Task.Run(() => WebPeopleGroup.SaveAsync(list));
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
        public static async Task<PeopleGroupBussines> GetAsync(Guid guid) => await UnitOfWork.PeopleGroup.GetAsync(Cache.ConnectionString, guid);
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

                res.AddReturnedValue(await UnitOfWork.PeopleGroup.SaveAsync(this, tr));
                if (res.HasError) return res;

                if (Cache.IsSendToServer)
                    _ = Task.Run(() => WebPeopleGroup.SaveAsync(this));
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
        public async Task<ReturnedSaveFuncInfo> ChangeStatusAsync(bool status, SqlTransaction tr = null)
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

                var list = await PeoplesBussines.GetAllAsync(Guid, false);
                foreach (var item in list)
                {
                    item.GroupGuid = Guid.Empty;
                    res.AddReturnedValue(await UnitOfWork.Peoples.SaveAsync(item, tr));
                    if (res.HasError) return res;
                }

                res.AddReturnedValue(await UnitOfWork.PeopleGroup.ChangeStatusAsync(this, status, tr));
                if (res.HasError) return res;

                if (Cache.IsSendToServer)
                    _ = Task.Run(() => WebPeopleGroup.SaveAsync(this));
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
        public static PeopleGroupBussines Get(Guid guid) => AsyncContext.Run(() => GetAsync(guid));
        public static async Task<bool> CheckNameAsync(string name, Guid guid) =>
            await UnitOfWork.PeopleGroup.CheckNameAsync(Cache.ConnectionString, name, guid);
        public static async Task<PeopleGroupBussines> GetAsync(string name) =>
            await UnitOfWork.PeopleGroup.GetAsync(Cache.ConnectionString, name);
        public static PeopleGroupBussines Get(string name) => AsyncContext.Run(() => GetAsync(name));
        public static async Task<int> ChildCountAsync(Guid guid) => await UnitOfWork.PeopleGroup.ChildCountAsync(Cache.ConnectionString, guid);
    }
}
