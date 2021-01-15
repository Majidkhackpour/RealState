using System;
using EntityCache.Bussines;
using Services;

namespace Advertise.ViewModels.Divar.Rent.Office
{
    public class Divar_OfficeStoreRent
    {
        private BuildingBussines bu;
        private bool isGiveChat = true;
        private string agahiDahande;
        private Divar_SetFixValue fixValue;

        public Divar_OfficeStoreRent(BuildingBussines building, int imgCount, bool giveChat, string ersalKonnade)
        {
            bu = building;
            fixValue = new Divar_SetFixValue(building, imgCount);
            isGiveChat = giveChat;
            agahiDahande = ersalKonnade;
        }

        public string FisrtCat => "املاک";
        public string SecondCat => "اجاره اداری و تجاری";
        public string ThirdCat => "مغازه و غرفه";
        public string City => fixValue.City();
        public string Region => fixValue.Region();
        public string ImageList => fixValue.ImageList();
        public string Metrazh => bu.Masahat.ToString();
        public string AgahiDahande => agahiDahande;
        public string Rahn => bu.RahnPrice1.ToString();
        public string Ejare => bu.EjarePrice1.ToString();
        public string Tabdil => fixValue.Tabdil();
        public string RoomCount => fixValue.RoomCount();
        public string SaleSakht => fixValue.SaleSakht();
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
