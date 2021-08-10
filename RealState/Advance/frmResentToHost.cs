using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityCache.Bussines;
using EntityCache.Mppings;
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
                    var list = await StatesBussines.GetAllAsync(_token.Token);
                    if (list != null && list.Count > 0)
                        await WebStates.SaveAsync(StateMapper.Instance.MapList(list));
                }
                if (chbCity.Checked)
                {
                    _token?.Cancel();
                    _token = new CancellationTokenSource();
                    var list = await CitiesBussines.GetAllAsync(_token.Token);
                    if (list != null && list.Count > 0)
                        await WebCity.SaveAsync(CityMapper.Instance.MapList(list));
                }
                if (chbRegion.Checked)
                {
                    _token?.Cancel();
                    _token = new CancellationTokenSource();
                    var list = await RegionsBussines.GetAllAsync(_token.Token);
                    if (list != null && list.Count > 0)
                        await WebRegion.SaveAsync(RegionMapper.Instance.MapList(list));
                }
                if (chbUsers.Checked)
                {
                    _token?.Cancel();
                    _token = new CancellationTokenSource();
                    var list = await UserBussines.GetAllAsync(_token.Token);
                    if (list != null && list.Count > 0)
                        await WebUser.SaveAsync(UserMapper.Instance.MapList(list));
                }

                if (chbPeopleGroup.Checked)
                {
                    var list = await PeopleGroupBussines.GetAllAsync();
                    if (list != null && list.Count > 0)
                        await WebPeopleGroup.SaveAsync(PeopleGroupMapper.Instance.MapList(list));
                }
                if (chbPeople.Checked)
                {
                    _token?.Cancel();
                    _token = new CancellationTokenSource();
                    var list = await PeoplesBussines.GetAllAsync(_token.Token);
                    if (list != null && list.Count > 0)
                        await WebPeople.SaveAsync(PeopleMapper.Instance.MapList(list));
                }
                if (chbAccountType.Checked)
                {
                    _token?.Cancel();
                    _token = new CancellationTokenSource();
                    var list = await BuildingAccountTypeBussines.GetAllAsync(_token.Token);
                    if (list != null && list.Count > 0)
                        await WebBuildingAccountType.SaveAsync(BuildingAccountTypeMapper.Instance.MapList(list));
                }
                if (chbCondition.Checked)
                {
                    _token?.Cancel();
                    _token = new CancellationTokenSource();
                    var list = await BuildingConditionBussines.GetAllAsync(_token.Token);
                    if (list != null && list.Count > 0)
                        await WebBuildingCondition.SaveAsync(BuildingConditionMapper.Instance.MapList(list));
                }
                if (chbType.Checked)
                {
                    _token?.Cancel();
                    _token = new CancellationTokenSource();
                    var list = await BuildingTypeBussines.GetAllAsync(_token.Token);
                    if (list != null && list.Count > 0)
                        await WebBuildingType.SaveAsync(BuildingTypeMapper.Instance.MapList(list));
                }
                if (chbView.Checked)
                {
                    _token?.Cancel();
                    _token = new CancellationTokenSource();
                    var list = await BuildingViewBussines.GetAllAsync(_token.Token);
                    if (list != null && list.Count > 0)
                        await WebBuildingView.SaveAsync(BuildingViewMapper.Instance.MapList(list));
                }
                if (chbDocType.Checked)
                {
                    _token?.Cancel();
                    _token = new CancellationTokenSource();
                    var list = await DocumentTypeBussines.GetAllAsync(_token.Token);
                    if (list != null && list.Count > 0)
                        await WebDocumentType.SaveAsync(DocumentTypeMapper.Instance.MapList(list));
                }

                if (chbFloor.Checked)
                {
                    _token?.Cancel();
                    _token = new CancellationTokenSource();
                    var list = await FloorCoverBussines.GetAllAsync(_token.Token);
                    if (list != null && list.Count > 0)
                        await WebFloorCover.SaveAsync(FloorCoverMapper.Instance.MapList(list));
                }

                if (chbKitchen.Checked)
                {
                    _token?.Cancel();
                    _token = new CancellationTokenSource();
                    var list = await KitchenServiceBussines.GetAllAsync(_token.Token);
                    if (list != null && list.Count > 0)
                        await WebKitchenService.SaveAsync(KitchenServiceMapper.Instance.MapList(list));
                }

                if (chbRental.Checked)
                {
                    _token?.Cancel();
                    _token = new CancellationTokenSource();
                    var list = await RentalAuthorityBussines.GetAllAsync(_token.Token);
                    if (list != null && list.Count > 0)
                        await WebRental.SaveAsync(RentalAuthorityMapper.Instance.MapList(list));
                }

                if (chbOptions.Checked)
                {
                    _token?.Cancel();
                    _token = new CancellationTokenSource();
                    var list = await BuildingOptionsBussines.GetAllAsync(_token.Token);
                    if (list != null && list.Count > 0)
                        await WebBuildingOptions.SaveAsync(BuildingOptionsMapper.Instance.MapList(list));
                }

                if (chbBuilding.Checked)
                {
                    _token?.Cancel();
                    _token = new CancellationTokenSource();
                    var list = await BuildingBussines.GetAllAsync(_token.Token, true);
                    if (list != null && list.Count > 0)
                        await WebBuilding.SaveAsync(BuildingMapper.Instance.MapList(list));
                }


                if (chbRequest.Checked)
                {
                    _token?.Cancel();
                    _token = new CancellationTokenSource();
                    var list = await BuildingRequestBussines.GetAllAsync(_token.Token);
                    if (list != null && list.Count > 0)
                        await WebBuildingRequest.SaveAsync(BuildingRequestMapper.Instance.MapList(list));
                }

                if (chbContract.Checked)
                {
                    _token?.Cancel();
                    _token = new CancellationTokenSource();
                    var list = await ContractBussines.GetAllAsync(_token.Token);
                    if (list != null && list.Count > 0)
                        await WebContract.SaveAsync(ContractMapper.Instance.MapList(list));
                }
                if (chbReception.Checked)
                {
                    _token?.Cancel();
                    _token = new CancellationTokenSource();
                    var list = await ReceptionBussines.GetAllAsync(_token.Token);
                    if (list != null && list.Count > 0)
                        await WebReception.SaveAsync(ReceptionMapper.Instance.MapList(list));
                }

                if (chbPardakht.Checked)
                {
                    _token?.Cancel();
                    _token = new CancellationTokenSource();
                    var list = await PardakhtBussines.GetAllAsync(_token.Token);
                    if (list != null && list.Count > 0)
                        await WebPardakht.SaveAsync(PardakhtMapper.Instance.MapList(list));
                }

                if (chbAdvisor.Checked)
                {
                    _token?.Cancel();
                    _token = new CancellationTokenSource();
                    var list = await AdvisorBussines.GetAllAsync(_token.Token);
                    if (list != null && list.Count > 0)
                        await WebAdvisor.SaveAsync(AdvisorMapper.Instance.MapList(list));
                }

                if (chbBank.Checked)
                {
                    _token?.Cancel();
                    _token = new CancellationTokenSource();
                    var list = await BankBussines.GetAllAsync(_token.Token);
                    if (list != null && list.Count > 0)
                        await WebBank.SaveAsync(BankMapper.Instance.MapList(list));
                }

                if (chbKol.Checked)
                {
                    _token?.Cancel();
                    _token = new CancellationTokenSource();
                    var list = await KolBussines.GetAllAsync(_token.Token);
                    if (list != null && list.Count > 0)
                        await WebKol.SaveAsync(KolMapper.Instance.MapList(list));
                }

                if (chbMoein.Checked)
                {
                    _token?.Cancel();
                    _token = new CancellationTokenSource();
                    var list = await MoeinBussines.GetAllAsync(_token.Token);
                    if (list != null && list.Count > 0)
                        await WebMoein.SaveAsync(MoeinMapper.Instance.MapList(list));
                }

                if (chbTafsil.Checked)
                {
                    _token?.Cancel();
                    _token = new CancellationTokenSource();
                    var list = await TafsilBussines.GetAllAsync(_token.Token);
                    if (list != null && list.Count > 0)
                        await WebTafsil.SaveAsync(TafsilMapper.Instance.MapList(list));
                }

                if (chbSanad.Checked)
                {
                    _token?.Cancel();
                    _token = new CancellationTokenSource();
                    var list = await SanadBussines.GetAllAsync(_token.Token);
                    if (list != null && list.Count > 0)
                        await WebSanad.SaveAsync(SanadMapper.Instance.MapList(list));
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
