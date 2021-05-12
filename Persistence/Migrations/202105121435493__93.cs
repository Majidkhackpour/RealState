namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _93 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdjectiveDescriptions",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Guid);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AdjectiveDescriptions");
        }
    }
}
