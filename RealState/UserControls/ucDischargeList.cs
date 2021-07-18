using System;
using System.Windows.Forms;
using WindowsSerivces;
using EntityCache.Bussines;
using EntityCache.ViewModels;
using Notification;
using Services;

namespace RealState.UserControls
{
    public partial class ucDischargeList : UserControl
    {
        private BuildingDischargeViewModel _model;
        public BuildingDischargeViewModel Model
        {
            get => _model;
            set
            {
                _model = value;
                if (_model == null) return;
                lblCode.Text = $@"کدقرارداد: {_model.Code}";
                lblDate.Text = $@"تاریخ تخلیه: {_model.ToDateSh}";
                lblOwner.Text = $@"مالک: {_model.FSideName}";
                lblMostajer.Text = $@"مستاجر:{_model.SSideName}";
            }
        }
        public ucDischargeList() => InitializeComponent();
        private async void lblOwner_Click(object sender, System.EventArgs e)
        {
            try
            {
                var bu = await BuildingBussines.GetAsync(Model.BuildingGuid);
                if (bu == null) return;
                if (!bu.IsArchive) return;
                if (MessageBox.Show("آیا مایلید ملک قرارداد جاری را از بایگانی خارج نمایید؟", "پیشغام سیستم", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    return;
                bu.IsArchive = false;
                bu.CreateDate = DateTime.Now;
                await bu.SaveAsync();
                this.ShowMessage("ملک قرارداد موردنظر از بایگانی خارج شد");
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
