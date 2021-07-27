using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityCache.Bussines;
using EntityCache.ViewModels;
using MetroFramework.Forms;
using Services;
using Settings.Classes;

namespace Advertise.Forms
{
    public partial class frmRobotSetting : MetroForm
    {
        private void SettData()
        {
            try
            {
                SetCategory();

                chbSilent.Checked = clsAdvertise.IsSilent;
                chbChat.Checked = clsAdvertise.IsGiveChat;

                txtD_DayCount.Value = clsAdvertise.Divar_AdvCountInDay;
                txtD_MountCount.Value = clsAdvertise.Divar_AdvCountInMounth;
                txtD_PicCount.Value = clsAdvertise.Divar_PicCountInPerAdv;
                txtD_Update.Value = clsAdvertise.Divar_DayCountForUpdateState;

                txtSh_DayCount.Value = clsAdvertise.Sheypoor_AdvCountInDay;
                txtSh_MounthCount.Value = clsAdvertise.Sheypoor_AdvCountInMounth;
                txtSh_PicCount.Value = clsAdvertise.Sheypoor_PicCountInPerAdv;
                txtSh_Update.Value = clsAdvertise.Sheypoor_DayCountForUpdateState;

                if (string.IsNullOrEmpty(clsAdvertise.Sender)) rbtnRealState.Checked = true;
                else
                {
                    if (clsAdvertise.Sender == "املاک") rbtnRealState.Checked = true;
                    else rbtnShakhsi.Checked = true;
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void SetCategory()
        {
            try
            {
                var list = SerializedDataBussines.GetDivarCategory();
                if (list == null || list.Count <= 0) return;
                foreach (var item in list)
                {
                    switch (item.Category)
                    {
                        case EnDivarCategory.RentAppartment:
                            chbRentAppartment.Checked = item.Value;
                            break;
                        case EnDivarCategory.RentVilla:
                            chbRentVilla.Checked = item.Value;
                            break;
                        case EnDivarCategory.BuyAppartment:
                            chbBuyAppartment.Checked = item.Value;
                            break;
                        case EnDivarCategory.BuyVilla:
                            chbBuyVilla.Checked = item.Value;
                            break;
                        case EnDivarCategory.BuyOldHouse:
                            chbBuyOldHouse.Checked = item.Value;
                            break;
                        case EnDivarCategory.BuyOffice:
                            chbBuyOffice.Checked = item.Value;
                            break;
                        case EnDivarCategory.BuyStore:
                            chbBuyStore.Checked = item.Value;
                            break;
                        case EnDivarCategory.BuyGuard:
                            chbBuyGuard.Checked = item.Value;
                            break;
                        case EnDivarCategory.RentOffice:
                            chbRentOffice.Checked = item.Value;
                            break;
                        case EnDivarCategory.RentStore:
                            chbRentStore.Checked = item.Value;
                            break;
                        case EnDivarCategory.RentGuard:
                            chbRentGuard.Checked = item.Value;
                            break;
                        case EnDivarCategory.ContributionConstruction:
                            chbContributionConstruction.Checked = item.Value;
                            break;
                        case EnDivarCategory.PreBuy:
                            chbPreBuy.Checked = item.Value;
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async Task SaveCategoryAsync()
        {
            try
            {
                var list = new List<DivarCategory>
                {
                    new DivarCategory() {Category = EnDivarCategory.RentAppartment, Value = chbRentAppartment.Checked},
                    new DivarCategory() {Category = EnDivarCategory.RentVilla, Value = chbRentVilla.Checked},
                    new DivarCategory() {Category = EnDivarCategory.BuyAppartment, Value = chbBuyAppartment.Checked},
                    new DivarCategory() {Category = EnDivarCategory.BuyVilla, Value = chbBuyVilla.Checked},
                    new DivarCategory() {Category = EnDivarCategory.BuyOldHouse, Value = chbBuyOldHouse.Checked},
                    new DivarCategory() {Category = EnDivarCategory.BuyOffice, Value = chbBuyOffice.Checked},
                    new DivarCategory() {Category = EnDivarCategory.BuyStore, Value = chbBuyStore.Checked},
                    new DivarCategory() {Category = EnDivarCategory.BuyGuard, Value = chbBuyGuard.Checked},
                    new DivarCategory() {Category = EnDivarCategory.RentOffice, Value = chbRentOffice.Checked},
                    new DivarCategory() {Category = EnDivarCategory.RentStore, Value = chbRentStore.Checked},
                    new DivarCategory() {Category = EnDivarCategory.RentGuard, Value = chbRentGuard.Checked},
                    new DivarCategory() {Category = EnDivarCategory.ContributionConstruction, Value = chbContributionConstruction.Checked},
                    new DivarCategory() {Category = EnDivarCategory.PreBuy, Value = chbPreBuy.Checked}
                };

                var serializedData = new SerializedDataBussines()
                {
                    Guid = Guid.NewGuid(),
                    Name = "DivarCategory",
                    Data = Json.ToStringJson(list)
                };
                await SerializedDataBussines.SaveAsync("DivarCategory", serializedData.Data);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        public frmRobotSetting()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
        private void frmRobotSetting_Load(object sender, EventArgs e)
        {
            SettData();
        }
        private async void btnFinish_Click(object sender, EventArgs e)
        {
            try
            {
                clsAdvertise.IsSilent = chbSilent.Checked;
                clsAdvertise.IsGiveChat = chbChat.Checked;

                clsAdvertise.Divar_AdvCountInDay = (int)txtD_DayCount.Value;
                clsAdvertise.Divar_AdvCountInMounth = (int)txtD_MountCount.Value;
                clsAdvertise.Divar_PicCountInPerAdv = (int)txtD_PicCount.Value;
                clsAdvertise.Divar_DayCountForUpdateState = (int)txtD_Update.Value;

                clsAdvertise.Sheypoor_AdvCountInDay = (int)txtSh_DayCount.Value;
                clsAdvertise.Sheypoor_AdvCountInMounth = (int)txtSh_MounthCount.Value;
                clsAdvertise.Sheypoor_PicCountInPerAdv = (int)txtSh_PicCount.Value;
                clsAdvertise.Sheypoor_DayCountForUpdateState = (int)txtSh_Update.Value;

                clsAdvertise.Sender = rbtnRealState.Checked ? "املاک" : "شخصی";

                await SaveCategoryAsync();

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void frmRobotSetting_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                switch (e.KeyCode)
                {
                    case Keys.Enter:
                        if (!btnFinish.Focused && !btnCancel.Focused)
                            SendKeys.Send("{Tab}");
                        break;
                    case Keys.F5:
                        btnFinish.PerformClick();
                        break;
                    case Keys.Escape:
                        btnCancel.PerformClick();
                        break;
                }
            }
            catch (Exception exception)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(exception);
            }
        }
    }
}
