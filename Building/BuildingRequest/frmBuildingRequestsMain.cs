using Building.Buildings;
using EntityCache.Bussines;
using MetroFramework.Forms;
using Peoples;
using Services;
using Services.FilterObjects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsSerivces;

namespace Building.BuildingRequest
{
    public partial class frmBuildingRequestsMain : MetroForm
    {
        private BuildingRequestBussines cls;
        private PeoplesBussines asker;
        private CancellationTokenSource _token = new CancellationTokenSource();

        private async Task SetDataAsync()
        {
            try
            {
                _token?.Cancel();
                _token = new CancellationTokenSource();
                LoadAsker();
                await FillRentalAuthorityAsync(_token.Token);
                FillCmbMetr();
                SetTxtMetr();
                await FillBuildingTypeAsync(_token.Token);
                await FillBuildingConditionAsync(_token.Token);
                await FillBuildingAccountTypeAsync(_token.Token);
                await FillStateAsync(_token.Token);

                lblDateNow.Text = cls?.DateSh;
                lblUserName.Text = cls?.UserName;

                chbHasVam.Checked = cls?.HasVam ?? false;
                chbHasOwner.Checked = cls?.HasOwner ?? false;
                chbShortDate.Checked = cls?.ShortDate ?? false;
                cmbRentalAuthority.SelectedValue = cls?.RentalAutorityGuid ?? Guid.Empty;
                txtPeopleCount.Text = (cls?.PeopleCount ?? 0).ToString();

                cmbBuildingType.SelectedValue = cls?.BuildingTypeGuid;
                cmbBuildingCondition.SelectedValue = cls?.BuildingConditionGuid;
                cmbBuildingAccountType.SelectedValue = cls?.BuildingAccountTypeGuid;
                txtRoomCount.Text = cls?.RoomCount.ToString();
                txtDesc.Text = cls?.ShortDesc;

                txtRahn1.TextDecimal = cls?.RahnPrice1 ?? 0;
                txtRahn2.TextDecimal = cls?.RahnPrice2 ?? 0;
                txtEjare1.TextDecimal = cls?.EjarePrice1 ?? 0;
                txtEjare2.TextDecimal = cls?.EjarePrice2 ?? 0;
                txtSellPrice1.TextDecimal = cls?.SellPrice1 ?? 0;
                txtSellPrice2.TextDecimal = cls?.SellPrice2 ?? 0;

                var city = await CitiesBussines.GetAsync(cls?.CityGuid ?? Guid.Empty);
                cmbState.SelectedValue = city?.StateGuid ?? Guid.Empty;
                if (cmbState.SelectedValue != null && (Guid)cmbState.SelectedValue != Guid.Empty)
                    cmbState_SelectedIndexChanged(null, null);
                cmbCity.SelectedValue = cls?.CityGuid;
                if (cmbCity.SelectedValue != null && (Guid)cmbCity.SelectedValue != Guid.Empty)
                    cmbCity_SelectedIndexChanged(null, null);

                SetRelatedRegions();

                if (cls?.Guid == Guid.Empty)
                {
                    lblUserName.Text = UserBussines.CurrentUser?.Name;
                    cmbRentalAuthority.SelectedIndex = 0;
                    cmbBuildingType.SelectedIndex = 0;
                    cmbBuildingCondition.SelectedIndex = 0;
                    cmbBuildingAccountType.SelectedIndex = 0;
                    if (SettingsBussines.Setting.CompanyInfo.EconomyState == Guid.Empty)
                        cmbState.SelectedIndex = 0;
                    else
                        cmbState.SelectedValue = SettingsBussines.Setting.CompanyInfo.EconomyState;
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async Task LoadWorkingRangeAsync()
        {
            try
            {
                if (InvokeRequired)
                {
                    Invoke(new MethodInvoker(() => LoadWorkingRangeAsync()));
                    return;
                }
                var list = await WorkingRangeBussines.GetAllAsync();
                if (list == null || list.Count < 0) return;

                for (var i = 0; i < DGrid.RowCount; i++)
                    foreach (var item in list)
                        if (item.RegionGuid == (Guid)DGrid[dgGuid.Index, i].Value)
                            DGrid[dgChecked.Index, i].Value = true;

                HighLightGrid();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void LoadAsker()
        {
            try
            {
                txttxtOwnerCode.Text = asker?.Code;
                lblOwnerName.Text = asker?.Name;
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
        private void FillCmbMetr()
        {
            try
            {
                var values = Enum.GetValues(typeof(EnMetr)).Cast<EnMetr>();
                foreach (var item in values)
                {
                    cmbMasahat1.Items.Add(item.GetDisplay());
                    cmbMasahat2.Items.Add(item.GetDisplay());
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void SetTxtMetr()
        {
            try
            {
                if (cls?.Masahat1 == 0)
                {
                    txtMasahat1.Text = cls?.Masahat1.ToString();
                    cmbMasahat1.SelectedIndex = 0;
                }
                if (cls?.Masahat1 != 0)
                {
                    if (cls?.Masahat1 >= 10000)
                    {
                        txtMasahat1.Text = (cls?.Masahat1 / 10000).ToString();
                        cmbMasahat1.SelectedIndex = 1;
                    }
                    if (cls?.Masahat1 <= 9999)
                    {
                        txtMasahat1.Text = cls?.Masahat1.ToString();
                        cmbMasahat1.SelectedIndex = 0;
                    }
                }


                if (cls?.Masahat2 == 0)
                {
                    txtMasahat2.Text = cls?.Masahat2.ToString();
                    cmbMasahat2.SelectedIndex = 0;
                }
                if (cls?.Masahat2 != 0)
                {
                    if (cls?.Masahat2 >= 10000)
                    {
                        txtMasahat2.Text = (cls?.Masahat2 / 10000).ToString();
                        cmbMasahat2.SelectedIndex = 1;
                    }
                    if (cls?.Masahat2 <= 9999)
                    {
                        txtMasahat2.Text = cls?.Masahat2.ToString();
                        cmbMasahat2.SelectedIndex = 0;
                    }
                }
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
                bTypeBindingSource.DataSource = list.Where(q => q.Status).OrderBy(q => q.Name);
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
                bConditionBindingSource.DataSource = list.Where(q => q.Status).OrderBy(q => q.Name);
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
                batBindingSource.DataSource = list.Where(q => q.Status).OrderBy(q => q.Name);
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
        private async Task SetRegionsAsync(Guid requestGuid)
        {
            try
            {
                cls.RegionList = new List<BuildingRequestRegionBussines>();
                if (requestGuid == Guid.Empty) return;
                _token?.Cancel();
                _token = new CancellationTokenSource();
                var list = await RegionsBussines.GetAllAsync(_token.Token);
                if (list.Count <= 0) return;
                foreach (var item in list)
                    for (var i = 0; i < DGrid.RowCount; i++)
                        if (item.Guid == ((Guid?)DGrid[dgGuid.Index, i].Value ?? Guid.Empty))
                        {
                            if (!(bool)DGrid[dgChecked.Index, i].Value) continue;
                            cls.RegionList.Add(new BuildingRequestRegionBussines()
                            {
                                Guid = Guid.NewGuid(),
                                RegionGuid = item.Guid,
                                Modified = DateTime.Now,
                                RequestGuid = cls.Guid
                            });
                        }
            }
            catch (Exception e)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(e);
            }
        }
        private void SetRelatedRegions()
        {
            try
            {
                if (cls == null || cls.RegionList == null || cls.RegionList.Count <= 0) return;
                foreach (var item in cls.RegionList)
                    for (var i = 0; i < DGrid.RowCount; i++)
                        if (item.RegionGuid == ((Guid?)DGrid[dgGuid.Index, i].Value ?? Guid.Empty))
                            DGrid[dgChecked.Index, i].Value = true;

                HighLightGrid();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void HighLightGrid()
        {
            try
            {
                for (var i = 0; i < DGrid.RowCount; i++)
                {
                    var val = DGrid[dgChecked.Index, i].Value;
                    if (val != null && (bool)val)
                        DGrid.Rows[i].DefaultCellStyle.BackColor = Color.Khaki;
                    else
                        DGrid.Rows[i].DefaultCellStyle.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        public frmBuildingRequestsMain(BuildingRequestBussines obj, PeoplesBussines _asker, bool isShowMode)
        {
            try
            {
                InitializeComponent();
                cls = obj;
                asker = _asker;
                if (!cls.IsModified)
                    ucHeader.Text = "افزودن تقاضای جدید";
                else
                    ucHeader.Text = !isShowMode ? $"ویرایش تقاضای {cls.AskerName}" : $"مشاهده تقاضای {cls.AskerName}";
                ucHeader.IsModified = cls.IsModified;
                ucAccept.Enabled = !isShowMode;
                groupPanel1.Enabled = groupPanel2.Enabled = groupPanel3.Enabled = !isShowMode;
                groupPanel4.Enabled = groupPanel5.Enabled = !isShowMode;
                WindowState = FormWindowState.Maximized;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
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
                if (cls.Guid != Guid.Empty) cmbCity.SelectedValue = cls.CityGuid;
                else if (SettingsBussines.Setting.CompanyInfo.EconomyCity != Guid.Empty)
                    cmbCity.SelectedValue = SettingsBussines.Setting.CompanyInfo.EconomyCity;

                SetRelatedRegions();
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
                if (cls.Guid == Guid.Empty) await LoadWorkingRangeAsync();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async void frmBuildingRequestsMain_Load(object sender, EventArgs e) => await SetDataAsync();
        private async void btnSearchOwner_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new frmShowPeoples(true);
                if (frm.ShowDialog(this) != DialogResult.OK) return;
                asker = await PeoplesBussines.GetAsync(frm.SelectedGuid, null);
                LoadAsker();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async void btnCreateOwner_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new frmPeopleMain(new PeoplesBussines(), false);
                if (frm.ShowDialog(this) != DialogResult.OK) return;
                asker = await PeoplesBussines.GetAsync(frm.SelectedGuid, null);
                LoadAsker();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void DGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e) => DGrid.Rows[e.RowIndex].Cells["dgRadif"].Value = e.RowIndex + 1;
        private void frmBuildingRequestsMain_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                switch (e.KeyCode)
                {
                    case Keys.Enter:
                        if (!ucAccept.Focused && !ucCancel.Focused && !txtDesc.Focused)
                            SendKeys.Send("{Tab}");
                        break;
                    case Keys.F5:
                        ucAccept.PerformClick();
                        break;
                    case Keys.Escape:
                        ucCancel.PerformClick();
                        break;
                }
            }
            catch (Exception exception)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(exception);
            }
        }
        private void DGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (DGrid.RowCount <= 0) return;
                if (e.ColumnIndex != dgChecked.Index) return;
                if (DGrid.CurrentRow == null) return;
                DGrid[dgChecked.Index, DGrid.CurrentRow.Index].Value = !(bool)DGrid[dgChecked.Index, DGrid.CurrentRow.Index].Value;
                HighLightGrid();
            }
            catch (Exception exception)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(exception);
            }
        }
        private async Task ucAccept_OnClick(object arg1, EventArgs arg2)
        {
            var res = new ReturnedSaveFuncInfo();
            ucAccept.Enabled = false;
            try
            {
                var isSendSms = false;
                if (cls.Guid == Guid.Empty)
                {
                    cls.Guid = Guid.NewGuid();
                    isSendSms = true;
                    cls.UserGuid = UserBussines.CurrentUser.Guid;
                }

                cls.AskerGuid = asker?.Guid ?? Guid.Empty;
                cls.Modified = DateTime.Now;

                cls.SellPrice1 = txtSellPrice1.TextDecimal;
                cls.SellPrice2 = txtSellPrice2.TextDecimal;
                cls.RahnPrice1 = txtRahn1.TextDecimal;
                cls.RahnPrice2 = txtRahn2.TextDecimal;
                cls.EjarePrice1 = txtEjare1.TextDecimal;
                cls.EjarePrice2 = txtEjare2.TextDecimal;

                cls.HasVam = chbHasVam.Checked;
                cls.PeopleCount = txtPeopleCount.Text.ParseToShort();
                cls.HasOwner = chbHasOwner.Checked;
                cls.ShortDate = chbShortDate.Checked;
                cls.RentalAutorityGuid = (Guid?)cmbRentalAuthority.SelectedValue ?? Guid.Empty;
                if (cmbCity.SelectedValue != null)
                    cls.CityGuid = (Guid)cmbCity.SelectedValue;
                cls.BuildingTypeGuid = (Guid)cmbBuildingType.SelectedValue;
                cls.Masahat1 = txtMasahat1.Text.ParseToInt();
                cls.Masahat2 = txtMasahat2.Text.ParseToInt();
                cls.RoomCount = txtRoomCount.Text.ParseToInt();
                cls.BuildingAccountTypeGuid = (Guid)cmbBuildingAccountType.SelectedValue;
                cls.BuildingConditionGuid = (Guid)cmbBuildingCondition.SelectedValue;
                cls.ShortDesc = txtDesc.Text;

                await SetRegionsAsync(cls.Guid);
                cls.ServerStatus = ServerStatus.None;
                res.AddReturnedValue(await cls.SaveAsync());

                if (res.HasError) return;

                if (SettingsBussines.Setting.Sms.IsSendToSayer && isSendSms)
                    _ = Task.Run(() => Payamak.FixSms.RequestSend.SendAsync(cls));

                if (MessageBox.Show("آیا مایلید املاک مطابق با این تقاضا را مشاهده نمایید؟", "تطبیق املاک با تقاضا",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
                    return;

                var filter = new BuildingFilter()
                {
                    Status = true,
                    RahnPrice1 = txtRahn1.TextDecimal,
                    EjarePrice1 = txtEjare1.TextDecimal,
                    RegionList = cls.RegionList?.Select(q => q.RegionGuid).ToList(),
                    BuildingAccountTypeGuid = cls.BuildingAccountTypeGuid,
                    UserGuid = null,
                    OwnerGuid = null,
                    BuildingTypeGuid = null,
                    AdvertiseType = null,
                    IsArchive = null,
                    SellPrice2 = txtSellPrice2.TextDecimal,
                    SellPrice1 = txtSellPrice1.TextDecimal,
                    Masahat1 = cls.Masahat1,
                    EjarePrice2 = txtEjare2.TextDecimal,
                    DocumentTypeGuid = null,
                    IsFullRahn = false,
                    IsPishForoush = false,
                    RahnPrice2 = txtRahn2.TextDecimal,
                    Masahat2 = cls.Masahat2,
                    IsSell = false,
                    IsRahn = false,
                    IsMosharekat = false,
                    MaxTabaqeNo = 0,
                    RoomCount1 = 0,
                    RoomCount2 = (int)txtRoomCount.Value,
                    ZirBana1 = 0,
                    ZirBana2 = 0
                };
                var frm = new frmShowBuildings(false, filter);
                frm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }
            finally
            {
                ucAccept.Enabled = true;
                if (res.HasError) this.ShowError(res, "خطا در ثبت تقاضا");
                else
                {
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
        }
        private async Task ucCancel_OnClick(object arg1, EventArgs arg2)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
