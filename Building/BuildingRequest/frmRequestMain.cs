using System;
using System.Collections.Generic;
using System.Linq;
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

        private void SetData()
        {
            try
            {
                LoadUsers();
                LoadAsker();
                FillCmbPrice();
                SetTxtPrice();
                FillRentalAuthority();
                FillCmbMetr();
                SetTxtMetr();
                FillBuildingType();
                FillBuildingCondition();
                FillBuildingAccountType();
                FillState();

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

                var city = CitiesBussines.Get(cls?.CityGuid ?? Guid.Empty);
                cmbState.SelectedValue = city?.StateGuid ?? Guid.Empty;
                if (cmbState.SelectedValue != null && (Guid)cmbState.SelectedValue != Guid.Empty)
                    cmbState_SelectedIndexChanged(null, null);
                cmbCity.SelectedValue = cls?.CityGuid;
                if (cmbCity.SelectedValue != null && (Guid)cmbCity.SelectedValue != Guid.Empty)
                    cmbCity_SelectedIndexChanged(null, null);

                SetRelatedRegions(cls?.Guid ?? Guid.Empty);

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
        private void LoadUsers()
        {
            try
            {
                var list = UserBussines.GetAll().Where(q => q.Status).OrderBy(q => q.Name).ToList();
                userBindingSource.DataSource = list;
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
        private void FillCmbPrice()
        {
            try
            {
                var values = Enum.GetValues(typeof(EnPrice)).Cast<EnPrice>();
                foreach (var item in values)
                {
                    cmbRahn1.Items.Add(item.GetDisplay());
                    cmbEjare1.Items.Add(item.GetDisplay());
                    cmbRahn2.Items.Add(item.GetDisplay());
                    cmbEjare2.Items.Add(item.GetDisplay());

                    cmbSellPrice1.Items.Add(item.GetDisplay());
                    cmbSellPrice2.Items.Add(item.GetDisplay());
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void SetTxtPrice()
        {
            try
            {
                if (cls?.RahnPrice1 == 0)
                {
                    txtRahn1.Text = cls?.RahnPrice1.ToString();
                    cmbRahn1.SelectedIndex = 0;
                }
                if (cls?.RahnPrice1 != 0)
                {
                    if (cls?.RahnPrice1 >= 10000 && cls?.RahnPrice1 >= 9999)
                    {
                        txtRahn1.Text = (cls?.RahnPrice1 / 10000).ToString();
                        cmbRahn1.SelectedIndex = 0;
                    }
                    if (cls?.RahnPrice1 >= 10000000 && cls?.RahnPrice1 >= 9999999)
                    {
                        txtRahn1.Text = (cls?.RahnPrice1 / 10000000).ToString();
                        cmbRahn1.SelectedIndex = 1;
                    }
                    if (cls?.RahnPrice1 >= 10000000000 && cls?.RahnPrice1 >= 9999999999)
                    {
                        txtRahn1.Text = (cls?.RahnPrice1 / 10000000000).ToString();
                        cmbRahn1.SelectedIndex = 2;
                    }
                }


                if (cls?.RahnPrice2 == 0)
                {
                    txtRahn2.Text = cls?.RahnPrice2.ToString();
                    cmbRahn2.SelectedIndex = 0;
                }
                if (cls?.RahnPrice2 != 0)
                {
                    if (cls?.RahnPrice2 >= 10000 && cls?.RahnPrice2 >= 9999)
                    {
                        txtRahn2.Text = (cls?.RahnPrice2 / 10000).ToString();
                        cmbRahn2.SelectedIndex = 0;
                    }
                    if (cls?.RahnPrice2 >= 10000000 && cls?.RahnPrice2 >= 9999999)
                    {
                        txtRahn2.Text = (cls?.RahnPrice2 / 10000000).ToString();
                        cmbRahn2.SelectedIndex = 1;
                    }
                    if (cls?.RahnPrice2 >= 10000000000 && cls?.RahnPrice2 >= 9999999999)
                    {
                        txtRahn2.Text = (cls?.RahnPrice2 / 10000000000).ToString();
                        cmbRahn2.SelectedIndex = 2;
                    }
                }



                if (cls?.EjarePrice1 == 0)
                {
                    txtEjare1.Text = cls?.EjarePrice1.ToString();
                    cmbEjare1.SelectedIndex = 0;
                }
                if (cls?.EjarePrice1 != 0)
                {
                    if (cls?.EjarePrice1 >= 10000 && cls?.EjarePrice1 >= 9999)
                    {
                        txtEjare1.Text = (cls?.EjarePrice1 / 10000).ToString();
                        cmbEjare1.SelectedIndex = 0;
                    }
                    if (cls?.EjarePrice1 >= 10000000 && cls?.EjarePrice1 >= 9999999)
                    {
                        txtEjare1.Text = (cls?.EjarePrice1 / 10000000).ToString();
                        cmbEjare1.SelectedIndex = 1;
                    }
                    if (cls?.EjarePrice1 >= 10000000000 && cls?.EjarePrice1 >= 9999999999)
                    {
                        txtEjare1.Text = (cls?.EjarePrice1 / 10000000000).ToString();
                        cmbEjare1.SelectedIndex = 2;
                    }
                }


                if (cls?.EjarePrice2 == 0)
                {
                    txtEjare2.Text = cls?.EjarePrice2.ToString();
                    cmbEjare2.SelectedIndex = 0;
                }
                if (cls?.EjarePrice2 != 0)
                {
                    if (cls?.EjarePrice2 >= 10000 && cls?.EjarePrice2 >= 9999)
                    {
                        txtEjare2.Text = (cls?.EjarePrice2 / 10000).ToString();
                        cmbEjare2.SelectedIndex = 0;
                    }
                    if (cls?.EjarePrice2 >= 10000000 && cls?.EjarePrice2 >= 9999999)
                    {
                        txtEjare2.Text = (cls?.EjarePrice2 / 10000000).ToString();
                        cmbEjare2.SelectedIndex = 1;
                    }
                    if (cls?.EjarePrice2 >= 10000000000 && cls?.EjarePrice2 >= 9999999999)
                    {
                        txtEjare2.Text = (cls?.EjarePrice2 / 10000000000).ToString();
                        cmbEjare2.SelectedIndex = 2;
                    }
                }


                if (cls?.SellPrice1 == 0)
                {
                    txtSellPrice1.Text = cls?.SellPrice1.ToString();
                    cmbSellPrice1.SelectedIndex = 0;
                }
                if (cls?.SellPrice1 != 0)
                {
                    if (cls?.SellPrice1 >= 10000 && cls?.SellPrice1 >= 9999)
                    {
                        txtSellPrice1.Text = (cls?.SellPrice1 / 10000).ToString();
                        cmbSellPrice1.SelectedIndex = 0;
                    }
                    if (cls?.SellPrice1 >= 10000000 && cls?.SellPrice1 >= 9999999)
                    {
                        txtSellPrice1.Text = (cls?.SellPrice1 / 10000000).ToString();
                        cmbSellPrice1.SelectedIndex = 1;
                    }
                    if (cls?.SellPrice1 >= 10000000000 && cls?.SellPrice1 >= 9999999999)
                    {
                        txtSellPrice1.Text = (cls?.SellPrice1 / 10000000000).ToString();
                        cmbSellPrice1.SelectedIndex = 2;
                    }
                }


                if (cls?.SellPrice2 == 0)
                {
                    txtSellPrice2.Text = cls?.SellPrice2.ToString();
                    cmbSellPrice2.SelectedIndex = 0;
                }
                if (cls?.SellPrice2 != 0)
                {
                    if (cls?.SellPrice2 >= 10000 && cls?.SellPrice2 >= 9999)
                    {
                        txtSellPrice2.Text = (cls?.SellPrice2 / 10000).ToString();
                        cmbSellPrice2.SelectedIndex = 0;
                    }
                    if (cls?.SellPrice2 >= 10000000 && cls?.SellPrice2 >= 9999999)
                    {
                        txtSellPrice2.Text = (cls?.SellPrice2 / 10000000).ToString();
                        cmbSellPrice2.SelectedIndex = 1;
                    }
                    if (cls?.SellPrice2 >= 10000000000 && cls?.SellPrice2 >= 9999999999)
                    {
                        txtSellPrice2.Text = (cls?.SellPrice2 / 10000000000).ToString();
                        cmbSellPrice2.SelectedIndex = 2;
                    }
                }

            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void FillRentalAuthority()
        {
            try
            {
                var list = RentalAuthorityBussines.GetAll("").Where(q => q.Status).OrderBy(q => q.Name).ToList();
                rentalBindingSource.DataSource = list;
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
        private void FillBuildingType()
        {
            try
            {
                var list = BuildingTypeBussines.GetAll("").Where(q => q.Status).ToList();
                bTypeBindingSource.DataSource = list.OrderBy(q => q.Name);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void FillBuildingCondition()
        {
            try
            {
                var list = BuildingConditionBussines.GetAll("").Where(q => q.Status).ToList();
                bConditionBindingSource.DataSource = list.OrderBy(q => q.Name);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void FillBuildingAccountType()
        {
            try
            {
                var list = BuildingAccountTypeBussines.GetAll("").Where(q => q.Status).ToList();
                batBindingSource.DataSource = list.OrderBy(q => q.Name);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void FillState()
        {
            try
            {
                var list = StatesBussines.GetAll().Where(q => q.Status).ToList();
                StateBindingSource.DataSource = list.OrderBy(q => q.Name);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void SetRegions(Guid requestGuid)
        {
            try
            {
                cls.RegionList = new List<BuildingRequestRegionBussines>();
                if (requestGuid == Guid.Empty) return;
                var list = RegionsBussines.GetAll("", Guid.Empty);
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
        private void SetRelatedRegions(Guid requestGuid)
        {
            try
            {
                if (requestGuid == Guid.Empty) return;
                var op = BuildingRequestRegionBussines.GetAll(requestGuid, true);
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
        }

        private void frmRequestMain_Load(object sender, EventArgs e)
        {
            SetData();
        }

        private void btnSearchOwner_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new frmShowPeoples(true);
                if (frm.ShowDialog() != DialogResult.OK) return;
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
                if (frm.ShowDialog() != DialogResult.OK) return;
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
            try
            {
                if (cls.Guid == Guid.Empty) cls.Guid = Guid.NewGuid();

                if (asker == null)
                {
                    frmNotification.PublicInfo.ShowMessage("لطفا متقاضی را انتخاب نمایید");
                    btnSearchOwner.Focus();
                    return;
                }
                if (txtRahn1.Text == "0" && txtRahn2.Text == "0" && txtEjare1.Text == "0" &&
                    txtEjare2.Text == "0" && txtSellPrice1.Text == "0" && txtSellPrice2.Text == "0")
                {
                    frmNotification.PublicInfo.ShowMessage("لطفا یکی از فیلدهای مبلغ را وارد نمایید");
                    btnSearchOwner.Focus();
                    return;
                }

                if (txtMasahat1.Text == "0" && txtMasahat2.Text == "0")
                {
                    frmNotification.PublicInfo.ShowMessage("لطفا مساحت را وارد نمایید");
                    btnSearchOwner.Focus();
                    return;
                }

                cls.AskerGuid = asker.Guid;
                cls.UserGuid = (Guid) cmbUser.SelectedValue;

                if (cmbSellPrice1.SelectedIndex == 0)
                    cls.SellPrice1 = txtSellPrice1.Text.ParseToDecimal() * 10000;
                if (cmbSellPrice1.SelectedIndex == 1)
                    cls.SellPrice1 = txtSellPrice1.Text.ParseToDecimal() * 10000000;
                if (cmbSellPrice1.SelectedIndex == 2)
                    cls.SellPrice1 = txtSellPrice1.Text.ParseToDecimal() * 10000000000;

                if (cmbSellPrice2.SelectedIndex == 0)
                    cls.SellPrice2 = txtSellPrice2.Text.ParseToDecimal() * 10000;
                if (cmbSellPrice2.SelectedIndex == 1)
                    cls.SellPrice2 = txtSellPrice2.Text.ParseToDecimal() * 10000000;
                if (cmbSellPrice2.SelectedIndex == 2)
                    cls.SellPrice2 = txtSellPrice2.Text.ParseToDecimal() * 10000000000;

                if (cmbRahn1.SelectedIndex == 0)
                    cls.RahnPrice1 = txtRahn1.Text.ParseToDecimal() * 10000;
                if (cmbRahn1.SelectedIndex == 1)
                    cls.RahnPrice1 = txtRahn1.Text.ParseToDecimal() * 10000000;
                if (cmbRahn1.SelectedIndex == 2)
                    cls.RahnPrice1 = txtRahn1.Text.ParseToDecimal() * 10000000000;

                if (cmbRahn2.SelectedIndex == 0)
                    cls.RahnPrice2 = txtRahn2.Text.ParseToDecimal() * 10000;
                if (cmbRahn2.SelectedIndex == 1)
                    cls.RahnPrice2 = txtRahn2.Text.ParseToDecimal() * 10000000;
                if (cmbRahn2.SelectedIndex == 2)
                    cls.RahnPrice2 = txtRahn2.Text.ParseToDecimal() * 10000000000;

                if (cmbEjare1.SelectedIndex == 0)
                    cls.EjarePrice1 = txtEjare1.Text.ParseToDecimal() * 10000;
                if (cmbEjare1.SelectedIndex == 1)
                    cls.EjarePrice1 = txtEjare1.Text.ParseToDecimal() * 10000000;
                if (cmbEjare1.SelectedIndex == 2)
                    cls.EjarePrice1 = txtEjare1.Text.ParseToDecimal() * 10000000000;

                if (cmbEjare2.SelectedIndex == 0)
                    cls.EjarePrice2 = txtEjare2.Text.ParseToDecimal() * 10000;
                if (cmbEjare2.SelectedIndex == 1)
                    cls.EjarePrice2 = txtEjare2.Text.ParseToDecimal() * 10000000;
                if (cmbEjare2.SelectedIndex == 2)
                    cls.EjarePrice2 = txtEjare2.Text.ParseToDecimal() * 10000000000;


                cls.HasVam = chbHasVam.Checked;
                cls.PeopleCount = txtPeopleCount.Text.ParseToShort();
                cls.HasOwner = chbHasOwner.Checked;
                cls.ShortDate = chbShortDate.Checked;
                cls.RentalAutorityGuid = (Guid?) cmbRentalAuthority.SelectedValue ?? Guid.Empty;
                cls.CityGuid = (Guid) cmbCity.SelectedValue;
                cls.BuildingTypeGuid = (Guid) cmbBuildingType.SelectedValue;
                cls.Masahat1 = txtMasahat1.Text.ParseToInt();
                cls.Masahat2 = txtMasahat2.Text.ParseToInt();
                cls.RoomCount = txtRoomCount.Text.ParseToInt();
                cls.BuildingAccountTypeGuid = (Guid) cmbBuildingAccountType.SelectedValue;
                cls.BuildingConditionGuid = (Guid) cmbBuildingCondition.SelectedValue;
                cls.ShortDesc = txtDesc.Text;

                SetRegions(cls.Guid);

                var res = await cls.SaveAsync();
                if (res.HasError)
                {
                    frmNotification.PublicInfo.ShowMessage(res.ErrorMessage);
                    return;
                }
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void cmbSellPrice1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbSellPrice2.SelectedIndex = cmbSellPrice1.SelectedIndex;
        }

        private void cmbRahn1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbRahn2.SelectedIndex = cmbRahn1.SelectedIndex;
        }

        private void cmbEjare1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbEjare2.SelectedIndex = cmbEjare1.SelectedIndex;
        }
    }
}
