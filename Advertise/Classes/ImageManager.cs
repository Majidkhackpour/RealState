using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Services;

namespace Advertise.Classes
{
    public static class ImageManager
    {
        public static string ModifyImage(string sourceFullPath)
        {
            try
            {
                var destinationPath = Path.Combine(Application.StartupPath, "temp");
                if (!Directory.Exists(destinationPath))
                    Directory.CreateDirectory(destinationPath);
                destinationPath = Path.Combine(destinationPath, $"{Guid.NewGuid()}.jpg");

                try
                {
                    using (var bm = new Bitmap(sourceFullPath))
                    {
                        var rnd = new Random();
                        var rnd_w = new Random();
                        var rnd_h = new Random();
                        for (var i = 0; i < 10; i++)
                        {
                            bm.SetPixel(rnd_w.Next(bm.Width - 1), rnd_h.Next(bm.Height - 1), Color.FromArgb(rnd.Next(255), rnd.Next(255), rnd.Next(255)));
                        }
                        bm.Save(destinationPath);
                    }
                }
                catch
                {
                }


                return destinationPath;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return "";
            }
        }
    }
}