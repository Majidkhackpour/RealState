using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mime;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Services;

namespace Advertise.Classes
{
    public static class Utility
    {
        private const string login = "@uuid:autocontrol;password$";
        [DllImport("wtsapi32.dll", SetLastError = true)]
        static extern bool WTSDisconnectSession(IntPtr hServer, int sessionId, bool bWait);

        [DllImport("advapi32.dll", SetLastError = true)]
        private static extern bool OpenProcessToken(IntPtr processHandle, uint desiredAccess, out IntPtr tokenHandle);
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool CloseHandle(IntPtr hObject);
        const int WtsCurrentSession = -1;
        static readonly IntPtr WtsCurrentServerHandle = IntPtr.Zero;
        public static async Task<string> GetLocalIpAddress()
        {
            try
            {
                var request = (HttpWebRequest)WebRequest.Create("http://ifconfig.me");

                request.UserAgent = "curl";

                string publicIpAddress;

                request.Method = "GET";
                using (var response = request.GetResponse())
                using (var reader = new StreamReader(response.GetResponseStream()))
                    publicIpAddress = reader.ReadToEnd();

                return publicIpAddress.Replace("\n", "");
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static async Task<string> GetNetworkIpAddress()
        {
            try
            {
                var host = Dns.GetHostEntry(Dns.GetHostName());
                foreach (var ip in host.AddressList)
                    if (ip.AddressFamily == AddressFamily.InterNetwork)
                        return ip.ToString();
                throw new Exception("No network adapters with an IPv4 address in the system!");
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return null;
            }
        }

        public static async Task Wait(double second = 0.5)
        {
            await Task.Delay((int)(second * 1000));
        }

        public static List<string> GetFiles(string path, string filePattern = "*.*")
        {
            return Directory.Exists(path) ? Directory.GetFiles(path, filePattern).ToList() : null;
        }

        public static void CloseAllChromeWindows()
        {
            try
            {
                var userName = Environment.UserName;
                foreach (var item in Process.GetProcesses())
                    if (item.ProcessName == "chromedriver" || item.ProcessName == "chrome")
                    {
                        var userOfProcess = GetProcessUser(item);
                        if (userOfProcess == userName)
                            item.Kill();
                    }
            }
            catch
            {
            }
        }

        private static string GetProcessUser(Process process)
        {
            var processHandle = IntPtr.Zero;
            try
            {
                OpenProcessToken(process.Handle, 8, out processHandle);
                var wi = new WindowsIdentity(processHandle);
                var user = wi.Name;
                return user.Contains(@"\") ? user.Substring(user.IndexOf(@"\", StringComparison.Ordinal) + 1) : user;
            }
            catch
            {
                return null;
            }
            finally
            {
                if (processHandle != IntPtr.Zero)
                {
                    CloseHandle(processHandle);
                }
            }
        }

        public static IWebDriver RefreshDriver(IWebDriver driver)
        {
            try
            {
                if (driver?.Title == null)
                {
                    CloseAllChromeWindows();
                    driver = new ChromeDriver();
                    driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(200);
                    driver?.Manage().Window.Maximize();
                    //CloseAllChromeWindows();
                    //var options = new ChromeOptions();
                    //options.AddArgument("headless");
                    //var driverService = ChromeDriverService.CreateDefaultService();
                    //driverService.HideCommandPromptWindow = true;
                    //driver = new ChromeDriver(driverService, options);
                }
            }
            catch (Exception)
            {
                CloseAllChromeWindows();
                driver = new ChromeDriver();
                driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(200);
                driver?.Manage().Window.Maximize();
                //var options = new ChromeOptions();
                //options.AddArgument("headless");
                //var driverService = ChromeDriverService.CreateDefaultService();
                //driverService.HideCommandPromptWindow = true;
                //driver = new ChromeDriver(driverService, options);
            }
            return driver;
        }

        public static string GetHtmlCode(string url)
        {
            var data = "";
            try
            {
                var request = (HttpWebRequest)WebRequest.Create(url);
                var response = (HttpWebResponse)request.GetResponse();

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var receiveStream = response.GetResponseStream();
                    StreamReader readStream = null;
                    if (receiveStream != null)
                    {
                        readStream = string.IsNullOrWhiteSpace(response.CharacterSet)
                            ? new StreamReader(receiveStream)
                            : new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));
                    }

                    data = readStream?.ReadToEnd();

                    response.Close();
                    readStream?.Close();
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return data;

        }

        public static async Task<string> FindGateWay()
        {
            try
            {
                var gateWay = NetworkInterface
                    .GetAllNetworkInterfaces()
                    .Where(n => n.OperationalStatus == OperationalStatus.Up)
                    .Where(n => n.NetworkInterfaceType != NetworkInterfaceType.Loopback)
                    .SelectMany(n => n.GetIPProperties()?.GatewayAddresses)
                    .Select(g => g?.Address)
                    .FirstOrDefault(a => a != null);
                return gateWay?.ToString() ?? null;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return null;
            }
        }

        public static async Task<bool> PingHost(string nameOrAddress)
        {
            var pingable = false;
            Ping pinger = null;

            try
            {
                pinger = new Ping();
                var reply = pinger.Send(nameOrAddress);
                pingable = reply?.Status == IPStatus.Success;
            }
            catch (PingException)
            {
                pingable = false;
            }
            finally
            {
                pinger?.Dispose();
            }

            return pingable;
        }

        public static void ShowBalloon(string title, List<string> body)
        {
            var notifyIcon = new NotifyIcon { Visible = true, Icon = SystemIcons.Application };
            try
            {
                notifyIcon.BalloonTipTitle = title;
                var text = "";
                foreach (var item in body)
                    text += item + '\n';
                notifyIcon.BalloonTipText = text;
                notifyIcon.ShowBalloonTip(30000);
            }
            catch
            {
                // ignored
            }
            finally
            {
                notifyIcon.Dispose();
            }
        }





        private static List<string> lstMessage = new List<string>();

        private static async Task UpdateAdvStatus(int dayCount = 0)
        {
            try
            {
                var thr = new Thread(async () => await DeleteTemp());
                thr.Start();

                var divar = DivarAdv.GetInstance();
                await divar.UpdateAllAdvStatus(500, dayCount);

                var thr1 = new Thread(async () => await DeleteTemp());
                thr1.Start();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        public static async Task DeleteTemp()
        {
            try
            {
                var item = Path.GetTempPath();
                var folders = new DirectoryInfo(item).GetDirectories().ToList();
                if (folders.Count <= 0)
                    return;
                foreach (var ff in folders)
                {
                    File.SetAttributes(ff.FullName, FileAttributes.Normal);
                    try
                    {
                        Directory.Delete(ff.FullName, true);
                    }
                    catch
                    {
                    }
                }

                var files = Directory.GetFiles(item);
                foreach (var ff in files)
                {
                    try
                    {
                        File.Delete(ff);
                    }
                    catch
                    {
                    }
                }

                try
                {
                    var tempPath = Path.Combine(Application.StartupPath, "Temp");
                    if (Directory.Exists(tempPath)) Directory.Delete(tempPath, true);
                }
                catch
                { }
            }
            catch (Exception)
            {
            }
        }
    }
}
