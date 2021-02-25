namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _71 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.SanadDetails", "MoeinGuid");
            CreateIndex("dbo.SanadDetails", "TafsilGuid");
            AddForeignKey("dbo.SanadDetails", "MoeinGuid", "dbo.Moeins", "Guid", cascadeDelete: true);
            AddForeignKey("dbo.SanadDetails", "TafsilGuid", "dbo.Tafsils", "Guid", cascadeDelete: true);
            DropColumn("dbo.Sanads", "SumDebit");
            DropColumn("dbo.Sanads", "SumCredit");
            DropColumn("dbo.SanadDetails", "MoeinCode");
            DropColumn("dbo.SanadDetails", "MoeinName");
            DropColumn("dbo.SanadDetails", "TafsilCode");
            DropColumn("dbo.SanadDetails", "TafsilName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SanadDetails", "TafsilName", c => c.String(maxLength: 200));
            AddColumn("dbo.SanadDetails", "TafsilCode", c => c.String(maxLength: 20));
            AddColumn("dbo.SanadDetails", "MoeinName", c => c.String(maxLength: 200));
            AddColumn("dbo.SanadDetails", "MoeinCode", c => c.String(maxLength: 20));
            AddColumn("dbo.Sanads", "SumCredit", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Sanads", "SumDebit", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropForeignKey("dbo.SanadDetails", "TafsilGuid", "dbo.Tafsils");
            DropForeignKey("dbo.SanadDetails", "MoeinGuid", "dbo.Moeins");
            DropIndex("dbo.SanadDetails", new[] { "TafsilGuid" });
            DropIndex("dbo.SanadDetails", new[] { "MoeinGuid" });
        }
    }
}
