namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _48 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Buildings", "SaleSakht", c => c.String(maxLength: 30));
            AlterColumn("dbo.Buildings", "DateParvane", c => c.String(maxLength: 30));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Buildings", "DateParvane", c => c.String(maxLength: 10));
            AlterColumn("dbo.Buildings", "SaleSakht", c => c.String(maxLength: 10));
        }
    }
}
