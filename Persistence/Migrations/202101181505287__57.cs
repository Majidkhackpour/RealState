namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _57 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Temps", "Type", c => c.Short(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Temps", "Type", c => c.Int(nullable: false));
        }
    }
}
