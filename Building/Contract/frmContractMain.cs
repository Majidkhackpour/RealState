using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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
        private decimal fPrice = 0, sPrice = 0;
        readonly List<string> lstList = new List<string>();
        private EnLogAction action;
        private void SetData()
        {
            try
            {
                LoadUsers();
                LoadfSide();
                LoadsSide();
                FillCmbPrice();
                SetTxtPrice();
                LoadBuilding();
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

                if (cls?.Finance != null)
                {
                    fPrice = (cls.Finance.FirstTotalPrice + cls.Finance.FirstAddedValue) -
                            cls.Finance.FirstDiscount;

                    sPrice = (cls.Finance.SecondTotalPrice + cls.Finance.SecondAddedValue) -
                             cls.Finance.SecondDiscount;

                    cmbfBabat.SelectedIndex = (int)cls?.Finance?.fBabat;
                    cmbsBabat.SelectedIndex = (int)cls?.Finance?.sBabat;
                }
                else
                {
                    cmbfBabat.SelectedIndex = 0;
                    cmbsBabat.SelectedIndex = 0;
                }


                fPanel.Controls.Clear();
                lstList.Clear();
                if (building?.GalleryList != null && building?.GalleryList.Count != 0)
                {
                    foreach (var image in building.GalleryList)
                    {
                        var a = Path.Combine(Application.StartupPath, "Images");
                        var b = Path.Combine(a, image.ImageName + ".jpg");
                        lstList.Add(b);
                    }

                    Make_Picture_Boxes(lstList);
                }


                if (cls?.Guid == Guid.Empty)
                {
                    NextCode();
                    cmbUser.SelectedValue = clsUser.CurrentUser?.Guid;
                    cmbfBabat.SelectedIndex = 0;
                    cmbsBabat.SelectedIndex = 0;
                    txtTerm.Text = "12";
                    txtfDate.Text = Calendar.MiladiToShamsi(DateTime.Now);
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
                if (cls.TotalPrice == 0 && cls.MinorPrice == 0)
                {
                    if (building?.SellPrice == 0)
                    {
                        //Rahn
                        lblfPrice.Text = building?.RahnPrice1.ToString("N0");
                        lblsPrice.Text = building?.EjarePrice1.ToString("N0");

                        if (building?.EjarePrice1 == 0)
                        {
                            txtEjare.Text = building?.EjarePrice1.ToString();
                            cmbEjare.SelectedIndex = 0;
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


                fPanel.Controls.Clear();
                lstList.Clear();
                if (building?.GalleryList == null || building.GalleryList.Count == 0) return;

                foreach (var image in building.GalleryList)
                {
                    var a = Path.Combine(Application.StartupPath, "Images");
                    var b = Path.Combine(a, image.ImageName + ".jpg");
                    lstList.Add(b);
                }

                Make_Picture_Boxes(lstList);
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

                //cmbfBabat.SelectedIndex = 0;
                //cmbsBabat.SelectedIndex = 0;
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
            superTabControl1.SelectedTab = superTabItem5;
            superTabControl2.SelectedTab = superTabItem8;
            action = EnLogAction.Insert;
        }
        public frmContractMain(Guid guid, bool isShowMode)
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            cls = ContractBussines.Get(guid);
            fSide = PeoplesBussines.Get(cls.FirstSideGuid);
            sSide = PeoplesBussines.Get(cls.SecondSideGuid);
            building = BuildingBussines.Get(cls.BuildingGuid);
            superTabControl1.SelectedTab = superTabItem5;
            superTabControl2.SelectedTab = superTabItem8;
            superTabControlPanel1.Enabled = !isShowMode;
            superTabControlPanel2.Enabled = !isShowMode;
            superTabControlPanel3.Enabled = !isShowMode;
            superTabControlPanel4.Enabled = !isShowMode;
            superTabControlPanel5.Enabled = !isShowMode;
            superTabControlPanel6.Enabled = !isShowMode;
            superTabControlPanel7.Enabled = !isShowMode;
            superTabControlPanel10.Enabled = !isShowMode;
            superTabControlPanel8.Enabled = !isShowMode;
            superTabControlPanel11.Enabled = !isShowMode;
            btnFinish.Enabled = !isShowMode;
            action = EnLogAction.Update;
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
                if (building.BuildingStatus == EnBuildingStatus.Vagozar)
                {
                    frmNotification.PublicInfo.ShowMessage("این ملک در وضعین واگذار شده قرارداد و شما قادر به ثبت قرارداد برای این ملک نمی باشید");
                    btnBuildingSearch.Focus();
                    return;
                }
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
                cls.BuildingGuid = building.Guid;

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
                cls.DischargeDate = string.IsNullOrEmpty(txtDisCharge.Text)
                    ? DateTime.Now.AddYears(1)
                    : Calendar.ShamsiToMiladi(txtDisCharge.Text);
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
                    cls.Finance = new ContractFinanceBussines { Guid = Guid.NewGuid() };

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

                var fSidePrice = (cls.Finance.FirstTotalPrice + cls.Finance.FirstAddedValue) -
                                 cls.Finance.FirstDiscount;
                fSide.Account -= fPrice;
                fSide.Account += fSidePrice;
                await fSide.SaveAsync();

                var sSidePrice = (cls.Finance.SecondTotalPrice + cls.Finance.SecondAddedValue) -
                                cls.Finance.SecondDiscount;
                sSide.Account -= sPrice;
                sSide.Account += sSidePrice;
                await sSide.SaveAsync();

                var perGardesh = await GardeshHesabBussines.GetAllAsync(cls.Guid, true);
                if (perGardesh != null && perGardesh.Count > 0)
                    await GardeshHesabBussines.RemoveRangeAsync(perGardesh.Select(q => q.Guid).ToList());


                var gardeshList = new List<GardeshHesabBussines>
                {
                    new GardeshHesabBussines()
                    {
                        Guid = Guid.NewGuid(),
                        ParentGuid = cls.Guid,
                        Babat = EnAccountBabat.InsContract,
                        PeopleGuid = fSide.Guid,
                        Price = fSidePrice,
                        Type = EnAccountType.Bed,
                        Description =
                            $"عقد قرارداد به شماره {cls.Code} در تاریخ {Calendar.MiladiToShamsi(DateTime.Now)}"
                    },
                    new GardeshHesabBussines()
                    {
                        Guid = Guid.NewGuid(),
                        ParentGuid = cls.Guid,
                        Babat = EnAccountBabat.InsContract,
                        PeopleGuid = sSide.Guid,
                        Price = sSidePrice,
                        Type = EnAccountType.Bed,
                        Description =
                            $"عقد قرارداد به شماره {cls.Code} در تاریخ {Calendar.MiladiToShamsi(DateTime.Now)}"
                    }
                };

                await GardeshHesabBussines.SaveRangeAsync(gardeshList);

                building.BuildingStatus = EnBuildingStatus.Vagozar;

                cls.Type = txtRahn.Value > 0 ? EnRequestType.Rahn : EnRequestType.Forush;

                await building.SaveAsync();

                var res = await cls.SaveAsync();
                if (res.HasError)
                {
                    frmNotification.PublicInfo.ShowMessage(res.ErrorMessage);
                    return;
                }

                User.UserLog.Save(action, EnLogPart.Contracts);

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

        private void txtfTotalPrice_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                SetFirstSallary();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void cmbfTotalPrice_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                SetFirstSallary();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void txtfDiscount_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                SetFirstSallary();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void cmbfDiscount_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                SetFirstSallary();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void txtfAddedValue_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                SetFirstSallary();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void cmbfAddedValue_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                SetFirstSallary();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void txtsTotalPrice_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                SetSecondSallary();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void cmbsTotalPrice_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                SetSecondSallary();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void txtsDiscount_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                SetSecondSallary();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void cmbsDiscount_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                SetSecondSallary();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void txtsAddedValue_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                SetSecondSallary();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void cmbsAddedValue_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                SetSecondSallary();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }


        private void SetFirstSallary()
        {
            try
            {
                decimal fTotal = 0, fDis = 0, fAdd = 0;

                if (cmbfAddedValue.SelectedIndex == 0)
                    fAdd = txtfAddedValue.Value.ToString().ParseToDecimal() * 10000;
                if (cmbfAddedValue.SelectedIndex == 1)
                    fAdd = txtfAddedValue.Value.ToString().ParseToDecimal() * 10000000;
                if (cmbfAddedValue.SelectedIndex == 2)
                    fAdd = txtfAddedValue.Value.ToString().ParseToDecimal() * 10000000000;

                if (cmbfDiscount.SelectedIndex == 0)
                    fDis = txtfDiscount.Value.ToString().ParseToDecimal() * 10000;
                if (cmbfDiscount.SelectedIndex == 1)
                    fDis = txtfDiscount.Value.ToString().ParseToDecimal() * 10000000;
                if (cmbfDiscount.SelectedIndex == 2)
                    fDis = txtfDiscount.Value.ToString().ParseToDecimal() * 10000000000;

                if (cmbfTotalPrice.SelectedIndex == 0)
                    fTotal = txtfTotalPrice.Value.ToString().ParseToDecimal() * 10000;
                if (cmbfTotalPrice.SelectedIndex == 1)
                    fTotal = txtfTotalPrice.Value.ToString().ParseToDecimal() * 10000000;
                if (cmbfTotalPrice.SelectedIndex == 2)
                    fTotal = txtfTotalPrice.Value.ToString().ParseToDecimal() * 10000000000;



                lblfSallary.Text = (fTotal - fDis).ToString("N0") + " ریال";

                lblfTotal.Text = ((fTotal + fAdd) - fDis).ToString("N0") + " ریال";
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void SetSecondSallary()
        {
            try
            {
                decimal sTotal = 0, sDis = 0, sAdd = 0;

                if (cmbsAddedValue.SelectedIndex == 0)
                    sAdd = txtsAddedValue.Value.ToString().ParseToDecimal() * 10000;
                if (cmbsAddedValue.SelectedIndex == 1)
                    sAdd = txtsAddedValue.Value.ToString().ParseToDecimal() * 10000000;
                if (cmbsAddedValue.SelectedIndex == 2)
                    sAdd = txtsAddedValue.Value.ToString().ParseToDecimal() * 10000000000;

                if (cmbsDiscount.SelectedIndex == 0)
                    sDis = txtsDiscount.Value.ToString().ParseToDecimal() * 10000;
                if (cmbsDiscount.SelectedIndex == 1)
                    sDis = txtsDiscount.Value.ToString().ParseToDecimal() * 10000000;
                if (cmbsDiscount.SelectedIndex == 2)
                    sDis = txtsDiscount.Value.ToString().ParseToDecimal() * 10000000000;

                if (cmbsTotalPrice.SelectedIndex == 0)
                    sTotal = txtsTotalPrice.Value.ToString().ParseToDecimal() * 10000;
                if (cmbsTotalPrice.SelectedIndex == 1)
                    sTotal = txtsTotalPrice.Value.ToString().ParseToDecimal() * 10000000;
                if (cmbsTotalPrice.SelectedIndex == 2)
                    sTotal = txtsTotalPrice.Value.ToString().ParseToDecimal() * 10000000000;



                lblsSallary.Text = (sTotal - sDis).ToString("N0") + " ریال";

                lblsTotal.Text = ((sTotal + sAdd) - sDis).ToString("N0") + " ریال";
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void txtfDate_TextChanged(object sender, EventArgs e)
        {
            try
            {
                SetMaxDate();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void txtTerm_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                SetMaxDate();
                SetFullPrice();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void SetMaxDate()
        {
            try
            {
                var date = Calendar.ShamsiToMiladi(txtfDate.Text);
                lblsDate.Text = Calendar.MiladiToShamsi(date.AddMonths((int)txtTerm.Value));
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void txtEjare_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                SetFullPrice();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void cmbEjare_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                SetFullPrice();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void SetFullPrice()
        {
            try
            {
                decimal price = 0;

                if (cmbEjare.SelectedIndex == 0)
                    price = txtEjare.Text.ParseToDecimal() * 10000;
                if (cmbEjare.SelectedIndex == 1)
                    price = txtEjare.Text.ParseToDecimal() * 10000000;
                if (cmbEjare.SelectedIndex == 2)
                    price = txtEjare.Text.ParseToDecimal() * 10000000000;

                lblEjareFull.Text = (price * txtTerm.Value).ToString("N0") + " ریال";
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void Make_Picture_Boxes(List<string> lst)
        {
            try
            {
                if (lst == null || lst.Count == 0)
                    return;
                fPanel.AutoScroll = true;
                for (var i = fPanel.Controls.Count - 1; i >= 0; i--)
                    fPanel.Controls[i].Dispose();
                for (var i = 0; i < lst.Count; i++)
                {
                    try
                    {
                        var picbox = new PictureBox();
                        Controls.Add(picbox);
                        picbox.Size = new Size(62, 63);
                        picbox.Load(lst[i]);
                        picbox.Name = "pic" + i;
                        picbox.Cursor = Cursors.Hand;
                        picbox.SizeMode = PictureBoxSizeMode.StretchImage;
                        fPanel.Controls.Add(picbox);
                    }
                    catch (Exception)
                    {
                        lst.RemoveAt(i);
                    }
                }
            }
            catch (Exception exception)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(exception);
            }
        }
    }
}
