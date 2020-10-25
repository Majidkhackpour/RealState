using System;
using System.Collections.Generic;
using System.Windows.Forms;
using EntityCache.Bussines;
using Services;

namespace RealState.Note
{
    public partial class frmReminder : Form
    {
        private List<NoteBussines> list;
        public frmReminder(List<NoteBussines> lst)
        {
            InitializeComponent();
            list = lst;
        }

        private void frmReminder_Load(object sender, System.EventArgs e)
        {
            try
            {
                for (var i = 0; i < list.Count; i++)
                {
                    if (i == 0) lblNaqz.Text += $"\n \n \n \n {i + 1}- {list[i].Description}";
                    else lblNaqz.Text += $"\n {i + 1}- {list[i].Description}";
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void frmReminder_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) Close();
        }
    }
}
