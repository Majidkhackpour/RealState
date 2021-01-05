using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityCache.Bussines;
using MetroFramework.Forms;
using Services;
using WebHesabBussines;

namespace RealState
{
    public partial class frmAdvance : MetroForm
    {
        public frmAdvance() => InitializeComponent();
        private void frmAdvance_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) Close();
        }
        private async Task ResendDataToHost()
        {
            try
            {
                if (chbState.Checked)
                    await WebStates.SaveAsync(await StatesBussines.GetAllAsync());
                if (chbCity.Checked)
                    await WebCity.SaveAsync(await CitiesBussines.GetAllAsync());
                if (chbRegion.Checked)
                    await WebRegion.SaveAsync(await RegionsBussines.GetAllAsync());


                if (chbUsers.Checked)
                    await WebUser.SaveAsync(await UserBussines.GetAllAsync());
                if (chbPeopleGroup.Checked)
                    await WebPeopleGroup.SaveAsync(await PeopleGroupBussines.GetAllAsync());
                if (chbPeople.Checked)
                    await WebPeople.SaveAsync(await PeoplesBussines.GetAllAsync());
                if (chbHazine.Checked)
                    await WebHazine.SaveAsync(await HazineBussines.GetAllAsync());


                if (chbAccountType.Checked)
                    await WebBuildingAccountType.SaveAsync(await BuildingAccountTypeBussines.GetAllAsync());
                if (chbCondition.Checked)
                    await WebBuildingCondition.SaveAsync(await BuildingConditionBussines.GetAllAsync());
                if (chbType.Checked)
                    await WebBuildingType.SaveAsync(await BuildingTypeBussines.GetAllAsync());
                if (chbView.Checked)
                    await WebBuildingView.SaveAsync(await BuildingViewBussines.GetAllAsync());
                if (chbDocType.Checked)
                    await WebDocumentType.SaveAsync(await DocumentTypeBussines.GetAllAsync());
                if (chbFloor.Checked)
                    await WebFloorCover.SaveAsync(await FloorCoverBussines.GetAllAsync());
                if (chbKitchen.Checked)
                    await WebKitchenService.SaveAsync(await KitchenServiceBussines.GetAllAsync());
                if (chbRental.Checked)
                    await WebRental.SaveAsync(await RentalAuthorityBussines.GetAllAsync());
                if (chbBuilding.Checked)
                    await WebBuilding.SaveAsync(await BuildingBussines.GetAllAsync());


                if (chbRequest.Checked)
                    await WebBuildingRequest.SaveAsync(await BuildingRequestBussines.GetAllAsync());
                if (chbContract.Checked)
                    await WebContract.SaveAsync(await ContractBussines.GetAllAsync());
                if (chbReception.Checked)
                    await WebReception.SaveAsync(await ReceptionBussines.GetAllAsync());
                if (chbPardakht.Checked)
                    await WebPardakht.SaveAsync(await PardakhtBussines.GetAllAsync());
                if (chbGardesh.Checked)
                    await WebGardeshHesab.SaveAsync(await GardeshHesabBussines.GetAllAsync());


                Invoke(new MethodInvoker(() => MessageBox.Show("انتقال داده ها به سرور با موفقیت انجام شد")));
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
            finally
            {
                Invoke(new MethodInvoker(() =>
                {
                    btnSend.Enabled = true;
                    Cursor = Cursors.Default;
                }));
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            btnSend.Enabled = false;
            Cursor = Cursors.WaitCursor;
            _ = Task.Run(ResendDataToHost);
        }

        private async void btnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtQuery.Text))
                {
                    MessageBox.Show("لطفا کوئری موردنظر را وارد نمایید");
                    return;
                }

                var res = await DataBaseUtilities.RunScript.RunAsync(this, txtQuery.Text,
                    new SqlConnection(Settings.AppSettings.DefaultConnectionString));
                if (res.HasError) MessageBox.Show(res.ErrorMessage, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show("اجرای کوئری با موفقیت انجام شد", "پیغام سیستم", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
