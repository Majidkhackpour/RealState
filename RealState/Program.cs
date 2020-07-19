using System;
using System.Windows.Forms;
using EntityCache.Assistence;
using EntityCache.Bussines;
using Settings;

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

            if (string.IsNullOrEmpty(SettingsBussines.EconomyName))
            {
                var frm = new frmEconomyUnit();
                if (frm.ShowDialog() == DialogResult.Cancel)  Application.Exit();
            }
            Application.Run(new frmMain());
            
        }
    }
}
