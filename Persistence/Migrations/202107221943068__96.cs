namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _96 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contracts", "CodeInArchive", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contracts", "CodeInArchive");
        }
    }
}
