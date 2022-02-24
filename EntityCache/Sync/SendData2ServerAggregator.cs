using System;
using Services;
using Services.Interfaces.Sync;

namespace EntityCache.Sync
{
    public class SendData2ServerAggregator
    {
        public SendData2ServerAggregator(ISendData2Server building,
            ISendData2Server buildingAccountType,
            ISendData2Server buildingOptions,
            ISendData2Server buildingRequest,
            ISendData2Server buildingType,
            ISendData2Server buildingView,
            ISendData2Server buildingReview,
            ISendData2Server buildingWindow,
            ISendData2Server buildingZoncan,
            ISendData2Server city,
            ISendData2Server region,
            ISendData2Server documentType,
            ISendData2Server floorCover,
            ISendData2Server kitchenService,
            ISendData2Server peopleGroup,
            ISendData2Server people,
            ISendData2Server buildingRental,
            ISendData2Server states,
            ISendData2Server users,
            ISendData2Server buildingCondition)
        {
            Building = building;
            BuildingAccountType = buildingAccountType;
            BuildingOptions = buildingOptions;
            BuildingRequest = buildingRequest;
            BuildingType = buildingType;
            BuildingView = buildingView;
            BuildingReview = buildingReview;
            BuildingWindow = buildingWindow;
            BuildingZoncan = buildingZoncan;
            City = city;
            Region = region;
            DocumentType = documentType;
            FloorCover = floorCover;
            KitchenService = kitchenService;
            PeopleGroup = peopleGroup;
            People = people;
            BuildingRental = buildingRental;
            States = states;
            Users = users;
            BuildingCondition = buildingCondition;
        }

        public ISendData2Server Building { get; private set; }
        public ISendData2Server BuildingAccountType { get; private set; }
        public ISendData2Server BuildingOptions { get; private set; }
        public ISendData2Server BuildingRequest { get; private set; }
        public ISendData2Server BuildingType { get; private set; }
        public ISendData2Server BuildingView { get; private set; }
        public ISendData2Server BuildingReview { get; private set; }
        public ISendData2Server BuildingWindow { get; private set; }
        public ISendData2Server BuildingZoncan { get; private set; }
        public ISendData2Server City { get; private set; }
        public ISendData2Server Region { get; private set; }
        public ISendData2Server DocumentType { get; private set; }
        public ISendData2Server FloorCover { get; private set; }
        public ISendData2Server KitchenService { get; private set; }
        public ISendData2Server PeopleGroup { get; private set; }
        public ISendData2Server People { get; private set; }
        public ISendData2Server BuildingRental { get; private set; }
        public ISendData2Server States { get; private set; }
        public ISendData2Server Users { get; private set; }
        public ISendData2Server BuildingCondition { get; private set; }

        public void Reset()
        {
            try
            {
                Building?.Reset();
                BuildingAccountType?.Reset();
                BuildingOptions?.Reset();
                BuildingRequest?.Reset();
                BuildingType?.Reset();
                BuildingView?.Reset();
                BuildingReview?.Reset();
                BuildingWindow?.Reset();
                BuildingZoncan?.Reset();
                City?.Reset();
                Region?.Reset();
                DocumentType?.Reset();
                FloorCover?.Reset();
                KitchenService?.Reset();
                PeopleGroup?.Reset();
                People?.Reset();
                BuildingRental?.Reset();
                States?.Reset();
                Users?.Reset();
                BuildingCondition?.Reset();
            }
            catch (Exception ex) { WebErrorLog.ErrorInstence.StartErrorLog(ex); }
        }
    }
}
