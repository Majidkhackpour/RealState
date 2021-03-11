using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
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
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
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
        public virtual DbSet<Contract> Contract { get; set; }
        public virtual DbSet<ContractFinance> ContractFinance { get; set; }
        public virtual DbSet<UserLog> UserLog { get; set; }
        public virtual DbSet<SmsLog> SmsLog { get; set; }
        public virtual DbSet<Note> Note { get; set; }
        public virtual DbSet<SerializedData> SerializedData { get; set; }
        public virtual DbSet<AdvertiseRelatedRegion> AdvertiseRelatedRegion { get; set; }
        public virtual DbSet<AdvToken> AdvTokens { get; set; }
        public virtual DbSet<BackUpLog> BackUpLogs { get; set; }
        public virtual DbSet<Temp> Temp { get; set; }
        public virtual DbSet<FileInfo> FileInfo { get; set; }
        public virtual DbSet<Kol> Kol { get; set; }
        public virtual DbSet<Moein> Moein { get; set; }
        public virtual DbSet<Tafsil> Tafsil { get; set; }
        public virtual DbSet<Bank> Bank { get; set; }
        public virtual DbSet<DasteCheck> DasteCheck { get; set; }
        public virtual DbSet<CheckPage> CheckPage { get; set; }
        public virtual DbSet<Sanad> Sanad { get; set; }
        public virtual DbSet<SanadDetail> SanadDetails { get; set; }
        public virtual DbSet<Reception> Reception { get; set; }
        public virtual DbSet<ReceptionCheck> ReceptionCheck { get; set; }
        public virtual DbSet<ReceptionNaqd> ReceptionNaqd { get; set; }
        public virtual DbSet<ReceptionHavale> ReceptionHavale { get; set; }
        public virtual DbSet<BankSegest> BankSegest { get; set; }
        public virtual DbSet<Pardakht> Pardakht { get; set; }
        public virtual DbSet<PardakhtCheckShakhsi> PardakhtCheckShakhsi { get; set; }
        public virtual DbSet<PardakhtHavale> PardakhtHavale { get; set; }
        public virtual DbSet<PardakhtCheckMoshtari> PardakhtCheckMoshtari { get; set; }
        public virtual DbSet<PardakhtNaqd> PardakhtNaqd { get; set; }
    }
}
