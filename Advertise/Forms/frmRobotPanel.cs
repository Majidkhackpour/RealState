using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Advertise.Classes;
using Advertise.Forms.MatchRegions;
using Advertise.Forms.Simcard;
using EntityCache.Bussines;
using EntityCache.ViewModels;
using Services;

namespace Advertise.Forms
{
    public partial class frmRobotPanel : Form
    {
        public frmRobotPanel()
        {
            InitializeComponent();
        }

        private void frmRobotPanel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) Close();
        }

        private void lblSimcard_MouseEnter(object sender, System.EventArgs e)
        {
            lblSimcard.ForeColor = Color.Red;
        }

        private void lblBaseInfo_MouseEnter(object sender, System.EventArgs e)
        {
            lblBaseInfo.ForeColor = Color.Red;
        }

        private void lblBaseInfo_MouseLeave(object sender, System.EventArgs e)
        {
            lblBaseInfo.ForeColor = Color.Silver;
        }

        private void lblSimcard_MouseLeave(object sender, System.EventArgs e)
        {
            lblSimcard.ForeColor = Color.Silver;
        }

        private void lblSimcard_Click(object sender, System.EventArgs e)
        {
            try
            {
                var frm = new frmShowSimcard(false);
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void picSimcard_Click(object sender, EventArgs e)
        {
            lblSimcard_Click(null, null);
        }

        private async void lblBaseInfo_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show(
                        "توجه داشته باشید... درصورتیکه از قبل داده ای را دریافت نموده باشید و مجددا نسبت به دریافت آن اقدام نمایدد، می بایست داده های موجود در صفحه تطبیق را هم اصلاح نمایید. آیا ادامه میدهید؟",
                        "هشدار", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No) return;


                var divar = DivarAdv.GetInstance();
                var cityList = divar.GetAllCityFromDivar();

                var serializedData = new SerializedDataBussines()
                {
                    Guid = Guid.NewGuid(),
                    Name = "DivarCities",
                    Data = Json.ToStringJson(cityList)
                };

                await SerializedDataBussines.SaveAsync("DivarCities", serializedData.Data);


                var cities = await SerializedDataBussines.GetDivarCityAsync();

                var dc = cities.Where(q =>
                    q.Name.Contains("مشهد") || q.Name.Contains("اصفهان") || q.Name.Contains("تهران") ||
                    q.Name.Contains("کرج") || q.Name.Contains("اهواز") || q.Name.Contains("شیراز") ||
                    q.Name.Contains("قم")).ToList();
                var regList = await divar.GetAllRegionFromDivar(dc);
                Utility.CloseAllChromeWindows();
                var serializedData_ = new SerializedDataBussines()
                {
                    Guid = Guid.NewGuid(),
                    Name = "DivarRegions",
                    Data = Json.ToStringJson(regList)
                };

                await SerializedDataBussines.SaveAsync("DivarRegions", serializedData_.Data);


                //var sheypoor = SheypoorAdv.GetInstance();
                //var cityList = sheypoor.GetAllCityFromSheypoor();

                //var serializedData = new SerializedDataBussines()
                //{
                //    Guid = Guid.NewGuid(),
                //    Name = "SheypoorCities",
                //    Data = Json.ToStringJson(cityList)
                //};

                //await SerializedDataBussines.SaveAsync("SheypoorCities", serializedData.Data);



                //var cities_ = await SerializedDataBussines.GetAsync("SheypoorCities");
                //var dc_ = cities_.Data.FromJson<List<SheypoorCities>>();

                //var regList_ = await sheypoor.GetAllRegionFromSheypoor(dc_);
                //Utility.CloseAllChromeWindows();
                //var serializedData_ = new SerializedDataBussines()
                //{
                //    Guid = Guid.NewGuid(),
                //    Name = "DivarRegions",
                //    Data = Json.ToStringJson(regList_)
                //};

                //await SerializedDataBussines.SaveAsync("DivarRegions", serializedData_.Data);


            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void picBaseInfo_Click(object sender, EventArgs e)
        {
            lblBaseInfo_Click(null, null);
        }

        private void lblMatchRegion_MouseEnter(object sender, EventArgs e)
        {
            lblMatchRegion.ForeColor = Color.Red;
        }

        private void lblMatchRegion_MouseLeave(object sender, EventArgs e)
        {
            lblMatchRegion.ForeColor = Color.Silver;
        }

        private void lblMatchRegion_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new frmShowMatchRegion();
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void picMatchRegion_Click(object sender, EventArgs e)
        {
            lblMatchRegion_Click(null, null);
        }

        private void lblSetting_MouseEnter(object sender, EventArgs e)
        {
            lblSetting.ForeColor = Color.Red;
        }

        private void lblSetting_MouseLeave(object sender, EventArgs e)
        {
            lblSetting.ForeColor = Color.Silver;
        }

        private void lblSetting_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new frmRobotSetting();
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            lblSetting_Click(null, null);
        }
    }
}
