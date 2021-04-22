using System;
using System.ComponentModel.DataAnnotations;
using Services;
using Servicess.Interfaces.Building;

namespace Persistence.Entities
{
    public class AdvertiseLog : IAdvertiseLog
    {
        [Key]
        public Guid Guid { get; set; }
        public long SimcardNumber { get; set; }
        public DateTime DateM { get; set; }
        [MaxLength(100)]
        public string Category { get; set; }
        [MaxLength(100)]
        public string SubCategory1 { get; set; }
        [MaxLength(100)]
        public string SubCategory2 { get; set; }
        [MaxLength(100)]
        public string City { get; set; }
        [MaxLength(100)]
        public string Region { get; set; }
        public decimal Price1 { get; set; }
        public decimal Price2 { get; set; }
        [MaxLength(500)]
        public string Title { get; set; }
        public string Content { get; set; }
        [MaxLength(100)]
        public string URL { get; set; }
        public string UpdateDesc { get; set; }
        public StatusCode StatusCode { get; set; }
        [MaxLength(20)]
        public string IP { get; set; }
        public DateTime LastUpdate { get; set; }
        public int VisitCount { get; set; }
        public AdvertiseType AdvType { get; set; }
        [MaxLength(20)]
        public string State { get; set; }
    }
}
