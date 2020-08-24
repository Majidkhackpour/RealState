using System;
using System.Threading.Tasks;
using Services;

namespace Settings
{
    public class clsRegistery
    {
        public static ReturnedSaveFuncInfo SetRegistery(string sqlConnection, string name)
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
        public static ReturnedSaveFuncInfo GetRegistery(string name)
        {
            var ret = new ReturnedSaveFuncInfo();
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
    }
}
