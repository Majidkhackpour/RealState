namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _62 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Banks",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        Modified = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                        Code = c.String(maxLength: 10),
                        Name = c.String(maxLength: 200),
                        Shobe = c.String(maxLength: 200),
                        CodeShobe = c.String(maxLength: 20),
                        HesabNumber = c.String(maxLength: 200),
                        Description = c.String(),
                        DateM = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Guid);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Banks");
        }
    }
}
