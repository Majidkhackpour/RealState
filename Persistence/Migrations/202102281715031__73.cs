namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _73 : DbMigration
    {
        public override void Up()
        {
            RenameIndex(table: "dbo.SanadDetails", name: "IX_MasterGuid", newName: "IX_Sanad_MasterGuid");
            CreateIndex("dbo.SanadDetails", "Modified", name: "IX_Sanad_Date");
        }
        
        public override void Down()
        {
            DropIndex("dbo.SanadDetails", "IX_Sanad_Date");
            RenameIndex(table: "dbo.SanadDetails", name: "IX_Sanad_MasterGuid", newName: "IX_MasterGuid");
        }
    }
}
