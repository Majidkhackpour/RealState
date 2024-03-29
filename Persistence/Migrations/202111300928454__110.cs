﻿namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _110 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contracts", "CheckPrice1", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Contracts", "CheckPrice2", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contracts", "CheckPrice2");
            DropColumn("dbo.Contracts", "CheckPrice1");
        }
    }
}
