using System;
using System.Threading.Tasks;
using Advertise.Classes;
using EntityCache.Bussines;
using Services;
using Settings.Classes;

namespace Advertise.ViewModels.Divar.Rent.Office
{
    public class Divar_OfficeOfficeRent
    {
        private BuildingBussines bu;
        private bool isGiveChat = true;
        private string agahiDahande;
        private Divar_SetFixValue fixValue;

        public Divar_OfficeOfficeRent(BuildingBussines building, int imgCount, bool giveChat, string ersalKonnade)
        {
            bu = building;
            fixValue = new Divar_SetFixValue(building, imgCount);
            isGiveChat = giveChat;
            agahiDahande = ersalKonnade;
        }

        public string FisrtCat => "املاک";
        public string SecondCat => "اجاره اداری و تجاری";
        public string ThirdCat => "دفتر کار، اتاق اداری و مطب";
        public string State => fixValue.State();
        public string City => fixValue.City();
        public string Region => fixValue.Region();
        public string ImageList => fixValue.ImageList();
        public string Metrazh => bu.Masahat.ToString();
        public string AgahiDahande => agahiDahande;
        public string Rahn => bu.RahnPrice1.ToString("0.##");
        public string Ejare => bu.EjarePrice1.ToString("0.##");
        public string Tabdil => fixValue.Tabdil();
        public string RoomCount => fixValue.RoomCount();
        public string SaleSakht => fixValue.SaleSakht().UpSideFixString();
        public string Tabaqe => fixValue.Tabaqe().UpSideFixString();
        public string Asansor => fixValue.Asansor();
        public string Parking => fixValue.Parking();
        public string Anbari => fixValue.Anbari();
        public bool IsGiveChat => isGiveChat;
        public string Title => fixValue.Title();
        public string Description => fixValue.Content();

        [Obsolete]
        public async Task<ReturnedSaveFuncInfo> SendAsync(long number)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                res.AddReturnedValue(await Utility.Init(number));
                if (res.HasError) return res;
                await Utility.Wait();

                var cat = new FixElements(Utility.RefreshDriver(clsAdvertise.IsSilent));
                cat.FirsCategory(FisrtCat)?.Click();
                await Utility.Wait();
                cat.SecondCategory(SecondCat)?.Click();
                await Utility.Wait();
                cat.ThirdCategory(ThirdCat)?.Click();
                await Utility.Wait();

                cat.ImageContainer()?.SendKeys(ImageList);
                cat.CitySearcher()?.Click();
                cat.City()?.SendKeys(City + "\n");
                cat.RegionSearcher()?.Click();
                cat.Region()?.SendKeys(Region + "\n");

                cat.Masahat()?.SendKeys(Metrazh);

                if (AgahiDahande.Contains("املاک")) cat.Sender_Amlak()?.Click();
                else cat.Sender_Shakhsi()?.Click();

                cat.Rahn()?.SendKeys(Rahn);
                cat.Ejare()?.SendKeys(Ejare);

                cat.Tabdil()?.Click();
                cat.SelectDropDown(Tabdil);

                cat.RoomCount()?.Click();
                cat.SelectDropDown(RoomCount);

                cat.SaleSakht()?.Click();
                cat.SelectDropDown(SaleSakht);

                cat.Tabaqe()?.Click();
                cat.SelectDropDown(Tabaqe);

                cat.Asansor()?.Click();
                cat.SelectDropDown(Asansor);

                cat.Parking()?.Click();
                cat.SelectDropDown(Parking);

                cat.Anbari()?.Click();
                cat.SelectDropDown(Anbari);

                if (!IsGiveChat) cat.Chat()?.Click();

                cat.Title()?.SendKeys(Title);
                cat.SendContent(Description);

                cat.SendAdv();

                res.AddReturnedValue(await Utility.SaveAdv(AdvertiseType.Divar, FisrtCat, SecondCat, ThirdCat, State,
                    City,
                    Region, Title, Description, number, bu.RahnPrice1, bu.EjarePrice1, cat.Url));
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
