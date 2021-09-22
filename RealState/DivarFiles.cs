using Advertise.Classes;
using EntityCache.Bussines;
using Notification;
using Services;
using Settings.Classes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebHesabBussines;

namespace RealState
{
    public class DivarFiles
    {
        public static void Init() => _ = Task.Run(GetFilesFromDivarAsync);
        private static async Task GetFilesFromDivarAsync()
        {
            try
            {
                return;
                if (!VersionAccess.Advertise) return;
                //if (!clsAdvertise.IsGiveFile) return;
                if (!WebCustomer.CheckCustomer()||
                    WebCustomer.Customer.isBlock ||
                    WebCustomer.Customer.isWebServiceBlock)
                    return;

                var getDate = clsAdvertise.GetFileDate ?? DateTime.Now.AddDays(-7);
                var newDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
                if (getDate != null && getDate > newDate) return;

                var insertedDate = new DateTime(getDate.Year, getDate.Month, getDate.Day, 0, 0, 0);
                var list = await WebScrapper.GetAllAsync(insertedDate);
                if (list == null || list.Count <= 0) return;
                var state = await StatesBussines.GetAsync("خراسان رضوی");
                if (state == null) return;
                var city = await CitiesBussines.GetDefualtAsync("مشهد", state.Guid);
                foreach (var item in list)
                {
                    try
                    {
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
                            BuildingAccountTypeGuid =
                                await BuildingAccountTypeBussines.GetDefultGuidAsync(GetAccountType(item.BuildingType)),
                            BuildingConditionGuid = await BuildingViewBussines.GetDefultGuidAsync("تعیین نشده"),
                            BuildingTypeGuid = await BuildingTypeBussines.GetDefultGuidAsync(item.BuildingType),
                            BuildingViewGuid = await BuildingViewBussines.GetDefultGuidAsync("تعیین نشده"),
                            CityGuid = city.Guid,
                            CreateDate = DateTime.Now,
                            Dang = 6,
                            DeliveryDate = DateTime.Now,
                            DivarCount = 0,
                            DocumentType = null,
                            EjarePrice2 = 0,
                            DateParvane = "",
                            ErtefaSaqf = 3,
                            FloorCoverGuid = await FloorCoverBussines.GetDefultGuidAsync("تعیین نشده"),
                            Gas = EnKhadamati.Mostaqel,
                            Hashie = 0,
                            IsArchive = false,
                            IsOwnerHere = false,
                            IsShortTime = false,
                            DivarTitle = item.Title,
                            Image = "",
                            KitchenServiceGuid = await KitchenServiceBussines.GetDefultGuidAsync("تعیین نشده"),
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
                            OwnerGuid = (await PeoplesBussines.GetDefaultPeopleAsync()).Guid
                        };

                        if (item.Evelator)
                        {
                            bu.OptionList.Add(new BuildingRelatedOptionsBussines()
                            {
                                Guid = Guid.NewGuid(),
                                Modified = DateTime.Now,
                                ServerStatus = ServerStatus.None,
                                ServerDeliveryDate = DateTime.Now,
                                BuildingOptionGuid = await BuildingOptionsBussines.GetEvelatorGuidAsync(),
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
                                BuildingOptionGuid = await BuildingOptionsBussines.GetBalconyGuidAsync(),
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
                                BuildingOptionGuid = await BuildingOptionsBussines.GetParkingGuidAsync(),
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
                                BuildingOptionGuid = await BuildingOptionsBussines.GetParkingGuidAsync(),
                                BuildinGuid = bu.Guid
                            });
                        }
                        var lstImage = item.ImagesList.FromJson<List<string>>();
                        if (lstImage == null || lstImage.Count <= 0) continue;
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
                            //ایجاد تصویر با بنر
                            CreateNewImage(path, bannerPath, pathsave);
                            var conType = item.RahnPrice > 0 ? "رهن و اجاره" : "فروش";
                            var title = $"{conType} {item.BuildingType} {item.Masahat} متری";
                            var num = clsEconomyUnit.ManagerMobile;
                            var pr = "";
                            if (item.RahnPrice > 0)
                            {
                                pr = $"رهن: \r\n{item.RahnPrice:N0} تومان \r\n" +
                                     $"اجاره: \r\n{item.EjarePrice:N0} تومان";
                            }
                            else if (item.SellPrice > 0 && item.Masahat > 0)
                                pr = $"قیمت کل:\r\n {item.SellPrice:N0} تومان \r\n" +
                                     $"قیمت هر متر: \r\n{(item.SellPrice / item.Masahat):N0} تومان";
                            else if (item.SellPrice > 0 && item.Masahat <= 0)
                                pr = $"قیمت کل:\r\n {item.SellPrice:N0} تومان ";
                            else pr = "قیمت توافقی";
                            //ایجاد تصویر نهایی
                            WriteTextOnImage(title, num, pr, clsEconomyUnit.EconomyName, pathsave, finnalPath);
                        }
                    }
                    catch (Exception ex)
                    {
                        WebErrorLog.ErrorInstence.StartErrorLog(ex);
                    }
                }
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
        private static void WriteTextOnImage(string text, string num, string pric, string link, string filePath, string savePath)
        {
            try
            {
                var firstText = text;
                var number = num;
                var price = pric;

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
                var linkLocation = new PointF(bitmap.Width - 150, bitmap.Height - 20);
                var priceLocation = new PointF(firstText.Length, bitmap.Height - 65);

                if (firstText.Length > 40)
                    firstText = "..." + firstText.Remove(38, firstText.Length - 38);

                var graphics = Graphics.FromImage(bitmap);


                var arialFont = new Font("B Mehr", 18);
                var numberFont = new Font("B Yekan", 14);
                var linkFont = new Font("B Yekan", 8);
                var priceFont = new Font("B Morvarid", 10);

                if (pric == "قیمت توافقی")
                    priceFont = new Font("B Morvarid", 18);


                graphics.DrawString(firstText, arialFont, Brushes.Black, firstLocation);
                graphics.DrawString(number, numberFont, Brushes.Red, numberLocation);
                graphics.DrawString(link, linkFont, Brushes.Black, linkLocation);
                graphics.DrawString(price, priceFont, Brushes.White, priceLocation);

                bitmap.Save(savePath);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
