using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsSerivces;
using EntityCache.Bussines;
using EntityCache.Bussines.ReportBussines;
using MetroFramework.Forms;
using Services;
using Services.FilterObjects;

namespace Building.BuildingReview
{
    public partial class frmShowReview : MetroForm
    {
        private BuildingReviewFilter _filter;
        private CancellationTokenSource _token = new CancellationTokenSource();
        private IEnumerable<BuildingReviewReportBussines> _list;

        private async Task LoadDataAsync(string search = "")
        {
            try
            {
                _list = await BuildingReviewReportBussines.GetAllAsync(_filter);
                await SearchAsync(search);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async Task SearchAsync(string srach = "")
        {
            try
            {
                var filteredList = _list;
                _token?.Cancel();
                _token = new CancellationTokenSource();
                var t = _token.Token;
                if (string.IsNullOrEmpty(srach)) srach = "";
                var searchItems = srach.SplitString();
                if (searchItems?.Count > 0)
                    foreach (var item in searchItems)
                    {
                        if (t.IsCancellationRequested) return;
                        if (!string.IsNullOrEmpty(item) && item.Trim() != "")
                        {
                            filteredList = filteredList?.Where(x => x.UserName.ToLower().Contains(item.ToLower()) ||
                                                 x.CustomerName.ToLower().Contains(item.ToLower()) ||
                                                 x.Report.ToLower().Contains(item.ToLower()) ||
                                                 x.BuildingCode.ToLower().Contains(item.ToLower()))
                                ?.ToList();
                        }
                    }

                BeginInvoke(new MethodInvoker(() => { ReviewBindingSource.DataSource = filteredList?.ToSortableBindingList(); }));
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        public frmShowReview(BuildingReviewFilter filter)
        {
            try
            {
                InitializeComponent();
                ucHeader.Text = "نمایش لیست گزارش بازدید";
                dgServerStatusImage.Visible = VersionAccess.WebService;
                _filter = filter;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void frmShowReview_Load(object sender, EventArgs e) => _ = Task.Run(() => LoadDataAsync());
        private void DGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DGrid.Rows[e.RowIndex].Cells["dgRadif"].Value = e.RowIndex + 1;
        }
        private void frmShowReview_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                switch (e.KeyCode)
                {
                    case Keys.Insert:
                        mnuAdd.PerformClick();
                        break;
                    case Keys.F7:
                        mnuEdit.PerformClick();
                        break;
                    case Keys.Delete:
                        mnuDelete.PerformClick();
                        break;
                    case Keys.F12:
                        mnuView.PerformClick();
                        break;
                    case Keys.Escape:
                        if (!string.IsNullOrEmpty(txtSearch.Text))
                        {
                            txtSearch.Text = "";
                            return;
                        }
                        Close();
                        break;
                    case Keys.Down:
                        if (txtSearch.Focused)
                            DGrid.Focus();
                        break;
                    case Keys.F:
                        if (e.Control) txtSearch.Focus();
                        break;
                    case Keys.Enter:
                        mnuEdit.PerformClick();
                        break;
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void txtSearch_TextChanged(object sender, EventArgs e) => _ = Task.Run(() => SearchAsync(txtSearch.Text));
        private async void mnuAdd_Click(object sender, EventArgs e)
        {
            try
            {
                var obj = new BuildingReviewBussines();
                if (_filter.BuildingGuid != null)
                    obj.BuildingGuid = _filter.BuildingGuid.Value;
                var frm = new frmReviewMain(obj);
                if (frm.ShowDialog(this) == DialogResult.OK)
                    await LoadDataAsync();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async void mnuView_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGrid.RowCount <= 0) return;
                if (DGrid.CurrentRow == null) return;
                var guid = (Guid)DGrid[dgGuid.Index, DGrid.CurrentRow.Index].Value;
                var obj = await BuildingReviewBussines.GetAsync(guid);
                if (obj == null) return;
                var frm = new frmReviewMain(obj, true);
                frm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async void mnuEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGrid.RowCount <= 0) return;
                if (DGrid.CurrentRow == null) return;
                var guid = (Guid)DGrid[dgGuid.Index, DGrid.CurrentRow.Index].Value;
                var obj = await BuildingReviewBussines.GetAsync(guid);
                if (obj == null) return;
                var frm = new frmReviewMain(obj);
                if (frm.ShowDialog(this) == DialogResult.OK)
                    await LoadDataAsync(txtSearch.Text);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async void mnuDelete_Click(object sender, EventArgs e)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                if (DGrid.RowCount <= 0) return;
                if (DGrid.CurrentRow == null) return;
                var guid = (Guid)DGrid[dgGuid.Index, DGrid.CurrentRow.Index].Value;
                if (MessageBox.Show(this, @"آیا از حذف اطمینان دارید؟", "حذف", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) == DialogResult.No) return;
                var prd = await BuildingReviewBussines.GetAsync(guid);
                res.AddReturnedValue(await prd.ChangeStataus(false));
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }
            finally
            {
                if (res.HasError)
                    this.ShowError(res, "خطا در تغییر وضعیت زونکن");
                else await LoadDataAsync(txtSearch.Text);
            }
        }
    }
}
