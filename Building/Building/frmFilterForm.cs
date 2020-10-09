using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Advertise.Classes;
using EntityCache.Bussines;
using EntityCache.ViewModels;
using MetroFramework.Forms;
using Services;
using User;

namespace Building.Building
{
    public partial class frmFilterForm : MetroForm
    {
        private async Task SetDataAsync()
        {
            try
            {
                FillCmbReqType();
                await FillBuildingAccountTypeAsync();
                await FillBuildingTypeAsync();
                FillCmbPrice();

                Invoke(new MethodInvoker(() =>
                {
                    chbSystem.Checked = true;
                    cmbRahn1.SelectedIndex = 0;
                    cmbRahn2.SelectedIndex = 0;
                    cmbEjare1.SelectedIndex = 0;
                    cmbEjare2.SelectedIndex = 0;
                }));
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void FillCmbReqType()
        {
            try
            {
                var values = Enum.GetValues(typeof(EnRequestType)).Cast<EnRequestType>();
                foreach (var item in values)
                    cmbReqType.Items.Add(item.GetDisplay());
                cmbReqType.SelectedIndex = 0;
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

                var a = new BuildingTypeBussines()
                {
                    Guid = Guid.Empty,
                    Name = "[همه]"
                };
                list.Add(a);


                if (list.Count > 0)
                    Invoke(new MethodInvoker(() =>
                    {
                        bTypeBindingSource.DataSource = list.ToList().Where(q => q.Status).OrderBy(q => q.Name);
                        cmbBuildingType.SelectedIndex = 0;
                    }));
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

                var a = new BuildingAccountTypeBussines()
                {
                    Guid = Guid.Empty,
                    Name = "[همه]"
                };
                list.Add(a);


                if (list.Count > 0)
                    Invoke(new MethodInvoker(() =>
                    {
                        batBindingSource.DataSource = list.ToList().Where(q => q.Status).OrderBy(q => q.Name);
                        cmbBuildingAccountType.SelectedIndex = 0;
                    }));
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
                    Invoke(new MethodInvoker(() =>
                    {
                        cmbRahn1.Items.Add(item.GetDisplay());
                        cmbEjare1.Items.Add(item.GetDisplay());
                        cmbRahn2.Items.Add(item.GetDisplay());
                        cmbEjare2.Items.Add(item.GetDisplay());
                    }));
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void SetAccess()
        {
            try
            {
                var access = clsUser.CurrentUser.UserAccess;
                chbDivar.Enabled = access?.BuildingSearch.Building_Search_Divar ?? false;
                chbSystem.Enabled = access?.BuildingSearch.Building_Search_System ?? false;
                chbSarasari.Enabled = access?.BuildingSearch.Building_Search_Site ?? false;
                //chbSheypoor.Enabled = access?.BuildingSearch.Building_Search_Sheypoor ?? false;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        public frmFilterForm()
        {
            InitializeComponent();
            Task.Run(() => SetDataAsync());
            SetAccess();
        }

        public frmFilterForm(EnRequestType type, Guid buildingType, Guid accountType, int roomCount, int fMasahat,
            int sMasahat, decimal fPrice1, decimal sPrice1, decimal fPrice2, decimal sPrice2)
        {
            InitializeComponent();
            Task.Run(() => SetDataAsync());
            SetFormControl(type, buildingType, accountType, roomCount, fMasahat, sMasahat, fPrice1, sPrice1, fPrice2,
                sPrice2);
            SetAccess();
        }

        private async void cmbReqType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                while (!IsHandleCreated)
                {
                    await Task.Delay(100);
                }
                Invoke(new MethodInvoker(() =>
                {
                    if (cmbReqType.SelectedIndex == (int)EnRequestType.Rahn)
                    {
                        lblSPrice1.Visible = lblSPrice2.Visible = true;
                        txtSPrice1.Visible = txtSPrice2.Visible = true;
                        cmbEjare1.Visible = cmbEjare2.Visible = true;
                        lblFPrice1.Text = "رهن از";
                    }
                    else
                    {
                        lblSPrice1.Visible = lblSPrice2.Visible = false;
                        txtSPrice1.Visible = txtSPrice2.Visible = false;
                        cmbEjare1.Visible = cmbEjare2.Visible = false;
                        lblFPrice1.Text = "مبلغ از";
                    }
                }));
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private async void btnSeach_Click(object sender, EventArgs e)
        {
            try
            {
                var list = new List<BuildingViewModel>();
                decimal fPrice1 = 0, sPrice1 = 0, fPrice2 = 0, sPrice2 = 0;

                if (cmbRahn1.SelectedIndex == 0)
                    fPrice1 = txtFPrice1.Text.ParseToDecimal() * 10000;
                if (cmbRahn1.SelectedIndex == 1)
                    fPrice1 = txtFPrice1.Text.ParseToDecimal() * 10000000;
                if (cmbRahn1.SelectedIndex == 2)
                    fPrice1 = txtFPrice1.Text.ParseToDecimal() * 10000000000;

                if (cmbRahn2.SelectedIndex == 0)
                    sPrice1 = txtFPrice2.Text.ParseToDecimal() * 10000;
                if (cmbRahn2.SelectedIndex == 1)
                    sPrice1 = txtFPrice2.Text.ParseToDecimal() * 10000000;
                if (cmbRahn2.SelectedIndex == 2)
                    sPrice1 = txtFPrice2.Text.ParseToDecimal() * 10000000000;

                if (cmbEjare1.SelectedIndex == 0)
                    fPrice2 = txtSPrice1.Text.ParseToDecimal() * 10000;
                if (cmbEjare1.SelectedIndex == 1)
                    fPrice2 = txtSPrice1.Text.ParseToDecimal() * 10000000;
                if (cmbEjare1.SelectedIndex == 2)
                    fPrice2 = txtSPrice1.Text.ParseToDecimal() * 10000000000;

                if (cmbEjare2.SelectedIndex == 0)
                    sPrice2 = txtSPrice2.Text.ParseToDecimal() * 10000;
                if (cmbEjare2.SelectedIndex == 1)
                    sPrice2 = txtSPrice2.Text.ParseToDecimal() * 10000000;
                if (cmbEjare2.SelectedIndex == 2)
                    sPrice2 = txtSPrice2.Text.ParseToDecimal() * 10000000000;





                if (chbSystem.Checked)
                {
                    list.AddRange(await BuildingBussines.GetAllAsync(txtCode.Text, (Guid)cmbBuildingType.SelectedValue,
                        (Guid)cmbBuildingAccountType.SelectedValue, txtFMasahat.Text.ParseToInt(),
                        txtSMasahat.Text.ParseToInt(), txtRoomCount.Text.ParseToInt(), fPrice1,
                        sPrice1, fPrice2,
                        sPrice2, (EnRequestType)cmbReqType.SelectedIndex));
                }

                if (chbDivar.Checked)
                {
                    var divar = DivarAdv.GetInstance();
                    list.AddRange(await divar.GetBuildingAsync((EnRequestType) cmbReqType.SelectedIndex, fPrice1,
                        sPrice1, fPrice2, sPrice2, txtFMasahat.Text.ParseToInt(),
                        txtSMasahat.Text.ParseToInt(), 24));
                }


                var frm = new frmBuildingAdvanceSearch(list);
                frm.ShowDialog();

            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void SetFormControl(EnRequestType type, Guid buildingType, Guid accountType, int roomCount, int fMasahat,
            int sMasahat, decimal fPrice1, decimal sPrice1, decimal fPrice2, decimal sPrice2)
        {
            try
            {
                cmbReqType.SelectedIndex = (int)type;
                cmbBuildingType.SelectedValue = buildingType;
                cmbBuildingAccountType.SelectedValue = accountType;
                txtRoomCount.Text = roomCount.ToString();

                if (fMasahat == 0)
                    txtFMasahat.Text = fMasahat.ToString();
                if (fMasahat != 0)
                {
                    if (fMasahat >= 10000)
                        txtFMasahat.Text = (fMasahat / 10000).ToString();
                    if (fMasahat <= 9999)
                        txtFMasahat.Text = fMasahat.ToString();
                }


                if (sMasahat == 0)
                    txtSMasahat.Text = sMasahat.ToString();
                if (sMasahat != 0)
                {
                    if (sMasahat >= 10000)
                        txtSMasahat.Text = (sMasahat / 10000).ToString();
                    if (sMasahat <= 9999)
                        txtSMasahat.Text = sMasahat.ToString();
                }



                if (fPrice1 == 0)
                {
                    txtFPrice1.Text = fPrice1.ToString();
                    cmbRahn1.SelectedIndex = 0;
                }
                if (fPrice1 != 0)
                {
                    if (fPrice1 >= 10000 && fPrice1 >= 9999)
                    {
                        txtFPrice1.Text = (fPrice1 / 10000).ToString();
                        cmbRahn1.SelectedIndex = 0;
                    }
                    if (fPrice1 >= 10000000 && fPrice1 >= 9999999)
                    {
                        txtFPrice1.Text = (fPrice1 / 10000000).ToString();
                        cmbRahn1.SelectedIndex = 1;
                    }
                    if (fPrice1 >= 10000000000 && fPrice1 >= 9999999999)
                    {
                        txtFPrice1.Text = (fPrice1 / 10000000000).ToString();
                        cmbRahn1.SelectedIndex = 2;
                    }
                }


                if (sPrice1 == 0)
                {
                    txtSPrice1.Text = sPrice1.ToString();
                    cmbRahn2.SelectedIndex = 0;
                }
                if (sPrice1 != 0)
                {
                    if (sPrice1 >= 10000 && sPrice1 >= 9999)
                    {
                        txtSPrice1.Text = (sPrice1 / 10000).ToString();
                        cmbRahn2.SelectedIndex = 0;
                    }
                    if (sPrice1 >= 10000000 && sPrice1 >= 9999999)
                    {
                        txtSPrice1.Text = (sPrice1 / 10000000).ToString();
                        cmbRahn2.SelectedIndex = 1;
                    }
                    if (sPrice1 >= 10000000000 && sPrice1 >= 9999999999)
                    {
                        txtSPrice1.Text = (sPrice1 / 10000000000).ToString();
                        cmbRahn2.SelectedIndex = 2;
                    }
                }



                if (fPrice2 == 0)
                {
                    txtFPrice2.Text = fPrice2.ToString();
                    cmbEjare1.SelectedIndex = 0;
                }
                if (fPrice2 != 0)
                {
                    if (fPrice2 >= 10000 && fPrice2 >= 9999)
                    {
                        txtFPrice2.Text = (fPrice2 / 10000).ToString();
                        cmbEjare1.SelectedIndex = 0;
                    }
                    if (fPrice2 >= 10000000 && fPrice2 >= 9999999)
                    {
                        txtFPrice2.Text = (fPrice2 / 10000000).ToString();
                        cmbEjare1.SelectedIndex = 1;
                    }
                    if (fPrice2 >= 10000000000 && fPrice2 >= 9999999999)
                    {
                        txtFPrice2.Text = (fPrice2 / 10000000000).ToString();
                        cmbEjare1.SelectedIndex = 2;
                    }
                }


                if (sPrice2 == 0)
                {
                    txtSPrice2.Text = sPrice2.ToString();
                    cmbEjare2.SelectedIndex = 0;
                }
                if (sPrice2 != 0)
                {
                    if (sPrice2 >= 10000 && sPrice2 >= 9999)
                    {
                        txtSPrice2.Text = (sPrice2 / 10000).ToString();
                        cmbEjare2.SelectedIndex = 0;
                    }
                    if (sPrice2 >= 10000000 && sPrice2 >= 9999999)
                    {
                        txtSPrice2.Text = (sPrice2 / 10000000).ToString();
                        cmbEjare2.SelectedIndex = 1;
                    }
                    if (sPrice2 >= 10000000000 && sPrice2 >= 9999999999)
                    {
                        txtSPrice2.Text = (sPrice2 / 10000000000).ToString();
                        cmbEjare2.SelectedIndex = 2;
                    }
                }


            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
