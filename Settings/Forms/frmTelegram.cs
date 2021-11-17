﻿using System;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using MetroFramework.Forms;
using Notification;
using Services;
using Settings.Classes;

namespace Settings.Forms
{
    public partial class frmTelegram : MetroForm
    {
        private void LoadTelegram()
        {
            try
            {
                txtToken.Text = clsTelegram.Token;
                txtChannel.Text = clsTelegram.Channel;
                txtText.Text = clsTelegram.Text;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void SaveTelegram()
        {
            try
            {
                clsTelegram.Token = txtToken.Text;
                clsTelegram.Channel = txtChannel.Text;
                clsTelegram.Text = txtText.Text;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void SetDataInTxt(ButtonX btn, TextBox txt)
        {
            try
            {
                var insertText = btn.Text;
                var selectionIndex = txt.SelectionStart;
                txt.Text = txt.Text.Insert(selectionIndex, insertText);
                txt.SelectionStart = selectionIndex + insertText.Length;
                txt.Focus();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        public frmTelegram() => InitializeComponent();
        private void frmTelegram_Load(object sender, System.EventArgs e) => LoadTelegram();
        private void btnFinish_Click(object sender, System.EventArgs e)
        {
            btnFinish.Enabled = false;
            try
            {
                SaveTelegram();
                frmNotification.PublicInfo.ShowMessage("تنظیمات با موفقیت ثبت شد");
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
            finally
            {
                btnFinish.Enabled = true;
            }
        }
        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
        private void frmTelegram_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Escape) btnCancel.PerformClick();
                else if (e.KeyCode == Keys.F5) btnFinish.PerformClick();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void btnType_Click(object sender, EventArgs e) => SetDataInTxt((ButtonX)sender, txtText);
        private void btnCode_Click(object sender, EventArgs e) => SetDataInTxt((ButtonX)sender, txtText);
        private void btnDocType_Click(object sender, EventArgs e) => SetDataInTxt((ButtonX)sender, txtText);
        private void btnSide_Click(object sender, EventArgs e) => SetDataInTxt((ButtonX)sender, txtText);
        private void btnConType_Click(object sender, EventArgs e) => SetDataInTxt((ButtonX)sender, txtText);
        private void btnTarakom_Click(object sender, EventArgs e) => SetDataInTxt((ButtonX)sender, txtText);
        private void btnAccType_Click(object sender, EventArgs e) => SetDataInTxt((ButtonX)sender, txtText);
        private void btnTabaqeNo_Click(object sender, EventArgs e) => SetDataInTxt((ButtonX)sender, txtText);
        private void btnRegion_Click(object sender, EventArgs e) => SetDataInTxt((ButtonX)sender, txtText);
        private void btnTabaqeCount_Click(object sender, EventArgs e) => SetDataInTxt((ButtonX)sender, txtText);
        private void btnSell_Click(object sender, EventArgs e) => SetDataInTxt((ButtonX)sender, txtText);
        private void btnRoomCount_Click(object sender, EventArgs e) => SetDataInTxt((ButtonX)sender, txtText);
        private void btnRahn_Click(object sender, EventArgs e) => SetDataInTxt((ButtonX)sender, txtText);
        private void btnSaleSakht_Click(object sender, EventArgs e) => SetDataInTxt((ButtonX)sender, txtText);
        private void btnAddress_Click(object sender, EventArgs e) => SetDataInTxt((ButtonX)sender, txtText);
        private void btnFloorCover_Click(object sender, EventArgs e) => SetDataInTxt((ButtonX)sender, txtText);
        private void btnMobile_Click(object sender, EventArgs e) => SetDataInTxt((ButtonX)sender, txtText);
        private void btnView_Click(object sender, EventArgs e) => SetDataInTxt((ButtonX)sender, txtText);
        private void btnEjare_Click(object sender, EventArgs e) => SetDataInTxt((ButtonX)sender, txtText);
        private void btnTejari_Click(object sender, EventArgs e) => SetDataInTxt((ButtonX)sender, txtText);
        private void btnTell_Click(object sender, EventArgs e) => SetDataInTxt((ButtonX)sender, txtText);
        private void btnKitchenService_Click(object sender, EventArgs e) => SetDataInTxt((ButtonX)sender, txtText);
        private void btnMasahat_Click(object sender, EventArgs e) => SetDataInTxt((ButtonX)sender, txtText);
        private void btnChannel_Click(object sender, EventArgs e) => SetDataInTxt((ButtonX)sender, txtText);
        private void btnZirBana_Click(object sender, EventArgs e) => SetDataInTxt((ButtonX)sender, txtText);
        private void btnDong_Click(object sender, EventArgs e) => SetDataInTxt((ButtonX)sender, txtText);
        private void btnPricePerMeter_Click(object sender, EventArgs e) => SetDataInTxt((ButtonX)sender, txtText);
        private void btnVahedPerTabaqe_Click(object sender, EventArgs e) => SetDataInTxt((ButtonX)sender, txtText);
        private void btnHitting_Click(object sender, EventArgs e) => SetDataInTxt((ButtonX)sender, txtText);
        private void btnParking_Click(object sender, EventArgs e) => SetDataInTxt((ButtonX)sender, txtText);
        private void btnColling_Click(object sender, EventArgs e) => SetDataInTxt((ButtonX)sender, txtText);
        private void btnEvelator_Click(object sender, EventArgs e) => SetDataInTxt((ButtonX)sender, txtText);
        private void btnStore_Click(object sender, EventArgs e) => SetDataInTxt((ButtonX)sender, txtText);
        private void btnBalcony_Click(object sender, EventArgs e) => SetDataInTxt((ButtonX)sender, txtText);
        private void btnOtherOptions_Click(object sender, EventArgs e) => SetDataInTxt((ButtonX)sender, txtText);
        private void btnTelegramManager_Click(object sender, EventArgs e) => new frmTelegramManager().ShowDialog(this);
    }
}