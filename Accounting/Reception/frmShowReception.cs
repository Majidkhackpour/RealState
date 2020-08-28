using System;
using System.Linq;
using System.Windows.Forms;
using EntityCache.Bussines;
using MetroFramework.Forms;
using Notification;
using Services;

namespace Accounting.Reception
{
    public partial class frmShowReception : MetroForm
    {
        private Guid _receptorGuid;
        private EnAccountingType type;
        private bool _st = true;
        private void LoadData(bool status, string search = "")
        {
            try
            {
                var list = ReceptionBussines.GetAll(search, _receptorGuid).Where(q => q.Status == status).ToList();
                receptionBindingSource.DataSource = list.ToSortableBindingList();
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
        public frmShowReception(Guid receptorGuid, EnAccountingType _type)
        {
            InitializeComponent();
            _receptorGuid = receptorGuid;
            type = _type;
            SetLabels();
        }

        private void SetLabels()
        {
            try
            {
                if (type == EnAccountingType.Peoples)
                {
                    var hesab = PeoplesBussines.Get(_receptorGuid);
                    if (hesab == null) return;
                    lblName.Text = hesab.Name;
                }
                else if (type == EnAccountingType.Users)
                {
                    var hesab = UserBussines.Get(_receptorGuid);
                    if (hesab == null) return;
                    lblName.Text = hesab.Name;
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void frmShowReception_Load(object sender, EventArgs e)
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

        private void frmShowReception_KeyDown(object sender, KeyEventArgs e)
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

        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new frmReceptionMain(_receptorGuid, type);
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
                var frm = new frmReceptionMain(guid, false, type);
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
                var frm = new frmReceptionMain(guid, true, type);
                frm.ShowDialog();
                LoadData(ST, txtSearch.Text);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
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
                            $@"آیا از حذف سند دریافت اطمینان دارید؟", "حذف",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question) == DialogResult.No) return;
                    var prd = await ReceptionBussines.GetAsync(guid);


                    if (type == EnAccountingType.Peoples)
                    {
                        var pe = await PeoplesBussines.GetAsync(_receptorGuid);
                        if (pe != null)
                        {
                            pe.Account += prd.TotalPrice;
                            await pe.SaveAsync();
                        }
                    }
                    else if (type == EnAccountingType.Users)
                    {
                        var user = await UserBussines.GetAsync(_receptorGuid);
                        if (user != null)
                        {
                            user.Account += prd.TotalPrice;
                            await user.SaveAsync(false);
                        }
                    }




                    var res = await prd.ChangeStatusAsync(false);
                    if (res.HasError)
                    {
                        frmNotification.PublicInfo.ShowMessage(res.ErrorMessage);
                        return;
                    }
                }
                else
                {
                    if (MessageBox.Show(
                            $@"آیا از فعال کردن سند دریافت اطمینان دارید؟", "حذف",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question) == DialogResult.No) return;
                    var prd = await ReceptionBussines.GetAsync(guid);
                    if (type == EnAccountingType.Peoples)
                    {
                        var pe = await PeoplesBussines.GetAsync(_receptorGuid);
                        if (pe != null)
                        {
                            pe.Account -= prd.TotalPrice;
                            await pe.SaveAsync();
                        }
                    }
                    else if (type == EnAccountingType.Users)
                    {
                        var user = await UserBussines.GetAsync(_receptorGuid);
                        if (user != null)
                        {
                            user.Account -= prd.TotalPrice;
                            await user.SaveAsync(false);
                        }
                    }
                    var res = await prd.ChangeStatusAsync(true);
                    if (res.HasError)
                    {
                        frmNotification.PublicInfo.ShowMessage(res.ErrorMessage);
                        return;
                    }
                }

                LoadData(ST, txtSearch.Text);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
