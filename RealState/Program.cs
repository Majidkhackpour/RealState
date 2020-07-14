using System;
using System.Windows.Forms;
using EntityCache.Assistence;

namespace RealState
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            ClsCache.Init();



            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain());
        }
    }
}
