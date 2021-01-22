using System;
using Services;

namespace EntityCache.ViewModels
{
    public class CheckViewModel
    {
        public string PeopleName { get; set; }
        public decimal Price { get; set; }
        public string Number { get; set; }
        public string BankName { get; set; }
        public DateTime CreateDate { get; set; }
        public string DateSh => Calendar.MiladiToShamsi(CreateDate);
    }
}
