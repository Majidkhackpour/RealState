using System;
using System.Threading.Tasks;
using Advertise.Classes;
using EntityCache.Bussines;
using Services;
using Settings.Classes;

namespace Advertise.ViewModels.Divar.Sell.Residential
{
    public class Divar_ResidentialApartmentSell
    {
        private BuildingBussines bu;
        private bool isGiveChat = true;
        private string agahiDahande, title, content;
        private Divar_SetFixValue fixValue;

        public Divar_ResidentialApartmentSell(BuildingBussines building, int imgCount, bool giveChat, string ersalKonnade, string _title, string _content)
        {
            bu = building;
            fixValue = new Divar_SetFixValue(building, imgCount);
            isGiveChat = giveChat;
            agahiDahande = ersalKonnade;
            title = _title;
            content = _content;
        }

        public string FisrtCat => "املاک";
        public string SecondCat => "فروش مسکونی";
        public string ThirdCat => "آپارتمان";
        public string State => fixValue.State();
        public string City => fixValue.City();
        public string Region => fixValue.Region();
        public string ImageList => fixValue.ImageList();
        public string Metrazh => fixValue.Metrazh;
        public string Price => bu.SellPrice.ToString("0.##");
        public string RoomCount => fixValue.RoomCount();
        public string SaleSakht => fixValue.SaleSakht().UpSideFixString();
        public string Tabaqe => fixValue.Tabaqe().UpSideFixString();
        public string Asansor => fixValue.Asansor();
        public string Parking => fixValue.Parking();
        public string Anbari => fixValue.Anbari();


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

                cat.Sell()?.SendKeys(Price);

                await Utility.Wait();
                cat.RoomCount(2)?.Click();
                await Utility.Wait();
                cat.SelectDropDown(RoomCount);

                await Utility.Wait();
                cat.SaleSakht(3)?.Click();
                await Utility.Wait();
                cat.SelectDropDown(SaleSakht);

                await Utility.Wait();
                cat.Tabaqe(4)?.Click();
                await Utility.Wait();
                cat.SelectDropDown(Tabaqe);

                await Utility.Wait();
                cat.Asansor(5)?.Click();
                await Utility.Wait();
                cat.SelectDropDown(Asansor);

                await Utility.Wait();
                cat.Parking(6)?.Click();
                await Utility.Wait();
                cat.SelectDropDown(Parking);

                await Utility.Wait();
                cat.Anbari(7)?.Click();
                await Utility.Wait();
                cat.SelectDropDown(Anbari);

                await Utility.Wait();
                if (!isGiveChat) cat.Chat()?.Click();

                cat.Title()?.SendKeys(title);
                cat.SendContent(content);

                await Utility.Wait();

                cat.SendAdv();

                res.AddReturnedValue(await Utility.SaveAdv(AdvertiseType.Divar, FisrtCat, SecondCat, ThirdCat, State,
                    City,
                    Region, title, content, number, bu.SellPrice, 0, cat.Url));
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
