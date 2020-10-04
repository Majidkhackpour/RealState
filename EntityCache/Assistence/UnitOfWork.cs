using EntityCache.Core;
using EntityCache.SqlServerPersistence;
using Persistence.Model;

namespace EntityCache.Assistence
{
    public static class UnitOfWork
    {
        private static readonly ModelContext db = new ModelContext();

        private static IUsersRepository _usersRepository;
        private static IStatesRepository _statesRepository;
        private static ICitiesRepository _citiesRepository;
        private static IRegionsRepository _regionsRepository;
        private static INaqzRepository _naqzRepository;
        private static IBuildingOptionRepository _buildingOptionRepository;
        private static IBuildingAccountTypeRepository _buildingAccountTypeRepository;
        private static IFloorCoverRepository _floorCoverRepository;
        private static IKitchenServiceRepository _kitchenServiceRepository;
        private static IDocumentTypeRepository _documentTypeRepository;
        private static IRentalAuthorityRepository _rentalAuthorityRepository;
        private static IBuildingViewRepository _buildingViewRepository;
        private static IBuildingConditionRepository _buildingConditionRepository;
        private static ISettingsRepository _settingsRepository;
        private static IBuildingTypeRepository _buildingTypeRepository;
        private static IPeopleGroupRepository _peopleGroupRepository;
        private static IPeoplesRepository _peopleRepository;
        private static IPhoneBookRepository _phoneBookRepository;
        private static IPeoplesBankAccountRepository _peopleBankRepository;
        private static ISmsPanelsRepository _smsPanelsRepository;
        private static ISimcardRepository _simcardRepository;
        private static IAdvertiseLogRepository _advertiseLogRepository;
        private static IBuildingRepository _buildingRepository;
        private static IBuildingRelatedOptionsRepository _buildingRelatedOptionsRepository;
        private static IBuildingGalleryRepository _buildingGalleryRepository;
        private static IBuildingRequestRepository _buildingRequestRepository;
        private static IBuildingRequestRegionRepository _buildingRequestRegionRepository;
        private static IGardeshHesabRepository _gardeshHesabRepository;
        private static IHazineRepository _hazineRepository;
        private static IReceptionRepository _receptionRepository;
        private static IPardakhtRepository _pardakhtRepository;
        private static IContractRepository _contractRepository;
        private static IContractFinanceRepository _contractFinanceRepository;
        private static IUserLogRepository _userLogRepository;
        private static ISmsLogRepository _smsLogRepository;
        private static INoteRepository _noteRepository;
        private static ISerializedDataRepository _serDataRepository;

        public static void Dispose() => db?.Dispose();
        public static void Set_Save() => db.SaveChanges();


        public static IUsersRepository Users => _usersRepository ??
                                                         (_usersRepository =
                                                             new UsersPersistenceRepository(db));

        public static IStatesRepository States => _statesRepository ??
                                                (_statesRepository =
                                                    new StatesPersistenceRepository(db));
        public static ICitiesRepository Cities => _citiesRepository ??
                                                (_citiesRepository =
                                                    new CitiesPersistenceRepository(db));
        public static IRegionsRepository Regions => _regionsRepository ??
                                                (_regionsRepository =
                                                    new RegionsPersistenceRepository(db));

        public static INaqzRepository Naqz => _naqzRepository ??
                                                    (_naqzRepository =
                                                        new NaqzPersistenceRepository(db));
        public static IBuildingOptionRepository BuildingOption => _buildingOptionRepository ??
                                                (_buildingOptionRepository =
                                                    new BuildingOptionPersistenceRepository(db));

        public static IBuildingAccountTypeRepository BuildingAccountType => _buildingAccountTypeRepository ??
                                                  (_buildingAccountTypeRepository =
                                                      new BuildingAccountTypePersistenceRepository(db));
        public static IFloorCoverRepository FloorCover => _floorCoverRepository ??
                                                  (_floorCoverRepository =
                                                      new FloorCoverPersistenceRepository(db));
        public static IKitchenServiceRepository KitchenService => _kitchenServiceRepository ??
                                                    (_kitchenServiceRepository =
                                                        new KitchenServicePersistenceRepository(db));

        public static IDocumentTypeRepository DocumentType => _documentTypeRepository ??
                                              (_documentTypeRepository =
                                                  new DocumentTypePersistenceRepository(db));
        public static IRentalAuthorityRepository RentalAuthority => _rentalAuthorityRepository ??
                                                (_rentalAuthorityRepository =
                                                    new RentalAuthorityPersistenceRepository(db));

        public static IBuildingViewRepository BuildingView => _buildingViewRepository ??
                                                  (_buildingViewRepository =
                                                      new BuildingViewPersistenceRepository(db));
        public static IBuildingConditionRepository BuildingCondition => _buildingConditionRepository ??
                                                  (_buildingConditionRepository =
                                                      new BuildingConditionPersistenceRepository(db));

        public static ISettingsRepository Settings => _settingsRepository ??
                                                                        (_settingsRepository =
                                                                            new SettingsPersistenceRepository(db));

        public static IBuildingTypeRepository BuildingType => _buildingTypeRepository ??
                                                      (_buildingTypeRepository =
                                                          new BuildingTypePersistenceRepository(db));

        public static IPeopleGroupRepository PeopleGroup => _peopleGroupRepository ??
                                                              (_peopleGroupRepository =
                                                                  new PeopleGroupPersistenceRepository(db));


        public static IPeoplesRepository Peoples => _peopleRepository ??
                                                            (_peopleRepository =
                                                                new PeoplesPersistenceRepository(db));


        public static IPhoneBookRepository PhoneBook => _phoneBookRepository ??
                                                            (_phoneBookRepository =
                                                                new PhoneBookPersistenceRepository(db));


        public static IPeoplesBankAccountRepository PeopleBankAccount => _peopleBankRepository ??
                                                            (_peopleBankRepository =
                                                                new PeopleBankAccountPersistenceRepository(db));


        public static ISmsPanelsRepository SmsPanels => _smsPanelsRepository ??
                                                        (_smsPanelsRepository =
                                                            new SmsPanelsPersistenceRepository(db));



        public static ISimcardRepository Simcard => _simcardRepository ??
                                                                         (_simcardRepository =
                                                                             new SimcardPersistenceRepository(db));


        public static IAdvertiseLogRepository AdvertiseLog => _advertiseLogRepository ??
                                                        (_advertiseLogRepository =
                                                            new AdvertiseLogPersistenceRepository(db));


        public static IBuildingRepository Building => _buildingRepository ??
                                                              (_buildingRepository =
                                                                  new BuildingPersistenceRepository(db));


        public static IBuildingRelatedOptionsRepository BuildingRelatedOptions => _buildingRelatedOptionsRepository ??
                                                      (_buildingRelatedOptionsRepository =
                                                          new BuildingRelatedOptionsPersistenceRepository(db));


        public static IBuildingGalleryRepository BuildingGallery => _buildingGalleryRepository ??
                                                      (_buildingGalleryRepository =
                                                          new BuildingGalleryPersistenceRepository(db));


        public static IBuildingRequestRepository BuildingRequest => _buildingRequestRepository ??
                                                                                  (_buildingRequestRepository =
                                                                                      new BuildingRequestPersistenceRepository(db));


        public static IBuildingRequestRegionRepository BuildingRequestRegion => _buildingRequestRegionRepository ??
                                                                    (_buildingRequestRegionRepository =
                                                                        new BuildingRequestRegionPersistenceRepository(db));


        public static IGardeshHesabRepository GardeshHesab => _gardeshHesabRepository ??
                                                                                (_gardeshHesabRepository =
                                                                                    new GardeshHesabPersistenceRepository(db));


        public static IHazineRepository Hazine => _hazineRepository ??
                                                              (_hazineRepository =
                                                                  new HazinePersistenceRepository(db));


        public static IReceptionRepository Reception => _receptionRepository ??
                                                  (_receptionRepository =
                                                      new ReceptionPersistenceRepository(db));


        public static IPardakhtRepository Pardakht => _pardakhtRepository ??
                                                        (_pardakhtRepository =
                                                            new PardakhtPersistenceRepository(db));


        public static IContractRepository Contract => _contractRepository ??
                                                        (_contractRepository =
                                                            new ContractPersistenceRepository(db));


        public static IContractFinanceRepository ContractFinance => _contractFinanceRepository ??
                                                      (_contractFinanceRepository =
                                                          new ContractFinancePersisteceRepository(db));


        public static IUserLogRepository UserLog => _userLogRepository ??
                                                      (_userLogRepository =
                                                          new UserLogPersistenceRepository(db));


        public static ISmsLogRepository SmsLog => _smsLogRepository ??
                                                    (_smsLogRepository =
                                                        new SmsLogPersistenceRepository(db));


        public static INoteRepository Note => _noteRepository ??
                                                  (_noteRepository =
                                                      new NotePersistenceRepository(db));


        public static ISerializedDataRepository SerializedData => _serDataRepository ??
                                              (_serDataRepository =
                                                  new SerializedDataPersistenceRepository(db));

    }
}
