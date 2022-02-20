namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1421 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Buildings", "PishDesc");
            DropColumn("dbo.Buildings", "MoavezeDesc");
            DropColumn("dbo.Buildings", "MosharekatDesc");
            DropColumn("dbo.Buildings", "MetrazhKouche");
            DropColumn("dbo.Buildings", "DateParvane");
            DropColumn("dbo.Buildings", "ParvaneSerial");
            DropColumn("dbo.Buildings", "BonBast");
            DropColumn("dbo.Buildings", "MamarJoda");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Buildings", "MamarJoda", c => c.Boolean(nullable: false));
            AddColumn("dbo.Buildings", "BonBast", c => c.Boolean(nullable: false));
            AddColumn("dbo.Buildings", "ParvaneSerial", c => c.String(maxLength: 200));
            AddColumn("dbo.Buildings", "DateParvane", c => c.String(maxLength: 30));
            AddColumn("dbo.Buildings", "MetrazhKouche", c => c.Single(nullable: false));
            AddColumn("dbo.Buildings", "MosharekatDesc", c => c.String());
            AddColumn("dbo.Buildings", "MoavezeDesc", c => c.String());
            AddColumn("dbo.Buildings", "PishDesc", c => c.String());
        }
    }
}
