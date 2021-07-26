using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Services;
using Settings.Classes;

namespace RealState
{
    public class FileFormatter
    {
        public static void Init()
        {
            try
            {
                _ = Task.Run(SyncImagesAsync);
                _ = Task.Run(SyncMediasAsync);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private static async Task SyncImagesAsync()
        {
            try
            {
                if (string.IsNullOrEmpty(clsGlobal.ImagePath)) return;

                var localDir = Path.Combine(Application.StartupPath, "Images");
                var localFiles = new DirectoryInfo(localDir).GetFiles()?.Select(o => o.Name)?.ToList();
                if (!Directory.Exists(clsGlobal.ImagePath))
                    Directory.CreateDirectory(clsGlobal.ImagePath);
                var serverFiles = new DirectoryInfo(clsGlobal.ImagePath).GetFiles()?.Select(o => o.Name)?.ToList();

                if (localFiles.Count <= 0 && serverFiles.Count <= 0) return;

                if (localFiles.Count <= 0 && serverFiles.Count > 0)
                {
                    await CopyImagesFromServerToClientAsync(serverFiles);
                    return;
                }

                if (localFiles.Count > 0 && serverFiles.Count <= 0)
                {
                    await CopyImagesFromClientToServerAsync(localFiles);
                    return;
                }

                await CopyImagesFromServerToClientAsync(serverFiles.Where(q => !localFiles.Contains(q))?.ToList());
                await CopyImagesFromClientToServerAsync(localFiles.Where(q => !serverFiles.Contains(q))?.ToList());
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private static async Task SyncMediasAsync()
        {
            try
            {
                if (string.IsNullOrEmpty(clsGlobal.MediaPath)) return;

                var localDir = Path.Combine(Application.StartupPath, "Media");
                var localFiles = new DirectoryInfo(localDir).GetFiles()?.Select(o => o.Name)?.ToList();
                if (!Directory.Exists(clsGlobal.MediaPath))
                    Directory.CreateDirectory(clsGlobal.MediaPath);
                var serverFiles = new DirectoryInfo(clsGlobal.MediaPath).GetFiles()?.Select(o => o.Name)?.ToList();

                if (localFiles.Count <= 0 && serverFiles.Count <= 0) return;

                if (localFiles.Count <= 0 && serverFiles.Count > 0)
                {
                    await CopyMediasFromServerToClientAsync(serverFiles);
                    return;
                }

                if (localFiles.Count > 0 && serverFiles.Count <= 0)
                {
                    await CopyMediasFromClientToServerAsync(localFiles);
                    return;
                }

                await CopyMediasFromServerToClientAsync(serverFiles.Where(q => !localFiles.Contains(q))?.ToList());
                await CopyMediasFromClientToServerAsync(localFiles.Where(q => !serverFiles.Contains(q))?.ToList());
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private static async Task CopyImagesFromClientToServerAsync(List<string> list)
        {
            try
            {
                if (list == null || list.Count <= 0) return;
                if (!Directory.Exists(clsGlobal.ImagePath))
                    Directory.CreateDirectory(clsGlobal.ImagePath);
                var dir = Path.Combine(Application.StartupPath, "Images");

                foreach (var item in list)
                {
                    var fileName = "";
                    fileName = !item.EndsWith(".jpg")
                        ? Path.Combine(clsGlobal.ImagePath, item + ".jpg")
                        : Path.Combine(clsGlobal.ImagePath, item);
                    try
                    {
                        var path_ = "";
                        path_ = item.EndsWith(".jpg") ? Path.Combine(dir, item) : Path.Combine(dir, item + ".jpg");
                        File.Copy(path_, fileName);
                    }
                    catch { }
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private static async Task CopyImagesFromServerToClientAsync(List<string> list)
        {
            try
            {
                if (list == null || list.Count <= 0) return;
                var dir = Path.Combine(Application.StartupPath, "Images");
                if (!Directory.Exists(dir))
                    Directory.CreateDirectory(dir);

                foreach (var item in list)
                {
                    var fileName = "";
                    fileName = !item.EndsWith(".jpg")
                        ? Path.Combine(dir, item + ".jpg")
                        : Path.Combine(dir, item);
                    try
                    {
                        var path_ = "";
                        path_ = item.EndsWith(".jpg")
                            ? Path.Combine(clsGlobal.ImagePath, item)
                            : Path.Combine(clsGlobal.ImagePath, item + ".jpg");
                        File.Copy(path_, fileName);
                    }
                    catch { }
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private static async Task CopyMediasFromClientToServerAsync(List<string> list)
        {
            try
            {
                if (list == null || list.Count <= 0) return;
                if (!Directory.Exists(clsGlobal.MediaPath))
                    Directory.CreateDirectory(clsGlobal.MediaPath);
                var dir = Path.Combine(Application.StartupPath, "Media");

                foreach (var item in list)
                {
                    var fileName = "";
                    fileName = Path.Combine(clsGlobal.MediaPath, item);
                    try
                    {
                        var path_ = "";
                        path_ = Path.Combine(dir, item);
                        File.Copy(path_, fileName);
                    }
                    catch { }
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private static async Task CopyMediasFromServerToClientAsync(List<string> list)
        {
            try
            {
                if (list == null || list.Count <= 0) return;
                var dir = Path.Combine(Application.StartupPath, "Media");
                if (!Directory.Exists(dir))
                    Directory.CreateDirectory(dir);

                foreach (var item in list)
                {
                    var fileName = "";
                    fileName = Path.Combine(dir, item);
                    try
                    {
                        var path_ = "";
                        path_ = Path.Combine(clsGlobal.MediaPath, item);
                        File.Copy(path_, fileName);
                    }
                    catch { }
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
