using System;
using System.Windows.Forms;
using EntityCache.Assistence;
using EntityCache.Bussines;
using Ertegha;
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
                var res = clsErtegha.StartErtegha();
                if (res.HasError)
                {
                    MessageBox.Show("خطا در بازسازی اطلاعات", "پیغام سیستم", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }
                MessageBox.Show("بازسازی اطلاعات با موفقیت انجام شد", "پیغام سیستم", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                var frm = new frmEconomyUnit();
                if (frm.ShowDialog() == DialogResult.Cancel)  Application.Exit();
            }
            Application.Run(new frmMain());
            
        }
    }
}
