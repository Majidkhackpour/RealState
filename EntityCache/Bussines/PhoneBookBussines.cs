using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EntityCache.Assistence;
using Nito.AsyncEx;
using PacketParser;
using PacketParser.Interfaces;

namespace EntityCache.Bussines
{
    public class PhoneBookBussines : IPhoneBook
    {
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; } = DateTime.Now;
        public bool Status { get; set; } = true;
        public string Name { get; set; }
        public string Tell { get; set; }
        public EnPhoneBookGroup Group { get; set; }
        public Guid ParentGuid { get; set; }


        public static async Task<List<PhoneBookBussines>> GetAllAsync(Guid parentGuid) =>
            await UnitOfWork.PhoneBook.GetAllAsync(parentGuid);

        public static List<PhoneBookBussines> GetAll(Guid parentGuid) =>
            AsyncContext.Run(() => GetAllAsync(parentGuid));
    }
}
