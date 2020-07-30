namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _10 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SmsPanels",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        Modified = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                        UserName = c.String(maxLength: 200),
                        Password = c.String(maxLength: 200),
                        Sender = c.String(maxLength: 200),
                        API = c.String(),
                    })
                .PrimaryKey(t => t.Guid);
            
            DropColumn("dbo.Peoples", "UserGuid");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Peoples", "UserGuid", c => c.Guid(nullable: false));
            DropTable("dbo.SmsPanels");
        }
    }
}
