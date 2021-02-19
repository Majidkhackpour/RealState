using EntityCache.Core;
using EntityCache.SqlServerPersistence;
using Persistence;
using Persistence.Model;

namespace EntityCache.Assistence
{
    public static class UnitOfWork
    {
        private static readonly ModelContext db = new ModelContext(Cache.ConnectionString);
        private static string _connectionString = Cache.ConnectionString;

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
        private static IAdvertiseRelatedRegionRepository _advertiseRelatedRegionRepository;
        private static IAdvTokensRepository _advTokenRepository;
        private static IBackUpLogRepository _bkLogRepository;
        private static ITempRepository _tempRepository;
        private static IFileInfoRepository _fileInfoRepository;
        private static IKolRepository _kolRepository;
        private static IMoeinRepository _moeinRepository;
        private static ITafsilRepository _tafsilRepository;
        private static IBankRepository _bankRepository;
        private static IDasteCheckRepository _dasteCheckRepository;
        private static ICheckPageRepository _checkPageRepository;

        public static void Dispose() => db?.Dispose();
        public static void Set_Save() => db.SaveChanges();


        public static IUsersRepository Users => _usersRepository ??
                                                         (_usersRepository =
                                                             new UsersPersistenceRepository(db, _connectionString));

        public static IStatesRepository States => _statesRepository ??
                                                (_statesRepository =
                                                    new StatesPersistenceRepository(db, _connectionString));
        public static ICitiesRepository Cities => _citiesRepository ??
                                                (_citiesRepository =
                                                    new CitiesPersistenceRepository(db, _connectionString));
        public static IRegionsRepository Regions => _regionsRepository ??
                                                (_regionsRepository =
                                                    new RegionsPersistenceRepository(db, _connectionString));

        public static INaqzRepository Naqz => _naqzRepository ??
                                                    (_naqzRepository =
                                                        new NaqzPersistenceRepository(db, _connectionString));
        public static IBuildingOptionRepository BuildingOption => _buildingOptionRepository ??
                                                (_buildingOptionRepository =
                                                    new BuildingOptionPersistenceRepository(db, _connectionString));

        public static IBuildingAccountTypeRepository BuildingAccountType => _buildingAccountTypeRepository ??
                                                  (_buildingAccountTypeRepository =
                                                      new BuildingAccountTypePersistenceRepository(db, _connectionString));
        public static IFloorCoverRepository FloorCover => _floorCoverRepository ??
                                                  (_floorCoverRepository =
                                                      new FloorCoverPersistenceRepository(db, _connectionString));
        public static IKitchenServiceRepository KitchenService => _kitchenServiceRepository ??
                                                    (_kitchenServiceRepository =
                                                        new KitchenServicePersistenceRepository(db, _connectionString));

        public static IDocumentTypeRepository DocumentType => _documentTypeRepository ??
                                              (_documentTypeRepository =
                                                  new DocumentTypePersistenceRepository(db, _connectionString));
        public static IRentalAuthorityRepository RentalAuthority => _rentalAuthorityRepository ??
                                                (_rentalAuthorityRepository =
                                                    new RentalAuthorityPersistenceRepository(db, _connectionString));

        public static IBuildingViewRepository BuildingView => _buildingViewRepository ??
                                                  (_buildingViewRepository =
                                                      new BuildingViewPersistenceRepository(db, _connectionString));
        public static IBuildingConditionRepository BuildingCondition => _buildingConditionRepository ??
                                                  (_buildingConditionRepository =
                                                      new BuildingConditionPersistenceRepository(db, _connectionString));

        public static ISettingsRepository Settings => _settingsRepository ??
                                                                        (_settingsRepository =
                                                                            new SettingsPersistenceRepository(db, _connectionString));

        public static IBuildingTypeRepository BuildingType => _buildingTypeRepository ??
                                                      (_buildingTypeRepository =
                                                          new BuildingTypePersistenceRepository(db, _connectionString));

        public static IPeopleGroupRepository PeopleGroup => _peopleGroupRepository ??
                                                              (_peopleGroupRepository =
                                                                  new PeopleGroupPersistenceRepository(db, _connectionString));


        public static IPeoplesRepository Peoples => _peopleRepository ??
                                                            (_peopleRepository =
                                                                new PeoplesPersistenceRepository(db, _connectionString));


        public static IPhoneBookRepository PhoneBook => _phoneBookRepository ??
                                                            (_phoneBookRepository =
                                                                new PhoneBookPersistenceRepository(db, _connectionString));


        public static IPeoplesBankAccountRepository PeopleBankAccount => _peopleBankRepository ??
                                                            (_peopleBankRepository =
                                                                new PeopleBankAccountPersistenceRepository(db, _connectionString));


        public static ISmsPanelsRepository SmsPanels => _smsPanelsRepository ??
                                                        (_smsPanelsRepository =
                                                            new SmsPanelsPersistenceRepository(db, _connectionString));



        public static ISimcardRepository Simcard => _simcardRepository ??
                                                                         (_simcardRepository =
                                                                             new SimcardPersistenceRepository(db, _connectionString));


        public static IAdvertiseLogRepository AdvertiseLog => _advertiseLogRepository ??
                                                        (_advertiseLogRepository =
                                                            new AdvertiseLogPersistenceRepository(db, _connectionString));


        public static IBuildingRepository Building => _buildingRepository ??
                                                              (_buildingRepository =
                                                                  new BuildingPersistenceRepository(db, _connectionString));


        public static IBuildingRelatedOptionsRepository BuildingRelatedOptions => _buildingRelatedOptionsRepository ??
                                                      (_buildingRelatedOptionsRepository =
                                                          new BuildingRelatedOptionsPersistenceRepository(db, _connectionString));


        public static IBuildingGalleryRepository BuildingGallery => _buildingGalleryRepository ??
                                                      (_buildingGalleryRepository =
                                                          new BuildingGalleryPersistenceRepository(db, _connectionString));


        public static IBuildingRequestRepository BuildingRequest => _buildingRequestRepository ??
                                                                                  (_buildingRequestRepository =
                                                                                      new BuildingRequestPersistenceRepository(db, _connectionString));


        public static IBuildingRequestRegionRepository BuildingRequestRegion => _buildingRequestRegionRepository ??
                                                                    (_buildingRequestRegionRepository =
                                                                        new BuildingRequestRegionPersistenceRepository(db, _connectionString));


        public static IGardeshHesabRepository GardeshHesab => _gardeshHesabRepository ??
                                                                                (_gardeshHesabRepository =
                                                                                    new GardeshHesabPersistenceRepository(db, _connectionString));


        public static IHazineRepository Hazine => _hazineRepository ??
                                                              (_hazineRepository =
                                                                  new HazinePersistenceRepository(db, _connectionString));


        public static IReceptionRepository Reception => _receptionRepository ??
                                                  (_receptionRepository =
                                                      new ReceptionPersistenceRepository(db, _connectionString));


        public static IPardakhtRepository Pardakht => _pardakhtRepository ??
                                                        (_pardakhtRepository =
                                                            new PardakhtPersistenceRepository(db, _connectionString));


        public static IContractRepository Contract => _contractRepository ??
                                                        (_contractRepository =
                                                            new ContractPersistenceRepository(db, _connectionString));


        public static IContractFinanceRepository ContractFinance => _contractFinanceRepository ??
                                                      (_contractFinanceRepository =
                                                          new ContractFinancePersisteceRepository(db, _connectionString));


        public static IUserLogRepository UserLog => _userLogRepository ??
                                                      (_userLogRepository =
                                                          new UserLogPersistenceRepository(db, _connectionString));


        public static ISmsLogRepository SmsLog => _smsLogRepository ??
                                                    (_smsLogRepository =
                                                        new SmsLogPersistenceRepository(db, _connectionString));


        public static INoteRepository Note => _noteRepository ??
                                                  (_noteRepository =
                                                      new NotePersistenceRepository(db, _connectionString));


        public static ISerializedDataRepository SerializedData => _serDataRepository ??
                                              (_serDataRepository =
                                                  new SerializedDataPersistenceRepository(db, _connectionString));


        public static IAdvertiseRelatedRegionRepository AdvertiseRelatedRegion => _advertiseRelatedRegionRepository ??
                                                                                  (_advertiseRelatedRegionRepository =
                                                                                      new
                                                                                          AdvertiseRelatedRegionPersistenceRepository(
                                                                                              db, _connectionString));


        public static IAdvTokensRepository AdvTokens => _advTokenRepository ??
                                                                  (_advTokenRepository =
                                                                      new AdvTokensPersistenceRepository(db, _connectionString));


        public static IBackUpLogRepository BackUpLog => _bkLogRepository ??
                                                        (_bkLogRepository =
                                                            new BackUpLogPersistenceRepository(db, _connectionString));


        public static ITempRepository Temp => _tempRepository ??
                                                        (_tempRepository =
                                                            new TempPersistenceRepository(db, _connectionString));


        public static IFileInfoRepository FileInfo => _fileInfoRepository ??
                                              (_fileInfoRepository =
                                                  new FileInfoPersistenceRepository(db, _connectionString));


        public static IKolRepository Kol => _kolRepository ??
                                                        (_kolRepository =
                                                            new KolPersistenceRepository(db, _connectionString));


        public static IMoeinRepository Moein => _moeinRepository ??
                                              (_moeinRepository =
                                                  new MoeinPersistenceRepository(db, _connectionString));


        public static ITafsilRepository Tafsil => _tafsilRepository ??
                                                      (_tafsilRepository =
                                                          new TafsilPersistenceRepository(db, _connectionString));


        public static IBankRepository Bank => _bankRepository ??
                                                  (_bankRepository =
                                                      new BankPersistenceRepository(db, _connectionString));


        public static IDasteCheckRepository DasteCheck => _dasteCheckRepository ??
                                              (_dasteCheckRepository =
                                                  new DasteCheckPersistenceRepository(db, _connectionString));


        public static ICheckPageRepository CheckPage => _checkPageRepository ??
                                                          (_checkPageRepository =
                                                              new CheckPagePersistenceRepository(db, _connectionString));
    }
}
