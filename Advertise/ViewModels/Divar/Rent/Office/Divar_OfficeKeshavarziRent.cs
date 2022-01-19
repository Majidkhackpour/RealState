using System;
using System.Threading.Tasks;
using Advertise.Classes;
using EntityCache.Bussines;
using Services;
using Settings.Classes;

namespace Advertise.ViewModels.Divar.Rent.Office
{
    public class Divar_OfficeKeshavarziRent
    {
        private BuildingBussines bu;
        private bool isGiveChat = true;
        private string agahiDahande, title, content;
        private Divar_SetFixValue fixValue;

        public Divar_OfficeKeshavarziRent(BuildingBussines building, int imgCount, bool giveChat, string ersalKonnade, string _title, string _content)
        {
            fixValue = new Divar_SetFixValue(building, imgCount);
            bu = building;
            isGiveChat = giveChat;
            agahiDahande = ersalKonnade;
            title = _title;
            content = _content;
        }

        public string FisrtCat => "املاک";
        public string SecondCat => "اجاره اداری و تجاری";
        public string ThirdCat => "صنعتی، کشاورزی و تجاری";
        public string ImageList => fixValue.ImageList();
        public string Metrazh => fixValue.Metrazh;
        public string Rahn => bu.RahnPrice1.ToString("0.##");
        public string Ejare => bu.EjarePrice1.ToString("0.##");
        public string Tabdil => fixValue.Tabdil();
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

                var cat = new FixElements(Utility.RefreshDriver(SettingsBussines.AdvertiseSetting.IsSilent));
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

                cat.Rahn()?.SendKeys(Rahn);
                cat.Ejare()?.SendKeys(Ejare);

                await Utility.Wait();
                cat.Tabdil(2)?.Click();
                await Utility.Wait();
                cat.SelectDropDown(Tabdil);

                await Utility.Wait();
                cat.RoomCount(3)?.Click();
                await Utility.Wait();
                cat.SelectDropDown(RoomCount);

                await Utility.Wait();
                cat.SaleSakht(4)?.Click();
                await Utility.Wait();
                cat.SelectDropDown(SaleSakht);

                await Utility.Wait();
                if (!isGiveChat) cat.Chat()?.Click();

                cat.Title()?.SendKeys(title);
                await cat.SendContentAsync(content);

                await Utility.Wait();

                await cat.SendAdvAsync();
                await Utility.Wait(5);
                res.AddReturnedValue(await Utility.SaveAdv(AdvertiseType.Divar, FisrtCat, SecondCat, ThirdCat, await fixValue.SetDivarStateAsync(),
                    await fixValue.SetDivarCityAsync(),
                    await fixValue.SetDivarRegionAsync(), title, content, number, bu.RahnPrice1, bu.EjarePrice1, cat.Url));
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
