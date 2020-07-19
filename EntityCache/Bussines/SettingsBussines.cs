using System;
using System.Threading.Tasks;
using EntityCache.Assistence;
using Nito.AsyncEx;
using PacketParser.Interfaces;
using PacketParser.Services;

namespace EntityCache.Bussines
{
    public class SettingsBussines : ISettings
    {
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; } = DateTime.Now;
        public bool Status { get; set; } = true;
        public string Name { get; set; }
        public string Value { get; set; }


        public static async Task<SettingsBussines> GetAsync(string memberName) =>
    await UnitOfWork.Settings.GetAsync(memberName);

        public static SettingsBussines Get(string memberName) => AsyncContext.Run(() => GetAsync(memberName));
        public static async Task<ReturnedSaveFuncInfo> SaveAsync(string key, string value, string tranName = "")
        {
            var res = new ReturnedSaveFuncInfo();
            var autoTran = string.IsNullOrEmpty(tranName);
            if (autoTran) tranName = Guid.NewGuid().ToString();
            try
            {
                if (autoTran)
                { //BeginTransaction
                }

                var sett = Get(key);
                if (sett != null)
                {
                    res.AddReturnedValue(await UnitOfWork.Settings.RemoveAsync(sett.Guid, tranName));
                    res.ThrowExceptionIfError();
                }

                var set = new SettingsBussines()
                {
                    Guid = Guid.NewGuid(),
                    Name = key,
                    Value = value,
                    Modified = DateTime.Now
                };

                res.AddReturnedValue(await UnitOfWork.Settings.SaveAsync(set, tranName));
                res.ThrowExceptionIfError();
                if (autoTran)
                {
                    //CommitTransAction
                }
            }
            catch (Exception ex)
            {
                if (autoTran)
                {
                    //RollBackTransAction
                }
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
        }

        public async Task<ReturnedSaveFuncInfo> RemoveAsync(string tranName = "")
        {
            var res = new ReturnedSaveFuncInfo();
            var autoTran = string.IsNullOrEmpty(tranName);
            if (autoTran) tranName = Guid.NewGuid().ToString();
            try
            {
                if (autoTran)
                { //BeginTransaction
                }

                res.AddReturnedValue(await UnitOfWork.Settings.RemoveAsync(Guid, tranName));
                res.ThrowExceptionIfError();
                if (autoTran)
                {
                    //CommitTransAction
                }
            }
            catch (Exception ex)
            {
                if (autoTran)
                {
                    //RollBackTransAction
                }
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
        }

        public static ReturnedSaveFuncInfo Save(string key, string value, string tranName = "") =>
            AsyncContext.Run(() => SaveAsync(key, value, tranName));



        #region EconomyUnit

        private static string _economyName = "";
        public static string EconomyName
        {
            get
            {
                if (!string.IsNullOrEmpty(_economyName)) return _economyName;
                var mem = Get("EconomyName");
                return mem == null ? "" : mem.Value;
            }
            set
            {
                _economyName = value;
                Save("EconomyName", _economyName);
            }
        }

        private static string _economyType = "";
        public static string EconomyType
        {
            get
            {
                if (!string.IsNullOrEmpty(_economyType)) return _economyType;
                var mem = Get("EconomyType");
                return mem == null ? "" : mem.Value;
            }
            set
            {
                _economyType = value;
                Save("EconomyType", _economyType);
            }
        }

        private static string _managerMobile = "";
        public static string ManagerMobile
        {
            get
            {
                if (!string.IsNullOrEmpty(_managerMobile)) return _managerMobile;
                var mem = Get("ManagerMobile");
                return mem == null ? "" : mem.Value;
            }
            set
            {
                _managerMobile = value;
                Save("ManagerMobile", _managerMobile);
            }
        }

        private static string _managerName = "";
        public static string ManagerName
        {
            get
            {
                if (!string.IsNullOrEmpty(_managerName)) return _managerName;
                var mem = Get("ManagerName");
                return mem == null ? "" : mem.Value;
            }
            set
            {
                _managerName = value;
                Save("ManagerName", _managerName);
            }
        }

        private static string _managerTell = "";
        public static string ManagerTell
        {
            get
            {
                if (!string.IsNullOrEmpty(_managerTell)) return _managerTell;
                var mem = Get("ManagerTell");
                return mem == null ? "" : mem.Value;
            }
            set
            {
                _managerTell = value;
                Save("ManagerTell", _managerTell);
            }
        }

        private static string _managerFax = "";
        public static string ManagerFax
        {
            get
            {
                if (!string.IsNullOrEmpty(_managerFax)) return _managerFax;
                var mem = Get("ManagerFax");
                return mem == null ? "" : mem.Value;
            }
            set
            {
                _managerFax = value;
                Save("ManagerFax", _managerFax);
            }
        }

        private static string _managerEmail = "";
        public static string ManagerEmail
        {
            get
            {
                if (!string.IsNullOrEmpty(_managerEmail)) return _managerEmail;
                var mem = Get("ManagerEmail");
                return mem == null ? "" : mem.Value;
            }
            set
            {
                _managerEmail = value;
                Save("ManagerEmail", _managerEmail);
            }
        }

        private static string _managerRegion = "";
        public static string ManagerRegion
        {
            get
            {
                if (!string.IsNullOrEmpty(_managerRegion)) return _managerRegion;
                var mem = Get("ManagerRegion");
                return mem == null ? "" : mem.Value;
            }
            set
            {
                _managerRegion = value;
                Save("ManagerRegion", _managerRegion);
            }
        }

        private static string _managerAddress = "";
        public static string ManagerAddress
        {
            get
            {
                if (!string.IsNullOrEmpty(_managerAddress)) return _managerAddress;
                var mem = Get("ManagerAddress");
                return mem == null ? "" : mem.Value;
            }
            set
            {
                _managerAddress = value;
                Save("ManagerAddress", _managerAddress);
            }
        }

        private static string _economyState = "";
        public static string EconomyState
        {
            get
            {
                if (!string.IsNullOrEmpty(_economyState)) return _economyState;
                var mem = Get("EconomyState");
                return mem == null ? "" : mem.Value;
            }
            set
            {
                _economyState = value;
                Save("EconomyState", _economyState);
            }
        }

        private static string _economyCity = "";
        public static string EconomyCity
        {
            get
            {
                if (!string.IsNullOrEmpty(_economyCity)) return _economyCity;
                var mem = Get("EconomyCity");
                return mem == null ? "" : mem.Value;
            }
            set
            {
                _economyCity = value;
                Save("EconomyCity", _economyCity);
            }
        }
        #endregion
    }
}
