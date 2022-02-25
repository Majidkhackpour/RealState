using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using WindowsSerivces;
using Building.Buildings;
using EntityCache.Bussines;
using MetroFramework.Forms;
using Services;

namespace Building.BuildingMatchesItem
{
    public partial class frmShowMatchesRequester : MetroForm
    {
        public frmShowMatchesRequester(List<BuildingRequestBussines> list)
        {
            InitializeComponent();
            ucHeader.Text = "نمایش متقاضیان ملک انتخاب شده";
            reqBindingSource.DataSource = list;
        }
        private void frmShowMatchesRequester_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) Close();
        }
        private async void mnuSendSms_Click(object sender, System.EventArgs e)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                if (DGrid.RowCount <= 0)
                {
                    res.AddError("داده ای جهت ارسال پیامک وجود ندارد");
                    return;
                }
                var item = (BuildingRequestBussines)reqBindingSource.Current;
                if (item == null)
                {
                    res.AddError("آیتم انتخاب شده معتبر نمی باشد");
                    return;
                }
                var tellList = await PhoneBookBussines.GetAllAsync(item.AskerGuid, true);
                var mobiles = tellList?.Where(q => q.IsMobile())?.ToList();
                if (!(mobiles?.Any() ?? false))
                {
                    res.AddError($"برای متقاضی جاری ({item.AskerName}) تلفن تماس ثبت نشده است");
                    return;
                }

                var text = Payamak.FixSms.MathItemSend.GetText(item);
                var frm = new frmBuildingTelegramText(text, "الگوی ارسال پیامک به متقاضی");
                if (frm.ShowDialog(this) != DialogResult.OK)
                {
                    res.AddWarning("عملیات ارسال پیامک به متقاضی لغو شد");
                    return;
                }

                text = frm.TelegramText;
                res.AddReturnedValue(await Payamak.FixSms.MathItemSend.SendAsync(text, mobiles?.Select(q => q.Tell).ToList()));
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }
            finally
            {
                if (res.HasError || res.HasWarning)
                    this.ShowError(res);
                else this.ShowMessage("ارسال پیامک به متقاضی با موفقیت انجام شد");
            }
        }
    }
}
