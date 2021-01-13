using EntityCache.Bussines;

namespace Advertise.ViewModels.Divar.Rent.Office
{
    public class Divar_OfficeOfficeRent
    {
        private BuildingBussines bu;
        private int imageCount = 3;
        private bool isGiveChat = true;
        private string agahiDahande;

        public Divar_OfficeOfficeRent(BuildingBussines building, int imgCount, bool giveChat, string ersalKonnade)
        {
            bu = building;
            imageCount = imgCount;
            isGiveChat = giveChat;
            agahiDahande = ersalKonnade;
        }

        public string FisrtCat => "املاک";
        public string SecondCat => "اجاره اداری و تجاری";
        public string ThirdCat => "دفتر کار، اتاق اداری و مطب";
        public string City => Divar_SetFixValue.City(bu);
        public string Region => Divar_SetFixValue.Region(bu);
        public string ImageList => Divar_SetFixValue.ImageList(bu, imageCount);
        public string Metrazh => bu.Masahat.ToString();
        public string AgahiDahande => agahiDahande;
        public string Rahn => bu.RahnPrice1.ToString();
        public string Ejare => bu.EjarePrice1.ToString();
        public string Tabdil => Divar_SetFixValue.Tabdil(bu);
        public string RoomCount => Divar_SetFixValue.RoomCount(bu);
        public string SaleSakht => Divar_SetFixValue.SaleSakht(bu);
        public string Tabaqe => Divar_SetFixValue.Tabaqe(bu);
        public string Asansor => Divar_SetFixValue.Asansor(bu);
        public string Parking => Divar_SetFixValue.Parking(bu);
        public string Anbari => Divar_SetFixValue.Anbari(bu);
        public bool IsGiveChat => isGiveChat;
        public string Title => Divar_SetFixValue.Title(bu);
        public string Description => Divar_SetFixValue.Content(bu);
    }
}
