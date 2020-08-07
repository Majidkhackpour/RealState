namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _15 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Buildings", "Code", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Buildings", "Code");
        }
    }
}
