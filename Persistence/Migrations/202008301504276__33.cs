namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _33 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ContractFinances", "fBabat", c => c.Short(nullable: false));
            AddColumn("dbo.ContractFinances", "sBabat", c => c.Short(nullable: false));
            DropColumn("dbo.ContractFinances", "TotalPrice");
            DropColumn("dbo.ContractFinances", "Babat");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ContractFinances", "Babat", c => c.Short(nullable: false));
            AddColumn("dbo.ContractFinances", "TotalPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.ContractFinances", "sBabat");
            DropColumn("dbo.ContractFinances", "fBabat");
        }
    }
}
