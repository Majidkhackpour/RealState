using System;
using System.Collections.Generic;
using EntityCache.Bussines;
using Services;
using WebHesabBussines;

namespace EntityCache.Mppings
{
    public class BuildingNoteMapper
    {
        public static BuildingNoteMapper Instance { get; private set; } = new BuildingNoteMapper();
        public WebBuildingNote Map(BuildingNoteBussines cls)
        {
            return new WebBuildingNote()
            {
                Guid = cls.Guid,
                Modified = cls.Modified,
                ServerStatus = cls.ServerStatus,
                ServerDeliveryDate = cls.ServerDeliveryDate,
                BuildingGuid = cls.BuildingGuid,
                Note = cls.Note
            };
        }
        public List<WebBuildingNote> MapList(List<BuildingNoteBussines> cls)
        {
            var list = new List<WebBuildingNote>();
            try
            {
                foreach (var item in cls)
                    list.Add(Map(item));
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return list;
        }
    }
}
