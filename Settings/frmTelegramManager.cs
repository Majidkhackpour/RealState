﻿using System;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using MetroFramework.Forms;
using Notification;
using Services;
using Settings.Classes;

namespace Settings
{
    public partial class frmTelegramManager : MetroForm
    {
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
        private void LoadTelegram()
        {
            try
            {
                txtChannel.Text = clsTelegram.ManagerChannel;
                txtText.Text = !string.IsNullOrEmpty(clsTelegram.ManagetText)
                    ? clsTelegram.ManagetText
                    : clsTelegram.Text;
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
                clsTelegram.ManagerChannel = txtChannel.Text;
                clsTelegram.ManagetText = txtText.Text;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        public frmTelegramManager() => InitializeComponent();

        private void frmTelegramManager_Load(object sender, EventArgs e) => LoadTelegram();
        private void btnFinish_Click(object sender, EventArgs e)
        {
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
        private void btnFloorCover_Click(object sender, EventArgs e) => SetDataInTxt((ButtonX)sender, txtText);
        private void btnMobile_Click(object sender, EventArgs e) => SetDataInTxt((ButtonX)sender, txtText);
        private void btnView_Click(object sender, EventArgs e) => SetDataInTxt((ButtonX)sender, txtText);
        private void btnEjare_Click(object sender, EventArgs e) => SetDataInTxt((ButtonX)sender, txtText);
        private void btnTejari_Click(object sender, EventArgs e) => SetDataInTxt((ButtonX)sender, txtText);
        private void btnKitchenService_Click(object sender, EventArgs e) => SetDataInTxt((ButtonX)sender, txtText);
        private void btnMasahat_Click(object sender, EventArgs e) => SetDataInTxt((ButtonX)sender, txtText);
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
        private void btnOwnerName_Click(object sender, EventArgs e) => SetDataInTxt((ButtonX)sender, txtText);
        private void btnOwnerTell_Click(object sender, EventArgs e) => SetDataInTxt((ButtonX)sender, txtText);
        private void btnOwnerAddress_Click(object sender, EventArgs e) => SetDataInTxt((ButtonX)sender, txtText);
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
        private void frmTelegramManager_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                switch (e.KeyCode)
                {
                    case Keys.F5: btnFinish.PerformClick(); break;
                    case Keys.Escape: btnCancel.PerformClick(); break;
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void btnOtherOptions_Click(object sender, EventArgs e) => SetDataInTxt((ButtonX)sender, txtText);
    }
}
