using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using EntityCache.Bussines;
using MetroFramework.Forms;
using Print;
using Services;

namespace User
{
    public partial class frmUserLog : MetroForm
    {
        private Guid userGuid;
        private DateTime d1, d2;
        private IEnumerable<UserLogBussines> list;
        private void LoadData()
        {
            try
            { 
                list = UserLogBussines.GetAll(userGuid, d1, d2).OrderByDescending(q => q.Date);
                logBindingSource.DataSource = list.ToSortableBindingList();
                lblUserName.Text = UserBussines.Get(userGuid)?.Name ?? "";
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void frmUserLog_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void frmUserLog_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Escape) Close();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new frmSetPrintSize();
                if (frm.ShowDialog() != DialogResult.OK) return;

                var cls = new ReportGenerator(StiType.User_Performence_List, frm.PrintType) { Lst = new List<object>(list) };
                cls.PrintNew();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        public frmUserLog(Guid _userGuid, DateTime _d1, DateTime _d2)
        {
            InitializeComponent();
            userGuid = _userGuid;
            d1 = _d1;
            d2 = _d2;
        }
    }
}
