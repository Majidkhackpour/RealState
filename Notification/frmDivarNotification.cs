using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using Services;

namespace Notification
{
    public partial class frmDivarNotification : Form
    {
        private int _startPosX;
        private int _startPosY;

        public frmDivarNotification(int rentAppartmentCount, int rentVillaCount, int rentOfficeCount,
            int rentStoreCount, int rentGraund,
            int buyAppartmentCount, int buyOldCount, int buyVillaCount, int buyOfficeCount, int buyStoreCount,
            int buyGraund,
            int mosharekatCount, int preBuyCount)
        {
            InitializeComponent();
            var workingArea = Screen.GetWorkingArea(this);
            Location = new Point(workingArea.Right - Size.Width, workingArea.Bottom - Size.Height);
            TopMost = true;
            _startPosY = Screen.PrimaryScreen.WorkingArea.Height;
            lblRentAppartment.Text = $"اجاره آپارتمان: {rentAppartmentCount} فایل";
            lblRentVilla.Text = $"اجاره خانه و ویلا: { rentVillaCount} فایل";
            lblRentOffice.Text = $"اجاره دفترکار، اتاق اداری و مطب: {rentOfficeCount} فایل";
            lblRentStore.Text = $"اجاره مغازه و غرفه: {rentStoreCount} فایل";
            lblRentGraund.Text = $"اجاره صنعتی، کشاورزی و تجاری: {rentGraund} فایل";
            lblBuyAppartment.Text = $"فروش آپارتمان: {buyAppartmentCount} فایل";
            lblBuyOldHouse.Text = $"فروش زمین و کلنگی: {buyOldCount} فایل";
            lblBuyVilla.Text = $"فروش خانه و ویلا: {buyVillaCount} فایل";
            lblBuyOffice.Text = $"فروش دفترکار، اتاق اداری و مطب: {buyOfficeCount} فایل";
            lblBuyStore.Text = $"فروش مغازه و غرفه: {buyStoreCount} فایل";
            lblBuyGraund.Text = $"فروش صنعتی، کشاورزی و تجاری: {buyGraund} فایل";
            lblMosharekat.Text = $"مشارکت در ساخت: {mosharekatCount} فایل";
            lblPreBuy.Text = $"پیش فروش: {preBuyCount} فایل";
            var total = rentAppartmentCount + rentVillaCount + rentOfficeCount + rentStoreCount + rentGraund +
                        buyAppartmentCount + buyOldCount + buyVillaCount + buyOfficeCount
                        + buyStoreCount + buyGraund + mosharekatCount + preBuyCount;
            lblTotal.Text = $"تعداد کل فایلهای دریافت شده: {total} فایل";
        }

        private void ClosingTimer_Tick(object sender, System.EventArgs e) => Close();
        private void frmDivarNotification_Load(object sender, System.EventArgs e)
        {
            try
            {
                Styler.Start();
                ClosingTimer.Start();
                _startPosX = Screen.PrimaryScreen.WorkingArea.Width - Width;
                _startPosY = Screen.PrimaryScreen.WorkingArea.Height;
                Invoke(new MethodInvoker(() => SetDesktopLocation(_startPosX, _startPosY)));
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void Styler_Tick(object sender, EventArgs e)
        {
            try
            {
                _startPosY -= 5;

                if (_startPosY <= Screen.PrimaryScreen.WorkingArea.Height - Height)
                    Styler?.Stop();
                else
                    SetDesktopLocation(_startPosX, _startPosY);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void frmDivarNotification_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) Close();
        }
    }
}
