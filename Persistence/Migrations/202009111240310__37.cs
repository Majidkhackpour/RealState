namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _37 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SmsLogs",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        Modified = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                        Date = c.DateTime(nullable: false),
                        UserGuid = c.Guid(nullable: false),
                        Sender = c.String(maxLength: 200),
                        Reciver = c.String(maxLength: 200),
                        Message = c.String(),
                        Cost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MessageId = c.Long(nullable: false),
                        StatusText = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Guid);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SmsLogs");
        }
    }
}
