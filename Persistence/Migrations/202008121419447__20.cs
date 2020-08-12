namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Buildings", "MetrazhTejari", c => c.Single(nullable: false));
            AlterColumn("dbo.Buildings", "MetrazhKouche", c => c.Single(nullable: false));
            AlterColumn("dbo.Buildings", "ErtefaSaqf", c => c.Single(nullable: false));
            AlterColumn("dbo.Buildings", "Hashie", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Buildings", "Hashie", c => c.Int(nullable: false));
            AlterColumn("dbo.Buildings", "ErtefaSaqf", c => c.Int(nullable: false));
            AlterColumn("dbo.Buildings", "MetrazhKouche", c => c.Int(nullable: false));
            AlterColumn("dbo.Buildings", "MetrazhTejari", c => c.Int(nullable: false));
        }
    }
}
