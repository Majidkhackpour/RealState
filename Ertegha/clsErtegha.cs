﻿using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityCache.Bussines;
using Services;

namespace Ertegha
{
    public class clsErtegha
    {
        public static async Task<ReturnedSaveFuncInfo> StartErteghaAsync(string connectionString, IWin32Window owner, bool isShowUi)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                var cn = new SqlConnection(connectionString);
                res.AddReturnedValue(await DataBaseUtilities.RunScript.RunAsync(isShowUi, owner, Properties.Resources.ErteghaFunctions, cn));
                res.AddReturnedValue(await DataBaseUtilities.RunScript.RunAsync(isShowUi, owner, Properties.Resources.Ertegha, cn));
                if (res.HasError) return res;
                res.AddReturnedValue(await clsFixBuilding.FixBuildingImage());
                if (res.HasError) return res;
                res.AddReturnedValue(await BuildingBussines.SetArchiveAsync());
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
