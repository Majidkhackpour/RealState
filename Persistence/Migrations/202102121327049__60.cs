namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _60 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Kols", "HesabGroup", c => c.Int(nullable: false));
            DropColumn("dbo.Kols", "GroupGuid");
            DropTable("dbo.HesabGroups");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.HesabGroups",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        Modified = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                        Name = c.String(maxLength: 200),
                        Code = c.String(maxLength: 10),
                    })
                .PrimaryKey(t => t.Guid);
            
            AddColumn("dbo.Kols", "GroupGuid", c => c.Guid(nullable: false));
            DropColumn("dbo.Kols", "HesabGroup");
        }
    }
}
