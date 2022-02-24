using System;
using EntityCache.Bussines;
using Services;

namespace Accounting.Sood_Zian
{
    public class clsSood_Zian
    {
        //private decimal _totalCommition = 0;
        //private decimal _totalBazarYab = 0;
        //private decimal _totalHazine = 0;
        //private decimal _totalTax = 0;
        private DateTime _date1, _date2;

        public clsSood_Zian(DateTime d1, DateTime d2)
        {
            _date1 = new DateTime(d1.Year, d1.Month, d1.Day, 0, 0, 0);
            _date2 = new DateTime(d2.Year, d2.Month, d2.Day, 23, 59, 59);
        }

        public string DateSh1 => Calendar.MiladiToShamsi(_date1);
        public string DateSh2 => Calendar.MiladiToShamsi(_date2);
        public string CompanyName => SettingsBussines.Setting.CompanyInfo.EconomyName;
        public decimal TotalCommition =>0 /*ContractBussines.GetTotalCommition(_date1, _date2)*/;
        public decimal TotalBazarYab =>0/* ContractBussines.GetTotalBazaryab(_date1, _date2)*/;
        public decimal Sood_Nakhales => TotalCommition - TotalBazarYab;
        public decimal Sood_BeforeTax => Sood_Nakhales;
        public decimal TotalTax => 0;/*ContractBussines.GetTotalTax(_date1, _date2);*/
        public decimal Sood_Total => Sood_BeforeTax - TotalTax;
        public string Ballance
        {
            get
            {
                if (Sood_Total > 0) return "مجموعه سود ده";
                if (Sood_Total < 0) return "مجموعه زیان ده";
                return "مجموعه بی اثر";
            }
        }
    }
}
