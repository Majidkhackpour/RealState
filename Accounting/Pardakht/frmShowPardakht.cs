using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsSerivces;
using EntityCache.Bussines;
using EntityCache.ViewModels;
using MetroFramework.Forms;
using Print;
using Services;

namespace Accounting.Pardakht
{
    public partial class frmShowPardakht : MetroForm
    {
        private CancellationTokenSource _token = new CancellationTokenSource();

        private async Task LoadDataAsync(string search = "")
        {
            try
            {
                _token?.Cancel();
                _token = new CancellationTokenSource();
                var list = await PardakhtBussines.GetAllAsync(search, _token.Token);
                Invoke(new MethodInvoker(() => PardakhtBindingSource.DataSource =
                    list.OrderByDescending(q => q.Number).ToSortableBindingList()));
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
                var access = UserBussines.CurrentUser.UserAccess;
                mnuAdd.Enabled = access?.Pardakht.Pardakht_Insert ?? false;
                mnuEdit.Enabled = access?.Pardakht.Pardakht_Update ?? false;
                mnuDelete.Enabled = access?.Pardakht.Pardakht_Delete ?? false;
                mnuView.Enabled = access?.Pardakht.Pardakht_View ?? false;
                mnuPrintList.Enabled = access?.Pardakht.Pardakht_PrintList ?? false;
                mnuPrintOne.Enabled = access?.Pardakht.Pardakht_PrintOne ?? false;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        public frmShowPardakht()
        {
            InitializeComponent();
            ucHeader.Text = "نمایش لیست وجوه پرداختی";
            SetAccess();
        }

        private async void frmShowPardakht_Load(object sender, EventArgs e) => await LoadDataAsync();
        private void frmShowPardakht_KeyDown(object sender, KeyEventArgs e)
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
        private async void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                await LoadDataAsync(txtSearch.Text);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async void mnuAdd_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new frmPardakhtMain();
                if (frm.ShowDialog() == DialogResult.OK)
                    await LoadDataAsync();
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

                var frm = new frmPardakhtMain(guid, false);
                if (frm.ShowDialog(this) == DialogResult.OK)
                    await LoadDataAsync(txtSearch.Text);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void mnuView_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGrid.RowCount <= 0) return;
                if (DGrid.CurrentRow == null) return;
                var guid = (Guid)DGrid[dgGuid.Index, DGrid.CurrentRow.Index].Value;

                var frm = new frmPardakhtMain(guid, true);
                frm.ShowDialog(this);
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
                var hazine = await PardakhtBussines.GetAsync(guid);
                if (hazine == null) return;
                var sum = (decimal)DGrid[dgSum.Index, DGrid.CurrentRow.Index].Value;

                if (MessageBox.Show(this,
                        $@"آیا از حذف پرداخت به شماره {DGrid[dgNumber.Index, DGrid.CurrentRow.Index].Value} و به جمع {sum:N0} اطمینان دارید؟",
                        "حذف",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) == DialogResult.No) return;
                res.AddReturnedValue(await hazine.RemoveAsync());
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }
            finally
            {
                if (res.HasError) this.ShowError(res, "خطا در حذف برگه پرداخت");
                else await LoadDataAsync(txtSearch.Text);
            }
        }
        private async void mnuPrintList_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGrid.RowCount <= 0) return;
                if (DGrid.CurrentRow == null) return;

                var frm = new frmSetPrintSize(false);
                if (frm.ShowDialog(this) != DialogResult.OK) return;
                _token?.Cancel();
                _token = new CancellationTokenSource();
                var pardakht = await PardakhtBussines.GetAllAsync(_token.Token);
                var list = new List<OperationListPrintViewModel>();
                foreach (var item in pardakht)
                {
                    var totalSum = pardakht.Sum(q => q.SumCheckMoshtari) + pardakht.Sum(q => q.SumHavale) +
                               pardakht.Sum(q => q.SumNaqd) + pardakht.Sum(q => q.SumCheckShakhsi);
                    list.Add(new OperationListPrintViewModel()
                    {
                        PrintDateSh = Calendar.MiladiToShamsi(DateTime.Now),
                        PrintTime = DateTime.Now.ToShortTimeString(),
                        DateM = item.DateM,
                        Count = pardakht.Count,
                        Description = item.Description,
                        Number = item.Number,
                        Check = 0,
                        DateSh = item.DateSh,
                        TafsilName = item.TafsilName,
                        Havale = 0,
                        Naqd = 0,
                        TotalRow = item.Sum,
                        TotalSum = totalSum,
                        TotalHorouf = $"{NumberToString.Num2Str(totalSum.ToString())} ریال"
                    });
                }

                list = list?.OrderBy(q => q.DateM)?.ToList();

                if (frm._PrintType == EnPrintType.Excel) return;
                var cls = new ReportGenerator(StiType.Pardakht_List, frm._PrintType) { Lst = new List<object>(list) };
                cls.PrintNew();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async void mnuPrintOne_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGrid.RowCount <= 0) return;
                if (DGrid.CurrentRow == null) return;

                var frm = new frmSetPrintSize(false);
                if (frm.ShowDialog(this) != DialogResult.OK) return;
                var guid = (Guid)DGrid[dgGuid.Index, DGrid.CurrentRow.Index].Value;
                var pardakht = await PardakhtBussines.GetAsync(guid);
                var list = new List<OperationOnePrintViewModel>();
                foreach (var item in pardakht.NaqdList)
                {
                    list.Add(new OperationOnePrintViewModel()
                    {
                        PrintDateSh = Calendar.MiladiToShamsi(DateTime.Now),
                        Description = pardakht.Description,
                        Type = "نقد",
                        Price = item.Price,
                        SanadNumber = pardakht.SanadNumber,
                        DateSh = pardakht.DateSh,
                        TafsilName = pardakht.TafsilName,
                        TotalSum = pardakht.Sum,
                        RowDesc = item.Description
                    });
                }
                foreach (var item in pardakht.HavaleList)
                {
                    list.Add(new OperationOnePrintViewModel()
                    {
                        PrintDateSh = Calendar.MiladiToShamsi(DateTime.Now),
                        Description = pardakht.Description,
                        Type = "حواله",
                        Price = item.Price,
                        SanadNumber = pardakht.SanadNumber,
                        DateSh = pardakht.DateSh,
                        TafsilName = pardakht.TafsilName,
                        TotalSum = pardakht.Sum,
                        RowDesc = item.Description
                    });
                }
                foreach (var item in pardakht.CheckMoshtariList)
                {
                    list.Add(new OperationOnePrintViewModel()
                    {
                        PrintDateSh = Calendar.MiladiToShamsi(DateTime.Now),
                        Description = pardakht.Description,
                        Type = "چک دریافتی",
                        Price = item.Price,
                        SanadNumber = pardakht.SanadNumber,
                        DateSh = pardakht.DateSh,
                        TafsilName = pardakht.TafsilName,
                        TotalSum = pardakht.Sum,
                        RowDesc = item.Description
                    });
                }
                foreach (var item in pardakht.CheckShakhsiList)
                {
                    list.Add(new OperationOnePrintViewModel()
                    {
                        PrintDateSh = Calendar.MiladiToShamsi(DateTime.Now),
                        Description = pardakht.Description,
                        Type = "چک شخصی",
                        Price = item.Price,
                        SanadNumber = pardakht.SanadNumber,
                        DateSh = pardakht.DateSh,
                        TafsilName = pardakht.TafsilName,
                        TotalSum = pardakht.Sum,
                        RowDesc = item.Description
                    });
                }

                if (frm._PrintType == EnPrintType.Excel) return;
                var cls = new ReportGenerator(StiType.Pardakht_One, frm._PrintType) { Lst = new List<object>(list) };
                cls.PrintNew();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
