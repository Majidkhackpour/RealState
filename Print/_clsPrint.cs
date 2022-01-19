using System;
using System.Collections.Generic;
using System.Data;
using EntityCache.Bussines;
using Services;
using Settings.Classes;
using Stimulsoft.Report;

namespace Print
{
    public class _clsPrint
    {
        public ReturnedSaveFuncInfo Print2PrinterNew(StiReport st, DataSet ds, int sanadId, int sanadType, List<object> lst)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                PutExtras(st, ds, sanadId, sanadType, lst);
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

        public ReturnedSaveFuncInfo PrintPreviewNew(StiReport st, DataSet ds, int sanadId, int sanadType,
            List<object> lst)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                PutExtras(st, ds, sanadId, sanadType, lst);
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

        public ReturnedSaveFuncInfo DesignNew(StiReport st, DataSet ds, int sanadId, int sanadType,
            List<object> lst)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                PutExtras(st, ds, sanadId, sanadType, lst);
                st.Design();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
        }

        private void PutExtras(StiReport st, DataSet ds, int sanadId, int sanadType,
            List<object> lst)
        {
            try
            {
                var lst_string = "";
                if (lst != null && lst.Count > 0)
                {
                    foreach (var item in lst)
                    {
                        if (string.IsNullOrEmpty(lst_string))
                            lst_string = item.ToString();
                        else lst_string = lst_string + "," + item;
                    }
                }

                lst_string = string.IsNullOrEmpty(lst_string) ? "0" : lst_string;

                st.Dictionary.Databases.Clear();
                st.Dictionary.Variables.Add("DateM", DateTime.Now);
                st.Dictionary.Variables.Add("DateSH", Calendar.MiladiToShamsi(DateTime.Now));
                st.Dictionary.Variables.Add("SanadID", sanadId);
                st.Dictionary.Variables.Add("SanadType", sanadType);
                st.Dictionary.Variables.Add("LST_String", lst_string);
                st.Dictionary.Variables.Add("CompanyTitle", SettingsBussines.Setting.CompanyInfo.EconomyName);
                st.Dictionary.Variables.Add("CompanyAddress", SettingsBussines.Setting.CompanyInfo.ManagerAddress);
                st.Dictionary.Variables.Add("CompanyTell", SettingsBussines.Setting.CompanyInfo.ManagerTell);

                if (lst != null & lst.Count > 0)
                    st.RegBusinessObject("لیست داده ها", lst);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
