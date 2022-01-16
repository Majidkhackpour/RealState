using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Accounting.Pardakht;
using Accounting.Reception;
using Building.BuildingAccountType;
using Building.BuildingCondition;
using Building.BuildingOptions;
using Building.BuildingRequest;
using Building.Buildings;
using Building.BuildingType;
using Building.BuildingView;
using Building.Contract;
using Building.DocumentType;
using Building.FloorCover;
using Building.KitchenService;
using Building.RentalAuthority;
using Cities.City;
using Cities.Region;
using EntityCache.Bussines;
using Peoples;
using Services;

namespace User
{
    public class Switcher
    {
        public static async Task SwitchAsync(EnLogPart part, Guid? objGuid)
        {
            try
            {
                if (objGuid == null || objGuid == Guid.Empty) return;
                Form frm = null;
                var guid = objGuid.Value;
                switch (part)
                {
                    case EnLogPart.Users:
                        var user = await UserBussines.GetAsync(guid);
                        frm = new frmUserMain(user, true); 
                        break;
                    case EnLogPart.Peoples: frm = new frmPeoples(guid, true); break;
                    case EnLogPart.Login:
                    case EnLogPart.Logout:
                        break;
                    case EnLogPart.Cities: frm = new frmCitiesMain(guid, true); break;
                    case EnLogPart.Regions: frm = new frmRegionMain(guid, true); break;
                    case EnLogPart.BuildingOptions: frm = new frmBuildingOptions(guid, true); break;
                    case EnLogPart.BuildingAccountType: frm = new frmBuildingAccountType(guid, true); break;
                    case EnLogPart.FloorCover: frm = new frmFloorCoverMain(guid, true); break;
                    case EnLogPart.KitchenService: frm = new frmKitchenServiceMain(guid, true); break;
                    case EnLogPart.DocumentType: frm = new frmDocumentTypeMain(guid, true); break;
                    case EnLogPart.RentalAuthority: frm = new frmRentalAuthorityMain(guid, true); break;
                    case EnLogPart.BuildingView: frm = new frmBuildingViewMain(guid, true); break;
                    case EnLogPart.BuildingCondition: frm = new frmBuildingConditionMain(guid, true); break;
                    case EnLogPart.BuildingType: frm = new frmBuildingTypeMain(guid, true); break;
                    case EnLogPart.Building:
                        var bu = await BuildingBussines.GetAsync(guid);
                        frm = new frmBuildingDetail(bu, false,false);
                        break;
                    case EnLogPart.BuildingRequest: frm = new frmBuildingRequestsMain(guid, true); break;
                    case EnLogPart.Contracts: frm = new frmContractMain(guid, true); break;
                    case EnLogPart.Reception:
                        var rec = await ReceptionBussines.GetAsync(guid);
                        frm = new frmReceptionMain(rec, true);
                        break;
                    case EnLogPart.Pardakht:
                        var par = await PardakhtBussines.GetAsync(guid);
                        frm = new frmPardakhtMain(par, true); 
                        break;
                }

                frm?.ShowDialog();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
