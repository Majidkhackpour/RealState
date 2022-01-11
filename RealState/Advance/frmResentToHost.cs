using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsSerivces;
using EntityCache.Bussines;
using EntityCache.Mppings;
using MetroFramework.Forms;
using Services;
using WebHesabBussines;

namespace RealState.Advance
{
    public partial class frmResentToHost : MetroForm
    {
        public frmResentToHost()
        {
            InitializeComponent();
            ucHeader.Text = "ارسال مجدد داده ها به هاست";
        }

        private async void btnSend_Click(object sender, System.EventArgs e)
        {
            var res=new ReturnedSaveFuncInfo();
            try
            {
                btnSend.Enabled = false;
                Cursor = Cursors.WaitCursor;
                res.AddReturnedValue(await ResendDataToHost());
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }
            finally
            {
                btnSend.Enabled = true;
                Cursor = Cursors.Default;
                if (res.HasError) this.ShowError(res);
                else this.ShowMessage("انتقال داده ها به سرور با موفقیت انجام شد");
            }
        }
        private async Task<ReturnedSaveFuncInfo> ResendDataToHost()
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                if (chbState.Checked)
                    res.AddReturnedValue(await StatesBussines.ResetAsync());
                if (chbCity.Checked)
                    res.AddReturnedValue(await CitiesBussines.ResetAsync());
                if (chbRegion.Checked)
                    res.AddReturnedValue(await RegionsBussines.ResetAsync());
                if (chbUsers.Checked)
                    res.AddReturnedValue(await UserBussines.ResetAsync());
                if (chbPeopleGroup.Checked)
                    res.AddReturnedValue(await PeopleGroupBussines.ResetAsync());
                if (chbPeople.Checked)
                    res.AddReturnedValue(await PeoplesBussines.ResetAsync());
                if (chbAccountType.Checked)
                    res.AddReturnedValue(await BuildingAccountTypeBussines.ResetAsync());
                if (chbCondition.Checked)
                    res.AddReturnedValue(await BuildingConditionBussines.ResetAsync());
                if (chbType.Checked)
                    res.AddReturnedValue(await BuildingTypeBussines.ResetAsync());
                if (chbView.Checked)
                    res.AddReturnedValue(await BuildingViewBussines.ResetAsync());
                if (chbDocType.Checked)
                    res.AddReturnedValue(await DocumentTypeBussines.ResetAsync());
                if (chbFloor.Checked)
                    res.AddReturnedValue(await FloorCoverBussines.ResetAsync());
                if (chbKitchen.Checked)
                    res.AddReturnedValue(await KitchenServiceBussines.ResetAsync());
                if (chbRental.Checked)
                    res.AddReturnedValue(await RentalAuthorityBussines.ResetAsync());
                if (chbOptions.Checked)
                    res.AddReturnedValue(await BuildingOptionsBussines.ResetAsync());
                if (chbBuilding.Checked)
                    res.AddReturnedValue(await BuildingBussines.ResetAsync());
                if (chbRequest.Checked)
                    res.AddReturnedValue(await BuildingRequestBussines.ResetAsync());
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }
            return res;
        }
        private void frmResentToHost_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) Close();
        }
    }
}
