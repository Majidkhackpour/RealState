namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _41 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SerializedDatas",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        Modified = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                        Name = c.String(maxLength: 200),
                        Data = c.String(),
                    })
                .PrimaryKey(t => t.Guid);
            
            AddColumn("dbo.AdvertiseLogs", "AdvType", c => c.Short(nullable: false));
            AddColumn("dbo.Simcards", "isSheypoorBlocked", c => c.Boolean(nullable: false));
            AddColumn("dbo.Simcards", "NextUseSheypoor", c => c.DateTime(nullable: false));
            AddColumn("dbo.Simcards", "NextUseDivar", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Simcards", "NextUseDivar");
            DropColumn("dbo.Simcards", "NextUseSheypoor");
            DropColumn("dbo.Simcards", "isSheypoorBlocked");
            DropColumn("dbo.AdvertiseLogs", "AdvType");
            DropTable("dbo.SerializedDatas");
        }
    }
}
