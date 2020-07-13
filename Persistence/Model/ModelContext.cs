using System.Data.Entity;
using Persistence.Entities;
using Persistence.Migrations;

namespace Persistence.Model
{
    public class ModelContext : DbContext
    {
        public ModelContext()
            : base("name=ModelContext")
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
    }
}
