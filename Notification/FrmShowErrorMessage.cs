using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using Services;

namespace Notification
{
    public partial class FrmShowErrorMessage : Form
    {
        private static FrmShowErrorMessage _lastThreadFrm = null;
        short rowIndex = 0;
        //private static Bitmap errorImage = new Bitmap(Properties.Resources.Error);
        //private static Bitmap infoImage = new Bitmap(Properties.Resources.icons8_info_50);
        //private static Bitmap warningImage = new Bitmap(Properties.Resources.icons8_warning_50);

        public FrmShowErrorMessage(ReturnedSaveFuncInfo pList, string title, MessageBoxButtons boxButtons = MessageBoxButtons.OK)
        {
            try
            {
                InitializeComponent();
                DgridInitializer();
                ShowError(pList, title, boxButtons);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        

        public FrmShowErrorMessage()
        {
            try
            {
                InitializeComponent();
                DgridInitializer();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }


        private void btnReturn_Click(object sender, EventArgs e) => DialogResult = DialogResult.Retry;
        private void btnContinue_Click(object sender, EventArgs e) => DialogResult = DialogResult.Ignore;
        private void btnCancel_Click(object sender, EventArgs e) => DialogResult = DialogResult.Cancel;
        private void btnCancelAll_Click(object sender, EventArgs e) => DialogResult = DialogResult.Abort;
        private void DgridInitializer()
        {
            try
            {
                dGrid.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void LoadErrors(List<clsShowError> errorList, CancellationToken token)
        {
            try
            {
                var count = 0;
                var errorCounter = 0;
                var infoCount = 0;
                ErrorBindingSource.DataSource = errorList;
                if (errorList != null)
                    foreach (var item in errorList)
                        if (item != null)
                        {
                            if (token.IsCancellationRequested || IsDisposed) return;
                            switch (item.Type)
                            {
                                case enType.Error: errorCounter++; break;
                                case enType.Warning: infoCount++; break;
                            }
                            count++;
                        }

                if (errorCounter > 0)
                {
                    lblMessage.Text = @"بدلیل وجود خطا امکان ادامه کار وجود ندارد";
                    lblMessage.ForeColor = Color.White;
                    btnContinue.Enabled = false;

                    panelEx1.Style.BackColor1.Color = Color.IndianRed;
                    panelEx1.Style.BackColor2.Color = Color.IndianRed;
                }
                else if (infoCount > 0)
                {
                    lblMessage.Text = $"تعداد {infoCount} هشدار وجود دارد";
                    panelEx1.Style.BackColor1.Color = Color.Khaki;
                    panelEx1.Style.BackColor2.Color = Color.Khaki;
                }
                else
                {
                    lblMessage.Text = "";
                    btnContinue.Visible = btnCancel.Visible = btnAbort.Visible = false;
                    btnReturn.Visible = false;
                }

                LblCountErrors.Text = errorCounter.ToString();
                lblCountWarning.Text = infoCount.ToString();
                lblSourceName.Text = clsShowError.Source.GetDisplay();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private List<clsShowError> FillObject(CancellationToken token, ReturnedSaveFuncInfo pList = null)
        {
            var errorList = new List<clsShowError>();
            try
            {
                if (pList != null)
                {
                    if (token.IsCancellationRequested || IsDisposed) return null;
                    foreach (var item in pList.ErrorList)
                    {
                        if (token.IsCancellationRequested || IsDisposed) return null;
                        //errorList.Add(new clsShowError()
                        //{
                        //    Text = item,
                        //    Title = item,
                        //    Type = enType.Error,
                        //    Icon = errorImage
                        //});
                    }
                    foreach (var item in pList.WarningList)
                    {
                        if (token.IsCancellationRequested || IsDisposed) return null;
                        //errorList.Add(new clsShowError()
                        //{
                        //    Text = item,
                        //    Title = item,
                        //    Type = enType.Warning,
                        //    Icon = warningImage
                        //});
                    }
                    foreach (var item in pList.InformationList)
                    {
                        if (token.IsCancellationRequested || IsDisposed) return null;
                        //errorList.Add(new clsShowError()
                        //{
                        //    Text = item,
                        //    Title = item,
                        //    Type = enType.Information,
                        //    Icon = infoImage
                        //});
                    }
                }
                if (token.IsCancellationRequested || IsDisposed) return null;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                errorList = null;
            }

            return errorList;
        }

        private void FrmShowErrorMessage_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                switch (e.KeyCode)
                {
                    case Keys.Escape:
                        DialogResult = DialogResult.Cancel;
                        Close();
                        break;
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        
        private void ShowError(ReturnedSaveFuncInfo pList, string title, MessageBoxButtons boxButtons, CancellationToken token = default)
        {
            try
            {
                Text = title;
                if (boxButtons == MessageBoxButtons.OK)
                    btnContinue.Visible = btnCancel.Visible = btnAbort.Visible = false;
                else if (boxButtons == MessageBoxButtons.AbortRetryIgnore)
                    btnReturn.Visible = false;


                var errorList = FillObject(token, pList);

                LoadErrors(errorList, token);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        

        private void dGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dGrid.RowCount < 0 || dGrid.CurrentRow == null) return;
                var msg = dGrid[dgDesc.Index, dGrid.CurrentRow.Index].Value.ToString();



                if (e.ColumnIndex == dgMore.Index)
                {
                    if (e.RowIndex == rowIndex)
                    {
                        rowIndex = (short)(dGrid.RowCount + 1);
                    }
                    else
                    {
                        rowIndex = (short)e.RowIndex;
                    }

                    var frm = new frmShowErrorDetails(msg, this.WindowState);
                    frm.ShowDialog(this);
                }


            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void dGrid_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex == dgMore.Index)
                {
                    var cell = dGrid.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    cell.ToolTipText = "نمایش جزئیات";
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}