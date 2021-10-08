using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using EntityCache.Bussines;
using Services;

namespace Building.UserControls
{
    public partial class UcBuildingImages : UserControl
    {
        private string _picNameJari = "", _pictureNameForClick = null;
        private PictureBox _orGpicBox, _fakepicBox;
        readonly List<string> _lstList = new List<string>();
        private List<BuildingGalleryBussines> _opList;
        public List<BuildingGalleryBussines> GalleryList
        {
            get
            {
                var res = new List<BuildingGalleryBussines>();
                try
                {
                    var img = Path.Combine(Application.StartupPath, "Images");
                    foreach (var item in _opList ?? new List<BuildingGalleryBussines>())
                    {
                        var path = Path.Combine(img, item.ImageName + ".jpg");
                        try { File.Delete(path); }
                        catch { }
                    }

                    res = new List<BuildingGalleryBussines>();

                    foreach (var item in _lstList)
                    {
                        var imagePath = Path.Combine(Application.StartupPath, "Temp");
                        if (!Directory.Exists(imagePath)) Directory.CreateDirectory(imagePath);
                        var name = Guid.NewGuid().ToString();
                        var fileName = Path.Combine(imagePath, name + ".jpg");
                        try { File.Copy(item, fileName); }
                        catch { }


                        var imagePath_ = Path.Combine(Application.StartupPath, "Images");
                        if (!Directory.Exists(imagePath_)) Directory.CreateDirectory(imagePath_);

                        var fileName_ = Path.Combine(imagePath_, name + ".jpg");
                        try { File.Copy(item, fileName_); }
                        catch { }

                        var a = new BuildingGalleryBussines()
                        {
                            Guid = Guid.NewGuid(),
                            ImageName = name,
                            Modified = DateTime.Now
                        };
                        res.Add(a);
                    }

                    try
                    {
                        var imagePath = Path.Combine(Application.StartupPath, "Temp");
                        Directory.Delete(imagePath, true);
                    }
                    catch { }
                }
                catch (Exception ex)
                {
                    WebErrorLog.ErrorInstence.StartErrorLog(ex);
                }

                return res;
            }
            set
            {
                try
                {
                    if (value == null || value.Count <= 0) return;
                    _opList = value;
                    fPanel.Controls.Clear();
                    _lstList.Clear();
                    if (_opList.Count != 0)
                        foreach (var image in _opList)
                        {
                            var a = Path.Combine(Application.StartupPath, "Images");
                            var b = !image.ImageName.EndsWith(".jpg")
                                ? Path.Combine(a, image.ImageName + ".jpg")
                                : Path.Combine(a, image.ImageName);
                            _lstList.Add(b);
                        }

                    Make_Picture_Boxes(_lstList);
                }
                catch (Exception ex)
                {
                    WebErrorLog.ErrorInstence.StartErrorLog(ex);
                }
            }
        }
        private void Make_Picture_Boxes(List<string> lst)
        {
            try
            {
                if (lst == null || lst.Count == 0) return;
                fPanel.AutoScroll = true;
                for (var i = fPanel.Controls.Count - 1; i >= 0; i--)
                    fPanel.Controls[i].Dispose();
                for (var i = 0; i < lst.Count; i++)
                {
                    try
                    {
                        var picbox = new PictureBox();
                        Controls.Add(picbox);
                        picbox.Size = new Size(62, 63);
                        picbox.Load(lst[i]);
                        picbox.Name = "pic" + i;
                        picbox.Cursor = Cursors.Hand;
                        picbox.SizeMode = PictureBoxSizeMode.StretchImage;
                        picbox.Click += picbox_Click;
                        fPanel.Controls.Add(picbox);
                    }
                    catch (Exception)
                    {
                        lst.RemoveAt(i);
                    }
                }
            }
            catch (Exception exception)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(exception);
            }
        }
        public UcBuildingImages()
        {
            InitializeComponent();
        }
        private void picbox_Click(object sender, EventArgs e)
        {
            try
            {
                var imageLocation = ((PictureBox)sender).ImageLocation;
                _picNameJari = ((PictureBox)sender).Name;
                if (_picNameJari == _pictureNameForClick)
                {
                    ((PictureBox)sender).BackColor = Color.Transparent;
                    ((PictureBox)sender).Padding = new Padding(-1);
                    _pictureNameForClick = null;
                    _lstList.Add(imageLocation);
                    _orGpicBox = null;
                    return;
                }

                ((PictureBox)sender).BackColor = Color.Red;
                ((PictureBox)sender).Padding = new Padding(1);
                _pictureNameForClick = ((PictureBox)sender).Name;
                _lstList.Remove(imageLocation);
                _orGpicBox = (PictureBox)sender;
            }
            catch (Exception exception)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(exception);
            }
        }
        private void btnInsImage_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (InvokeRequired)
                {
                    var t = new Thread(() =>
                    {
                        var ofd = new OpenFileDialog { Multiselect = true, RestoreDirectory = true };
                        if (ofd.ShowDialog(this) != DialogResult.OK) return;
                        foreach (var name in ofd.FileNames)
                            _lstList.Add(name);
                    });

                    t.SetApartmentState(ApartmentState.STA);
                    t.Start();
                    t.Join();
                }
                else
                {
                    var ofd = new OpenFileDialog { Multiselect = true, RestoreDirectory = true };
                    if (ofd.ShowDialog(this) != DialogResult.OK) return;
                    foreach (var name in ofd.FileNames)
                        _lstList.Add(name);
                }
                Make_Picture_Boxes(_lstList);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void btnDelImage_Click(object sender, EventArgs e)
        {
            try
            {
                Make_Picture_Boxes(_lstList);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
