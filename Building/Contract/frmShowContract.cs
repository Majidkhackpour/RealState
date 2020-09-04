using System;
using System.Linq;
using System.Windows.Forms;
using EntityCache.Bussines;
using MetroFramework.Forms;
using Notification;
using Services;

namespace Building.Contract
{
    public partial class frmShowContract : MetroForm
    {
        private bool _st = true;
        private void LoadData(bool status, string search = "")
        {
            try
            {
                var list = ContractBussines.GetAll(search).Where(q => q.Status == status).ToList();
                conBindingSource.DataSource =
                    list.OrderByDescending(q => q.Modified).ToSortableBindingList();
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
        public frmShowContract()
        {
            InitializeComponent();
        }

        private void frmShowContract_Load(object sender, EventArgs e)
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

        private void frmShowContract_KeyDown(object sender, KeyEventArgs e)
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

        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new frmContractMain();
                if (frm.ShowDialog() == DialogResult.OK)
                    LoadData(ST, txtSearch.Text);
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
                var con = ContractBussines.Get(guid);
                if (con == null) return;
                if (!con.IsTemp)
                {
                    frmNotification.PublicInfo.ShowMessage(
                        "شما مجاز به ویرایش داده نهایی شده نمی باشید");
                    return;
                }
                var frm = new frmContractMain(guid, false);
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
                var frm = new frmContractMain(guid, true);
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
                            $@"آیا از حذف قرارداد اطمینان دارید؟", "حذف",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question) == DialogResult.No) return;
                    var prd = await ContractBussines.GetAsync(guid);
                    if (!prd.IsTemp)
                    {
                        frmNotification.PublicInfo.ShowMessage(
                            "شما مجاز به حذف داده نهایی شده نمی باشید");
                        return;
                    }

                    var pe = await PeoplesBussines.GetAsync(prd.FirstSideGuid);
                    if (pe != null)
                    {
                        pe.Account -= (prd.Finance.FirstTotalPrice + prd.Finance.FirstAddedValue) -
                                      prd.Finance.FirstDiscount;
                        await pe.SaveAsync();
                    }

                    var pe_ = await PeoplesBussines.GetAsync(prd.SecondSideGuid);
                    if (pe_ != null)
                    {
                        pe_.Account -= (prd.Finance.SecondTotalPrice + prd.Finance.SecondAddedValue) -
                                       prd.Finance.SecondDiscount;
                        await pe_.SaveAsync();
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
                            $@"آیا از فعال کردن سند پرداخت اطمینان دارید؟", "حذف",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question) == DialogResult.No) return;
                    var prd = await ContractBussines.GetAsync(guid);

                    var pe = await PeoplesBussines.GetAsync(prd.FirstSideGuid);
                    if (pe != null)
                    {
                        pe.Account += (prd.Finance.FirstTotalPrice + prd.Finance.FirstAddedValue) -
                                      prd.Finance.FirstDiscount;
                        await pe.SaveAsync();
                    }

                    var pe_ = await PeoplesBussines.GetAsync(prd.SecondSideGuid);
                    if (pe_ != null)
                    {
                        pe_.Account += (prd.Finance.SecondTotalPrice + prd.Finance.SecondAddedValue) -
                                       prd.Finance.SecondDiscount;
                        await pe_.SaveAsync();
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

        private void btnChangeStatus_Click(object sender, EventArgs e)
        {
            ST = !ST;
        }

        private async void btnChangeTemp_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGrid.RowCount <= 0) return;
                if (DGrid.CurrentRow == null) return;
                var guid = (Guid)DGrid[dgGuid.Index, DGrid.CurrentRow.Index].Value;
                var bu = await ContractBussines.GetAsync(guid);
                if (bu == null) return;
                if (!bu.IsTemp)
                {
                    frmNotification.PublicInfo.ShowMessage(
                        "وضعیت قرارداد هم اکنون بسته شده می باشد");
                    return;
                }
                if (MessageBox.Show(
                        $@"آیا از اعمال تغییرات اطمینان دارید؟", "تغییر وضعیت قرارداد",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) == DialogResult.No) return;

                bu.IsTemp = false;
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
    }
}
