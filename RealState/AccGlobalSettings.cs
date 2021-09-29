using System;
using System.Reflection;
using System.Windows.Forms;
using Services;

namespace RealState
{
    public class AccGlobalSettings
    {
        public static string AppVersion
        {
            get
            {
                try
                {
                    var version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
                    var ret = version.Replace(".", "");
                    switch (ret.Length)
                    {
                        case 1:
                            ret += "000";
                            break;
                        case 2:
                            ret += "00";
                            break;
                        case 3:
                            ret += "0";
                            break;
                        default:
                        {
                            if (ret.Length > 4) ret = ret.Substring(0, 4);
                            break;
                        }
                    }

                    return ret;
                }
                catch (Exception ex)
                {
                    WebErrorLog.ErrorInstence.StartErrorLog(ex);
                    return "";
                }
            }
        }

        private static bool _isAuthorize = false;
        public static bool IsAuthorize
        {
            get => _isAuthorize;
            set
            {
                if (value)
                {
                    _isAuthorize = true;
                    return;
                }
                MessageBox.Show("مشتری گرامی، مشخصه فنی شما مورد تایید نمی باشد. لطفا برای احراز هویت با تیم پشتیبانی تماس بگیرید");
                //SoftwareLock.clsRegistery.SetRegistery("", "U1001ML");
            }
        }
    }
}
