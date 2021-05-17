using EntityCache.ViewModels;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityCache.Bussines;
using Services;

namespace Accounting.Report
{
    public partial class frmTarazHesab : MetroForm
    {
        private List<TarazHesabViewModel> _list = new List<TarazHesabViewModel>();
        private long _code1, _code2;
        private DateTime _date1, _date2;
        private CancellationTokenSource _token = new CancellationTokenSource();


        private async Task LoadDataAsync(string search = "")
        {
            try
            {
                while (!IsHandleCreated)
                {
                    if (_token.IsCancellationRequested || IsDisposed) return;
                    await Task.Delay(100);
                }

                _token?.Cancel();
                _token = new CancellationTokenSource();
                _list = await SanadDetailBussines.GetAllTarazHesabAsync(_token.Token, _date1, _date2, _code1, _code2);
                Search(_token.Token, search);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void Search(CancellationToken token, string search = "")
        {
            try
            {
                if (!IsHandleCreated) return;

                var temp = _list;
                if (string.IsNullOrEmpty(search)) search = "";
                var searchItems = search.SplitString();
                if (searchItems?.Count > 0)
                    foreach (var item in searchItems)
                    {
                        if (token.IsCancellationRequested) return;
                        temp = temp?.Where(p => p.TafsilCode.ToString().Contains(item) ||
                                                p.MoeinCode.ToString().Contains(item) ||
                                                p.TafsilName.Contains(item) ||
                                                p.MoeinName.ToString().Contains(item))
                            .ToList();
                    }

                if (token.IsCancellationRequested) return;
                Invoke(new MethodInvoker(() => TarazBindingSource.DataSource = temp?.ToSortableBindingList()));
                if (token.IsCancellationRequested) return;
                RefreshLables();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void RefreshGrid()
        {
            try
            {
                DGRemDebit.Visible = false;
                DGRemCredit.Visible = false;

                DGSDDebin.Visible = false;
                DGSDCredit.Visible = false;

                DGEDDebin.Visible = false;
                DGEDCredit.Visible = false;

                if (rbtn4.Checked)
                {
                    DGRemDebit.Visible = true;
                    DGRemCredit.Visible = true;
                }
                else if (rbtn6.Checked)
                {
                    DGSDDebin.Visible = true;
                    DGSDCredit.Visible = true;

                    DGEDDebin.Visible = true;
                    DGEDCredit.Visible = true;
                }
                else if (rbtn8.Checked)
                {
                    DGSDDebin.Visible = true;
                    DGSDCredit.Visible = true;

                    DGEDDebin.Visible = true;
                    DGEDCredit.Visible = true;

                    DGRemDebit.Visible = true;
                    DGRemCredit.Visible = true;
                }

                DGRemDebit.Width = 5;
                DGRemCredit.Width = 5;
                DGSDDebin.Width = 5;
                DGSDCredit.Width = 5;
                DGDDDebin.Width = 5;
                DGDDCredit.Width = 5;
                DGEDDebin.Width = 5;
                DGEDCredit.Width = 5;

                DGRemDebit.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                DGRemCredit.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                DGSDDebin.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                DGSDCredit.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                DGDDDebin.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                DGDDCredit.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                DGEDDebin.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                DGEDCredit.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                RefrehTopLablesPosition();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void RefreshLables()
        {
            try
            {
                decimal sdDebit = 0;
                decimal sdCredit = 0;

                decimal ddDebit = 0;
                decimal ddCredit = 0;

                decimal edDebit = 0;
                decimal edCredit = 0;

                decimal debit = 0;
                decimal credit = 0;

                for (var i = 0; i <= _list.Count - 1; i++)
                {
                    sdDebit += _list[i].SD_Debit;
                    sdCredit += _list[i].SD_Credit;

                    ddDebit += _list[i].DD_Debit;
                    ddCredit += _list[i].DD_Credit;

                    edDebit += _list[i].ED_Debit;
                    edCredit += _list[i].ED_Credit;

                    debit += _list[i].RemPayan2ReDebit;
                    credit += _list[i].RemPayan2ReCredit;
                }

                LBLSD_Debit.Text = sdDebit.ToString("N0");
                LBLSD_Credit.Text = sdCredit.ToString("N0");

                LBLDD_Debit.Text = ddDebit.ToString("N0");
                LBLDD_Credit.Text = ddCredit.ToString("N0");

                LBLED_Debit.Text = edDebit.ToString("N0");
                LBLED_Credit.Text = edCredit.ToString("N0");

                LBLDebitCredit_Debit.Text = debit.ToString("N0");
                LBLDebitCredit_Credit.Text = credit.ToString("N0");
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void RefrehTopLablesPosition()
        {
            try
            {
                var lblsdLeft = Width - DGrid.Right;

                for (var i = 0; i <= DGSDCredit.Index; i++)
                    if (DGrid.Columns[i].Visible)
                        lblsdLeft += DGrid.Columns[i].Width;

                LBLSD.Visible = DGSDCredit.Visible;
                LBLSD.Width = DGSDCredit.Width + DGSDDebin.Width;
                LBLSD.Left = Width - LBLSD.Width - lblsdLeft + DGSDCredit.Width + DGSDDebin.Width - 41;

                LBLSD_Credit.Visible = LBLSD.Visible;
                LBLSD_Credit.Left = LBLSD.Left;
                LBLSD_Credit.Width = LBLSD.Width;

                LBLSD_Debit.Visible = LBLSD.Visible;
                LBLSD_Debit.Left = LBLSD.Left;
                LBLSD_Debit.Width = LBLSD.Width;
                //----------------------------------------------------------------------

                var lblddLeft = Width - DGrid.Right;
                for (var i = 0; i <= DGDDCredit.Index; i++)
                    if (DGrid.Columns[i].Visible)
                        lblddLeft += DGrid.Columns[i].Width;

                LBLDD.Visible = DGDDCredit.Visible;
                LBLDD.Width = DGDDCredit.Width + DGDDDebin.Width;
                LBLDD.Left = Width - LBLDD.Width - lblddLeft + DGDDCredit.Width + DGDDDebin.Width - 41;

                LBLDD_Credit.Visible = LBLDD.Visible;
                LBLDD_Credit.Left = LBLDD.Left;
                LBLDD_Credit.Width = LBLDD.Width;

                LBLDD_Debit.Visible = LBLDD.Visible;
                LBLDD_Debit.Left = LBLDD.Left;
                LBLDD_Debit.Width = LBLDD.Width;

                //----------------------------------------------------------------------

                var lbledLeft = Width - DGrid.Right;
                for (var i = 0; i <= DGEDCredit.Index; i++)
                    if (DGrid.Columns[i].Visible)
                        lbledLeft += DGrid.Columns[i].Width;

                LBLED.Visible = DGEDCredit.Visible;
                LBLED.Width = DGEDCredit.Width + DGEDDebin.Width;
                LBLED.Left = Width - LBLED.Width - lbledLeft + DGEDCredit.Width + DGEDDebin.Width - 41;

                LBLED_Credit.Visible = LBLED.Visible;
                LBLED_Credit.Left = LBLED.Left;
                LBLED_Credit.Width = LBLED.Width;

                LBLED_Debit.Visible = LBLED.Visible;
                LBLED_Debit.Left = LBLED.Left;
                LBLED_Debit.Width = LBLED.Width;

                //----------------------------------------------------------------------
                LBLDebitCredit.Visible = false;
                if (DGRemCredit.Visible)
                {
                    var lblDebitCreditLeft = Width - DGrid.Right;
                    for (var i = 0; i <= DGRemCredit.Index; i++)
                        if (DGrid.Columns[i].Visible)
                            lblDebitCreditLeft += DGrid.Columns[i].Width;

                    LBLDebitCredit.Visible = DGRemCredit.Visible;
                    LBLDebitCredit.Width = DGRemCredit.Width + DGRemDebit.Width;
                    LBLDebitCredit.Left = Width - LBLDebitCredit.Width - lblDebitCreditLeft + DGRemCredit.Width +
                                          DGRemDebit.Width - 41;
                }
                LBLDebitCredit_Credit.Visible = LBLDebitCredit.Visible;
                LBLDebitCredit_Credit.Left = LBLDebitCredit.Left;
                LBLDebitCredit_Credit.Width = LBLDebitCredit.Width;

                LBLDebitCredit_Debit.Visible = LBLDebitCredit.Visible;
                LBLDebitCredit_Debit.Left = LBLDebitCredit.Left;
                LBLDebitCredit_Debit.Width = LBLDebitCredit.Width;

                LBLDebitCredit_Debit.Top = DGrid.Bottom;
                LBLED_Debit.Top = DGrid.Bottom;
                LBLDD_Debit.Top = DGrid.Bottom;
                LBLSD_Debit.Top = DGrid.Bottom;
                //----------------------------
                LBLDebitCredit_Credit.Top = LBLDebitCredit_Debit.Bottom;
                LBLED_Credit.Top = LBLDebitCredit_Debit.Bottom;
                LBLDD_Credit.Top = LBLDebitCredit_Debit.Bottom;
                LBLSD_Credit.Top = LBLDebitCredit_Debit.Bottom;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }


        public frmTarazHesab(DateTime d1, DateTime d2, long code1, long code2)
        {
            try
            {
                InitializeComponent();
                _code1 = code1;
                _code2 = code2;

                _date1 = d1;
                _date2 = d2;

                rbtn2.Checked = true;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                _token?.Cancel();
                _token = new CancellationTokenSource();
                Search(_token.Token, txtSearch.Text);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void rbtn2_CheckedChanged(object sender, EventArgs e) => RefreshGrid();
        private void rbtn4_CheckedChanged(object sender, EventArgs e) => RefreshGrid();
        private void rbtn6_CheckedChanged(object sender, EventArgs e) => RefreshGrid();
        private void rbtn8_CheckedChanged(object sender, EventArgs e) => RefreshGrid();
        private void frmTarazHesab_MinimumSizeChanged(object sender, EventArgs e) => RefrehTopLablesPosition();
        private void frmTarazHesab_ResizeEnd(object sender, EventArgs e) => RefrehTopLablesPosition();
        private async void frmTarazHesab_Load(object sender, EventArgs e)
        {
            await LoadDataAsync();
            RefrehTopLablesPosition();
        }
        private void frmTarazHesab_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Escape) Close();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
