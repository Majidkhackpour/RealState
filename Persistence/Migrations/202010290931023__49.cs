namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _49 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BackUpLogs",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        Modified = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                        InsertedDate = c.DateTime(nullable: false),
                        Path = c.String(maxLength: 1000),
                        Type = c.Short(nullable: false),
                        BackUpStatus = c.Short(nullable: false),
                        StatusDesc = c.String(maxLength: 1000),
                    })
                .PrimaryKey(t => t.Guid);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.BackUpLogs");
        }
    }
}
