using System;
using System.Runtime.InteropServices;
using Services;

namespace EntityCache.ViewModels
{
    public class TarazAzmayeshiViewModel
    {
        public Guid Guid { get; set; }
        public string DateSh => Calendar.MiladiToShamsi(DateTime.Now);
        public long Code { get; set; }
        public string Name { get; set; }
        public decimal Debit { get; set; }
        public decimal Credit { get; set; }
    }
}
