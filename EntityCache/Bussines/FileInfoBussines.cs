using System;
using Services.Interfaces.Building;

namespace EntityCache.Bussines
{
    public class FileInfoBussines : IFileInfo
    {
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public bool Status { get; set; }
        public string FileName { get; set; }
    }
}
