﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Advertise.Classes;
using Advertise.Forms.Simcard;
using EntityCache.Bussines;
using MetroFramework.Forms;
using Notification;
using Print;
using Services;
using User;

namespace Building.Building
{
    public partial class frmShowBuildings : MetroForm
    {
        private bool _st = true;
        public Guid SelectedGuid { get; set; }
        private bool isShowMode = false;
        private List<BuildingBussines> list;
        private async Task FillCmbAsync()
        {
            try
            {
                cmbStatus.Items.Add(EnBuildingStatus.All.GetDisplay());
                cmbStatus.Items.Add(EnBuildingStatus.Mojod.GetDisplay());
                cmbStatus.Items.Add(EnBuildingStatus.Vagozar.GetDisplay());

                var list = await BuildingTypeBussines.GetAllAsync();
                list.Add(new BuildingTypeBussines()
                {
                    Guid = Guid.Empty,
                    Name = "[همه]"
                });
                btBindingSource.DataSource = list.OrderBy(q => q.Name).ToList();


                var list2 = await UserBussines.GetAllAsync();
                list2.Add(new UserBussines()
                {
                    Guid = Guid.Empty,
                    Name = "[همه]"
                });
                userBindingSource.DataSource = list2.OrderBy(q => q.Name).ToList();

                cmbStatus.SelectedIndex = 0;
                cmbBuildingType.SelectedIndex = 0;
                cmbUser.SelectedValue = clsUser.CurrentUser.Guid;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void LoadData(bool status, string search = "")
        {
            try
            {
                list = BuildingBussines
                    .GetAll(search, (EnBuildingStatus)cmbStatus.SelectedIndex - 1,
                        (Guid)cmbBuildingType.SelectedValue,
                        (Guid)cmbUser.SelectedValue);
                Invoke(new MethodInvoker(() => BuildingBindingSource.DataSource =
                    list.Where(q => q.Status == status).OrderByDescending(q => q.CreateDate).ToSortableBindingList()));
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
                btnInsert.Enabled = access?.Building.Building_Insert ?? false;
                btnEdit.Enabled = access?.Building.Building_Update ?? false;
                btnDelete.Enabled = access?.Building.Building_Delete ?? false;
                btnChangeStatus.Enabled = access?.Building.Building_Disable ?? false;
                btnView.Enabled = access?.Building.Building_View ?? false;
                btnMatchRequest.Enabled = access?.Building.Building_Show_request ?? false;
                btnMojod.Enabled = access?.Building.Building_Mojod ?? false;
                btnVagozar.Enabled = access?.Building.Building_Vagozar ?? false;
                btnSendSms.Enabled = access?.Building.Building_Send_Sms ?? false;
                btnSendToDivar.Enabled = access?.Building.Building_Send_Divar ?? false;
                btnSendToSheypoor.Enabled = access?.Building.Building_Send_Sheypoor ?? false;
                btnSendToTelegram.Enabled = access?.Building.Building_Send_Telegram ?? false;
                btnPrint.Enabled = access?.Building.Building_Print ?? false;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        public bool ST
        {
            get => _st;
            set
            {
                _st = value;
                if (_st)
                {
                    btnChangeStatus.Text = "غیرفعال (Ctrl+S)";
                    LoadData(ST, txtSearch.Text);
                    btnDelete.Text = "حذف (Del)";
                }
                else
                {
                    btnChangeStatus.Text = "فعال (Ctrl+S)";

                    LoadData(ST, txtSearch.Text);
                    btnDelete.Text = "فعال کردن";
                }
            }
        }
        public frmShowBuildings(bool _isShowMode)
        {
            InitializeComponent();
            isShowMode = _isShowMode;
            if (isShowMode)
            {
                btnDelete.Visible = false;
                btnInsert.Visible = false;
                btnEdit.Visible = false;
                btnView.Visible = false;
                btnChangeStatus.Visible = false;
                btnSelect.Visible = true;
                btnOther.Visible = false;
            }
            else
            {
                btnDelete.Visible = true;
                btnInsert.Visible = true;
                btnEdit.Visible = true;
                btnView.Visible = true;
                btnChangeStatus.Visible = true;
                btnSelect.Visible = false;
                btnOther.Visible = true;
            }

            SetAccess();
        }

        private async void frmShowBuildings_Load(object sender, EventArgs e)
        {
            await FillCmbAsync();
            LoadData(ST);
        }

        private void DGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                LoadData(ST, txtSearch.Text);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void frmShowBuildings_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                switch (e.KeyCode)
                {
                    case Keys.Insert:
                        btnInsert.PerformClick();
                        break;
                    case Keys.F7:
                        btnEdit.PerformClick();
                        break;
                    case Keys.Delete:
                        btnDelete.PerformClick();
                        break;
                    case Keys.F12:
                        btnView.PerformClick();
                        break;
                    case Keys.S:
                        if (e.Control) ST = !ST;
                        break;
                    case Keys.Escape:
                        Close();
                        break;
                    case Keys.F:
                        if (e.Control) txtSearch.Focus();
                        break;
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void btnChangeStatus_Click(object sender, EventArgs e)
        {
            ST = !ST;
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGrid.RowCount <= 0) return;
                if (DGrid.CurrentRow == null) return;
                var guid = (Guid)DGrid[dgGuid.Index, DGrid.CurrentRow.Index].Value;
                if (ST)
                {
                    if (MessageBox.Show(this,
                            $@" آیا از حذف ملک{DGrid[dgCode.Index, DGrid.CurrentRow.Index].Value} اطمینان دارید؟", "حذف",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question) == DialogResult.No) return;
                    var prd = await BuildingBussines.GetAsync(guid);
                    var res = await prd.ChangeStatusAsync(false);
                    if (res.HasError)
                    {
                        frmNotification.PublicInfo.ShowMessage(res.ErrorMessage);
                        return;
                    }

                    UserLog.Save(EnLogAction.Delete, EnLogPart.Building);


                }
                else
                {
                    if (MessageBox.Show(this,
                            $@"آیا از فعال کردن ملک{DGrid[dgCode.Index, DGrid.CurrentRow.Index].Value} اطمینان دارید؟", "حذف",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question) == DialogResult.No) return;
                    var prd = await BuildingBussines.GetAsync(guid);
                    var res = await prd.ChangeStatusAsync(true);
                    if (res.HasError)
                    {
                        frmNotification.PublicInfo.ShowMessage(res.ErrorMessage);
                        return;
                    }

                    UserLog.Save(EnLogAction.Enable, EnLogPart.Building);
                }

                LoadData(ST, txtSearch.Text);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new frmBuildingMain();
                if (frm.ShowDialog(this) == DialogResult.OK)
                    LoadData(ST);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGrid.RowCount <= 0) return;
                if (DGrid.CurrentRow == null) return;
                if (!ST)
                {
                    frmNotification.PublicInfo.ShowMessage(
                        "شما مجاز به ویرایش داده حذف شده نمی باشید \r\n برای این منظور، ابتدا فیلد موردنظر را از حالت حذف شده به فعال، تغییر وضعیت دهید");
                    return;
                }
                var guid = (Guid)DGrid[dgGuid.Index, DGrid.CurrentRow.Index].Value;
                var frm = new frmBuildingMain(guid, false);
                if (frm.ShowDialog(this) == DialogResult.OK)
                    LoadData(ST, txtSearch.Text);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGrid.RowCount <= 0) return;
                if (DGrid.CurrentRow == null) return;
                var guid = (Guid)DGrid[dgGuid.Index, DGrid.CurrentRow.Index].Value;
                var frm = new frmBuildingMain(guid, true);
                frm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void DGrid_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                txtSearch.Focus();
                txtSearch.Text = e.KeyChar.ToString();
                txtSearch.SelectionStart = 9999;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private async void btnMojod_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGrid.RowCount <= 0) return;
                if (DGrid.CurrentRow == null) return;
                var guid = (Guid)DGrid[dgGuid.Index, DGrid.CurrentRow.Index].Value;
                var bu = await BuildingBussines.GetAsync(guid);
                if (bu == null) return;
                if (bu.BuildingStatus == EnBuildingStatus.Mojod)
                {
                    frmNotification.PublicInfo.ShowMessage(
                        "وضعیت ملک هم اکنون موجود می باشد");
                    return;
                }
                if (MessageBox.Show(this,
                        $@"آیا از اعمال تغییرات اطمینان دارید؟", "تغییر وضعیت ملک",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) == DialogResult.No) return;

                bu.BuildingStatus = EnBuildingStatus.Mojod;
                var res = await bu.SaveAsync();
                if (res.HasError)
                {
                    frmNotification.PublicInfo.ShowMessage(res.ErrorMessage);
                    return;
                }

                LoadData(ST, txtSearch.Text);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private async void btnVagozar_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGrid.RowCount <= 0) return;
                if (DGrid.CurrentRow == null) return;
                var guid = (Guid)DGrid[dgGuid.Index, DGrid.CurrentRow.Index].Value;
                var bu = await BuildingBussines.GetAsync(guid);
                if (bu == null) return;
                if (bu.BuildingStatus == EnBuildingStatus.Vagozar)
                {
                    frmNotification.PublicInfo.ShowMessage(
                        "وضعیت ملک هم اکنون واگذارشده می باشد");
                    return;
                }
                if (MessageBox.Show(this,
                        $@"آیا از اعمال تغییرات اطمینان دارید؟", "تغییر وضعیت ملک",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) == DialogResult.No) return;

                bu.BuildingStatus = EnBuildingStatus.Vagozar;
                var res = await bu.SaveAsync();
                if (res.HasError)
                {
                    frmNotification.PublicInfo.ShowMessage(res.ErrorMessage);
                    return;
                }
                LoadData(ST, txtSearch.Text);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void cmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                LoadData(ST, txtSearch.Text);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void cmbBuildingType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                LoadData(ST, txtSearch.Text);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void cmbUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                LoadData(ST, txtSearch.Text);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void DGrid_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (!isShowMode) return;
                btnSelect.PerformClick();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGrid.RowCount <= 0) return;
                if (DGrid.CurrentRow == null) return;
                SelectedGuid = (Guid)DGrid[dgGuid.Index, DGrid.CurrentRow.Index].Value;
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new frmSetPrintSize();
                if (frm.ShowDialog(this) != DialogResult.OK) return;

                if (frm._PrintType != EnPrintType.Excel)
                {
                    var cls = new ReportGenerator(StiType.Building_List, frm._PrintType) { Lst = new List<object>(list) };
                    cls.PrintNew();
                    return;
                }

                ExportToExcel.ExportBuilding(list, this);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private async void btnSendToDivar_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGrid.RowCount <= 0) return;
                if (DGrid.CurrentRow == null) return;
                var simList = new List<SimcardBussines>();
                var buList = new List<BuildingBussines>();

                var bu = await BuildingBussines.GetAsync((Guid)DGrid[dgGuid.Index, DGrid.CurrentRow.Index].Value);
                if (bu == null) return;
                buList.Add(bu);

                var frm = new frmShowSimcard(true);
                if (frm.ShowDialog(this) == DialogResult.OK)
                    simList.Add(await SimcardBussines.GetAsync(frm.SelectedGuid));



                var res = await Utility.ManageAdvSend(buList, simList, AdvertiseType.Divar);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private async void btnSendToSheypoor_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGrid.RowCount <= 0) return;
                if (DGrid.CurrentRow == null) return;
                var simList = new List<SimcardBussines>();
                var buList = new List<BuildingBussines>();

                var bu = await BuildingBussines.GetAsync((Guid)DGrid[dgGuid.Index, DGrid.CurrentRow.Index].Value);
                if (bu == null) return;
                buList.Add(bu);

                var frm = new frmShowSimcard(true);
                if (frm.ShowDialog(this) == DialogResult.OK)
                    simList.Add(await SimcardBussines.GetAsync(frm.SelectedGuid));



                var res = await Utility.ManageAdvSend(buList, simList, AdvertiseType.Sheypoor);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
