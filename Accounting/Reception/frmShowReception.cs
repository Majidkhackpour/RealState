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

namespace Accounting.Reception
{
    public partial class frmShowReception : MetroForm
    {
        private CancellationTokenSource _token = new CancellationTokenSource();

        private async Task LoadDataAsync(string search = "")
        {
            try
            {
                _token?.Cancel();
                _token = new CancellationTokenSource();
                var list = await ReceptionBussines.GetAllAsync(search, _token.Token);
                Invoke(new MethodInvoker(() => ReceptionBindingSource.DataSource =
                    list.OrderByDescending(q => q.Number).ToSortableBindingList()));
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        public frmShowReception()
        {
            InitializeComponent();
            ucHeader.Text = "نمایش لیست وجوه دریافتی";
        }

        private async void mnuAdd_Click(object sender, System.EventArgs e)
        {
            try
            {
                var frm = new frmReceptionMain();
                if (frm.ShowDialog() == DialogResult.OK)
                    await LoadDataAsync();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async void frmShowReception_Load(object sender, EventArgs e) => await LoadDataAsync();
        private void frmShowReception_KeyDown(object sender, KeyEventArgs e)
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
        private async void mnuEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGrid.RowCount <= 0) return;
                if (DGrid.CurrentRow == null) return;
                var guid = (Guid)DGrid[dgGuid.Index, DGrid.CurrentRow.Index].Value;

                var frm = new frmReceptionMain(guid, false);
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

                var frm = new frmReceptionMain(guid, true);
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
                var hazine = await ReceptionBussines.GetAsync(guid);
                if (hazine == null) return;
                var sum = (decimal)DGrid[dgSum.Index, DGrid.CurrentRow.Index].Value;

                if (MessageBox.Show(this,
                        $@"آیا از حذف دریافت به شماره {DGrid[dgNumber.Index, DGrid.CurrentRow.Index].Value} و به جمع {sum:N0} اطمینان دارید؟",
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
                if (res.HasError) this.ShowError(res, "خطا در حذف برگه دریافت");
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
                var reception = await ReceptionBussines.GetAllAsync(_token.Token);
                var list = new List<OperationListPrintViewModel>();
                foreach (var item in reception)
                {
                    var totalSum = reception.Sum(q => q.SumCheck) + reception.Sum(q => q.SumHavale) +
                                   reception.Sum(q => q.SumNaqd);
                    list.Add(new OperationListPrintViewModel()
                    {
                        PrintDateSh = Calendar.MiladiToShamsi(DateTime.Now),
                        PrintTime = DateTime.Now.ToShortTimeString(),
                        DateM = item.DateM,
                        Count = reception.Count,
                        Description = item.Description,
                        Number = item.Number,
                        Check = item.SumCheck,
                        DateSh = item.DateSh,
                        TafsilName = item.TafsilName,
                        Havale = item.SumHavale,
                        Naqd = item.SumNaqd,
                        TotalRow = totalSum,
                        TotalSum = item.Sum,
                        TotalHorouf = $"{NumberToString.Num2Str(totalSum.ToString())} ریال"
                    });
                }

                list = list?.OrderBy(q => q.DateM)?.ToList();

                if (frm._PrintType == EnPrintType.Excel) return;
                var cls = new ReportGenerator(StiType.Reception_List, frm._PrintType) { Lst = new List<object>(list) };
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
                var reception = await ReceptionBussines.GetAsync(guid);
                var list = new List<OperationOnePrintViewModel>();
                foreach (var item in reception.NaqdList)
                {
                    list.Add(new OperationOnePrintViewModel()
                    {
                        PrintDateSh = Calendar.MiladiToShamsi(DateTime.Now),
                        Description = reception.Description,
                        Type = "نقد",
                        Price = item.Price,
                        SanadNumber = reception.SanadNumber,
                        DateSh = reception.DateSh,
                        TafsilName = reception.TafsilName,
                        TotalSum = reception.Sum,
                        RowDesc = item.Description
                    });
                }
                foreach (var item in reception.HavaleList)
                {
                    list.Add(new OperationOnePrintViewModel()
                    {
                        PrintDateSh = Calendar.MiladiToShamsi(DateTime.Now),
                        Description = reception.Description,
                        Type = "حواله",
                        Price = item.Price,
                        SanadNumber = reception.SanadNumber,
                        DateSh = reception.DateSh,
                        TafsilName = reception.TafsilName,
                        TotalSum = reception.Sum,
                        RowDesc = item.Description
                    });
                }
                foreach (var item in reception.CheckList)
                {
                    list.Add(new OperationOnePrintViewModel()
                    {
                        PrintDateSh = Calendar.MiladiToShamsi(DateTime.Now),
                        Description = reception.Description,
                        Type = "چک",
                        Price = item.Price,
                        SanadNumber = reception.SanadNumber,
                        DateSh = reception.DateSh,
                        TafsilName = reception.TafsilName,
                        TotalSum = reception.Sum,
                        RowDesc = item.Description
                    });
                }

                if (frm._PrintType == EnPrintType.Excel) return;
                var cls = new ReportGenerator(StiType.Reception_One, frm._PrintType) { Lst = new List<object>(list) };
                cls.PrintNew();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
