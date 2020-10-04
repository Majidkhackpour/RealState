using System;
using System.Threading.Tasks;
using Services;

namespace Settings
{
    public class clsRegistery
    {
        public static ReturnedSaveFuncInfo SetConnectionRegistery(string sqlConnection, string name)
        {
            var ret = new ReturnedSaveFuncInfo();
            try
            {
                Microsoft.Win32.Registry.SetValue("HKEY_CURRENT_USER\\Software\\Arad\\" + name + "", "SQLCN",
                    sqlConnection);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                ret.AddReturnedValue(ex);
            }
            return ret;
        }
        public static ReturnedSaveFuncInfoWithValue<string> GetConnectionRegistery(string name)
        {
            var ret = new ReturnedSaveFuncInfoWithValue<string>();
            try
            {
                var a = Microsoft.Win32.Registry.GetValue("HKEY_CURRENT_USER\\Software\\Arad\\", name,
                    "");
                ret.value = a.ToString();
            }
            catch (Exception ex)
            {
                //WebErrorLog.ErrorInstence.StartErrorLog(ex);
                ret.AddReturnedValue(ex);
            }
            return ret;
        }


        public static ReturnedSaveFuncInfo SetRegistery(string value, string name)
        {
            var ret = new ReturnedSaveFuncInfo();
            try
            {
                Microsoft.Win32.Registry.SetValue("HKEY_CURRENT_USER\\Software\\Arad", name,
                    value);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                ret.AddReturnedValue(ex);
            }
            return ret;
        }
        public static string GetRegistery(string name)
        {
            try
            {
                var a = Microsoft.Win32.Registry.GetValue("HKEY_CURRENT_USER\\Software\\Arad\\", name,
                    "");
                return a.ToString();
            }
            catch (Exception ex)
            {
                //WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return null;
            }
        }
    }
}
