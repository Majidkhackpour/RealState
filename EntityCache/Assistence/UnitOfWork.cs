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
    }
}
