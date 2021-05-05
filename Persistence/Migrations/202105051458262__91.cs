namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _91 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pardakhts", "SumCheckMoshtari", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Pardakhts", "SumCheckShakhsi", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Pardakhts", "SumHavale", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Pardakhts", "SumNaqd", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Pardakhts", "Sum", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Receptions", "SumCheck", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Receptions", "SumHavale", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Receptions", "SumNaqd", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Receptions", "Sum", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Receptions", "Sum");
            DropColumn("dbo.Receptions", "SumNaqd");
            DropColumn("dbo.Receptions", "SumHavale");
            DropColumn("dbo.Receptions", "SumCheck");
            DropColumn("dbo.Pardakhts", "Sum");
            DropColumn("dbo.Pardakhts", "SumNaqd");
            DropColumn("dbo.Pardakhts", "SumHavale");
            DropColumn("dbo.Pardakhts", "SumCheckShakhsi");
            DropColumn("dbo.Pardakhts", "SumCheckMoshtari");
        }
    }
}
