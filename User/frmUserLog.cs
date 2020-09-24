﻿using System;
using System.Linq;
using System.Windows.Forms;
using EntityCache.Bussines;
using MetroFramework.Forms;
using Services;

namespace User
{
    public partial class frmUserLog : MetroForm
    {
        private Guid userGuid;
        private DateTime d1, d2;

        private void LoadData()
        {
            try
            {
                var list = UserLogBussines.GetAll(userGuid, d1, d2).OrderByDescending(q => q.Date);
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

        public frmUserLog(Guid _userGuid, DateTime _d1, DateTime _d2)
        {
            InitializeComponent();
            userGuid = _userGuid;
            d1 = _d1;
            d2 = _d2;
        }
    }
}