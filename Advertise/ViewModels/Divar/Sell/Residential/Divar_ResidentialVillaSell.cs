using System;
using EntityCache.Bussines;
using Services;

namespace Advertise.ViewModels.Divar.Sell.Residential
{
    public class Divar_ResidentialVillaSell
    {
        private BuildingBussines bu;
        private bool isGiveChat = true;
        private string agahiDahande;
        private Divar_SetFixValue fixValue;

        public Divar_ResidentialVillaSell(BuildingBussines building, int imgCount, bool giveChat, string ersalKonnade)
        {
            bu = building;
            fixValue = new Divar_SetFixValue(building, imgCount);
            isGiveChat = giveChat;
            agahiDahande = ersalKonnade;
        }

        public string FisrtCat => "املاک";
        public string SecondCat => "فروش مسکونی";
        public string ThirdCat => "خانه و ویلا";
        public string City => fixValue.City();
        public string Region => fixValue.Region();
        public string ImageList => fixValue.ImageList();
        public string Metrazh => bu.Masahat.ToString();
        public string AgahiDahande => agahiDahande;
        public string Price => bu.SellPrice.ToString();
        public string RoomCount => fixValue.RoomCount();
        public string SaleSakht => fixValue.SaleSakht();
        public string Asansor => fixValue.Asansor();
        public string Parking => fixValue.Parking();
        public string Balkon => fixValue.Balkon();
        public bool IsGiveChat => isGiveChat;
        public string Title => fixValue.Title();
        public string Description => fixValue.Content();


        public ReturnedSaveFuncInfo Send(long number)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {

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
