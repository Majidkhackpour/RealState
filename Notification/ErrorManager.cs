using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Services;

namespace Notification
{
    public static class ErrorManager
    {
        private static IWin32Window Owner { get; set; } = null;
        private static CancellationTokenSource _displayErrorToken = new CancellationTokenSource();
        public static void Init(ENSource _source, IWin32Window owner)
        {
            try
            {
                Owner = owner;
                clsShowError.Source = _source;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        public static bool IsShowError(Form frm)
        {
            try
            {
                var processes = Application.OpenForms;
                foreach (Form p in processes)
                {
                    if (p.Name == frm.Name)  return true;
                }
            }
            catch (Exception ex) { WebErrorLog.ErrorInstence.StartErrorLog(ex); }
            return false;
        }
    }
}