using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EntityCache.Assistence;
using Persistence;
using Services;
using Services.FilterObjects;

namespace EntityCache.Bussines.ReportBussines
{
    public class BuildingReviewReportBussines
    {
        public Guid Guid { get; set; }
        public Guid BuildingGuid { get; set; }
        public DateTime Date { get; set; }
        public string DateSh => Calendar.MiladiToShamsi(Date);
        public string Report { get; set; }
        public ServerStatus ServerStatus { get; set; }
        public string UserName { get; set; }
        public string CustomerName { get; set; }
        public string BuildingCode { get; set; }
        public byte[] ServerStatusImage
        {
            get
            {
                if (ServerStatus == ServerStatus.Delivered || ServerStatus == ServerStatus.DirectDelivery)
                    return ImageResourceManager.ServerStatusDelivered;
                if (ServerStatus == ServerStatus.DeliveryError)
                    return ImageResourceManager.ServerStatusDeliveryFailed;
                if (ServerStatus == ServerStatus.Sent)
                    return ImageResourceManager.ServerStatusSent;
                if (ServerStatus == ServerStatus.SendError)
                    return ImageResourceManager.ServerStatusSentError;
                return ImageResourceManager.ServerStatusNone;
            }
        }

        public static async Task<List<BuildingReviewReportBussines>> GetAllAsync(BuildingReviewFilter filter) =>
            await UnitOfWork.BuildingReview.GetAllReportAsync(Cache.ConnectionString, filter);
    }
}
