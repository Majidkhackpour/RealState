﻿namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _19 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Buildings", "SaleSakht", c => c.String(maxLength: 10));
            AlterColumn("dbo.Buildings", "DateParvane", c => c.String(maxLength: 10));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Buildings", "DateParvane", c => c.DateTime());
            AlterColumn("dbo.Buildings", "SaleSakht", c => c.DateTime());
        }
    }
}
