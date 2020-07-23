﻿using EntityCache.Core;
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

        public static void Dispose()
        {
            db?.Dispose();
        }
        public static void Set_Save()
        {
            db.SaveChanges();
        }


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

    }
}