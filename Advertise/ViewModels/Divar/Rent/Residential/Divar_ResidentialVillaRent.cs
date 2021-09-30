﻿using System;
using System.Threading.Tasks;
using Advertise.Classes;
using EntityCache.Bussines;
using Services;
using Settings.Classes;

namespace Advertise.ViewModels.Divar.Rent.Residential
{
    public class Divar_ResidentialVillaRent
    {
        private BuildingBussines bu;
        private bool isGiveChat = true;
        private string agahiDahande, title, content;
        private Divar_SetFixValue fixValue;

        public Divar_ResidentialVillaRent(BuildingBussines building, int imgCount, bool giveChat, string ersalKonnade, string _title, string _content)
        {
            bu = building;
            fixValue = new Divar_SetFixValue(building, imgCount);
            isGiveChat = giveChat;
            agahiDahande = ersalKonnade;
            title = _title;
            content = _content;
        }

        public string FisrtCat => "املاک";
        public string SecondCat => "اجاره مسکونی";
        public string ThirdCat => "خانه و ویلا";
        public string State => fixValue.State();
        public string City => fixValue.City();
        public string Region => fixValue.Region();
        public string ImageList => fixValue.ImageList();
        public string Metrazh => bu.Masahat.ToString();
        public string Rahn => bu.RahnPrice1.ToString("0.##");
        public string Ejare => bu.EjarePrice1.ToString("0.##");
        public string Tabdil => fixValue.Tabdil();
        public string RentalAuthority => fixValue.RentalAuthority();
        public string RoomCount => fixValue.RoomCount();
        public string SaleSakht => fixValue.SaleSakht().UpSideFixString();
        public string Parking => fixValue.Parking();
        public string Anbari => fixValue.Anbari();
        public string Balkon => fixValue.Balkon();



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
                cat.City()?.SendKeys(City + "\n");
                await Utility.Wait(2);
                await cat.SetRegionAsync(Region);

                cat.Masahat()?.SendKeys(Metrazh);

                if (agahiDahande.Contains("املاک")) cat.Sender_Amlak()?.Click();
                else cat.Sender_Shakhsi()?.Click();

                cat.Rahn()?.SendKeys(Rahn);
                cat.Ejare()?.SendKeys(Ejare);

                await Utility.Wait();
                cat.Tabdil(2)?.Click();
                await Utility.Wait();
                cat.SelectDropDown(Tabdil);

                await Utility.Wait();
                cat.Rental(3)?.Click();
                await Utility.Wait();
                cat.SelectDropDown(RentalAuthority);

                await Utility.Wait();
                cat.RoomCount(4)?.Click();
                await Utility.Wait();
                cat.SelectDropDown(RoomCount);

                await Utility.Wait();
                cat.SaleSakht(5)?.Click();
                await Utility.Wait();
                cat.SelectDropDown(SaleSakht);

                await Utility.Wait();
                cat.Parking(6)?.Click();
                await Utility.Wait();
                cat.SelectDropDown(Parking);

                await Utility.Wait();
                cat.Anbari(7)?.Click();
                await Utility.Wait();
                cat.SelectDropDown(Anbari);

                await Utility.Wait();
                cat.Balkon(8)?.Click();
                await Utility.Wait();
                cat.SelectDropDown(Balkon);

                await Utility.Wait();
                if (!isGiveChat) cat.Chat()?.Click();

                cat.Title()?.SendKeys(title);
                cat.SendContent(content);

                await Utility.Wait();

                cat.SendAdv();

                res.AddReturnedValue(await Utility.SaveAdv(AdvertiseType.Divar, FisrtCat, SecondCat, ThirdCat, State,
                    City,
                    Region, title, content, number, bu.RahnPrice1, bu.EjarePrice1, cat.Url));
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
