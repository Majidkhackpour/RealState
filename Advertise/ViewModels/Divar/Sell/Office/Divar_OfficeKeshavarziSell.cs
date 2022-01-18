﻿using System;
using System.Threading.Tasks;
using Advertise.Classes;
using EntityCache.Bussines;
using Services;
using Settings.Classes;

namespace Advertise.ViewModels.Divar.Sell.Office
{
    public class Divar_OfficeKeshavarziSell
    {
        private BuildingBussines bu;
        private bool isGiveChat = true;
        private string agahiDahande, title, content;
        private Divar_SetFixValue fixValue;

        public Divar_OfficeKeshavarziSell(BuildingBussines building, int imgCount, bool giveChat, string ersalKonnade, string _title, string _content)
        {
            bu = building;
            fixValue = new Divar_SetFixValue(building, imgCount);
            isGiveChat = giveChat;
            agahiDahande = ersalKonnade;
            title = _title;
            content = _content;
        }

        public string FisrtCat => "املاک";
        public string SecondCat => "فروش اداری و تجاری";
        public string ThirdCat => "صنعتی، کشاورزی و تجاری";
        public string ImageList => fixValue.ImageList();
        public string Metrazh => fixValue.Metrazh;
        public string Price => bu.SellPrice.ToString("0.##");
        public string RoomCount => fixValue.RoomCount();
        public string SaleSakht => fixValue.SaleSakht().UpSideFixString();


        public async Task<ReturnedSaveFuncInfo> SendAsync(long number)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                res.AddReturnedValue(await Utility.Init(number));
                if (res.HasError) return res;
                await Utility.Wait(2);

                var cat = new FixElements(Utility.RefreshDriver(clsAdvertise.IsSilent));
                cat.FirsCategory(FisrtCat)?.Click();
                await Utility.Wait();
                cat.SecondCategory(SecondCat)?.Click();
                await Utility.Wait();
                cat.ThirdCategory(ThirdCat)?.Click();
                await Utility.Wait(2);

                if (!string.IsNullOrEmpty(ImageList) && ImageList.Length >= 5)
                    cat.ImageContainer()?.SendKeys(ImageList);
                cat.CitySearcher()?.Click();
                await Utility.Wait();
                cat.City()?.SendKeys(await fixValue.SetDivarCityAsync() + "\n");
                await Utility.Wait(2);
                await cat.SetRegionAsync(await fixValue.SetDivarRegionAsync());

                cat.Masahat()?.SendKeys(Metrazh);

                if (agahiDahande.Contains("املاک")) cat.Sender_Amlak()?.Click();
                else cat.Sender_Shakhsi()?.Click();

                cat.Sell()?.SendKeys(Price);

                await Utility.Wait();
                if (!isGiveChat) cat.Chat()?.Click();

                await Utility.Wait();
                cat.RoomCount(2)?.Click();
                await Utility.Wait();
                cat.SelectDropDown(RoomCount);

                await Utility.Wait();
                cat.SaleSakht(3)?.Click();
                await Utility.Wait();
                cat.SelectDropDown(SaleSakht);

                if (await fixValue.GetSanadEdariAsync()) cat.SanadEdari()?.Click();

                cat.Title()?.SendKeys(title);
                await cat.SendContentAsync(content);

                await Utility.Wait();

                await cat.SendAdvAsync();
                await Utility.Wait(5);
                res.AddReturnedValue(await Utility.SaveAdv(AdvertiseType.Divar, FisrtCat, SecondCat, ThirdCat, await fixValue.SetDivarStateAsync(),
                    await fixValue.SetDivarCityAsync(),
                    await fixValue.SetDivarRegionAsync(), title, content, number, bu.SellPrice, 0, cat.Url));
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
        }
    }
}
