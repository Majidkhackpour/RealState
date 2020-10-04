using System;
using Services;

namespace PacketParser.Interfaces
{
    public interface IAdvertiseLog : IHasGuid
    {
        long SimcardNumber { get; set; }
        DateTime DateM { get; set; }
        string Category { get; set; }
        string SubCategory1 { get; set; }
        string SubCategory2 { get; set; }
        string City { get; set; }
        string Region { get; set; }
        decimal Price1 { get; set; }
        decimal Price2 { get; set; }
        string Title { get; set; }
        string Content { get; set; }
        string URL { get; set; }
        string UpdateDesc { get; set; }
        StatusCode StatusCode { get; set; }
        string IP { get; set; }
        DateTime LastUpdate { get; set; }
        int VisitCount { get; set; }
        AdvertiseType AdvType { get; set; }
    }
}
