using EntityCache.Bussines;
using Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

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
                if (string.IsNullOrEmpty(SettingsBussines.Setting.Global.ImagePath)) return;

                var localDir = Path.Combine(Application.StartupPath, "Images");
                if (!Directory.Exists(localDir))
                {
                    Directory.CreateDirectory(localDir);
                    return;
                }
                var localFiles = new DirectoryInfo(localDir).GetFiles()?.Select(o => o.Name)?.ToList();
                if (!Directory.Exists(SettingsBussines.Setting.Global.ImagePath))
                    Directory.CreateDirectory(SettingsBussines.Setting.Global.ImagePath);
                var serverFiles = new DirectoryInfo(SettingsBussines.Setting.Global.ImagePath).GetFiles()?.Select(o => o.Name)?.ToList();

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
                if (string.IsNullOrEmpty(SettingsBussines.Setting.Global.MediaPath)) return;

                var localDir = Path.Combine(Application.StartupPath, "Media");
                if (!Directory.Exists(localDir))
                {
                    Directory.CreateDirectory(localDir);
                    return;
                }
                var localFiles = new DirectoryInfo(localDir).GetFiles()?.Select(o => o.Name)?.ToList();
                if (!Directory.Exists(SettingsBussines.Setting.Global.MediaPath))
                    Directory.CreateDirectory(SettingsBussines.Setting.Global.MediaPath);
                var serverFiles = new DirectoryInfo(SettingsBussines.Setting.Global.MediaPath).GetFiles()?.Select(o => o.Name)?.ToList();

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
                if (!Directory.Exists(SettingsBussines.Setting.Global.ImagePath))
                    Directory.CreateDirectory(SettingsBussines.Setting.Global.ImagePath);
                var dir = Path.Combine(Application.StartupPath, "Images");

                foreach (var item in list)
                {
                    var fileName = "";
                    fileName = !item.EndsWith(".jpg")
                        ? Path.Combine(SettingsBussines.Setting.Global.ImagePath, item + ".jpg")
                        : Path.Combine(SettingsBussines.Setting.Global.ImagePath, item);
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
                            ? Path.Combine(SettingsBussines.Setting.Global.ImagePath, item)
                            : Path.Combine(SettingsBussines.Setting.Global.ImagePath, item + ".jpg");
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
                if (!Directory.Exists(SettingsBussines.Setting.Global.MediaPath))
                    Directory.CreateDirectory(SettingsBussines.Setting.Global.MediaPath);
                var dir = Path.Combine(Application.StartupPath, "Media");

                foreach (var item in list)
                {
                    var fileName = "";
                    fileName = Path.Combine(SettingsBussines.Setting.Global.MediaPath, item);
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
                        path_ = Path.Combine(SettingsBussines.Setting.Global.MediaPath, item);
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
