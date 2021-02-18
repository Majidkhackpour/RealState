using System;
using System.Windows.Forms;
using Services;

namespace Notification
{
    public partial class frmSplash : Form
    {
        private int _total = 0;
        public frmSplash(int total)
        {
            InitializeComponent();
            _total = total;
        }
        public int Level
        {
            set
            {
                try
                {
                    progressBarX1.Value = (100 * value / _total);
                    if (value - 1 >= _total) Close();
                }
                catch (Exception ex)
                {
                    WebErrorLog.ErrorInstence.StartErrorLog(ex);
                }
            }
        }
    }
}
