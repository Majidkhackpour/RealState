﻿using Advertise.Classes;
using EntityCache.Bussines;
using Notification;
using Services;
using Settings.Classes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebHesabBussines;

namespace RealState
{
    public class DivarFiles
    {
        private static bool _isInited = false;

        public static event Func<int, Task> OnSavedFinished;
        public static event Func<int, Task> OnSavedStarted;
        public static event Func<int, Task> OnDataRecieved;
        public static void Init() => _ = Task.Run(GetFilesFromDivarAsync);
        private static async Task GetFilesFromDivarAsync()
        {
            try
            {
                if (_isInited) return;
                await Task.Delay(5000);
                //return;
                if (!VersionAccess.Advertise) return;
                //if (!clsAdvertise.IsGiveFile) return;
                if (!WebCustomer.CheckCustomer() ||
                    WebCustomer.Customer.isBlock ||
                    WebCustomer.Customer.isWebServiceBlock)
                    return;

                var lstImagesForRemove = new List<string>();

                var getDate = clsAdvertise.GetFileDate ?? DateTime.Now.AddDays(-7);
                var newDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
                if (getDate != null && getDate > newDate) return;

                var insertedDate = new DateTime(getDate.Year, getDate.Month, getDate.Day, 0, 0, 0);
                var list = await WebScrapper.GetAllAsync(insertedDate);
                if (list == null || list.Count <= 0) return;
                _isInited = true;
                var state = await StatesBussines.GetAsync("خراسان رضوی");
                if (state == null) return;
                var city = await CitiesBussines.GetDefualtAsync("مشهد", state.Guid);

                RaiseStartedEvent(list.Count);
                var _buildingCount = 0;
                foreach (var item in list)
                {
                    try
                    {
                        if (await BuildingBussines.CheckDuplicateAsync(item.Title.FixString()))
                            continue;

                        var region = await RegionsBussines.GetDefualtAsync(item.Region, city.Guid);
                        var bu = new BuildingBussines
                        {
                            Guid = Guid.NewGuid(),
                            Modified = DateTime.Now,
                            Status = true,
                            Masahat = item.Masahat,
                            SellPrice = item.SellPrice,
                            ServerStatus = ServerStatus.None,
                            Code = BuildingBussines.NextCode(),
                            RahnPrice1 = item.RahnPrice,
                            ServerDeliveryDate = DateTime.Now,
                            EjarePrice1 = item.EjarePrice,
                            RegionGuid = region.Guid,
                            Tell = EnKhadamati.Mostaqel,
                            RoomCount = item.RoomCount,
                            Address = $"{item.State} {item.City} {item.Region}",
                            AdvertiseType = item.Type,
                            Barq = EnKhadamati.Mostaqel,
                            BonBast = false,
                            BuildingAccountTypeGuid = await BuildingAccountTypeBussines.GetDefultGuidAsync(GetAccountType(item.BuildingType)),
                            BuildingConditionGuid = BuildingConditionBussines.DefualtGuid,
                            BuildingTypeGuid = await BuildingTypeBussines.GetDefultGuidAsync(item.BuildingType),
                            BuildingViewGuid = BuildingViewBussines.DefualtGuid,
                            CityGuid = city.Guid,
                            CreateDate = DateTime.Now,
                            Dang = 6,
                            DeliveryDate = DateTime.Now,
                            DivarCount = 0,
                            DocumentType = null,
                            EjarePrice2 = 0,
                            DateParvane = "",
                            ErtefaSaqf = 3,
                            FloorCoverGuid = FloorCoverBussines.DefualtGuid,
                            Gas = EnKhadamati.Mostaqel,
                            Hashie = 0,
                            IsArchive = false,
                            IsOwnerHere = false,
                            IsShortTime = false,
                            DivarTitle = item.Title,
                            Image = "",
                            KitchenServiceGuid = KitchenServiceBussines.DefualtGuid,
                            Lenght = 0,
                            MamarJoda = true,
                            MetrazhKouche = 0,
                            MetrazhTejari = 0,
                            MoavezeDesc = "",
                            MosharekatDesc = "",
                            ParvaneSerial = "",
                            Water = EnKhadamati.Mostaqel,
                            ZirBana = item.Masahat,
                            VamPrice = 0,
                            VahedPerTabaqe = item.VahedPerTabaqe,
                            UserGuid = UserBussines.CurrentUser.Guid,
                            TelegramCount = 0,
                            TedadTabaqe = item.TabaqeCount,
                            Tarakom = EnTarakom.Min,
                            TabaqeNo = item.TabaqeNo,
                            Side = GetSide(item.BuildingSide),
                            ShortDesc = item.Description,
                            SheypoorCount = 0,
                            SaleSakht = item.SaleSakht,
                            RahnPrice2 = 0,
                            QestPrice = 0,
                            PishTotalPrice = 0,
                            PishPrice = 0,
                            Priority = EnBuildingPriority.Low,
                            PishDesc = "",
                            OptionList = new List<BuildingRelatedOptionsBussines>(),
                            RentalAutorityGuid = RentalAuthorityBussines.Get(item.RentalAuthority)?.Guid ?? null,
                            OwnerGuid = PeoplesBussines.DefualtGuid
                        };

                        if (item.BuildingType == "پیش‌فروش" || item.BuildingType == "پیش‌ فروش")
                            bu.PishDesc = item.Description;
                        if (item.BuildingType == "مشارکت در ساخت")
                            bu.MosharekatDesc = item.Description;

                        if (item.SaleSakht.Contains("از"))
                            bu.SaleSakht = "1370";

                        if (bu.RentalAutorityGuid == Guid.Empty)
                            bu.RentalAutorityGuid = null;

                        if (item.Evelator)
                        {
                            bu.OptionList.Add(new BuildingRelatedOptionsBussines()
                            {
                                Guid = Guid.NewGuid(),
                                Modified = DateTime.Now,
                                ServerStatus = ServerStatus.None,
                                ServerDeliveryDate = DateTime.Now,
                                BuildingOptionGuid = BuildingOptionsBussines.EveletorGuid,
                                BuildinGuid = bu.Guid
                            });
                        }
                        if (item.Balcony)
                        {
                            bu.OptionList.Add(new BuildingRelatedOptionsBussines()
                            {
                                Guid = Guid.NewGuid(),
                                Modified = DateTime.Now,
                                ServerStatus = ServerStatus.None,
                                ServerDeliveryDate = DateTime.Now,
                                BuildingOptionGuid = BuildingOptionsBussines.BalconyGuid,
                                BuildinGuid = bu.Guid
                            });
                        }
                        if (item.Parking)
                        {
                            bu.OptionList.Add(new BuildingRelatedOptionsBussines()
                            {
                                Guid = Guid.NewGuid(),
                                Modified = DateTime.Now,
                                ServerStatus = ServerStatus.None,
                                ServerDeliveryDate = DateTime.Now,
                                BuildingOptionGuid = BuildingOptionsBussines.ParkingGuid,
                                BuildinGuid = bu.Guid
                            });
                        }
                        if (item.Store)
                        {
                            bu.OptionList.Add(new BuildingRelatedOptionsBussines()
                            {
                                Guid = Guid.NewGuid(),
                                Modified = DateTime.Now,
                                ServerStatus = ServerStatus.None,
                                ServerDeliveryDate = DateTime.Now,
                                BuildingOptionGuid = BuildingOptionsBussines.StoreGuid,
                                BuildinGuid = bu.Guid
                            });
                        }


                        var lstImage = item.ImagesList.FromJson<List<string>>();
                        if (lstImage == null || lstImage.Count <= 0) continue;
                        bu.GalleryList = new List<BuildingGalleryBussines>();
                        foreach (var img in lstImage)
                        {
                            var bannerPath = Path.Combine(Application.StartupPath, "testBanner__.jpg");
                            var savePathFile = Path.Combine(Application.StartupPath, "Images");
                            if (!Directory.Exists(savePathFile)) Directory.CreateDirectory(savePathFile);
                            var path = Path.Combine(savePathFile, Guid.NewGuid() + ".jpg");
                            var pathsave = Path.Combine(savePathFile, Guid.NewGuid() + ".jpg");
                            var finnalPath = Path.Combine(savePathFile, Guid.NewGuid() + ".jpg");
                            //دانلود تصویر
                            DivarAPI.DownloadImage(img, path);
                            if (!File.Exists(path)) continue;
                            //ایجاد تصویر با بنر
                            CreateNewImage(path, bannerPath, pathsave);
                            //ایجاد تصویر نهایی
                            WriteTextOnImage(clsEconomyUnit.EconomyName, clsEconomyUnit.ManagerMobile, pathsave, finnalPath);
                            lstImagesForRemove.Add(path);
                            lstImagesForRemove.Add(pathsave);

                            bu.GalleryList.Add(new BuildingGalleryBussines()
                            {
                                Guid = Guid.NewGuid(),
                                Modified = DateTime.Now,
                                ServerStatus = ServerStatus.None,
                                ServerDeliveryDate = DateTime.Now,
                                BuildingGuid = bu.Guid,
                                ImageName = finnalPath
                            });
                        }

                        var res = await bu.SaveAsync(null, false, true);
                        if (!res.HasError)
                        {
                            _buildingCount++;
                            RaiseDataRecievedEvent(_buildingCount);
                        }

                        if (_buildingCount % 100 != 0) continue;
                        if (!WebCustomer.CheckCustomer()) continue;
                        var msg = "درحال دریافت \r\n" +
                                  $"{_buildingCount} فایل دریافت شد";
                        _ = Task.Run(() => WebTelegramReporter.SendBuildingReport(WebCustomer.Customer.Guid, msg));
                    }
                    catch (Exception ex)
                    {
                        WebErrorLog.ErrorInstence.StartErrorLog(ex);
                    }
                }

                RemoveUnusedFiles(lstImagesForRemove);
                BuildingBussines.RaiseStaticEvent();
                RaiseFinishedEvent(_buildingCount);
                _isInited = false;
                //clsAdvertise.GetFileDate = DateTime.Now;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                clsAdvertise.GetFileDate = DateTime.Now.AddDays(-1);
            }
        }
        private static EnBuildingSide GetSide(string sideName)
        {
            try
            {
                switch (sideName)
                {
                    case "شمالی": return EnBuildingSide.One;
                    case "جنوبی": return EnBuildingSide.Tow;
                    case "شرقی": return EnBuildingSide.Three;
                    case "غربی": return EnBuildingSide.Four;
                    case "شمالی شرقی": return EnBuildingSide.Five;
                    case "شمالی غربی": return EnBuildingSide.Six;
                    case "جنوبی شرقی": return EnBuildingSide.Seven;
                    case "جنوبی غربی": return EnBuildingSide.Eight;
                    case "شمالی جنوبی دوکله": return EnBuildingSide.Nine;
                    case "شرقی غربی دوکله": return EnBuildingSide.Ten;
                    case "شمالی شرقی غربی": return EnBuildingSide.Eleven;
                    case "جنوبی شرقی غربی": return EnBuildingSide.Towelve;
                    case "شرقی شمالی جنوبی": return EnBuildingSide.Thirteen;
                    case "غربی شمالی جنوبی": return EnBuildingSide.Fourteen;
                    default: return EnBuildingSide.One;
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return EnBuildingSide.One;
            }
        }
        private static string GetAccountType(string item)
        {
            try
            {
                switch (item)
                {
                    case "پیش‌فروش":
                    case "پیش‌ فروش":
                    case "مشارکت در ساخت":
                        return "مسکونی";
                    case "مغازه و غرفه":
                    case "دفتر کار، اتاق اداری و مطب":
                        return "مشاغل تجاری";
                    case "زمین و کلنگی":
                    case "خانه و ویلا":
                    case "آپارتمان":
                        return "مسکونی";
                    case "صنعتی، کشاورزی و تجاری":
                        return "مشاغل تجاری";
                    default:
                        return "تعیین نشده";
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return "تعیین نشده";
            }
        }
        private static void CreateNewImage(string bodyPath, string bannerPath, string savePath)
        {
            try
            {
                var banner = Image.FromFile(bannerPath);
                var body = Image.FromFile(bodyPath);
                var bitmap = new Bitmap(body.Width, body.Height);
                var canvas = Graphics.FromImage(bitmap);
                canvas.InterpolationMode = InterpolationMode.HighQualityBicubic;
                canvas.DrawImage(body, new Rectangle(0, 0, body.Width, body.Height),
                    new Rectangle(0, 0, body.Width, body.Height), GraphicsUnit.Pixel);
                canvas.DrawImage(banner, 0, body.Height - 75, body.Width, 75);
                canvas.Save();
                bitmap.Save(savePath);
                bitmap.Dispose();
            }
            catch (Exception e)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(e);
            }
        }
        private static void WriteTextOnImage(string text, string num, string filePath, string savePath)
        {
            try
            {
                var firstText = text;
                var number = num;

                var imageFilePath = filePath;
                var bitmap = (Bitmap)Image.FromFile(imageFilePath);


                var firstLocation = new PointF();
                if (firstText.Length < 20)
                    firstLocation = new PointF(bitmap.Width - 200, bitmap.Height - 70);
                else if (firstText.Length >= 20 && firstText.Length < 30)
                    firstLocation = new PointF(bitmap.Width - 300, bitmap.Height - 70);
                else if (firstText.Length >= 30 && firstText.Length < 40)
                    firstLocation = new PointF(bitmap.Width - 415, bitmap.Height - 70);
                else if (firstText.Length > 40)
                    firstLocation = new PointF(bitmap.Width - 435, bitmap.Height - 70);
                var numberLocation = new PointF(number.Length * 20, bitmap.Height - 30);

                if (firstText.Length > 40)
                    firstText = "..." + firstText.Remove(38, firstText.Length - 38);

                var graphics = Graphics.FromImage(bitmap);


                var arialFont = new Font("B Mehr", 18);
                var numberFont = new Font("B Yekan", 14);

                graphics.DrawString(firstText, arialFont, Brushes.Black, firstLocation);
                graphics.DrawString(number, numberFont, Brushes.Red, numberLocation);

                bitmap.Save(savePath);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private static void RemoveUnusedFiles(List<string> fileName)
        {
            try
            {
                foreach (var item in fileName)
                {
                    try
                    {
                        if (File.Exists(item))
                            File.Delete(item);
                    }
                    catch { }
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private static void RaiseFinishedEvent(int count)
        {
            try
            {
                var handler = OnSavedFinished;
                if (handler != null) OnSavedFinished?.Invoke(count);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private static void RaiseStartedEvent(int count)
        {
            try
            {
                var handler = OnSavedStarted;
                if (handler != null) OnSavedStarted?.Invoke(count);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private static void RaiseDataRecievedEvent(int count)
        {
            try
            {
                var handler = OnDataRecieved;
                if (handler != null) OnDataRecieved?.Invoke(count);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
