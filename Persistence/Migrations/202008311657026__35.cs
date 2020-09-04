namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _35 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserLogs",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        Modified = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                        UserGuid = c.Guid(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Action = c.Short(nullable: false),
                        Part = c.Short(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Guid);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserLogs");
        }
    }
}
