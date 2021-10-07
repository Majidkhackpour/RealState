namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _106 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Buildings", "Water", c => c.Short());
            AlterColumn("dbo.Buildings", "Barq", c => c.Short());
            AlterColumn("dbo.Buildings", "Gas", c => c.Short());
            AlterColumn("dbo.Buildings", "Tell", c => c.Short());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Buildings", "Tell", c => c.Short(nullable: false));
            AlterColumn("dbo.Buildings", "Gas", c => c.Short(nullable: false));
            AlterColumn("dbo.Buildings", "Barq", c => c.Short(nullable: false));
            AlterColumn("dbo.Buildings", "Water", c => c.Short(nullable: false));
        }
    }
}
