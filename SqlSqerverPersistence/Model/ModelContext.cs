using System.Data.Entity;

namespace SqlSqerverPersistence.Model
{
    public class ModelContext : DbContext
    {
        public ModelContext()
            : base("name=ModelContext")
        {
            //Database.SetInitializer(
            //    new MigrateDatabaseToLatestVersion<ModelContext, Configuration>());
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
        //public virtual DbSet<CustomerGroup> CustomerGroup { get; set; }

    }
}
