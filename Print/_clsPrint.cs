using EntityCache.Bussines;
using Persistence;
using Services;
using Stimulsoft.Report;
using System;
using System.Collections.Generic;

namespace Print
{
    public class _clsPrint
    {
        public ReturnedSaveFuncInfo Print2PrinterNew(StiReport st, Guid sanadGuid, int sanadType, List<object> lst, int refrenceId, object companyInfo, bool isLimit)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                PutExtras(st, sanadGuid, sanadType, lst, refrenceId, companyInfo, isLimit);
                if (SettingsBussines.Setting.Print.ShowDesign) st.Design();
                else if (SettingsBussines.Setting.Print.ShowPreview) st.Show();
                else st.Print(false, 1);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
        }

        public ReturnedSaveFuncInfo PrintPreviewNew(StiReport st, Guid sanadGuid, int sanadType, List<object> lst, int refrenceId, object companyInfo, bool isLimit)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                PutExtras(st, sanadGuid, sanadType, lst, refrenceId, companyInfo, isLimit);
                if (SettingsBussines.Setting.Print.ShowDesign) st.Design();
                else st.Show(true);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
        }

        public ReturnedSaveFuncInfo DesignNew(StiReport st, Guid sanadGuid, int sanadType, List<object> lst, int refrenceId, object companyInfo, bool isLimit)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                PutExtras(st, sanadGuid, sanadType, lst, refrenceId, companyInfo, isLimit);
                st.Design();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
        }

        private void PutExtras(StiReport st, Guid sanadGuid, int sanadType, List<object> lst, int refrenceId, object companyInfo, bool isLimit)
        {
            try
            {
                st.Dictionary.Databases.Clear();
                var db = new Stimulsoft.Report.Dictionary.StiSqlDatabase("Database", Cache.ConnectionString);
                st.Dictionary.Databases.Add(db);
                st.Dictionary.Variables.Add("DateM", DateTime.Now);
                st.Dictionary.Variables.Add("DateSH", Calendar.MiladiToShamsi(DateTime.Now));
                st.Dictionary.Variables.Add("SanadGuid", sanadGuid);
                st.Dictionary.Variables.Add("SanadType", sanadType);
                st.Dictionary.Variables.Add("RefrenceId", refrenceId);
                st.Dictionary.Variables.Add("LimitReport", isLimit);
                st.Dictionary.Variables.Add("Time", $"{DateTime.Now.Hour}:{DateTime.Now.Minute}");

                if (lst != null && lst.Count > 0)
                    st.RegBusinessObject("لیست داده ها", lst);
                if (companyInfo != null)
                    st.RegBusinessObject("مشخصات_شرکت", companyInfo);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
