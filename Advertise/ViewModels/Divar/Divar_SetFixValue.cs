using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Advertise.Classes;
using EntityCache.Bussines;
using Nito.AsyncEx;
using Services;

namespace Advertise.ViewModels.Divar
{
    public class Divar_SetFixValue
    {
        private BuildingBussines bu;
        private int imageCount;
        public Divar_SetFixValue(BuildingBussines _bu, int imgCount)
        {
            bu = _bu;
            imageCount = imgCount;
        }

        private async Task<string> SetDivarCityAsync(BuildingBussines bu)
        {
            var city = "";
            try
            {
                var c = await CitiesBussines.GetAsync(bu.CityGuid);
                city = c?.Name ?? "";
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return city;
        }
        private async Task<string> SetDivarRegionAsync(BuildingBussines bu)
        {
            var region = "";
            try
            {
                var relatedRegion = await AdvertiseRelatedRegionBussines.GetByRegionGuidAsync(bu.RegionGuid);
                if (relatedRegion != null) region = relatedRegion?.OnlineRegionName ?? "";
                else
                {
                    var reg = await RegionsBussines.GetAsync(bu.RegionGuid);
                    if (reg != null) region = reg?.Name ?? "";
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return region;
        }

        public string City() => AsyncContext.Run(() => SetDivarCityAsync(bu));
        public string Region() => AsyncContext.Run(() => SetDivarRegionAsync(bu));
        public string Tabdil()
        {
            try
            {
                if (bu.RahnPrice2 > 0 || bu.EjarePrice2 > 0)
                    return "قابل تبدیل";
                return "غیر قابل تبدیل";
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return "";
            }
        }
        public string RoomCount()
        {
            try
            {
                if (bu.RoomCount <= 0) return "بدون اتاق";
                if (bu.RoomCount == 1) return "یک";
                if (bu.RoomCount == 2) return "دو";
                if (bu.RoomCount == 3) return "سه";
                if (bu.RoomCount == 4) return "چهار";
                if (bu.RoomCount >= 5) return "پنج یا بیشتر";
                return "";
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return "";
            }
        }
        public string SaleSakht() => bu.SaleSakht.ParseToInt() <= 1370 ? "قبل از 1370" : bu.SaleSakht;
        public string Title()
        {
            try
            {
                var type = "";
                var regionName = "";

                if (bu.RahnPrice1 > 0 || bu.RahnPrice2 > 0) type = "رهن و اجاره";
                else if (bu.SellPrice > 0) type = "فروش";

                if (bu.RegionGuid != Guid.Empty) regionName = RegionsBussines.Get(bu.RegionGuid)?.Name ?? "";

                return $"{type} ملک در {regionName}";
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return "";
            }
        }
        public string Content()
        {
            try
            {
                var content = new StringBuilder();
                var reg = "";
                if (bu.RegionGuid != Guid.Empty)
                    reg = RegionsBussines.Get(bu.RegionGuid)?.Name ?? "";

                content.AppendLine($"محدوده: {reg}");
                content.AppendLine($"متراژ: {bu.Masahat}");
                content.AppendLine($"سال ساخت: {bu.SaleSakht}");

                return content.ToString();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return "";
            }
        }
        private List<string> GetNextImages(BuildingBussines bu, int imgCount)
        {
            var resultImages = new List<string>();
            try
            {
                //گرفتن تمام عکسهای پوشه و فیلتر کردن عکسهای درست
                var advFullPath = bu.GalleryList.Select(q => q.ImageName);
                var allImages = new List<string>();
                var imageAddress = Path.Combine(Application.StartupPath, "Images");
                foreach (var imgName in advFullPath)
                {
                    string fullPath;
                    if (!imgName.EndsWith(".jpg") && !imgName.EndsWith(".png"))
                        fullPath = Path.Combine(imageAddress, imgName + ".jpg");
                    else fullPath = Path.Combine(imageAddress, imgName);
                    if (!File.Exists(fullPath)) continue;
                    allImages.Add(fullPath);
                }
                var selectedImages = new List<string>();
                //حذف عکسهای زیر پیکسل 600*600
                foreach (var imgItem in allImages)
                {
                    var img = Image.FromFile(imgItem);
                    if (img.Width < 600 || img.Height < 600)
                        try
                        {
                            img.Dispose();
                            File.Delete(imgItem);
                        }
                        catch
                        {
                            /**/
                        }
                    img.Dispose();
                }

                if (allImages.Count <= imgCount) selectedImages = allImages;
                else
                {
                    var indexes = new List<int>();
                    var rnd = new Random();
                    while (indexes.Count < imgCount)
                    {
                        var index = rnd.Next(allImages.Count);
                        if (!indexes.Contains(index))
                            indexes.Add(index);
                    }

                    selectedImages.AddRange(indexes.Select(index => allImages[index]));
                }


                //ویرایش عکسها
                foreach (var img in selectedImages)
                    resultImages.Add(ImageManager.ModifyImage(img));

                return resultImages;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return resultImages;
            }
        }
        public string ImageList()
        {
            try
            {
                var imagesPathList = AsyncContext.Run(() => GetNextImages(bu, imageCount));
                return imagesPathList != null && imagesPathList.Count > 0
                    ? string.Join("\r\n", imagesPathList)
                    : "---";
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return "";
            }

        }
        public string Tabaqe()
        {
            try
            {
                if (bu.TabaqeNo <= 0) return "همکف";
                if (bu.TabaqeNo >= 1 && bu.TabaqeNo <= 30) return bu.TabaqeNo.ToString();
                return "بالاتر از 30";
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return "";
            }
        }
        public string Asansor()
        {
            try
            {
                var options = bu.OptionList;
                if (options == null) return "";

                var asansor = options.Any(q => q.OptionName.Contains("آسانسور") || q.OptionName.Contains("اسانسور"));
                return asansor ? "دارد" : "ندارد";
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return "";
            }
        }
        public string Parking()
        {
            try
            {
                var options = bu.OptionList;
                if (options == null) return "";

                var parking = options.Any(q => q.OptionName.Contains("پارکینگ"));
                return parking ? "دارد" : "ندارد";
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return "";
            }
        }
        public string Anbari()
        {
            try
            {
                var options = bu.OptionList;
                if (options == null) return "";

                var anbar = options.Any(q => q.OptionName.Contains("انبار"));
                return anbar ? "دارد" : "ندارد";
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return "";
            }
        }
        public string Balkon()
        {
            try
            {
                var options = bu.OptionList;
                if (options == null) return "";

                var balkon = options.Any(q => q.OptionName.Contains("بالکن") || q.OptionName.Contains("تراس"));
                return balkon ? "دارد" : "ندارد";
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return "";
            }
        }
        public string RentalAuthority()
        {
            try
            {

                var rentAuth = RentalAuthorityBussines.Get(bu.RentalAutorityGuid ?? Guid.Empty);
                if (rentAuth != null && rentAuth.Name.Contains("خانواده و مجرد"))
                    return "خانواده و مجرد";
                return "خانواده";
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return "";
            }
        }
        public bool SanadEdari()
        {
            try
            {
                var doc = DocumentTypeBussines.Get(bu.DocumentType ?? Guid.Empty);
                return doc != null && doc.Name.Contains("اداری");
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return false;
            }
        }
    }
}
