namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _6 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PeopleBankAccounts",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        Modified = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                        BankName = c.String(maxLength: 200),
                        AccountNumber = c.String(maxLength: 200),
                        Shobe = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.Guid);
            
            CreateTable(
                "dbo.Peoples",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        Modified = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                        Code = c.String(maxLength: 10),
                        Name = c.String(maxLength: 500),
                        NationalCode = c.String(maxLength: 20),
                        IdCode = c.String(maxLength: 20),
                        FatherName = c.String(maxLength: 200),
                        PlaceBirth = c.String(maxLength: 500),
                        DateBirth = c.String(maxLength: 20),
                        Address = c.String(),
                        IssuedFrom = c.String(maxLength: 200),
                        PostalCode = c.String(maxLength: 50),
                        UserGuid = c.Guid(nullable: false),
                        GroupGuid = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Guid);
            
            CreateTable(
                "dbo.PhoneBooks",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        Modified = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                        Name = c.String(maxLength: 500),
                        Tell = c.String(maxLength: 20),
                        Email = c.String(maxLength: 50),
                        IsSystem = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Guid);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PhoneBooks");
            DropTable("dbo.Peoples");
            DropTable("dbo.PeopleBankAccounts");
        }
    }
}
