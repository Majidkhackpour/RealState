namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _8 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PhoneBooks", "Group", c => c.Short(nullable: false));
            DropColumn("dbo.PhoneBooks", "IsSystem");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PhoneBooks", "IsSystem", c => c.Boolean(nullable: false));
            DropColumn("dbo.PhoneBooks", "Group");
        }
    }
}
