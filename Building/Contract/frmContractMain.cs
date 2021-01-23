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
        readonly List<string> lstList = new List<string>();
        private EnLogAction action;
        private async Task SetDataAsync()
        {
            try
            {
                await LoadUsersAsync();
                await LoadBazaryabAsync();
                LoadfSide();
                LoadsSide();
                SetTxtPrice();
                LoadBuilding();
                FillCmbBabat();

                txtCode.Text = cls?.Code.ToString();
                lblDateNow.Text = cls?.DateSh;
                cmbUser.SelectedValue = cls?.UserGuid;

                txtTerm.Value = (decimal)(cls?.Term ?? 0);
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
                    cls.FPrice = (cls.Finance.FirstTotalPrice + cls.Finance.FirstAddedValue) -
                            cls.Finance.FirstDiscount;

                    cls.SPrice = (cls.Finance.SecondTotalPrice + cls.Finance.SecondAddedValue) -
                             cls.Finance.SecondDiscount;

                    cmbfBabat.SelectedIndex = (int)cls?.Finance?.fBabat;
                    cmbsBabat.SelectedIndex = (int)cls?.Finance?.sBabat;
                    SetFirstSallary();
                    SetSecondSallary();
                }
                else
                {
                    cmbfBabat.SelectedIndex = 0;
                    cmbsBabat.SelectedIndex = 0;
                    lblfTotal.Text = lblsTotal.Text = "0";
                    lblTotalCommition.Text = "0";
                }

                cmbBazaryab.SelectedValue = cls?.BazaryabGuid;
                txtBazaryabPrice.TextDecimal = cls?.BazaryabPrice ?? 0;


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
                    await NextCodeAsync();
                    cmbUser.SelectedValue = clsUser.CurrentUser?.Guid;
                    cmbfBabat.SelectedIndex = 0;
                    cmbsBabat.SelectedIndex = 0;
                    txtTerm.Value = 12;
                    txtfDate.Text = Calendar.MiladiToShamsi(DateTime.Now);
                }
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
                txtCode.Text = await ContractBussines.NextCodeAsync() ?? "";
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
        private async Task LoadBazaryabAsync()
        {
            try
            {
                var list = await UserBussines.GetAllAsync();
                list.Add(new UserBussines()
                {
                    Guid = Guid.Empty,
                    Name = "[هیچکدام]"
                });
                bazaryabBindingSource.DataSource = list.Where(q => q.Status).OrderBy(q => q.Name).ToList();
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
                        txtEjare.TextDecimal = building?.EjarePrice1 ?? 0;
                        txtRahn.TextDecimal = building?.RahnPrice1 ?? 0;
                        txtTerm.Value = 12;
                        SetFullPrice();
                    }
                    else
                    {
                        //Foroush
                        lblfPrice.Text = building?.SellPrice.ToString("N0");
                        lblsPrice.Text = "0";
                        txtSellPrice.TextDecimal = building?.SellPrice ?? 0;
                    }
                }


                fPanel.Controls.Clear();
                lstList.Clear();
                if (building?.GalleryList == null || building.GalleryList.Count == 0) return;

                foreach (var image in building.GalleryList)
                {
                    var a = Path.Combine(Application.StartupPath, "Images");
                    var b = Path.Combine(a, image.ImageName + ".jpg");
                    if (!b.EndsWith(".jpg")) b += ".jpg";
                    lstList.Add(b);
                }

                Make_Picture_Boxes(lstList);
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
                if (cls?.Type == EnRequestType.Rahn)
                {
                    txtEjare.TextDecimal = cls?.MinorPrice ?? 0;
                    txtRahn.TextDecimal = cls?.TotalPrice ?? 0;
                }

                txtSarQofli.TextDecimal = cls?.SarQofli ?? 0;
                txtDelay.TextDecimal = cls?.Delay ?? 0;

                if (cls?.Type == EnRequestType.Forush)
                {
                    txtSellPrice.TextDecimal = cls?.TotalPrice ?? 0;
                    txtBeyane.TextDecimal = cls?.MinorPrice ?? 0;
                }

                if (cls?.Finance == null)
                {
                    txtfTotalPrice.TextDecimal = 0;
                    txtfDiscount.TextDecimal = 0;
                    txtfAddedValue.TextDecimal = 0;
                    txtsTotalPrice.TextDecimal = 0;
                    txtsDiscount.TextDecimal = 0;
                    txtsAddedValue.TextDecimal = 0;
                }
                else
                {
                    txtfTotalPrice.TextDecimal = cls?.Finance?.FirstTotalPrice ?? 0;
                    txtfDiscount.TextDecimal = cls?.Finance?.FirstDiscount ?? 0;
                    txtfAddedValue.TextDecimal = cls?.Finance?.FirstAddedValue ?? 0;
                    txtsTotalPrice.TextDecimal = cls?.Finance?.SecondTotalPrice ?? 0;
                    txtsDiscount.TextDecimal = cls?.Finance?.SecondDiscount ?? 0;
                    txtsAddedValue.TextDecimal = cls?.Finance?.SecondAddedValue ?? 0;
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
        private async Task<ReturnedSaveFuncInfo> CheckValidationAsync()
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                if (string.IsNullOrWhiteSpace(txtCode.Text))
                {
                    res.AddError("کد قرارداد نمی تواند خالی باشد");
                    txtCode.Focus();
                }
                if (!await ContractBussines.CheckCodeAsync(txtCode.Text.Trim(), cls.Guid))
                {
                    res.AddError("کد ملک وارد شده تکراری است");
                    txtCode.Focus();
                }

                if (fSide == null)
                {
                    res.AddError("لطفا طرف اول قرارداد را انتخاب نمایید");
                    btnfSearch.Focus();
                }
                if (sSide == null)
                {
                    res.AddError("لطفا طرف دوم قرارداد را انتخاب نمایید");
                    btnsSearch.Focus();
                }
                if (building == null)
                {
                    res.AddError("لطفا ملک موضوع قرارداد را انتخاب نمایید");
                    btnBuildingSearch.Focus();
                }
                if (txtRahn.Text == "0" && txtEjare.Text == "0" && txtSellPrice.Text == "0" &&
                    txtBeyane.Text == "0")
                {
                    res.AddError("لطفا یکی از فیلدهای مبلغ را وارد نمایید");
                    btnSearchOwner.Focus();
                }

                if ((Guid)cmbBazaryab.SelectedValue == Guid.Empty && txtBazaryabPrice.TextDecimal > 0)
                {
                    res.AddError("لطفا بازاریاب را انتخاب نمایید");
                }
                if ((Guid)cmbBazaryab.SelectedValue != Guid.Empty && txtBazaryabPrice.TextDecimal <= 0)
                {
                    res.AddError("لطفا مبلغ پورسانت بازاریاب را مشخص نمایید");
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
        }
        private async Task<ReturnedSaveFuncInfo> SaveAsync()
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                if (cls.Guid == Guid.Empty) cls.Guid = Guid.NewGuid();

                res.AddReturnedValue(await CheckValidationAsync());
                if (res.HasError) return res;

                cls.Code = txtCode.Text.ParseToLong();
                cls.UserGuid = (Guid)cmbUser.SelectedValue;
                cls.FirstSideGuid = fSide.Guid;
                cls.SecondSideGuid = sSide.Guid;
                cls.BuildingGuid = building.Guid;

                cls.Term = txtTerm.Text.ParseToInt();
                cls.FromDate = Calendar.ShamsiToMiladi(txtfDate.Text);
                if (txtSellPrice.TextDecimal != 0)
                    cls.TotalPrice = txtSellPrice.TextDecimal;
                if (txtRahn.TextDecimal != 0)
                    cls.TotalPrice = txtRahn.TextDecimal;
                if (txtBeyane.TextDecimal != 0)
                    cls.MinorPrice = txtBeyane.TextDecimal;
                if (txtEjare.TextDecimal != 0)
                    cls.MinorPrice = txtEjare.TextDecimal;

                cls.CheckNo = txtCheckNo.Text;
                cls.BankName = txtBankName.Text;
                cls.SarResid = txtSarResid.Text;
                cls.Shobe = txtShobe.Text;
                cls.DischargeDate = string.IsNullOrEmpty(txtDisCharge.Text)
                    ? DateTime.Now.AddYears(1)
                    : Calendar.ShamsiToMiladi(txtDisCharge.Text);
                cls.SetDocPlace = txtSetDocAddress.Text;
                cls.SetDocDate = Calendar.ShamsiToMiladi(txtSetDocDate.Text);
                cls.SarQofli = txtSarQofli.TextDecimal;
                cls.Description = txtDesc.Text;
                cls.Delay = txtDelay.TextDecimal;

                if (cls.Finance == null)
                    cls.Finance = new ContractFinanceBussines { Guid = Guid.NewGuid() };

                cls.Finance.FirstAddedValue = txtfAddedValue.TextDecimal;
                cls.Finance.FirstDiscount = txtfDiscount.TextDecimal;
                cls.Finance.FirstTotalPrice = txtfTotalPrice.TextDecimal;
                cls.Finance.SecondAddedValue = txtsAddedValue.TextDecimal;
                cls.Finance.SecondDiscount = txtsDiscount.TextDecimal;
                cls.Finance.SecondTotalPrice = txtsTotalPrice.TextDecimal;

                cls.Finance.fBabat = (EnContractBabat)cmbfBabat.SelectedIndex;
                cls.Finance.sBabat = (EnContractBabat)cmbsBabat.SelectedIndex;
                cls.Finance.ConGuid = cls.Guid;
                cls.BazaryabGuid = (Guid)cmbBazaryab.SelectedValue;
                cls.BazaryabPrice = txtBazaryabPrice.TextDecimal;

                res.AddReturnedValue(await cls.SaveAsync());
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
        }
        private void SetFirstSallary()
        {
            try
            {
                decimal fTotal = 0, fDis = 0, fAdd = 0;
                decimal sTotal = 0, sDis = 0, sAdd = 0;

                fAdd = txtfAddedValue.TextDecimal;
                fDis = txtfDiscount.TextDecimal;
                fTotal = txtfTotalPrice.TextDecimal;

                sAdd = txtsAddedValue.TextDecimal;
                sDis = txtsDiscount.TextDecimal;
                sTotal = txtsTotalPrice.TextDecimal;

                lblfSallary.Text = (fTotal - fDis).ToString("N0") + " ریال";
                lblfTotal.Text = ((fTotal + fAdd) - fDis).ToString("N0") + " ریال";

                lblTotalCommition.Text = (((fTotal + fAdd) - fDis) + ((sTotal + sAdd) - sDis)).ToString("N0");
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
                decimal fTotal = 0, fDis = 0, fAdd = 0;
                decimal sTotal = 0, sDis = 0, sAdd = 0;

                fAdd = txtfAddedValue.TextDecimal;
                fDis = txtfDiscount.TextDecimal;
                fTotal = txtfTotalPrice.TextDecimal;

                sAdd = txtsAddedValue.TextDecimal;
                sDis = txtsDiscount.TextDecimal;
                sTotal = txtsTotalPrice.TextDecimal;

                lblsSallary.Text = (sTotal - sDis).ToString("N0") + " ریال";
                lblsTotal.Text = ((sTotal + sAdd) - sDis).ToString("N0") + " ریال";

                lblTotalCommition.Text = (((fTotal + fAdd) - fDis) + ((sTotal + sAdd) - sDis)).ToString("N0");
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
        private void SetFullPrice()
        {
            try
            {
                var price = txtEjare.TextDecimal;
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
        private void SetBazaryabPrice()
        {
            try
            {
                var price = lblTotalCommition.Text.ParseToDecimal();
                var percent = (int)txtBazaryabPercent.Value;

                txtBazaryabPrice.TextDecimal = (price * percent) / 100;
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

        private async void frmContractMain_Load(object sender, EventArgs e)
        {
            await SetDataAsync();
        }
        private void btnfSearch_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new frmShowPeoples(true);
                if (frm.ShowDialog(this) != DialogResult.OK) return;
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
                if (frm.ShowDialog(this) != DialogResult.OK) return;
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
                var frm = new frmShowBuildings(true, fSide?.Guid ?? Guid.Empty);
                if (frm.ShowDialog(this) != DialogResult.OK) return;
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
            var res = new ReturnedSaveFuncInfo();
            try
            {
                if (MessageBox.Show("آیا از ثبت اطلاعات اطمینان دارید؟", "پیغام سیستم", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    return;
                cls.IsTemp = true;
                res.AddReturnedValue(await SaveAsync());
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
                    var frm = new FrmShowErrorMessage(res, "خطا در ثبت قولنامه به صورت موقت");
                    frm.ShowDialog(this);
                    frm.Dispose();
                }
                else
                {
                    UserLog.Save(action, EnLogPart.Contracts);
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
        }
        private async void btnSaveNoTemp_Click(object sender, EventArgs e)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                if (MessageBox.Show("آیا از ثبت اطلاعات اطمینان دارید؟", "پیغام سیستم", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    return;
                cls.IsTemp = false;
                res.AddReturnedValue(await SaveAsync());
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
                    var frm = new FrmShowErrorMessage(res, "خطا در ثبت قولنامه به صورت داپم");
                    frm.ShowDialog(this);
                    frm.Dispose();
                }
                else
                {
                    UserLog.Save(action, EnLogPart.Contracts);
                    DialogResult = DialogResult.OK;
                    Close();
                }
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
        private void btnCalculateCommition_Click(object sender, EventArgs e)
        {
            try
            {
                decimal commition = 0;
                if (txtRahn.TextDecimal > 0 || txtEjare.TextDecimal > 0)
                {
                    decimal rahn = 0, ejare = 0;

                    rahn = txtRahn.TextDecimal;
                    ejare = txtEjare.TextDecimal;

                    var tabdilPercent = Settings.Classes.clsSandouq.Tabdil.ParseToInt();

                    commition = CalculateCommition.CalculateEjare(rahn, ejare, tabdilPercent);
                    txtfTotalPrice.TextDecimal = commition;
                    txtsTotalPrice.TextDecimal = commition;
                }
                else if (txtSellPrice.TextDecimal > 0)
                {
                    var sellPrice = txtSellPrice.TextDecimal;
                    commition = CalculateCommition.CalculateKharid(sellPrice);
                    txtfTotalPrice.TextDecimal = commition;
                    txtsTotalPrice.TextDecimal = commition;
                }

                var arzehPercent = Settings.Classes.clsSandouq.ArzeshAfzoude.ParseToInt();

                var arzesh = (commition * arzehPercent) / 100;
                txtfAddedValue.TextDecimal = arzesh;
                txtsAddedValue.TextDecimal = arzesh;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void txtfTotalPrice_OnTextChanged() => SetFirstSallary();
        private void txtfDiscount_OnTextChanged() => SetFirstSallary();
        private void txtfAddedValue_OnTextChanged() => SetFirstSallary();
        private void txtsTotalPrice_OnTextChanged() => SetSecondSallary();
        private void txtsDiscount_OnTextChanged() => SetSecondSallary();
        private void txtsAddedValue_OnTextChanged() => SetSecondSallary();
        private void txtBazaryabPercent_ValueChanged(object sender, EventArgs e) => SetBazaryabPrice();
    }
}
