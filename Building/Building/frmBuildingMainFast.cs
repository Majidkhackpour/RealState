using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Building.BuildingMatchesItem;
using EntityCache.Bussines;
using EntityCache.ViewModels;
using MetroFramework.Forms;
using Nito.AsyncEx;
using Notification;
using Peoples;
using Services;
using Settings.Classes;
using User;

namespace Building.Building
{
    public partial class frmBuildingMainFast : MetroForm
    {
        private BuildingBussines cls;
        private PeoplesBussines owner;
        private CancellationTokenSource _token = new CancellationTokenSource();

        private async Task SetDataAsync()
        {
            try
            {
                await LoadUsersAsync();
                LoadOwner();
                FillCmbTarakom();
                FillCmbMetr();
                _token?.Cancel();
                _token = new CancellationTokenSource();
                await FillRentalAuthorityAsync(_token.Token);
                await FillSanadTypeAsync(_token.Token);
                await FillStateAsync(_token.Token);
                await FillBuildingConditionAsync(_token.Token);
                await FillBuildingTypeAsync(_token.Token);
                await FillBuildingAccountTypeAsync(_token.Token);
                await FillOptionsAsync(_token.Token);
                await NextCodeAsync();

                lblDateNow.Text = Calendar.MiladiToShamsi(DateTime.Now);
                cmbUser.SelectedValue = UserBussines.CurrentUser?.Guid;
                cmbRentalAuthority.SelectedIndex = 0;

                cmbSellTarakom.SelectedIndex = 0;
                cmbSellSanadType.SelectedIndex = 0;
                txtDong.Text = (cls?.Dang ?? 0).ToString();

                cmbState.SelectedIndex = 0;
                if (cmbState.SelectedValue != null && (Guid)cmbState.SelectedValue != Guid.Empty)
                    cmbState_SelectedIndexChanged(null, null);
                if (CityBindingSource.Count > 0) cmbCity.SelectedIndex = 0;
                if (cmbCity.SelectedValue != null && (Guid)cmbCity.SelectedValue != Guid.Empty)
                    cmbCity_SelectedIndexChanged(null, null);
                if (RegionBindingSource.Count > 0)
                    cmbRegion.SelectedIndex = 0;

                cmbBuildingCondition.SelectedIndex = 0;

                cmbBuildingType.SelectedIndex = 0;
                txtShortDesc.Text = cls?.ShortDesc;
                cmbBAccountType.SelectedIndex = 0;
                txtTedadOtaq.Value = 0;

                txtRahnPrice1.TextDecimal = 0;
                txtEjarePrice1.TextDecimal = 0;
                txtSellPrice.TextDecimal = 0;
                txtVamPrice.TextDecimal = 0;
                txtQestPrice.TextDecimal = 0;
                txtMasahat.Value = 0;
                txtZirBana.Value = 0;

                if (string.IsNullOrEmpty(clsEconomyUnit.EconomyState))
                    cmbState.SelectedIndex = 0;
                else
                    cmbState.SelectedValue = Guid.Parse(clsEconomyUnit.EconomyState);
                if (!string.IsNullOrEmpty(clsEconomyUnit.EconomyCity))
                    cmbCity.SelectedValue = Guid.Parse(clsEconomyUnit.EconomyCity);
                if (!string.IsNullOrEmpty(clsEconomyUnit.ManagerRegion))
                    cmbRegion.SelectedValue = Guid.Parse(clsEconomyUnit.ManagerRegion);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async Task NextCodeAsync()
        {
            try
            {
                txtCode.Text = await BuildingBussines.NextCodeAsync() ?? "";
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async Task LoadUsersAsync()
        {
            try
            {
                var list = await UserBussines.GetAllAsync();
                userBindingSource.DataSource = list.Where(q => q.Status).OrderBy(q => q.Name).ToList();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void LoadOwner()
        {
            try
            {
                txttxtOwnerCode.Text = owner?.Code;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void FillCmbTarakom()
        {
            try
            {
                var values = Enum.GetValues(typeof(EnTarakom)).Cast<EnTarakom>();
                foreach (var item in values)
                    cmbSellTarakom.Items.Add(item.GetDisplay());
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void FillCmbMetr()
        {
            try
            {
                var values = Enum.GetValues(typeof(EnMetr)).Cast<EnMetr>();
                foreach (var item in values)
                {
                    cmbMasahat.Items.Add(item.GetDisplay());
                    cmbZirBana.Items.Add(item.GetDisplay());
                }

                cmbMasahat.SelectedIndex = 0;
                cmbZirBana.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async Task FillRentalAuthorityAsync(CancellationToken token)
        {
            try
            {
                var list = await RentalAuthorityBussines.GetAllAsync(token);
                rentalBindingSource.DataSource = list.Where(q => q.Status).OrderBy(q => q.Name).ToList();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async Task FillSanadTypeAsync(CancellationToken token)
        {
            try
            {
                var list = await DocumentTypeBussines.GetAllAsync(token);
                sanadTypeBindingSource.DataSource = list.Where(q => q.Status).OrderBy(q => q.Name).ToList();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async Task FillStateAsync(CancellationToken token)
        {
            try
            {
                var list = await StatesBussines.GetAllAsync(token);
                StateBindingSource.DataSource = list.Where(q => q.Status).OrderBy(q => q.Name);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async Task FillBuildingConditionAsync(CancellationToken token)
        {
            try
            {
                var list = await BuildingConditionBussines.GetAllAsync(token);
                bConditionBindingSource.DataSource = list.Where(q => q.Status).ToList().OrderBy(q => q.Name);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async Task FillBuildingTypeAsync(CancellationToken token)
        {
            try
            {
                var list = await BuildingTypeBussines.GetAllAsync(token);
                bTypeBindingSource.DataSource = list.Where(q => q.Status).ToList().OrderBy(q => q.Name);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async Task FillBuildingAccountTypeAsync(CancellationToken token)
        {
            try
            {
                var list = await BuildingAccountTypeBussines.GetAllAsync(token);
                batBindingSource.DataSource = list.Where(q => q.Status).ToList().OrderBy(q => q.Name);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async Task FillOptionsAsync(CancellationToken token)
        {
            try
            {
                var list = await BuildingOptionsBussines.GetAllAsync(token);
                BuildingOptionBindingSource.DataSource = list.Where(q => q.Status).OrderBy(q => q.Name).ToList();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async Task<ReturnedSaveFuncInfo> CheckValidationAsync()
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                if (string.IsNullOrWhiteSpace(txtCode.Text))
                {
                    res.AddError("کد ملک نمی تواند خالی باشد");
                    txtCode.Focus();
                }

                if (!await BuildingBussines.CheckCodeAsync(txtCode.Text.Trim(), cls.Guid))
                {
                    res.AddError("کد ملک وارد شده تکراری است");
                    txtCode.Focus();
                }

                if (owner == null)
                {
                    res.AddError("لطفا مالک را انتخاب نمایید");
                    btnSearchOwner.Focus();
                }


                if (txtRahnPrice1.Text == "0" && txtEjarePrice1.Text == "0" && txtSellPrice.Text == "0")
                {
                    res.AddError("لطفا یکی از فیلدهای مبلغ را وارد نمایید");
                    btnSearchOwner.Focus();
                }

                if (txtZirBana.Text == "0" && txtMasahat.Text == "0")
                {
                    res.AddError("لطفا مساحت و زیربنا را وارد نمایید");
                    btnSearchOwner.Focus();
                }

                if (cmbRegion.SelectedValue == null)
                {
                    res.AddError("لطفا محدوده ملک را وارد نمایید");
                    btnSearchOwner.Focus();
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }
            return res;
        }
        private async Task<ReturnedSaveFuncInfo> SetObjectAsync()
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                cls.Code = txtCode.Text;
                cls.OwnerGuid = owner.Guid;
                cls.UserGuid = (Guid)cmbUser.SelectedValue;
                cls.Priority = EnBuildingPriority.Medium;
                cls.IsArchive = false;
                cls.SellPrice = txtSellPrice.TextDecimal;
                cls.QestPrice = txtQestPrice.TextDecimal;
                cls.VamPrice = txtVamPrice.TextDecimal;
                cls.Dang = txtDong.Text.ParseToInt();
                cls.DocumentType = (Guid)cmbSellSanadType.SelectedValue;
                cls.Tarakom = (EnTarakom)cmbSellTarakom.SelectedIndex;
                cls.RahnPrice1 = txtRahnPrice1.TextDecimal;
                cls.RahnPrice2 = 0;
                cls.EjarePrice1 = txtEjarePrice1.TextDecimal;
                cls.EjarePrice2 = 0;
                cls.RentalAutorityGuid = (Guid)cmbRentalAuthority.SelectedValue;
                cls.IsShortTime = false;
                cls.IsOwnerHere = false;
                cls.PishTotalPrice = 0;
                cls.PishPrice = 0;
                cls.DeliveryDate = null;

                if (cmbMasahat.SelectedIndex == 0)
                    cls.Masahat = txtMasahat.Text.ParseToInt();
                if (cmbMasahat.SelectedIndex == 1)
                    cls.Masahat = txtMasahat.Text.ParseToInt() * 10000;

                if (cmbZirBana.SelectedIndex == 0)
                    cls.ZirBana = txtZirBana.Text.ParseToInt();
                if (cmbZirBana.SelectedIndex == 1)
                    cls.ZirBana = txtZirBana.Text.ParseToInt() * 10000;

                cls.CityGuid = (Guid)cmbCity.SelectedValue;
                cls.RegionGuid = (Guid)cmbRegion.SelectedValue;
                cls.Address = txtAddress.Text;
                cls.BuildingConditionGuid = (Guid)cmbBuildingCondition.SelectedValue;
                cls.Side = EnBuildingSide.One;
                cls.BuildingTypeGuid = (Guid)cmbBuildingType.SelectedValue;
                cls.ShortDesc = txtShortDesc.Text;
                cls.BuildingAccountTypeGuid = (Guid)cmbBAccountType.SelectedValue;
                cls.MetrazhTejari = 0;
                _token?.Cancel();
                _token = new CancellationTokenSource();
                var views = await BuildingViewBussines.GetAllAsync(_token.Token);
                if (views.Count > 0)
                    cls.BuildingViewGuid = views[0].Guid;
                _token?.Cancel();
                _token = new CancellationTokenSource();
                var fCover = await FloorCoverBussines.GetAllAsync(_token.Token);
                if (fCover.Count > 0)
                    cls.FloorCoverGuid = fCover[0].Guid;
                _token?.Cancel();
                _token = new CancellationTokenSource();
                var kService = await KitchenServiceBussines.GetAllAsync(_token.Token);
                if (kService.Count > 0)
                    cls.KitchenServiceGuid = kService[0].Guid;
                cls.Water = EnKhadamati.Mostaqel;
                cls.Barq = EnKhadamati.Mostaqel;
                cls.Gas = EnKhadamati.Mostaqel;
                cls.Tell = EnKhadamati.Mostaqel;
                cls.TedadTabaqe = 0;
                cls.TabaqeNo = 0;
                cls.VahedPerTabaqe = 0;
                cls.MetrazhKouche = 0;
                cls.Hashie = 0;
                cls.ErtefaSaqf = 3;
                cls.SaleSakht = txtSaleSakht.Text;
                cls.BonBast = false;
                cls.MamarJoda = true;
                cls.RoomCount = txtTedadOtaq.Text.ParseToInt();
                cls.Image = "";
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
        }
        private async Task<ReturnedSaveFuncInfo> SetOptionsAsync(Guid buildingGuid)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                cls.OptionList = new List<BuildingRelatedOptionsBussines>();
                if (buildingGuid == Guid.Empty) return res;
                _token?.Cancel();
                _token = new CancellationTokenSource();
                var list = await BuildingOptionsBussines.GetAllAsync(_token.Token);
                if (list.Count <= 0) return res;
                foreach (var item in list)
                    for (var i = 0; i < DGrid.RowCount; i++)
                        if (item.Guid == ((Guid?)DGrid[dgOptionGuid.Index, i].Value ?? Guid.Empty))
                        {
                            if (!(bool)DGrid[dgChecked.Index, i].Value) continue;
                            cls.OptionList.Add(new BuildingRelatedOptionsBussines()
                            {
                                Guid = Guid.NewGuid(),
                                BuildingOptionGuid = item.Guid,
                                Modified = DateTime.Now,
                                BuildinGuid = cls.Guid
                            });
                        }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
        }
        private void CalculateSellPrice()
        {
            try
            {
                decimal masahat = 0, zirbana = 0;

                if (cmbMasahat.SelectedIndex == 0)
                    masahat = txtMasahat.Value;
                else
                    masahat = txtMasahat.Value * 10000;

                if (cmbZirBana.SelectedIndex == 0)
                    zirbana = txtZirBana.Value;
                else
                    zirbana = txtZirBana.Value * 10000;

                if (txtSellPrice.TextDecimal == 0)
                {
                    lblPricePerZirBana.Text = "0";
                    lblPricePerMetr.Text = "0";
                    return;
                }
                if (masahat > 0)
                    lblPricePerMetr.Text = (txtSellPrice.TextDecimal / masahat).ToString("N0") + " ریال";
                if (zirbana > 0)
                    lblPricePerZirBana.Text = (txtSellPrice.TextDecimal / zirbana).ToString("N0") + " ریال";
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }


        public frmBuildingMainFast()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            cls = new BuildingBussines();
            superTabControl1.SelectedTab = superTabItem1;
            superTabControl2.SelectedTab = superTabItem8;
        }


        private async void cmbState_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbState.SelectedValue == null) return;
                _token?.Cancel();
                _token = new CancellationTokenSource();
                var list = await CitiesBussines.GetAllAsync((Guid)cmbState.SelectedValue, _token.Token);
                CityBindingSource.DataSource = list?.Where(q => q.Status).OrderBy(q => q.Name).ToList();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async void cmbCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbCity.SelectedValue == null) return;
                _token?.Cancel();
                _token = new CancellationTokenSource();
                var list = await RegionsBussines.GetAllAsync((Guid)cmbCity.SelectedValue, _token.Token);
                RegionBindingSource.DataSource = list.Where(q => q.Status).OrderBy(q => q.Name).ToList();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void frmBuildingMainFast_Load(object sender, EventArgs e) => AsyncContext.Run(SetDataAsync);
        private void btnSearchOwner_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new frmShowPeoples(true);
                if (frm.ShowDialog(this) != DialogResult.OK) return;
                owner = PeoplesBussines.Get(frm.SelectedGuid);
                LoadOwner();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void btnCreateOwner_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new frmPeoples();
                if (frm.ShowDialog(this) != DialogResult.OK) return;
                owner = PeoplesBussines.Get(frm.SelectedGuid);
                LoadOwner();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void frmBuildingMainFast_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                switch (e.KeyCode)
                {
                    case Keys.Enter:
                        if (!btnFinish.Focused && !btnCancel.Focused)
                            SendKeys.Send("{Tab}");
                        break;
                    case Keys.F5:
                        btnFinish.PerformClick();
                        break;
                    case Keys.Escape:
                        btnCancel.PerformClick();
                        break;
                }
            }
            catch (Exception exception)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(exception);
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
        private async void btnFinish_Click(object sender, EventArgs e)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                var isSendSms = false;
                if (cls.Guid == Guid.Empty)
                {
                    cls.Guid = Guid.NewGuid();
                    isSendSms = true;
                }

                res.AddReturnedValue(await CheckValidationAsync());
                if (res.HasError) return;

                res.AddReturnedValue(await SetObjectAsync());
                if (res.HasError) return;

                res.AddReturnedValue(await SetOptionsAsync(cls.Guid));
                if (res.HasError) return;

                res.AddReturnedValue(await cls.SaveAsync());
                if (res.HasError) return;


                if (!Settings.Classes.Payamak.IsSendToOwner.ParseToBoolean() || !isSendSms) return;
                var tr = await Payamak.FixSms.OwnerSend.SendAsync(cls);
                frmNotification.PublicInfo.ShowMessage(tr.HasError
                    ? tr.ErrorMessage
                    : "ارسال پیامک به مالک با موفقیت انجام شد");

                if (res.HasError) return;

                if (MessageBox.Show("آیا مایلید تقاضاهای مطابق با این ملک را مشاهده نمایید؟", "تطبیق املاک با تقاضا",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
                    return;

                var list = await BuildingRequestViewModel.GetAllMatchesItemsAsync(cls);
                if (list.Count <= 0)
                {
                    MessageBox.Show("فایل مطابقی جهت نمایش وجود ندارد");
                    return;
                }

                new frmShowRequestMatches(list).ShowDialog();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }
            finally
            {
                if (res.HasError)
                {
                    var frm = new FrmShowErrorMessage(res, "خطا در ذخیره سازی ملک");
                    frm.ShowDialog(this);
                    frm.Dispose();
                }
                else
                {
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
        }
        private void txtMasahat_ValueChanged(object sender, EventArgs e) => CalculateSellPrice();
        private void txtZirBana_ValueChanged(object sender, EventArgs e) => CalculateSellPrice();
        private void cmbMasahat_SelectedIndexChanged(object sender, EventArgs e) => CalculateSellPrice();
        private void cmbZirBana_SelectedIndexChanged(object sender, EventArgs e) => CalculateSellPrice();
        private void txtSellPrice_OnTextChanged() => CalculateSellPrice();
    }
}
