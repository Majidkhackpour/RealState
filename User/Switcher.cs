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
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace User
{
    public class Switcher
    {
        public static async Task SwitchAsync(EnLogPart part, Guid? objGuid, IWin32Window owner)
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
                    case EnLogPart.Peoples:
                        var pe = await PeoplesBussines.GetAsync(guid, null);
                        frm = new frmPeoples(pe, true);
                        break;
                    case EnLogPart.Login:
                    case EnLogPart.Logout:
                        break;
                    case EnLogPart.Cities:
                        var city = await CitiesBussines.GetAsync(guid);
                        frm = new frmCitiesMain(city, true);
                        break;
                    case EnLogPart.Regions:
                        var region = await RegionsBussines.GetAsync(guid);
                        frm = new frmRegionMain(region, true);
                        break;
                    case EnLogPart.BuildingOptions:
                        var bop = await BuildingOptionsBussines.GetAsync(guid);
                        frm = new frmBuildingOptions(bop, true);
                        break;
                    case EnLogPart.BuildingAccountType:
                        var acc = await BuildingAccountTypeBussines.GetAsync(guid);
                        frm = new frmBuildingAccountType(acc, true);
                        break;
                    case EnLogPart.FloorCover:
                        var flor = await FloorCoverBussines.GetAsync(guid);
                        frm = new frmFloorCoverMain(flor, true);
                        break;
                    case EnLogPart.KitchenService:
                        var kitchen = await KitchenServiceBussines.GetAsync(guid);
                        frm = new frmKitchenServiceMain(kitchen, true);
                        break;
                    case EnLogPart.DocumentType:
                        var doc = await DocumentTypeBussines.GetAsync(guid);
                        frm = new frmDocumentTypeMain(doc, true);
                        break;
                    case EnLogPart.RentalAuthority:
                        var rental = await RentalAuthorityBussines.GetAsync(guid);
                        frm = new frmRentalAuthorityMain(rental, true);
                        break;
                    case EnLogPart.BuildingView:
                        var view = await BuildingViewBussines.GetAsync(guid);
                        frm = new frmBuildingViewMain(view, true);
                        break;
                    case EnLogPart.BuildingCondition:
                        var cond = await BuildingConditionBussines.GetAsync(guid);
                        frm = new frmBuildingConditionMain(cond, true);
                        break;
                    case EnLogPart.BuildingType:
                        var type = await BuildingTypeBussines.GetAsync(guid);
                        frm = new frmBuildingTypeMain(type, true);
                        break;
                    case EnLogPart.Building:
                        var bu = await BuildingBussines.GetAsync(guid);
                        frm = new frmBuildingDetail(bu, false, false);
                        break;
                    case EnLogPart.BuildingRequest:
                        var req = await BuildingRequestBussines.GetAsync(guid);
                        var asker = await PeoplesBussines.GetAsync(req?.AskerGuid ?? Guid.Empty, null);
                        frm = new frmBuildingRequestsMain(req, asker, true);
                        break;
                    case EnLogPart.Contracts:
                        var con = await ContractBussines.GetAsync(guid);
                        frm = null;
                        ContractFormHandler.FormHandler(con, true, owner);
                        break;
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
