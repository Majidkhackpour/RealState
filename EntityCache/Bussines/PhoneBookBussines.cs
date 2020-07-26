using System;
using PacketParser.Interfaces;

namespace EntityCache.Bussines
{
    public class PhoneBookBussines : IPhoneBook
    {
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public bool Status { get; set; }
        public string Name { get; set; }
        public string Tell { get; set; }
        public bool IsSystem { get; set; }
    }
}
