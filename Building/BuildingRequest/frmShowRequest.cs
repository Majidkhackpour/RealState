using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Building.Building;
using EntityCache.Bussines;
using MetroFramework.Forms;
using Notification;
using Print;
using Services;
using User;

namespace Building.BuildingRequest
{
    public partial class frmShowRequest : MetroForm
    {
        private bool _st = true;
        private List<BuildingRequestBussines> list;
        private void LoadData(bool status, string search = "")
        {
            try
            { 
                list = BuildingRequestBussines.GetAll(search).Where(q => q.Status == status).ToList();
                reqBindingSource.DataSource =
                    list.OrderByDescending(q => q.CreateDate).ToSortableBindingList();
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
                btnInsert.Enabled = access?.BuildingRequest.Building_Request_Insert ?? false;
                btnEdit.Enabled = access?.BuildingRequest.Building_Request_Update ?? false;
                btnDelete.Enabled = access?.BuildingRequest.Building_Request_Delete ?? false;
                btnChangeStatus.Enabled = access?.BuildingRequest.Building_Request_Disable ?? false;
                btnView.Enabled = access?.BuildingRequest.Building_Request_View ?? false;
                btnPrint.Enabled = access?.BuildingRequest.Building_Request_Print ?? false;
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
        public frmShowRequest()
        {
            InitializeComponent();
            SetAccess();
        }

        private void frmShowRequest_Load(object sender, EventArgs e)
        {
            LoadData(ST);
        }

        private void DGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DGrid.Rows[e.RowIndex].Cells["dgRadif"].Value = e.RowIndex + 1;
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

        private void frmShowRequest_KeyDown(object sender, KeyEventArgs e)
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
                    if (MessageBox.Show(
                            $@"آیا از حذف درخواست {DGrid[dgName.Index, DGrid.CurrentRow.Index].Value} اطمینان دارید؟", "حذف",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question) == DialogResult.No) return;
                    var prd = await BuildingRequestBussines.GetAsync(guid);
                    var res = await prd.ChangeStatusAsync(false);
                    if (res.HasError)
                    {
                        frmNotification.PublicInfo.ShowMessage(res.ErrorMessage);
                        return;
                    }

                    User.UserLog.Save(EnLogAction.Delete, EnLogPart.BuildingRequest);
                }
                else
                {
                    if (MessageBox.Show(
                            $@"آیا از فعال کردن درخواست {DGrid[dgName.Index, DGrid.CurrentRow.Index].Value} اطمینان دارید؟", "حذف",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question) == DialogResult.No) return;
                    var prd = await BuildingRequestBussines.GetAsync(guid);
                    var res = await prd.ChangeStatusAsync(true);
                    if (res.HasError)
                    {
                        frmNotification.PublicInfo.ShowMessage(res.ErrorMessage);
                        return;
                    }

                    User.UserLog.Save(EnLogAction.Enable, EnLogPart.BuildingRequest);
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
                var frm = new frmRequestMain();
                if (frm.ShowDialog() == DialogResult.OK)
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
                var frm = new frmRequestMain(guid, false);
                if (frm.ShowDialog() == DialogResult.OK)
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
                var frm = new frmRequestMain(guid, true);
                frm.ShowDialog();
                LoadData(ST, txtSearch.Text);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void btnShowBuilding_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGrid.RowCount <= 0) return;
                if (DGrid.CurrentRow == null) return;
                var guid = (Guid)DGrid[dgGuid.Index, DGrid.CurrentRow.Index].Value;
                var req = BuildingRequestBussines.Get(guid);
                if (req == null) return;
                
                var type = EnRequestType.Rahn;
                decimal fPrice1 = 0, sPrice1 = 0, fPrice2 = 0, sPrice2 = 0;

                if (req.SellPrice1 > 0) type = EnRequestType.Forush;
                if (req.RahnPrice1 > 0) type = EnRequestType.Rahn;

                if (type == EnRequestType.Forush)
                {
                    fPrice1 = req.SellPrice1;
                    sPrice1 = req.SellPrice2;
                }
                else
                {
                    fPrice1 = req.RahnPrice1;
                    sPrice1 = req.RahnPrice2;
                    fPrice2 = req.EjarePrice1;
                    sPrice2 = req.EjarePrice2;
                }

                var frm = new frmFilterForm(type, req.BuildingTypeGuid, req.BuildingAccountTypeGuid, req.RoomCount,
                    req.Masahat1, req.Masahat2, fPrice1, sPrice1, fPrice2, sPrice2);
                frm.ShowDialog();
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
                if (frm.ShowDialog() != DialogResult.OK) return;

                if (frm._PrintType != EnPrintType.Excel)
                {
                    var cls = new ReportGenerator(StiType.Building_Request_List, frm._PrintType)
                        {Lst = new List<object>(list)};
                    cls.PrintNew();
                    return;
                }

                ExportToExcel.ExportRequest(list);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
