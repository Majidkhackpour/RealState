﻿namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _90 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Advisors", "ServerStatus", c => c.Short(nullable: false));
            AddColumn("dbo.Advisors", "ServerDeliveryDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Banks", "ServerStatus", c => c.Short(nullable: false));
            AddColumn("dbo.Banks", "ServerDeliveryDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.DasteChecks", "ServerStatus", c => c.Short(nullable: false));
            AddColumn("dbo.DasteChecks", "ServerDeliveryDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.CheckPages", "ServerStatus", c => c.Short(nullable: false));
            AddColumn("dbo.CheckPages", "ServerDeliveryDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Tafsils", "ServerStatus", c => c.Short(nullable: false));
            AddColumn("dbo.Tafsils", "ServerDeliveryDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Contracts", "ServerStatus", c => c.Short(nullable: false));
            AddColumn("dbo.Contracts", "ServerDeliveryDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Buildings", "ServerStatus", c => c.Short(nullable: false));
            AddColumn("dbo.Buildings", "ServerDeliveryDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.BuildingAccountTypes", "ServerStatus", c => c.Short(nullable: false));
            AddColumn("dbo.BuildingAccountTypes", "ServerDeliveryDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.BuildingRequests", "ServerStatus", c => c.Short(nullable: false));
            AddColumn("dbo.BuildingRequests", "ServerDeliveryDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.BuildingTypes", "ServerStatus", c => c.Short(nullable: false));
            AddColumn("dbo.BuildingTypes", "ServerDeliveryDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.BuildingRequestRegions", "ServerStatus", c => c.Short(nullable: false));
            AddColumn("dbo.BuildingRequestRegions", "ServerDeliveryDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Regions", "ServerStatus", c => c.Short(nullable: false));
            AddColumn("dbo.Regions", "ServerDeliveryDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Cities", "ServerStatus", c => c.Short(nullable: false));
            AddColumn("dbo.Cities", "ServerDeliveryDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.States", "ServerStatus", c => c.Short(nullable: false));
            AddColumn("dbo.States", "ServerDeliveryDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.BuildingConditions", "ServerStatus", c => c.Short(nullable: false));
            AddColumn("dbo.BuildingConditions", "ServerDeliveryDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.RentalAuthorities", "ServerStatus", c => c.Short(nullable: false));
            AddColumn("dbo.RentalAuthorities", "ServerDeliveryDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Users", "ServerStatus", c => c.Short(nullable: false));
            AddColumn("dbo.Users", "ServerDeliveryDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Pardakhts", "ServerStatus", c => c.Short(nullable: false));
            AddColumn("dbo.Pardakhts", "ServerDeliveryDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Moeins", "ServerStatus", c => c.Short(nullable: false));
            AddColumn("dbo.Moeins", "ServerDeliveryDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Kols", "ServerStatus", c => c.Short(nullable: false));
            AddColumn("dbo.Kols", "ServerDeliveryDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.PardakhtHavales", "ServerStatus", c => c.Short(nullable: false));
            AddColumn("dbo.PardakhtHavales", "ServerDeliveryDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.PardakhtNaqds", "ServerStatus", c => c.Short(nullable: false));
            AddColumn("dbo.PardakhtNaqds", "ServerDeliveryDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Receptions", "ServerStatus", c => c.Short(nullable: false));
            AddColumn("dbo.Receptions", "ServerDeliveryDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.ReceptionChecks", "ServerStatus", c => c.Short(nullable: false));
            AddColumn("dbo.ReceptionChecks", "ServerDeliveryDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.ReceptionHavales", "ServerStatus", c => c.Short(nullable: false));
            AddColumn("dbo.ReceptionHavales", "ServerDeliveryDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.ReceptionNaqds", "ServerStatus", c => c.Short(nullable: false));
            AddColumn("dbo.ReceptionNaqds", "ServerDeliveryDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.ReceptionCheckAvalDores", "ServerStatus", c => c.Short(nullable: false));
            AddColumn("dbo.ReceptionCheckAvalDores", "ServerDeliveryDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.SanadDetails", "ServerStatus", c => c.Short(nullable: false));
            AddColumn("dbo.SanadDetails", "ServerDeliveryDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Sanads", "ServerStatus", c => c.Short(nullable: false));
            AddColumn("dbo.Sanads", "ServerDeliveryDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.PardakhtCheckMoshtaris", "ServerStatus", c => c.Short(nullable: false));
            AddColumn("dbo.PardakhtCheckMoshtaris", "ServerDeliveryDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.PardakhtCheckShakhsis", "ServerStatus", c => c.Short(nullable: false));
            AddColumn("dbo.PardakhtCheckShakhsis", "ServerDeliveryDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.PardakhtCheckAvalDores", "ServerStatus", c => c.Short(nullable: false));
            AddColumn("dbo.PardakhtCheckAvalDores", "ServerDeliveryDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.BuildingGalleries", "ServerStatus", c => c.Short(nullable: false));
            AddColumn("dbo.BuildingGalleries", "ServerDeliveryDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.BuildingRelatedOptions", "ServerStatus", c => c.Short(nullable: false));
            AddColumn("dbo.BuildingRelatedOptions", "ServerDeliveryDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.BuildingOptions", "ServerStatus", c => c.Short(nullable: false));
            AddColumn("dbo.BuildingOptions", "ServerDeliveryDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.BuildingViews", "ServerStatus", c => c.Short(nullable: false));
            AddColumn("dbo.BuildingViews", "ServerDeliveryDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.FloorCovers", "ServerStatus", c => c.Short(nullable: false));
            AddColumn("dbo.FloorCovers", "ServerDeliveryDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.KitchenServices", "ServerStatus", c => c.Short(nullable: false));
            AddColumn("dbo.KitchenServices", "ServerDeliveryDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Peoples", "ServerStatus", c => c.Short(nullable: false));
            AddColumn("dbo.Peoples", "ServerDeliveryDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.PeopleGroups", "ServerStatus", c => c.Short(nullable: false));
            AddColumn("dbo.PeopleGroups", "ServerDeliveryDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.PhoneBooks", "ServerStatus", c => c.Short(nullable: false));
            AddColumn("dbo.PhoneBooks", "ServerDeliveryDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.DocumentTypes", "ServerStatus", c => c.Short(nullable: false));
            AddColumn("dbo.DocumentTypes", "ServerDeliveryDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.FileInfoes", "ServerStatus", c => c.Short(nullable: false));
            AddColumn("dbo.FileInfoes", "ServerDeliveryDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.AdvertiseLogs", "Modified");
            DropColumn("dbo.AdvertiseLogs", "Status");
            DropColumn("dbo.AdvertiseRelatedRegions", "Modified");
            DropColumn("dbo.AdvertiseRelatedRegions", "Status");
            DropColumn("dbo.AdvTokens", "Modified");
            DropColumn("dbo.AdvTokens", "Status");
            DropColumn("dbo.BackUpLogs", "Modified");
            DropColumn("dbo.BackUpLogs", "Status");
            DropColumn("dbo.CheckPages", "Status");
            DropColumn("dbo.BuildingRequestRegions", "Status");
            DropColumn("dbo.Notes", "Modified");
            DropColumn("dbo.Notes", "Status");
            DropColumn("dbo.Pardakhts", "Status");
            DropColumn("dbo.Moeins", "Status");
            DropColumn("dbo.Kols", "Status");
            DropColumn("dbo.PardakhtHavales", "Status");
            DropColumn("dbo.PardakhtNaqds", "Status");
            DropColumn("dbo.Receptions", "Status");
            DropColumn("dbo.ReceptionChecks", "Status");
            DropColumn("dbo.ReceptionHavales", "Status");
            DropColumn("dbo.ReceptionNaqds", "Status");
            DropColumn("dbo.ReceptionCheckAvalDores", "Status");
            DropColumn("dbo.SanadDetails", "Status");
            DropColumn("dbo.Sanads", "Status");
            DropColumn("dbo.PardakhtCheckMoshtaris", "Status");
            DropColumn("dbo.PardakhtCheckShakhsis", "Status");
            DropColumn("dbo.PardakhtCheckAvalDores", "Status");
            DropColumn("dbo.SmsLogs", "Modified");
            DropColumn("dbo.SmsLogs", "Status");
            DropColumn("dbo.UserLogs", "Modified");
            DropColumn("dbo.UserLogs", "Status");
            DropColumn("dbo.BuildingGalleries", "Status");
            DropColumn("dbo.BuildingRelatedOptions", "Status");
            DropColumn("dbo.PeopleBankAccounts", "Modified");
            DropColumn("dbo.PeopleBankAccounts", "Status");
            DropColumn("dbo.BankSegests", "Modified");
            DropColumn("dbo.BankSegests", "Status");
            DropColumn("dbo.FileInfoes", "Status");
            DropColumn("dbo.Naqzs", "Modified");
            DropColumn("dbo.Naqzs", "Status");
            DropColumn("dbo.SerializedDatas", "Modified");
            DropColumn("dbo.SerializedDatas", "Status");
            DropColumn("dbo.Settings", "Modified");
            DropColumn("dbo.Settings", "Status");
            DropColumn("dbo.Simcards", "Modified");
            DropColumn("dbo.SmsPanels", "Modified");
            DropColumn("dbo.Temps", "Modified");
            DropColumn("dbo.Temps", "Status");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Temps", "Status", c => c.Boolean(nullable: false));
            AddColumn("dbo.Temps", "Modified", c => c.DateTime(nullable: false));
            AddColumn("dbo.SmsPanels", "Modified", c => c.DateTime(nullable: false));
            AddColumn("dbo.Simcards", "Modified", c => c.DateTime(nullable: false));
            AddColumn("dbo.Settings", "Status", c => c.Boolean(nullable: false));
            AddColumn("dbo.Settings", "Modified", c => c.DateTime(nullable: false));
            AddColumn("dbo.SerializedDatas", "Status", c => c.Boolean(nullable: false));
            AddColumn("dbo.SerializedDatas", "Modified", c => c.DateTime(nullable: false));
            AddColumn("dbo.Naqzs", "Status", c => c.Boolean(nullable: false));
            AddColumn("dbo.Naqzs", "Modified", c => c.DateTime(nullable: false));
            AddColumn("dbo.FileInfoes", "Status", c => c.Boolean(nullable: false));
            AddColumn("dbo.BankSegests", "Status", c => c.Boolean(nullable: false));
            AddColumn("dbo.BankSegests", "Modified", c => c.DateTime(nullable: false));
            AddColumn("dbo.PeopleBankAccounts", "Status", c => c.Boolean(nullable: false));
            AddColumn("dbo.PeopleBankAccounts", "Modified", c => c.DateTime(nullable: false));
            AddColumn("dbo.BuildingRelatedOptions", "Status", c => c.Boolean(nullable: false));
            AddColumn("dbo.BuildingGalleries", "Status", c => c.Boolean(nullable: false));
            AddColumn("dbo.UserLogs", "Status", c => c.Boolean(nullable: false));
            AddColumn("dbo.UserLogs", "Modified", c => c.DateTime(nullable: false));
            AddColumn("dbo.SmsLogs", "Status", c => c.Boolean(nullable: false));
            AddColumn("dbo.SmsLogs", "Modified", c => c.DateTime(nullable: false));
            AddColumn("dbo.PardakhtCheckAvalDores", "Status", c => c.Boolean(nullable: false));
            AddColumn("dbo.PardakhtCheckShakhsis", "Status", c => c.Boolean(nullable: false));
            AddColumn("dbo.PardakhtCheckMoshtaris", "Status", c => c.Boolean(nullable: false));
            AddColumn("dbo.Sanads", "Status", c => c.Boolean(nullable: false));
            AddColumn("dbo.SanadDetails", "Status", c => c.Boolean(nullable: false));
            AddColumn("dbo.ReceptionCheckAvalDores", "Status", c => c.Boolean(nullable: false));
            AddColumn("dbo.ReceptionNaqds", "Status", c => c.Boolean(nullable: false));
            AddColumn("dbo.ReceptionHavales", "Status", c => c.Boolean(nullable: false));
            AddColumn("dbo.ReceptionChecks", "Status", c => c.Boolean(nullable: false));
            AddColumn("dbo.Receptions", "Status", c => c.Boolean(nullable: false));
            AddColumn("dbo.PardakhtNaqds", "Status", c => c.Boolean(nullable: false));
            AddColumn("dbo.PardakhtHavales", "Status", c => c.Boolean(nullable: false));
            AddColumn("dbo.Kols", "Status", c => c.Boolean(nullable: false));
            AddColumn("dbo.Moeins", "Status", c => c.Boolean(nullable: false));
            AddColumn("dbo.Pardakhts", "Status", c => c.Boolean(nullable: false));
            AddColumn("dbo.Notes", "Status", c => c.Boolean(nullable: false));
            AddColumn("dbo.Notes", "Modified", c => c.DateTime(nullable: false));
            AddColumn("dbo.BuildingRequestRegions", "Status", c => c.Boolean(nullable: false));
            AddColumn("dbo.CheckPages", "Status", c => c.Boolean(nullable: false));
            AddColumn("dbo.BackUpLogs", "Status", c => c.Boolean(nullable: false));
            AddColumn("dbo.BackUpLogs", "Modified", c => c.DateTime(nullable: false));
            AddColumn("dbo.AdvTokens", "Status", c => c.Boolean(nullable: false));
            AddColumn("dbo.AdvTokens", "Modified", c => c.DateTime(nullable: false));
            AddColumn("dbo.AdvertiseRelatedRegions", "Status", c => c.Boolean(nullable: false));
            AddColumn("dbo.AdvertiseRelatedRegions", "Modified", c => c.DateTime(nullable: false));
            AddColumn("dbo.AdvertiseLogs", "Status", c => c.Boolean(nullable: false));
            AddColumn("dbo.AdvertiseLogs", "Modified", c => c.DateTime(nullable: false));
            DropColumn("dbo.FileInfoes", "ServerDeliveryDate");
            DropColumn("dbo.FileInfoes", "ServerStatus");
            DropColumn("dbo.DocumentTypes", "ServerDeliveryDate");
            DropColumn("dbo.DocumentTypes", "ServerStatus");
            DropColumn("dbo.PhoneBooks", "ServerDeliveryDate");
            DropColumn("dbo.PhoneBooks", "ServerStatus");
            DropColumn("dbo.PeopleGroups", "ServerDeliveryDate");
            DropColumn("dbo.PeopleGroups", "ServerStatus");
            DropColumn("dbo.Peoples", "ServerDeliveryDate");
            DropColumn("dbo.Peoples", "ServerStatus");
            DropColumn("dbo.KitchenServices", "ServerDeliveryDate");
            DropColumn("dbo.KitchenServices", "ServerStatus");
            DropColumn("dbo.FloorCovers", "ServerDeliveryDate");
            DropColumn("dbo.FloorCovers", "ServerStatus");
            DropColumn("dbo.BuildingViews", "ServerDeliveryDate");
            DropColumn("dbo.BuildingViews", "ServerStatus");
            DropColumn("dbo.BuildingOptions", "ServerDeliveryDate");
            DropColumn("dbo.BuildingOptions", "ServerStatus");
            DropColumn("dbo.BuildingRelatedOptions", "ServerDeliveryDate");
            DropColumn("dbo.BuildingRelatedOptions", "ServerStatus");
            DropColumn("dbo.BuildingGalleries", "ServerDeliveryDate");
            DropColumn("dbo.BuildingGalleries", "ServerStatus");
            DropColumn("dbo.PardakhtCheckAvalDores", "ServerDeliveryDate");
            DropColumn("dbo.PardakhtCheckAvalDores", "ServerStatus");
            DropColumn("dbo.PardakhtCheckShakhsis", "ServerDeliveryDate");
            DropColumn("dbo.PardakhtCheckShakhsis", "ServerStatus");
            DropColumn("dbo.PardakhtCheckMoshtaris", "ServerDeliveryDate");
            DropColumn("dbo.PardakhtCheckMoshtaris", "ServerStatus");
            DropColumn("dbo.Sanads", "ServerDeliveryDate");
            DropColumn("dbo.Sanads", "ServerStatus");
            DropColumn("dbo.SanadDetails", "ServerDeliveryDate");
            DropColumn("dbo.SanadDetails", "ServerStatus");
            DropColumn("dbo.ReceptionCheckAvalDores", "ServerDeliveryDate");
            DropColumn("dbo.ReceptionCheckAvalDores", "ServerStatus");
            DropColumn("dbo.ReceptionNaqds", "ServerDeliveryDate");
            DropColumn("dbo.ReceptionNaqds", "ServerStatus");
            DropColumn("dbo.ReceptionHavales", "ServerDeliveryDate");
            DropColumn("dbo.ReceptionHavales", "ServerStatus");
            DropColumn("dbo.ReceptionChecks", "ServerDeliveryDate");
            DropColumn("dbo.ReceptionChecks", "ServerStatus");
            DropColumn("dbo.Receptions", "ServerDeliveryDate");
            DropColumn("dbo.Receptions", "ServerStatus");
            DropColumn("dbo.PardakhtNaqds", "ServerDeliveryDate");
            DropColumn("dbo.PardakhtNaqds", "ServerStatus");
            DropColumn("dbo.PardakhtHavales", "ServerDeliveryDate");
            DropColumn("dbo.PardakhtHavales", "ServerStatus");
            DropColumn("dbo.Kols", "ServerDeliveryDate");
            DropColumn("dbo.Kols", "ServerStatus");
            DropColumn("dbo.Moeins", "ServerDeliveryDate");
            DropColumn("dbo.Moeins", "ServerStatus");
            DropColumn("dbo.Pardakhts", "ServerDeliveryDate");
            DropColumn("dbo.Pardakhts", "ServerStatus");
            DropColumn("dbo.Users", "ServerDeliveryDate");
            DropColumn("dbo.Users", "ServerStatus");
            DropColumn("dbo.RentalAuthorities", "ServerDeliveryDate");
            DropColumn("dbo.RentalAuthorities", "ServerStatus");
            DropColumn("dbo.BuildingConditions", "ServerDeliveryDate");
            DropColumn("dbo.BuildingConditions", "ServerStatus");
            DropColumn("dbo.States", "ServerDeliveryDate");
            DropColumn("dbo.States", "ServerStatus");
            DropColumn("dbo.Cities", "ServerDeliveryDate");
            DropColumn("dbo.Cities", "ServerStatus");
            DropColumn("dbo.Regions", "ServerDeliveryDate");
            DropColumn("dbo.Regions", "ServerStatus");
            DropColumn("dbo.BuildingRequestRegions", "ServerDeliveryDate");
            DropColumn("dbo.BuildingRequestRegions", "ServerStatus");
            DropColumn("dbo.BuildingTypes", "ServerDeliveryDate");
            DropColumn("dbo.BuildingTypes", "ServerStatus");
            DropColumn("dbo.BuildingRequests", "ServerDeliveryDate");
            DropColumn("dbo.BuildingRequests", "ServerStatus");
            DropColumn("dbo.BuildingAccountTypes", "ServerDeliveryDate");
            DropColumn("dbo.BuildingAccountTypes", "ServerStatus");
            DropColumn("dbo.Buildings", "ServerDeliveryDate");
            DropColumn("dbo.Buildings", "ServerStatus");
            DropColumn("dbo.Contracts", "ServerDeliveryDate");
            DropColumn("dbo.Contracts", "ServerStatus");
            DropColumn("dbo.Tafsils", "ServerDeliveryDate");
            DropColumn("dbo.Tafsils", "ServerStatus");
            DropColumn("dbo.CheckPages", "ServerDeliveryDate");
            DropColumn("dbo.CheckPages", "ServerStatus");
            DropColumn("dbo.DasteChecks", "ServerDeliveryDate");
            DropColumn("dbo.DasteChecks", "ServerStatus");
            DropColumn("dbo.Banks", "ServerDeliveryDate");
            DropColumn("dbo.Banks", "ServerStatus");
            DropColumn("dbo.Advisors", "ServerDeliveryDate");
            DropColumn("dbo.Advisors", "ServerStatus");
        }
    }
}
