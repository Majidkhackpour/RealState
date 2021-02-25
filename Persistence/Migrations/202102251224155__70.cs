namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _70 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SanadDetails", "Sanad_Guid", "dbo.Sanads");
            DropIndex("dbo.SanadDetails", new[] { "Sanad_Guid" });
            DropColumn("dbo.SanadDetails", "MasterGuid");
            RenameColumn(table: "dbo.SanadDetails", name: "Sanad_Guid", newName: "MasterGuid");
            DropPrimaryKey("dbo.SanadDetails");
            AlterColumn("dbo.SanadDetails", "MasterGuid", c => c.Guid(nullable: false));
            AddPrimaryKey("dbo.SanadDetails", new[] { "Guid", "MasterGuid" });
            CreateIndex("dbo.SanadDetails", "MasterGuid");
            AddForeignKey("dbo.SanadDetails", "MasterGuid", "dbo.Sanads", "Guid", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SanadDetails", "MasterGuid", "dbo.Sanads");
            DropIndex("dbo.SanadDetails", new[] { "MasterGuid" });
            DropPrimaryKey("dbo.SanadDetails");
            AlterColumn("dbo.SanadDetails", "MasterGuid", c => c.Guid());
            AddPrimaryKey("dbo.SanadDetails", "Guid");
            RenameColumn(table: "dbo.SanadDetails", name: "MasterGuid", newName: "Sanad_Guid");
            AddColumn("dbo.SanadDetails", "MasterGuid", c => c.Guid(nullable: false));
            CreateIndex("dbo.SanadDetails", "Sanad_Guid");
            AddForeignKey("dbo.SanadDetails", "Sanad_Guid", "dbo.Sanads", "Guid");
        }
    }
}
