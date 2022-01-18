﻿using Advertise.Classes;
using EntityCache.Bussines;
using Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        public async Task<string> SetDivarStateAsync()
        {
            var state = "";
            try
            {
                var c = await CitiesBussines.GetAsync(bu.CityGuid);
                if (c == null || c.StateGuid == Guid.Empty) return state;
                var st = await StatesBussines.GetAsync(c.StateGuid);
                state = st?.Name ?? "";
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return state;
        }
        public async Task<string> SetDivarCityAsync()
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
        public async Task<string> SetDivarRegionAsync()
        {
            var region = "";
            try
            {
                var relatedRegion = await AdvertiseRelatedRegionBussines.GetByRegionGuidAsync(bu.RegionGuid);
                if (relatedRegion != null) region = relatedRegion?.OnlineRegionName ?? "";
                else
                {
                    var reg = await RegionsBussines.GetAsync(bu.RegionGuid);
                    if (reg != null)
                    {
                        region = reg?.Name;
                        if (region.StartsWith(" ")) region = region.Remove(0, 1);
                    }
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return region;
        }
        public string Metrazh => bu.Masahat > 0 ? bu.Masahat.ToString() : bu.ZirBana.ToString();
        public string Tabdil()
        {
            try
            {
                if (bu.Tabdil != null && bu.Tabdil == true)
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
                var imagesPathList = GetNextImages(bu, imageCount);
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
        public async Task<string> GetAsansorAsync()
        {
            try
            {
                var options = bu.OptionList;
                if (options == null) return "";
                var asGuid = await BuildingOptionsBussines.GetEvelatorGuidAsync();
                var asansor = options?.Select(q => q.BuildingOptionGuid)?.Contains(asGuid) ?? false;
                return asansor ? "دارد" : "ندارد";
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return "";
            }
        }
        public async Task<string> GetParkingAsync()
        {
            try
            {
                var options = bu.OptionList;
                if (options == null) return "";

                var asGuid = await BuildingOptionsBussines.GetParkingGuidAsync();
                var parking = options?.Select(q => q.BuildingOptionGuid)?.Contains(asGuid) ?? false;
                return parking ? "دارد" : "ندارد";
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return "";
            }
        }
        public async Task<string> GetAnbariAsync()
        {
            try
            {
                var options = bu.OptionList;
                if (options == null) return "";

                var asGuid = await BuildingOptionsBussines.GetStoreGuidAsync();
                var anbar = options?.Select(q => q.BuildingOptionGuid)?.Contains(asGuid) ?? false;
                return anbar ? "دارد" : "ندارد";
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return "";
            }
        }
        public async Task<string> GetBalkonAsync()
        {
            try
            {
                var options = bu.OptionList;
                if (options == null) return "";

                var asGuid = await BuildingOptionsBussines.GetBalconyGuidAsync();
                var balkon = options?.Select(q => q.BuildingOptionGuid)?.Contains(asGuid) ?? false;
                return balkon ? "دارد" : "ندارد";
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return "";
            }
        }
        public async Task<string> GetRentalAuthorityAsync()
        {
            try
            {

                var rentAuth = await RentalAuthorityBussines.GetAsync(bu.RentalAutorityGuid ?? Guid.Empty);
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
        public async Task<bool> GetSanadEdariAsync()
        {
            try
            {
                var doc = await DocumentTypeBussines.GetAsync(bu.DocumentType ?? Guid.Empty);
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
