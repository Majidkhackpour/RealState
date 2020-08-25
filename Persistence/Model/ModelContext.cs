using System.Data.Entity;
using Persistence.Entities;
using Persistence.Migrations;

namespace Persistence.Model
{
    public class ModelContext : DbContext
    {
        public ModelContext(string connectionString) : base(connectionString)
        {
            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<ModelContext, Configuration>());
        }
        public ModelContext() : base(Cache.ConnectionString)
        {
            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<ModelContext, Configuration>());
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<States> States { get; set; }
        public virtual DbSet<Cities> Cities { get; set; }
        public virtual DbSet<Regions> Regions { get; set; }
        public virtual DbSet<Naqz> Naqz { get; set; }
        public virtual DbSet<BuildingOptions> BuildingOptions { get; set; }
        public virtual DbSet<BuildingAccountType> BuildingAccountType { get; set; }
        public virtual DbSet<FloorCover> FloorCover { get; set; }
        public virtual DbSet<KitchenService> KitchenService { get; set; }
        public virtual DbSet<DocumentType> DocumentType { get; set; }
        public virtual DbSet<RentalAuthority> RentalAuthority { get; set; }
        public virtual DbSet<BuildingView> BuildingView { get; set; }
        public virtual DbSet<BuildingCondition> BuildingCondition { get; set; }
        public virtual DbSet<Settings> Settings { get; set; }
        public virtual DbSet<BuildingType> BuildingType { get; set; }
        public virtual DbSet<PeopleGroup> PeopleGroup { get; set; }
        public virtual DbSet<Peoples> Peoples { get; set; }
        public virtual DbSet<PeopleBankAccount> PeopleBankAccount { get; set; }
        public virtual DbSet<PhoneBook> PhoneBook { get; set; }
        public virtual DbSet<SmsPanels> SmsPanels { get; set; }
        public virtual DbSet<Simcard> Simcard { get; set; }
        public virtual DbSet<AdvertiseLog> AdvertiseLog { get; set; }
        public virtual DbSet<Building> Building { get; set; }
        public virtual DbSet<BuildingRelatedOptions> BuildingRelatedOptions { get; set; }
        public virtual DbSet<BuildingGallery> BuildingGallery { get; set; }
        public virtual DbSet<BuildingRequest> BuildingRequest { get; set; }
        public virtual DbSet<BuildingRequestRegion> BuildingRequestRegions { get; set; }
    }
}
