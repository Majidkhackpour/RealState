using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityCache.Bussines;
using MetroFramework.Forms;
using Services;
using WebHesabBussines;

namespace RealState.Advance
{
    public partial class frmResentToHost : MetroForm
    {
        private CancellationTokenSource _token = new CancellationTokenSource();

        public frmResentToHost()
        {
            InitializeComponent();
            ucHeader.Text = "ارسال مجدد داده ها به هاست";
        }

        private void btnSend_Click(object sender, System.EventArgs e)
        {
            btnSend.Enabled = false;
            Cursor = Cursors.WaitCursor;
            _ = Task.Run(ResendDataToHost);
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
                    await WebBuilding.SaveAsync(await BuildingBussines.GetAllAsync(_token.Token,true), Application.StartupPath);
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
                    _token?.Cancel();
                    _token = new CancellationTokenSource();
                    await WebReception.SaveAsync(await ReceptionBussines.GetAllAsync(_token.Token));
                }

                if (chbPardakht.Checked)
                {
                    _token?.Cancel();
                    _token = new CancellationTokenSource();
                    await WebPardakht.SaveAsync(await PardakhtBussines.GetAllAsync(_token.Token));
                }

                if (chbAdvisor.Checked)
                {
                    _token?.Cancel();
                    _token = new CancellationTokenSource();
                    await WebAdvisor.SaveAsync(await AdvisorBussines.GetAllAsync(_token.Token));
                }

                if (chbBank.Checked)
                {
                    _token?.Cancel();
                    _token = new CancellationTokenSource();
                    await WebBank.SaveAsync(await BankBussines.GetAllAsync(_token.Token));
                }

                if (chbKol.Checked)
                {
                    _token?.Cancel();
                    _token = new CancellationTokenSource();
                    await WebKol.SaveAsync(await KolBussines.GetAllAsync(_token.Token));
                }

                if (chbMoein.Checked)
                {
                    _token?.Cancel();
                    _token = new CancellationTokenSource();
                    await WebMoein.SaveAsync(await MoeinBussines.GetAllAsync(_token.Token));
                }

                if (chbTafsil.Checked)
                {
                    _token?.Cancel();
                    _token = new CancellationTokenSource();
                    await WebTafsil.SaveAsync(await TafsilBussines.GetAllAsync(_token.Token));
                }

                if (chbSanad.Checked)
                {
                    _token?.Cancel();
                    _token = new CancellationTokenSource();
                    await WebSanad.SaveAsync(await SanadBussines.GetAllAsync(_token.Token));
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
        private void frmResentToHost_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) Close();
        }
    }
}
