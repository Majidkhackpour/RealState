namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _92 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PhoneBooks", "ParentGuid", "dbo.Peoples");
            AddForeignKey("dbo.PhoneBooks", "ParentGuid", "dbo.Tafsils", "Guid");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PhoneBooks", "ParentGuid", "dbo.Tafsils");
            AddForeignKey("dbo.PhoneBooks", "ParentGuid", "dbo.Peoples", "Guid");
        }
    }
}
