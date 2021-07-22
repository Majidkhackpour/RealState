using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Services.Interfaces.Building;

namespace Persistence.Entities
{
    public class WorkingRange : IWorkingRange
    {
        [Key]
        public Guid Guid { get; set; }
        [ForeignKey("Region")]
        public Guid RegionGuid { get; set; }
        public virtual Regions Region { get; set; }
    }
}
