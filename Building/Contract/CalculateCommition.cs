using System;
using Services;

namespace Building.Contract
{
    public class CalculateCommition
    {
        public static decimal CalculateEjare(decimal rahn, decimal ejare, int tabdilPercent)
        {
            var res = (decimal)0;
            try
            {
                var tabdil = (rahn * 3) / 100;
                var totalEjare = tabdil + ejare;

                res = (totalEjare * 25) / 100;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return res;
        }
        public static decimal CalculateKharid(decimal sellPrice)
        {
            var res = (decimal)0;
            try
            {
                if (sellPrice <= 5000000000)
                    res = (sellPrice * (decimal)0.5) / 100;
                else
                {
                    var ezafe = sellPrice - 5000000000;

                    var commition1= (5000000000 * (decimal)0.5) / 100;
                    var commition2 = (ezafe * (decimal) 0.25) / 100;

                    res = commition1 + commition2;
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return res;
        }
    }
}
