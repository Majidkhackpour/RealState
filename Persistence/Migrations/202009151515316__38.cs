namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _38 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Notes",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        Modified = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                        Title = c.String(maxLength: 500),
                        Description = c.String(),
                        DateSabt = c.DateTime(nullable: false),
                        DateSarresid = c.DateTime(),
                        UserGuid = c.Guid(nullable: false),
                        Priority = c.Short(nullable: false),
                        NoteStatus = c.Short(nullable: false),
                    })
                .PrimaryKey(t => t.Guid);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Notes");
        }
    }
}
