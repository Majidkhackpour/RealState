using System;
using System.Windows.Forms;
using EntityCache.Bussines;
using Services;

namespace Building.UserControls
{
    public partial class UcBuildingLog : UserControl
    {
        public UserLogBussines Log
        {
            set
            {
                try
                {
                    if (value == null) return;
                    lblTitle.Text = value.ActionName;
                    lblUserName.Text = value.UserName;
                    lblDate.Text = value.DateSh;
                    lblTime.Text = value.Time;
                }
                catch (Exception ex)
                {
                    WebErrorLog.ErrorInstence.StartErrorLog(ex);
                }
            }
        }
        public UcBuildingLog() => InitializeComponent();
    }
}
