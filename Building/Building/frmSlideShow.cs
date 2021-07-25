using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityCache.Bussines;
using MetroFramework.Forms;
using Services;

namespace Building.Building
{
    public partial class frmSlideShow : MetroForm
    {
        private List<BuildingGalleryBussines> _imageList;

        public frmSlideShow(List<BuildingGalleryBussines> images)
        {
            InitializeComponent();
            _imageList = images;
            timer1.Start();
            timer1_Tick(null, null);
        }

        private void frmSlideShow_FormClosing(object sender, FormClosingEventArgs e) => timer1.Stop();
        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                var rand = new Random().Next(0, _imageList.Count - 1);
                var a = Path.Combine(Application.StartupPath, "Images");
                var fileName = _imageList[rand].ImageName;
                if (!fileName.EndsWith(".jpg"))  fileName += ".jpg";
                var b = Path.Combine(a, fileName);
                picBox.Load(b);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void frmSlideShow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Escape) return;
            timer1.Stop();
            Close();
        }
    }
}
