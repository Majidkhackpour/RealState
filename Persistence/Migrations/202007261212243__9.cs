namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _9 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PeopleBankAccounts", "ParentGuid", c => c.Guid(nullable: false));
            AddColumn("dbo.PhoneBooks", "ParentGuid", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PhoneBooks", "ParentGuid");
            DropColumn("dbo.PeopleBankAccounts", "ParentGuid");
        }
    }
}
