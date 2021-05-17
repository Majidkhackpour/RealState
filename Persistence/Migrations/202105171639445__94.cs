namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _94 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Calendars",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        Modified = c.DateTime(nullable: false),
                        DateM = c.DateTime(nullable: false),
                        Monasebat = c.String(maxLength: 500),
                        Description = c.String(),
                        isTatil = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Guid);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Calendars");
        }
    }
}
