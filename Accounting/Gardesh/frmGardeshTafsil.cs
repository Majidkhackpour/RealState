using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityCache.Bussines;
using EntityCache.ViewModels;
using MetroFramework.Forms;
using Print;
using Services;

namespace Accounting.Gardesh
{
    public partial class frmGardeshTafsil : MetroForm
    {
        private Guid _tafsilGuid;
        private List<GardeshBussines> _listData;

        private async Task LoadDataAsync()
        {
            try
            {
                _listData = await GardeshBussines.GetAllGardeshAsync(_tafsilGuid);
                GardeshBindingSource.DataSource = _listData?.OrderBy(q => q.DateM)?.ToSortableBindingList();
                _ = Task.Run(HilightGridAsync);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private Task HilightGridAsync()
        {
            try
            {
                Invoke(new MethodInvoker(() =>
                {
                    for (var i = 0; i < DGrid.RowCount; i++)
                    {
                        var debit = (decimal)DGrid[dgDebit.Index, i].Value;
                        var credit = (decimal)DGrid[dgCredit.Index, i].Value;

                        if (debit > credit)
                            DGrid.Rows[i].DefaultCellStyle.BackColor = Color.OrangeRed;
                        else if (credit > debit)
                            DGrid.Rows[i].DefaultCellStyle.BackColor = Color.PaleTurquoise;
                    }
                }));
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
            return Task.CompletedTask;
        }

        public frmGardeshTafsil(Guid tafsilGuid)
        {
            InitializeComponent();
            _tafsilGuid = tafsilGuid;
        }

        private void DGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
             => DGrid.Rows[e.RowIndex].Cells["dgRadif"].Value = e.RowIndex + 1;
        private async void frmGardeshTafsil_Load(object sender, EventArgs e) => await LoadDataAsync();
        private void frmGardeshTafsil_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) Close();
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGrid.RowCount <= 0) return;
                if (DGrid.CurrentRow == null) return;

                var frm = new frmSetPrintSize(false);
                if (frm.ShowDialog(this) != DialogResult.OK) return;

                var list = new List<GardeshPrintViewModel>();
                foreach (var item in _listData)
                {
                    list.Add(new GardeshPrintViewModel()
                    {
                        PrintDateSh = Calendar.MiladiToShamsi(DateTime.Now),
                        DateM = item.DateM,
                        Description = item.Description,
                        Debit = item.Debit,
                        Credit = item.Credit,
                        DateSh = item.DateSh,
                        SumCredit = _listData.Sum(q => q.Credit),
                        SumDebit = _listData.Sum(q => q.Debit),
                        Rem_ = item.Rem,
                        TafsilName = item.TafsilName,
                        TafsilCode = item.TafsilCode
                    });
                }

                list = list?.OrderBy(q => q.DateM)?.ToList();

                if (frm._PrintType == EnPrintType.Excel) return;
                var cls = new ReportGenerator(StiType.Account_Performence_List, frm._PrintType) { Lst = new List<object>(list) };
                cls.PrintNew();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
