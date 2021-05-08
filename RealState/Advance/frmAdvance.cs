using System;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityCache.Bussines;
using MetroFramework.Forms;
using Services;
using WebHesabBussines;

namespace RealState.Advance
{
    public partial class frmAdvance : MetroForm
    {
        private CancellationTokenSource _token = new CancellationTokenSource();
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
                {
                    _token?.Cancel();
                    _token = new CancellationTokenSource();
                    await WebStates.SaveAsync(await StatesBussines.GetAllAsync(_token.Token));
                }
                if (chbCity.Checked)
                {
                    _token?.Cancel();
                    _token = new CancellationTokenSource();
                    await WebCity.SaveAsync(await CitiesBussines.GetAllAsync(_token.Token));
                }

                if (chbRegion.Checked)
                {
                    _token?.Cancel();
                    _token = new CancellationTokenSource();
                    await WebRegion.SaveAsync(await RegionsBussines.GetAllAsync(_token.Token));
                }


                if (chbUsers.Checked)
                {
                    _token?.Cancel();
                    _token = new CancellationTokenSource();
                    await WebUser.SaveAsync(await UserBussines.GetAllAsync(_token.Token));
                }
                if (chbPeopleGroup.Checked)
                    await WebPeopleGroup.SaveAsync(await PeopleGroupBussines.GetAllAsync());
                if (chbPeople.Checked)
                {
                    _token?.Cancel();
                    _token = new CancellationTokenSource();
                    await WebPeople.SaveAsync(await PeoplesBussines.GetAllAsync(_token.Token));
                }


                if (chbAccountType.Checked)
                {
                    _token?.Cancel();
                    _token = new CancellationTokenSource();
                    await WebBuildingAccountType.SaveAsync(await BuildingAccountTypeBussines.GetAllAsync(_token.Token));
                }

                if (chbCondition.Checked)
                {
                    _token?.Cancel();
                    _token = new CancellationTokenSource();
                    await WebBuildingCondition.SaveAsync(await BuildingConditionBussines.GetAllAsync(_token.Token));
                }

                if (chbType.Checked)
                {
                    _token?.Cancel();
                    _token = new CancellationTokenSource();
                    await WebBuildingType.SaveAsync(await BuildingTypeBussines.GetAllAsync(_token.Token));
                }

                if (chbView.Checked)
                {
                    _token?.Cancel();
                    _token = new CancellationTokenSource();
                    await WebBuildingView.SaveAsync(await BuildingViewBussines.GetAllAsync(_token.Token));
                }

                if (chbDocType.Checked)
                {
                    _token?.Cancel();
                    _token = new CancellationTokenSource();
                    await WebDocumentType.SaveAsync(await DocumentTypeBussines.GetAllAsync(_token.Token));
                }

                if (chbFloor.Checked)
                {
                    _token?.Cancel();
                    _token = new CancellationTokenSource();
                    await WebFloorCover.SaveAsync(await FloorCoverBussines.GetAllAsync(_token.Token));
                }

                if (chbKitchen.Checked)
                {
                    _token?.Cancel();
                    _token = new CancellationTokenSource();
                    await WebKitchenService.SaveAsync(await KitchenServiceBussines.GetAllAsync(_token.Token));
                }

                if (chbRental.Checked)
                {
                    _token?.Cancel();
                    _token = new CancellationTokenSource();
                    await WebRental.SaveAsync(await RentalAuthorityBussines.GetAllAsync(_token.Token));
                }

                if (chbOptions.Checked)
                {
                    _token?.Cancel();
                    _token = new CancellationTokenSource();
                    await WebBuildingOptions.SaveAsync(await BuildingOptionsBussines.GetAllAsync(_token.Token));
                }

                if (chbBuilding.Checked)
                {
                    _token?.Cancel();
                    _token = new CancellationTokenSource();
                    await WebBuilding.SaveAsync(await BuildingBussines.GetAllAsync(_token.Token), Application.StartupPath);
                }


                if (chbRequest.Checked)
                {
                    _token?.Cancel();
                    _token = new CancellationTokenSource();
                    await WebBuildingRequest.SaveAsync(await BuildingRequestBussines.GetAllAsync(_token.Token));
                }

                if (chbContract.Checked)
                {
                    _token?.Cancel();
                    _token = new CancellationTokenSource();
                    await WebContract.SaveAsync(await ContractBussines.GetAllAsync(_token.Token));
                }
                if (chbReception.Checked)
                {
                    //await WebReception.SaveAsync(await ReceptionBussines.GetAllAsync());
                }

                if (chbPardakht.Checked)
                {
                    //await WebPardakht.SaveAsync(await PardakhtBussines.GetAllAsync());
                }


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
