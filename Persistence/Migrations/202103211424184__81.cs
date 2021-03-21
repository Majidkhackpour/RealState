namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _81 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PardakhtCheckAvalDores", "Number", c => c.String(maxLength: 200));
            AlterColumn("dbo.ReceptionCheckAvalDores", "BankName", c => c.String(maxLength: 200));
            AlterColumn("dbo.ReceptionCheckAvalDores", "CheckNumber", c => c.String(maxLength: 200));
            AlterColumn("dbo.ReceptionCheckAvalDores", "PoshtNomre", c => c.String(maxLength: 200));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ReceptionCheckAvalDores", "PoshtNomre", c => c.String());
            AlterColumn("dbo.ReceptionCheckAvalDores", "CheckNumber", c => c.String());
            AlterColumn("dbo.ReceptionCheckAvalDores", "BankName", c => c.String());
            AlterColumn("dbo.PardakhtCheckAvalDores", "Number", c => c.String());
        }
    }
}
