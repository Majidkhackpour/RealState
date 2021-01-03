using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityCache.Bussines;
using MetroFramework.Forms;
using Notification;
using Peoples;
using Services;
using User;

namespace Building.BuildingRequest
{
    public partial class frmRequestMain : MetroForm
    {
        private BuildingRequestBussines cls;
        private PeoplesBussines asker;
        private EnLogAction action;

        private async Task SetDataAsync()
        {
            try
            {
                await LoadUsersAsync();
                LoadAsker();
                await FillRentalAuthorityAsync();
                FillCmbMetr();
                SetTxtMetr();
                await FillBuildingTypeAsync();
                await FillBuildingConditionAsync();
                await FillBuildingAccountTypeAsync();
                await FillStateAsync();

                lblDateNow.Text = cls?.DateSh;
                cmbUser.SelectedValue = cls?.UserGuid;

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

                var city = CitiesBussines.Get(cls?.CityGuid ?? Guid.Empty);
                cmbState.SelectedValue = city?.StateGuid ?? Guid.Empty;
                if (cmbState.SelectedValue != null && (Guid)cmbState.SelectedValue != Guid.Empty)
                    cmbState_SelectedIndexChanged(null, null);
                cmbCity.SelectedValue = cls?.CityGuid;
                if (cmbCity.SelectedValue != null && (Guid)cmbCity.SelectedValue != Guid.Empty)
                    cmbCity_SelectedIndexChanged(null, null);

                await SetRelatedRegionsAsync(cls?.Guid ?? Guid.Empty);

                if (cls?.Guid == Guid.Empty)
                {
                    cmbUser.SelectedValue = clsUser.CurrentUser?.Guid;
                    cmbRentalAuthority.SelectedIndex = 0;
                    cmbBuildingType.SelectedIndex = 0;
                    cmbBuildingCondition.SelectedIndex = 0;
                    cmbBuildingAccountType.SelectedIndex = 0;
                    cmbState.SelectedIndex = 0;
                }
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
        private void LoadAsker()
        {
            try
            {
                txttxtOwnerCode.Text = asker?.Code;
                lblOwnerAddress.Text = asker?.Address;
                lblOwnerDateBirth.Text = asker?.DateBirth;
                lblOwnerFatherName.Text = asker?.FatherName;
                lblOwnerNCode.Text = asker?.NationalCode;
                lblOwnerName.Text = asker?.Name;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async Task FillRentalAuthorityAsync()
        {
            try
            {
                var list = await RentalAuthorityBussines.GetAllAsync();
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
        private async Task FillBuildingTypeAsync()
        {
            try
            {
                var list = await BuildingTypeBussines.GetAllAsync();
                bTypeBindingSource.DataSource = list.Where(q => q.Status).OrderBy(q => q.Name);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async Task FillBuildingConditionAsync()
        {
            try
            {
                var list = await BuildingConditionBussines.GetAllAsync();
                bConditionBindingSource.DataSource = list.Where(q => q.Status).OrderBy(q => q.Name);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async Task FillBuildingAccountTypeAsync()
        {
            try
            {
                var list = await BuildingAccountTypeBussines.GetAllAsync();
                batBindingSource.DataSource = list.Where(q => q.Status).OrderBy(q => q.Name);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async Task FillStateAsync()
        {
            try
            {
                var list = await StatesBussines.GetAllAsync();
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
                var list = await RegionsBussines.GetAllAsync();
                if (list.Count <= 0) return;
                foreach (var item in list)
                    for (var i = 0; i < DGrid.RowCount; i++)
                        if (item.Guid == ((Guid?)DGrid[dgGuid.Index, i].Value ?? Guid.Empty))
                        {
                            if (!(bool)DGrid[dgChecked.Index, i].Value) continue;
                            cls.RegionList.Add(new BuildingRequestRegionBussines()
                            {
                                Guid = Guid.NewGuid(),
                                Status = true,
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
        private async Task SetRelatedRegionsAsync(Guid requestGuid)
        {
            try
            {
                if (requestGuid == Guid.Empty) return;
                var op = await BuildingRequestRegionBussines.GetAllAsync(requestGuid, true);
                foreach (var item in op)
                    for (var i = 0; i < DGrid.RowCount; i++)
                        if (item.RegionGuid == ((Guid?)DGrid[dgGuid.Index, i].Value ?? Guid.Empty))
                            DGrid[dgChecked.Index, i].Value = true;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        public frmRequestMain()
        {
            InitializeComponent();
            cls = new BuildingRequestBussines();
            WindowState = FormWindowState.Maximized;
            action = EnLogAction.Insert;
        }
        public frmRequestMain(Guid guid, bool isShowMode)
        {
            InitializeComponent();
            cls = BuildingRequestBussines.Get(guid);
            asker = PeoplesBussines.Get(cls.AskerGuid);
            superTabControlPanel1.Enabled = !isShowMode;
            superTabControlPanel2.Enabled = !isShowMode;
            superTabControlPanel3.Enabled = !isShowMode;
            btnFinish.Enabled = !isShowMode;
            superTabControl1.SelectedTab = superTabItem1;
            WindowState = FormWindowState.Maximized;
            action = EnLogAction.Update;
        }

        private async void frmRequestMain_Load(object sender, EventArgs e) => await SetDataAsync();

        private void btnSearchOwner_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new frmShowPeoples(true);
                if (frm.ShowDialog(this) != DialogResult.OK) return;
                asker = PeoplesBussines.Get(frm.SelectedGuid);
                LoadAsker();
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
                asker = PeoplesBussines.Get(frm.SelectedGuid);
                LoadAsker();
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
                var list = await CitiesBussines.GetAllAsync((Guid)cmbState.SelectedValue);
                CityBindingSource.DataSource = list.Where(q => q.Status).OrderBy(q => q.Name).ToList();
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
                var list = await RegionsBussines.GetAllAsync((Guid)cmbCity.SelectedValue);
                RegionBindingSource.DataSource = list.Where(q => q.Status).OrderBy(q => q.Name).ToList();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void DGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DGrid.Rows[e.RowIndex].Cells["dgRadif"].Value = e.RowIndex + 1;
        }

        private void frmRequestMain_KeyDown(object sender, KeyEventArgs e)
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

                if (asker == null)
                {
                    res.AddError("لطفا متقاضی را انتخاب نمایید");
                    btnSearchOwner.Focus();
                }

                if (txtRahn1.Text == "0" && txtRahn2.Text == "0" && txtEjare1.Text == "0" &&
                    txtEjare2.Text == "0" && txtSellPrice1.Text == "0" && txtSellPrice2.Text == "0")
                {
                    res.AddError("لطفا یکی از فیلدهای مبلغ را وارد نمایید");
                    btnSearchOwner.Focus();
                }

                if (txtMasahat1.Text == "0" && txtMasahat2.Text == "0")
                {
                    res.AddError("لطفا مساحت را وارد نمایید");
                    btnSearchOwner.Focus();
                }

                cls.AskerGuid = asker.Guid;
                cls.UserGuid = (Guid)cmbUser.SelectedValue;

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
                cls.CityGuid = (Guid)cmbCity.SelectedValue;
                cls.BuildingTypeGuid = (Guid)cmbBuildingType.SelectedValue;
                cls.Masahat1 = txtMasahat1.Text.ParseToInt();
                cls.Masahat2 = txtMasahat2.Text.ParseToInt();
                cls.RoomCount = txtRoomCount.Text.ParseToInt();
                cls.BuildingAccountTypeGuid = (Guid)cmbBuildingAccountType.SelectedValue;
                cls.BuildingConditionGuid = (Guid)cmbBuildingCondition.SelectedValue;
                cls.ShortDesc = txtDesc.Text;

                await SetRegionsAsync(cls.Guid);

                res.AddReturnedValue(await cls.SaveAsync());

                if (res.HasError) return;

                if (Settings.Classes.Payamak.IsSendToSayer.ParseToBoolean() && isSendSms)
                    _ = Task.Run(() => Payamak.FixSms.RequestSend.SendAsync(cls));
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
                    var frm = new FrmShowErrorMessage(res, "خطا در ثبت تقاضا");
                    frm.ShowDialog(this);
                    frm.Dispose();
                }
                else
                {
                    UserLog.Save(action, EnLogPart.BuildingRequest);
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
        }
    }
}
