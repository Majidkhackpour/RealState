using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Building.Building;
using EntityCache.Bussines;
using MetroFramework.Forms;
using Notification;
using Peoples;
using Services;
using User;

namespace Building.Contract
{
    public partial class frmContractMain : MetroForm
    {
        private ContractBussines cls;
        private PeoplesBussines fSide;
        private PeoplesBussines sSide;
        private BuildingBussines building;
        private void SetData()
        {
            try
            {
                LoadUsers();
                LoadfSide();
                LoadsSide();
                LoadBuilding();
                FillCmbPrice();
                SetTxtPrice();
                FillCmbBabat();

                txtCode.Text = cls?.Code.ToString();
                lblDateNow.Text = cls?.DateSh;
                cmbUser.SelectedValue = cls?.UserGuid;

                txtTerm.Text = (cls?.Term ?? 0).ToString();
                txtfDate.Text = Calendar.MiladiToShamsi(cls?.FromDate);

                txtDisCharge.Text = Calendar.MiladiToShamsi(cls?.DischargeDate);
                txtCheckNo.Text = cls?.CheckNo;
                txtSarResid.Text = cls?.SarResid;
                txtBankName.Text = cls?.BankName;
                txtShobe.Text = cls?.Shobe;

                txtSetDocDate.Text = Calendar.MiladiToShamsi(cls?.SetDocDate);
                txtSetDocAddress.Text = cls?.SetDocPlace;

                txtDesc.Text = cls?.Description;


                if (cls?.Guid == Guid.Empty)
                {
                    NextCode();
                    cmbUser.SelectedValue = clsUser.CurrentUser?.Guid;
                    cmbfBabat.SelectedIndex = 0;
                    cmbsBabat.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void NextCode()
        {
            try
            {
                txtCode.Text = ContractBussines.NextCode() ?? "";
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
        private void LoadfSide()
        {
            try
            {
                txtfCode.Text = fSide?.Code;
                lblfAddress.Text = fSide?.Address;
                lblfDateBirth.Text = fSide?.DateBirth;
                lblfFatherName.Text = fSide?.FatherName;
                lblfNationalCode.Text = fSide?.NationalCode;
                lblfName.Text = fSide?.Name;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void LoadsSide()
        {
            try
            {
                txtsCode.Text = sSide?.Code;
                lblsAddress.Text = sSide?.Address;
                lblsDateBirth.Text = sSide?.DateBirth;
                lblsFatherName.Text = sSide?.FatherName;
                lblsNationalCode.Text = sSide?.NationalCode;
                lblsName.Text = sSide?.Name;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void LoadBuilding()
        {
            try
            {
                lblMasahat.Text = building?.Masahat.ToString();
                lblZirBana.Text = building?.ZirBana.ToString();
                lblBuildingAddress.Text = building?.Address;
                if (building?.SellPrice == 0)
                {
                    //Rahn
                    lblfPrice.Text = building?.RahnPrice1.ToString("N0");
                    lblsPrice.Text = building?.EjarePrice1.ToString("N0");

                    if (building?.EjarePrice1 == 0)
                    {
                        txtEjare.Text = building?.EjarePrice1.ToString();
                        cmbRahn1.SelectedIndex = 0;
                    }
                    if (building?.EjarePrice1 != 0)
                    {
                        if (building?.EjarePrice1 >= 10000 && building?.EjarePrice1 >= 9999)
                        {
                            txtEjare.Text = (building?.EjarePrice1 / 10000).ToString();
                            cmbEjare.SelectedIndex = 0;
                        }
                        if (building?.EjarePrice1 >= 10000000 && building?.EjarePrice1 >= 9999999)
                        {
                            txtEjare.Text = (building?.EjarePrice1 / 10000000).ToString();
                            cmbEjare.SelectedIndex = 1;
                        }
                        if (building?.EjarePrice1 >= 10000000000 && building?.EjarePrice1 >= 9999999999)
                        {
                            txtEjare.Text = (building?.EjarePrice1 / 10000000000).ToString();
                            cmbEjare.SelectedIndex = 2;
                        }
                    }


                    if (building?.RahnPrice1 == 0)
                    {
                        txtRahn.Text = building?.RahnPrice1.ToString();
                        cmbRahn.SelectedIndex = 0;
                    }
                    if (building?.RahnPrice1 != 0)
                    {
                        if (building?.RahnPrice1 >= 10000 && building?.RahnPrice1 >= 9999)
                        {
                            txtRahn.Text = (building?.RahnPrice1 / 10000).ToString();
                            cmbRahn.SelectedIndex = 0;
                        }
                        if (building?.RahnPrice1 >= 10000000 && building?.RahnPrice1 >= 9999999)
                        {
                            txtRahn.Text = (building?.RahnPrice1 / 10000000).ToString();
                            cmbRahn.SelectedIndex = 1;
                        }
                        if (building?.RahnPrice1 >= 10000000000 && building?.RahnPrice1 >= 9999999999)
                        {
                            txtRahn.Text = (building?.RahnPrice1 / 10000000000).ToString();
                            cmbRahn.SelectedIndex = 2;
                        }
                    }
                }
                else
                {
                    //Foroush
                    lblfPrice.Text = building?.SellPrice.ToString("N0");
                    lblsPrice.Text = "0";

                    if (building?.SellPrice == 0)
                    {
                        txtSellPrice.Text = building?.SellPrice.ToString();
                        cmbSellPrice.SelectedIndex = 0;
                    }
                    if (building?.SellPrice != 0)
                    {
                        if (building?.SellPrice >= 10000 && building?.SellPrice >= 9999)
                        {
                            txtSellPrice.Text = (building?.SellPrice / 10000).ToString();
                            cmbSellPrice.SelectedIndex = 0;
                        }
                        if (building?.SellPrice >= 10000000 && building?.SellPrice >= 9999999)
                        {
                            txtSellPrice.Text = (building?.SellPrice / 10000000).ToString();
                            cmbSellPrice.SelectedIndex = 1;
                        }
                        if (building?.SellPrice >= 10000000000 && building?.SellPrice >= 9999999999)
                        {
                            txtSellPrice.Text = (building?.SellPrice / 10000000000).ToString();
                            cmbSellPrice.SelectedIndex = 2;
                        }
                    }
                }
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
                    cmbRahn.Items.Add(item.GetDisplay());
                    cmbEjare.Items.Add(item.GetDisplay());
                    cmbSarQofli.Items.Add(item.GetDisplay());
                    cmbDelay.Items.Add(item.GetDisplay());

                    cmbSellPrice.Items.Add(item.GetDisplay());
                    cmbBeyane.Items.Add(item.GetDisplay());

                    cmbfTotalPrice.Items.Add(item.GetDisplay());
                    cmbfDiscount.Items.Add(item.GetDisplay());
                    cmbfAddedValue.Items.Add(item.GetDisplay());

                    cmbsTotalPrice.Items.Add(item.GetDisplay());
                    cmbsAddedValue.Items.Add(item.GetDisplay());
                    cmbsDiscount.Items.Add(item.GetDisplay());
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
                if (cls?.MinorPrice == 0)
                {
                    txtEjare.Text = cls?.MinorPrice.ToString();
                    cmbEjare.SelectedIndex = 0;
                }
                if (cls?.MinorPrice != 0)
                {
                    if (cls?.MinorPrice >= 10000 && cls?.MinorPrice >= 9999)
                    {
                        txtEjare.Text = (cls?.MinorPrice / 10000).ToString();
                        cmbEjare.SelectedIndex = 0;
                    }
                    if (cls?.MinorPrice >= 10000000 && cls?.MinorPrice >= 9999999)
                    {
                        txtEjare.Text = (cls?.MinorPrice / 10000000).ToString();
                        cmbEjare.SelectedIndex = 1;
                    }
                    if (cls?.MinorPrice >= 10000000000 && cls?.MinorPrice >= 9999999999)
                    {
                        txtEjare.Text = (cls?.MinorPrice / 10000000000).ToString();
                        cmbEjare.SelectedIndex = 2;
                    }
                }


                if (cls?.TotalPrice == 0)
                {
                    txtRahn.Text = cls?.TotalPrice.ToString();
                    cmbRahn.SelectedIndex = 0;
                }
                if (cls?.TotalPrice != 0)
                {
                    if (cls?.TotalPrice >= 10000 && cls?.TotalPrice >= 9999)
                    {
                        txtRahn.Text = (cls?.TotalPrice / 10000).ToString();
                        cmbRahn.SelectedIndex = 0;
                    }
                    if (cls?.TotalPrice >= 10000000 && cls?.TotalPrice >= 9999999)
                    {
                        txtRahn.Text = (cls?.TotalPrice / 10000000).ToString();
                        cmbRahn.SelectedIndex = 1;
                    }
                    if (cls?.TotalPrice >= 10000000000 && cls?.TotalPrice >= 9999999999)
                    {
                        txtRahn.Text = (cls?.TotalPrice / 10000000000).ToString();
                        cmbRahn.SelectedIndex = 2;
                    }
                }



                if (cls?.SarQofli == 0)
                {
                    txtSarQofli.Text = cls?.SarQofli.ToString();
                    cmbSarQofli.SelectedIndex = 0;
                }
                if (cls?.SarQofli != 0)
                {
                    if (cls?.SarQofli >= 10000 && cls?.SarQofli >= 9999)
                    {
                        txtSarQofli.Text = (cls?.SarQofli / 10000).ToString();
                        cmbSarQofli.SelectedIndex = 0;
                    }
                    if (cls?.SarQofli >= 10000000 && cls?.SarQofli >= 9999999)
                    {
                        txtSarQofli.Text = (cls?.SarQofli / 10000000).ToString();
                        cmbSarQofli.SelectedIndex = 1;
                    }
                    if (cls?.SarQofli >= 10000000000 && cls?.SarQofli >= 9999999999)
                    {
                        txtSarQofli.Text = (cls?.SarQofli / 10000000000).ToString();
                        cmbSarQofli.SelectedIndex = 2;
                    }
                }


                if (cls?.Delay == 0)
                {
                    txtDelay.Text = cls?.Delay.ToString();
                    cmbDelay.SelectedIndex = 0;
                }
                if (cls?.Delay != 0)
                {
                    if (cls?.Delay >= 10000 && cls?.Delay >= 9999)
                    {
                        txtDelay.Text = (cls?.Delay / 10000).ToString();
                        cmbDelay.SelectedIndex = 0;
                    }
                    if (cls?.Delay >= 10000000 && cls?.Delay >= 9999999)
                    {
                        txtDelay.Text = (cls?.Delay / 10000000).ToString();
                        cmbDelay.SelectedIndex = 1;
                    }
                    if (cls?.Delay >= 10000000000 && cls?.Delay >= 9999999999)
                    {
                        txtDelay.Text = (cls?.Delay / 10000000000).ToString();
                        cmbDelay.SelectedIndex = 2;
                    }
                }


                if (cls?.TotalPrice == 0)
                {
                    txtSellPrice.Text = cls?.TotalPrice.ToString();
                    cmbSellPrice.SelectedIndex = 0;
                }
                if (cls?.TotalPrice != 0)
                {
                    if (cls?.TotalPrice >= 10000 && cls?.TotalPrice >= 9999)
                    {
                        txtSellPrice.Text = (cls?.TotalPrice / 10000).ToString();
                        cmbSellPrice.SelectedIndex = 0;
                    }
                    if (cls?.TotalPrice >= 10000000 && cls?.TotalPrice >= 9999999)
                    {
                        txtSellPrice.Text = (cls?.TotalPrice / 10000000).ToString();
                        cmbSellPrice.SelectedIndex = 1;
                    }
                    if (cls?.TotalPrice >= 10000000000 && cls?.TotalPrice >= 9999999999)
                    {
                        txtSellPrice.Text = (cls?.TotalPrice / 10000000000).ToString();
                        cmbSellPrice.SelectedIndex = 2;
                    }
                }



                if (cls?.MinorPrice == 0)
                {
                    txtBeyane.Text = cls?.MinorPrice.ToString();
                    cmbBeyane.SelectedIndex = 0;
                }
                if (cls?.MinorPrice != 0)
                {
                    if (cls?.MinorPrice >= 10000 && cls?.MinorPrice >= 9999)
                    {
                        txtBeyane.Text = (cls?.MinorPrice / 10000).ToString();
                        cmbBeyane.SelectedIndex = 0;
                    }
                    if (cls?.MinorPrice >= 10000000 && cls?.MinorPrice >= 9999999)
                    {
                        txtBeyane.Text = (cls?.MinorPrice / 10000000).ToString();
                        cmbBeyane.SelectedIndex = 1;
                    }
                    if (cls?.MinorPrice >= 10000000000 && cls?.MinorPrice >= 9999999999)
                    {
                        txtBeyane.Text = (cls?.MinorPrice / 10000000000).ToString();
                        cmbBeyane.SelectedIndex = 2;
                    }
                }


                if (cls?.Finance == null)
                {
                    txtfTotalPrice.Text = "0";
                    cmbfTotalPrice.SelectedIndex = 0;

                    txtfDiscount.Text = "0";
                    cmbfDiscount.SelectedIndex = 0;

                    txtfAddedValue.Text = "0";
                    cmbfAddedValue.SelectedIndex = 0;

                    txtsTotalPrice.Text = "0";
                    cmbsTotalPrice.SelectedIndex = 0;

                    txtsDiscount.Text = "0";
                    cmbsDiscount.SelectedIndex = 0;

                    txtsAddedValue.Text = "0";
                    cmbsAddedValue.SelectedIndex = 0;
                }
                else
                {

                    if (cls?.Finance?.FirstTotalPrice == 0)
                    {
                        txtfTotalPrice.Text = cls?.Finance?.FirstTotalPrice.ToString();
                        cmbfTotalPrice.SelectedIndex = 0;
                    }

                    if (cls?.Finance?.FirstTotalPrice != 0)
                    {
                        if (cls?.Finance?.FirstTotalPrice >= 10000 && cls?.Finance?.FirstTotalPrice >= 9999)
                        {
                            txtfTotalPrice.Text = (cls?.Finance?.FirstTotalPrice / 10000).ToString();
                            cmbfTotalPrice.SelectedIndex = 0;
                        }

                        if (cls?.Finance?.FirstTotalPrice >= 10000000 && cls?.Finance?.FirstTotalPrice >= 9999999)
                        {
                            txtfTotalPrice.Text = (cls?.Finance?.FirstTotalPrice / 10000000).ToString();
                            cmbfTotalPrice.SelectedIndex = 1;
                        }

                        if (cls?.Finance?.FirstTotalPrice >= 10000000000 && cls?.Finance?.FirstTotalPrice >= 9999999999)
                        {
                            txtfTotalPrice.Text = (cls?.Finance?.FirstTotalPrice / 10000000000).ToString();
                            cmbfTotalPrice.SelectedIndex = 2;
                        }
                    }




                    if (cls?.Finance?.FirstDiscount == 0)
                    {
                        txtfDiscount.Text = cls?.Finance?.FirstDiscount.ToString();
                        cmbfDiscount.SelectedIndex = 0;
                    }

                    if (cls?.Finance?.FirstDiscount != 0)
                    {
                        if (cls?.Finance?.FirstDiscount >= 10000 && cls?.Finance?.FirstDiscount >= 9999)
                        {
                            txtfDiscount.Text = (cls?.Finance?.FirstDiscount / 10000).ToString();
                            cmbfDiscount.SelectedIndex = 0;
                        }

                        if (cls?.Finance?.FirstDiscount >= 10000000 && cls?.Finance?.FirstDiscount >= 9999999)
                        {
                            txtfDiscount.Text = (cls?.Finance?.FirstDiscount / 10000000).ToString();
                            cmbfDiscount.SelectedIndex = 1;
                        }

                        if (cls?.Finance?.FirstDiscount >= 10000000000 && cls?.Finance?.FirstDiscount >= 9999999999)
                        {
                            txtfDiscount.Text = (cls?.Finance?.FirstDiscount / 10000000000).ToString();
                            cmbfDiscount.SelectedIndex = 2;
                        }
                    }




                    if (cls?.Finance?.FirstAddedValue == 0)
                    {
                        txtfAddedValue.Text = cls?.Finance?.FirstAddedValue.ToString();
                        cmbfAddedValue.SelectedIndex = 0;
                    }

                    if (cls?.Finance?.FirstAddedValue != 0)
                    {
                        if (cls?.Finance?.FirstAddedValue >= 10000 && cls?.Finance?.FirstAddedValue >= 9999)
                        {
                            txtfAddedValue.Text = (cls?.Finance?.FirstAddedValue / 10000).ToString();
                            cmbfAddedValue.SelectedIndex = 0;
                        }

                        if (cls?.Finance?.FirstAddedValue >= 10000000 && cls?.Finance?.FirstAddedValue >= 9999999)
                        {
                            txtfAddedValue.Text = (cls?.Finance?.FirstAddedValue / 10000000).ToString();
                            cmbfAddedValue.SelectedIndex = 1;
                        }

                        if (cls?.Finance?.FirstAddedValue >= 10000000000 && cls?.Finance?.FirstAddedValue >= 9999999999)
                        {
                            txtfAddedValue.Text = (cls?.Finance?.FirstAddedValue / 10000000000).ToString();
                            cmbfAddedValue.SelectedIndex = 2;
                        }
                    }



                    if (cls?.Finance?.SecondTotalPrice == 0)
                    {
                        txtsTotalPrice.Text = cls?.Finance?.SecondTotalPrice.ToString();
                        cmbsTotalPrice.SelectedIndex = 0;
                    }

                    if (cls?.Finance?.SecondTotalPrice != 0)
                    {
                        if (cls?.Finance?.SecondTotalPrice >= 10000 && cls?.Finance?.SecondTotalPrice >= 9999)
                        {
                            txtsTotalPrice.Text = (cls?.Finance?.SecondTotalPrice / 10000).ToString();
                            cmbsTotalPrice.SelectedIndex = 0;
                        }

                        if (cls?.Finance?.SecondTotalPrice >= 10000000 && cls?.Finance?.SecondTotalPrice >= 9999999)
                        {
                            txtsTotalPrice.Text = (cls?.Finance?.SecondTotalPrice / 10000000).ToString();
                            cmbsTotalPrice.SelectedIndex = 1;
                        }

                        if (cls?.Finance?.SecondTotalPrice >= 10000000000 &&
                            cls?.Finance?.SecondTotalPrice >= 9999999999)
                        {
                            txtsTotalPrice.Text = (cls?.Finance?.SecondTotalPrice / 10000000000).ToString();
                            cmbsTotalPrice.SelectedIndex = 2;
                        }
                    }




                    if (cls?.Finance?.SecondDiscount == 0)
                    {
                        txtsDiscount.Text = cls?.Finance?.SecondDiscount.ToString();
                        cmbsDiscount.SelectedIndex = 0;
                    }

                    if (cls?.Finance?.SecondDiscount != 0)
                    {
                        if (cls?.Finance?.SecondDiscount >= 10000 && cls?.Finance?.SecondDiscount >= 9999)
                        {
                            txtsDiscount.Text = (cls?.Finance?.SecondDiscount / 10000).ToString();
                            cmbsDiscount.SelectedIndex = 0;
                        }

                        if (cls?.Finance?.SecondDiscount >= 10000000 && cls?.Finance?.SecondDiscount >= 9999999)
                        {
                            txtsDiscount.Text = (cls?.Finance?.SecondDiscount / 10000000).ToString();
                            cmbsDiscount.SelectedIndex = 1;
                        }

                        if (cls?.Finance?.SecondDiscount >= 10000000000 && cls?.Finance?.SecondDiscount >= 9999999999)
                        {
                            txtsDiscount.Text = (cls?.Finance?.SecondDiscount / 10000000000).ToString();
                            cmbsDiscount.SelectedIndex = 2;
                        }
                    }




                    if (cls?.Finance?.SecondAddedValue == 0)
                    {
                        txtsAddedValue.Text = cls?.Finance?.SecondAddedValue.ToString();
                        cmbsAddedValue.SelectedIndex = 0;
                    }

                    if (cls?.Finance?.SecondAddedValue != 0)
                    {
                        if (cls?.Finance?.SecondAddedValue >= 10000 && cls?.Finance?.SecondAddedValue >= 9999)
                        {
                            txtsAddedValue.Text = (cls?.Finance?.SecondAddedValue / 10000).ToString();
                            cmbsAddedValue.SelectedIndex = 0;
                        }

                        if (cls?.Finance?.SecondAddedValue >= 10000000 && cls?.Finance?.SecondAddedValue >= 9999999)
                        {
                            txtsAddedValue.Text = (cls?.Finance?.SecondAddedValue / 10000000).ToString();
                            cmbsAddedValue.SelectedIndex = 1;
                        }

                        if (cls?.Finance?.SecondAddedValue >= 10000000000 &&
                            cls?.Finance?.SecondAddedValue >= 9999999999)
                        {
                            txtsAddedValue.Text = (cls?.Finance?.SecondAddedValue / 10000000000).ToString();
                            cmbsAddedValue.SelectedIndex = 2;
                        }
                    }

                }

            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void FillCmbBabat()
        {
            try
            {
                var values = Enum.GetValues(typeof(EnContractBabat)).Cast<EnContractBabat>();
                foreach (var item in values)
                {
                    cmbfBabat.Items.Add(item.GetDisplay());
                    cmbsBabat.Items.Add(item.GetDisplay());
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        public frmContractMain()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            cls = new ContractBussines();
        }

        private void frmContractMain_Load(object sender, EventArgs e)
        {
            SetData();
        }

        private void btnfSearch_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new frmShowPeoples(true);
                if (frm.ShowDialog() != DialogResult.OK) return;
                fSide = PeoplesBussines.Get(frm.SelectedGuid);
                LoadfSide();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void btnsSearch_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new frmShowPeoples(true);
                if (frm.ShowDialog() != DialogResult.OK) return;
                sSide = PeoplesBussines.Get(frm.SelectedGuid);
                LoadsSide();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void btnBuildingSearch_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new frmShowBuildings(true);
                if (frm.ShowDialog() != DialogResult.OK) return;
                building = BuildingBussines.Get(frm.SelectedGuid);
                LoadBuilding();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void frmContractMain_KeyDown(object sender, KeyEventArgs e)
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

        private async void btnSaveTemp_Click(object sender, EventArgs e)
        {
            try
            {
                cls.IsTemp = true;
                await Save();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private async void btnSaveNoTemp_Click(object sender, EventArgs e)
        {
            try
            {
                cls.IsTemp = false;
                await Save();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private async Task Save()
        {
            try
            {
                if (cls.Guid == Guid.Empty) cls.Guid = Guid.NewGuid();

                if (string.IsNullOrWhiteSpace(txtCode.Text))
                {
                    frmNotification.PublicInfo.ShowMessage("کد قرارداد نمی تواند خالی باشد");
                    txtCode.Focus();
                    return;
                }
                if (!await ContractBussines.CheckCodeAsync(txtCode.Text.Trim(), cls.Guid))
                {
                    frmNotification.PublicInfo.ShowMessage("کد ملک وارد شده تکراری است");
                    txtCode.Focus();
                    return;
                }

                if (fSide == null)
                {
                    frmNotification.PublicInfo.ShowMessage("لطفا طرف اول قرارداد را انتخاب نمایید");
                    btnfSearch.Focus();
                    return;
                }
                if (sSide == null)
                {
                    frmNotification.PublicInfo.ShowMessage("لطفا طرف دوم قرارداد را انتخاب نمایید");
                    btnsSearch.Focus();
                    return;
                }
                if (building == null)
                {
                    frmNotification.PublicInfo.ShowMessage("لطفا ملک موضوع قرارداد را انتخاب نمایید");
                    btnBuildingSearch.Focus();
                    return;
                }
                if (txtRahn.Text == "0" && txtEjare.Text == "0" && txtSellPrice.Text == "0" &&
                    txtBeyane.Text == "0")
                {
                    frmNotification.PublicInfo.ShowMessage("لطفا یکی از فیلدهای مبلغ را وارد نمایید");
                    btnSearchOwner.Focus();
                    return;
                }

                cls.Code = txtCode.Text.ParseToLong();
                cls.UserGuid = (Guid)cmbUser.SelectedValue;
                cls.FirstSideGuid = fSide.Guid;
                cls.SecondSideGuid = sSide.Guid;

                cls.Term = txtTerm.Text.ParseToInt();
                cls.FromDate = Calendar.ShamsiToMiladi(txtfDate.Text);
                if (txtSellPrice.Text != "0")
                {
                    if (cmbSellPrice.SelectedIndex == 0)
                        cls.TotalPrice = txtSellPrice.Text.ParseToDecimal() * 10000;
                    if (cmbSellPrice.SelectedIndex == 1)
                        cls.TotalPrice = txtSellPrice.Text.ParseToDecimal() * 10000000;
                    if (cmbSellPrice.SelectedIndex == 2)
                        cls.TotalPrice = txtSellPrice.Text.ParseToDecimal() * 10000000000;
                }
                if (txtRahn.Text != "0")
                {
                    if (cmbRahn.SelectedIndex == 0)
                        cls.TotalPrice = txtRahn.Text.ParseToDecimal() * 10000;
                    if (cmbRahn.SelectedIndex == 1)
                        cls.TotalPrice = txtRahn.Text.ParseToDecimal() * 10000000;
                    if (cmbRahn.SelectedIndex == 2)
                        cls.TotalPrice = txtRahn.Text.ParseToDecimal() * 10000000000;
                }
                if (txtBeyane.Text != "0")
                {
                    if (cmbBeyane.SelectedIndex == 0)
                        cls.MinorPrice = txtBeyane.Text.ParseToDecimal() * 10000;
                    if (cmbBeyane.SelectedIndex == 1)
                        cls.MinorPrice = txtBeyane.Text.ParseToDecimal() * 10000000;
                    if (cmbBeyane.SelectedIndex == 2)
                        cls.MinorPrice = txtBeyane.Text.ParseToDecimal() * 10000000000;
                }
                if (txtEjare.Text != "0")
                {
                    if (cmbEjare.SelectedIndex == 0)
                        cls.MinorPrice = txtEjare.Text.ParseToDecimal() * 10000;
                    if (cmbEjare.SelectedIndex == 1)
                        cls.MinorPrice = txtEjare.Text.ParseToDecimal() * 10000000;
                    if (cmbEjare.SelectedIndex == 2)
                        cls.MinorPrice = txtEjare.Text.ParseToDecimal() * 10000000000;
                }

                cls.CheckNo = txtCheckNo.Text;
                cls.BankName = txtBankName.Text;
                cls.SarResid = txtSarResid.Text;
                cls.Shobe = txtShobe.Text;
                cls.DischargeDate = Calendar.ShamsiToMiladi(txtDisCharge.Text);
                cls.SetDocPlace = txtSetDocAddress.Text;
                cls.SetDocDate = Calendar.ShamsiToMiladi(txtSetDocDate.Text);

                if (cmbSarQofli.SelectedIndex == 0)
                    cls.SarQofli = txtSarQofli.Text.ParseToDecimal() * 10000;
                if (cmbSarQofli.SelectedIndex == 1)
                    cls.SarQofli = txtSarQofli.Text.ParseToDecimal() * 10000000;
                if (cmbSarQofli.SelectedIndex == 2)
                    cls.SarQofli = txtSarQofli.Text.ParseToDecimal() * 10000000000;

                cls.Description = txtDesc.Text;

                if (cmbDelay.SelectedIndex == 0)
                    cls.Delay = txtDelay.Text.ParseToDecimal() * 10000;
                if (cmbDelay.SelectedIndex == 1)
                    cls.Delay = txtDelay.Text.ParseToDecimal() * 10000000;
                if (cmbDelay.SelectedIndex == 2)
                    cls.Delay = txtDelay.Text.ParseToDecimal() * 10000000000;

                if (cls.Finance == null)
                    cls.Finance = new ContractFinanceBussines {Guid = Guid.NewGuid()};

                if (cmbfAddedValue.SelectedIndex == 0)
                    cls.Finance.FirstAddedValue = txtfAddedValue.Text.ParseToDecimal() * 10000;
                if (cmbfAddedValue.SelectedIndex == 1)
                    cls.Finance.FirstAddedValue = txtfAddedValue.Text.ParseToDecimal() * 10000000;
                if (cmbfAddedValue.SelectedIndex == 2)
                    cls.Finance.FirstAddedValue = txtfAddedValue.Text.ParseToDecimal() * 10000000000;

                if (cmbfDiscount.SelectedIndex == 0)
                    cls.Finance.FirstDiscount = txtfDiscount.Text.ParseToDecimal() * 10000;
                if (cmbfDiscount.SelectedIndex == 1)
                    cls.Finance.FirstDiscount = txtfDiscount.Text.ParseToDecimal() * 10000000;
                if (cmbfDiscount.SelectedIndex == 2)
                    cls.Finance.FirstDiscount = txtfDiscount.Text.ParseToDecimal() * 10000000000;

                if (cmbfTotalPrice.SelectedIndex == 0)
                    cls.Finance.FirstTotalPrice = txtfTotalPrice.Text.ParseToDecimal() * 10000;
                if (cmbfTotalPrice.SelectedIndex == 1)
                    cls.Finance.FirstTotalPrice = txtfTotalPrice.Text.ParseToDecimal() * 10000000;
                if (cmbfTotalPrice.SelectedIndex == 2)
                    cls.Finance.FirstTotalPrice = txtfTotalPrice.Text.ParseToDecimal() * 10000000000;

                if (cmbsAddedValue.SelectedIndex == 0)
                    cls.Finance.SecondAddedValue = txtsAddedValue.Text.ParseToDecimal() * 10000;
                if (cmbsAddedValue.SelectedIndex == 1)
                    cls.Finance.SecondAddedValue = txtsAddedValue.Text.ParseToDecimal() * 10000000;
                if (cmbsAddedValue.SelectedIndex == 2)
                    cls.Finance.SecondAddedValue = txtsAddedValue.Text.ParseToDecimal() * 10000000000;

                if (cmbsDiscount.SelectedIndex == 0)
                    cls.Finance.SecondDiscount = txtsDiscount.Text.ParseToDecimal() * 10000;
                if (cmbsDiscount.SelectedIndex == 1)
                    cls.Finance.SecondDiscount = txtsDiscount.Text.ParseToDecimal() * 10000000;
                if (cmbsDiscount.SelectedIndex == 2)
                    cls.Finance.SecondDiscount = txtsDiscount.Text.ParseToDecimal() * 10000000000;

                if (cmbsTotalPrice.SelectedIndex == 0)
                    cls.Finance.SecondTotalPrice = txtsTotalPrice.Text.ParseToDecimal() * 10000;
                if (cmbsTotalPrice.SelectedIndex == 1)
                    cls.Finance.SecondTotalPrice = txtsTotalPrice.Text.ParseToDecimal() * 10000000;
                if (cmbsTotalPrice.SelectedIndex == 2)
                    cls.Finance.SecondTotalPrice = txtsTotalPrice.Text.ParseToDecimal() * 10000000000;

                cls.Finance.fBabat = (EnContractBabat)cmbfBabat.SelectedIndex;
                cls.Finance.sBabat = (EnContractBabat)cmbsBabat.SelectedIndex;
                cls.Finance.ConGuid = cls.Guid;


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

        private void txtCode_Enter(object sender, EventArgs e)
        {
            txtSetter.Focus(txtCode);
        }

        private void txtCode_Leave(object sender, EventArgs e)
        {
            txtSetter.Follow(txtCode);
        }

        private void txtCheckNo_Enter(object sender, EventArgs e)
        {
            txtSetter.Focus(txtCheckNo);
        }

        private void txtCheckNo_Leave(object sender, EventArgs e)
        {
            txtSetter.Follow(txtCheckNo);
        }

        private void txtBankName_Enter(object sender, EventArgs e)
        {
            txtSetter.Focus(txtBankName);
        }

        private void txtBankName_Leave(object sender, EventArgs e)
        {
            txtSetter.Follow(txtBankName);
        }

        private void txtShobe_Enter(object sender, EventArgs e)
        {
            txtSetter.Focus(txtShobe);
        }

        private void txtShobe_Leave(object sender, EventArgs e)
        {
            txtSetter.Follow(txtShobe);
        }
    }
}
