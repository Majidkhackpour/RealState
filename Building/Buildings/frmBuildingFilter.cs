using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cities.Region;
using EntityCache.Bussines;
using MetroFramework.Forms;
using Nito.AsyncEx;
using Services;
using Services.FilterObjects;

namespace Building.Buildings
{
    public partial class frmBuildingFilter : MetroForm
    {
        private CancellationTokenSource _token = new CancellationTokenSource();
        private List<Guid> _regList;

        public BuildingFilter Filter
        {
            get
            {
                var filter = new BuildingFilter();
                try
                {
                    if (cmbBuildingType.SelectedValue != null)
                        filter.BuildingTypeGuid = (Guid?)cmbBuildingType.SelectedValue;
                    if (cmbUser.SelectedValue != null)
                        filter.UserGuid = (Guid?)cmbUser.SelectedValue;
                    if (cmbAccType.SelectedValue != null)
                        filter.BuildingAccountTypeGuid = (Guid?)cmbAccType.SelectedValue;
                    if (cmbDocType.SelectedValue != null)
                        filter.DocumentTypeGuid = (Guid?)cmbDocType.SelectedValue;

                    if (rbtnAdvType_All.Checked)
                        filter.AdvertiseType = null;
                    else if (rbtnAdvType_None.Checked)
                        filter.AdvertiseType = AdvertiseType.None;
                    else if (rbtnAdvType_Recieved.Checked)
                        filter.AdvertiseType = AdvertiseType.Divar;

                    filter.IsFullRahn = rbtnFullRahn.Checked;
                    filter.IsRahn = rbtnRahn.Checked;
                    filter.IsSell = rbtnSell.Checked;
                    filter.IsPishForoush = rbtnPishForoush.Checked;
                    filter.IsMosharekat = rbtnMosharekat.Checked;

                    if (chbRegion.Checked) filter.RegionList = _regList;

                    filter.RoomCount1 = (int)txtRoomCount1.Value;
                    filter.RoomCount2 = (int)txtRoomCount2.Value;
                    filter.Masahat1 = (int)txtFMasahat.Value;
                    filter.Masahat2 = (int)txtSMasahat.Value;
                    filter.ZirBana1 = (int)txtZirBana1.Value;
                    filter.ZirBana2 = (int)txtZirBana2.Value;
                    filter.SellPrice1 = txtSell1.TextDecimal;
                    filter.SellPrice2 = txtSell2.TextDecimal;
                    filter.RahnPrice1 = txtRahn1.TextDecimal;
                    filter.RahnPrice2 = txtRahn2.TextDecimal;
                    filter.EjarePrice1 = txtEjare1.TextDecimal;
                    filter.EjarePrice2 = txtEjare2.TextDecimal;
                }
                catch (Exception ex)
                {
                    WebErrorLog.ErrorInstence.StartErrorLog(ex);
                }
                return filter;
            }
            set
            {
                try
                {
                    if (value.BuildingTypeGuid != null)
                        cmbBuildingType.SelectedValue = value.BuildingTypeGuid;
                    if (value.BuildingAccountTypeGuid != null)
                        cmbAccType.SelectedValue = value.BuildingAccountTypeGuid;
                    if (value.UserGuid != null)
                        cmbUser.SelectedValue = value.UserGuid;
                    if (value.DocumentTypeGuid != null)
                        cmbDocType.SelectedValue = value.DocumentTypeGuid;

                    if (value.AdvertiseType == null)
                        rbtnAdvType_All.Checked = true;
                    else if (value.AdvertiseType == AdvertiseType.None)
                        rbtnAdvType_None.Checked = true;
                    else if (value.AdvertiseType == AdvertiseType.Divar)
                        rbtnAdvType_Recieved.Checked = true;

                    if (value.IsFullRahn) rbtnFullRahn.Checked = true;
                    else if (value.IsRahn) rbtnRahn.Checked = true;
                    else if (value.IsSell) rbtnSell.Checked = true;
                    else if (value.IsMosharekat) rbtnMosharekat.Checked = true;
                    else if (value.IsPishForoush) rbtnPishForoush.Checked = true;
                    else rbtnAll.Checked = true;

                    if (value.RegionList != null && value.RegionList.Count > 0)
                    {
                        _regList = value.RegionList;
                        chbRegion.Checked = true;
                        lblRegionCount.Visible = true;
                        lblRegionCount.Text = $@"تعداد منطقه انتخاب شده جهت فیلتر: {value.RegionList.Count}";
                    }

                    txtRoomCount1.Value = value.RoomCount1;
                    txtRoomCount2.Value = value.RoomCount2;
                    txtFMasahat.Value = value.Masahat1;
                    txtSMasahat.Value = value.Masahat2;
                    txtZirBana1.Value = value.ZirBana1;
                    txtZirBana2.Value = value.ZirBana2;
                    txtSell1.TextDecimal = value.SellPrice1;
                    txtSell2.TextDecimal = value.SellPrice2;
                    txtRahn1.TextDecimal = value.RahnPrice1;
                    txtRahn2.TextDecimal = value.RahnPrice2;
                    txtEjare1.TextDecimal = value.EjarePrice1;
                    txtEjare2.TextDecimal = value.EjarePrice2;
                }
                catch (Exception ex)
                {
                    WebErrorLog.ErrorInstence.StartErrorLog(ex);
                }
            }
        }

        private async Task FillCmbAsync()
        {
            try
            {
                _token?.Cancel();
                _token = new CancellationTokenSource();
                var list = await BuildingTypeBussines.GetAllAsync(_token.Token);
                list.Add(new BuildingTypeBussines()
                {
                    Guid = Guid.Empty,
                    Name = "[همه]"
                });
                btBindingSource.DataSource = list.OrderBy(q => q.Name).ToList();

                _token?.Cancel();
                _token = new CancellationTokenSource();
                var list2 = await UserBussines.GetAllAsync(_token.Token);
                list2.Add(new UserBussines()
                {
                    Guid = Guid.Empty,
                    Name = "[همه]"
                });
                userBindingSource.DataSource = list2?.Where(q => q.Status)?.OrderBy(q => q.Name).ToList();

                _token?.Cancel();
                _token = new CancellationTokenSource();
                var list3 = await DocumentTypeBussines.GetAllAsync(_token.Token);
                list3.Add(new DocumentTypeBussines()
                {
                    Guid = Guid.Empty,
                    Name = "[همه]"
                });
                docTypeBindingSource.DataSource = list3.OrderBy(q => q.Name).ToList();

                _token?.Cancel();
                _token = new CancellationTokenSource();
                var list4 = await BuildingAccountTypeBussines.GetAllAsync(_token.Token);
                list4.Add(new BuildingAccountTypeBussines()
                {
                    Guid = Guid.Empty,
                    Name = "[همه]"
                });
                AccTypeBindingSource.DataSource = list4.OrderBy(q => q.Name).ToList();

                cmbBuildingType.SelectedIndex = 0;
                cmbUser.SelectedValue = UserBussines.CurrentUser.Guid;
                cmbDocType.SelectedIndex = 0;
                cmbAccType.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        public frmBuildingFilter()
        {
            InitializeComponent();
            ucHeader.Text = "فیلتر املاک";
            AsyncContext.Run(FillCmbAsync);
        }

        private void chbRegion_CheckedChanged(object sender, System.EventArgs e)
        {
            try
            {
                if (!chbRegion.Focused) return;
                if (!chbRegion.Checked)
                {
                    _regList = null;
                    lblRegionCount.Visible = false;
                    return;
                }
                var frm = new frmSelectRegion();
                if (_regList != null && _regList.Count > 0)
                    frm.Guids = _regList;
                if (frm.ShowDialog(this) != DialogResult.OK)
                {
                    chbRegion.Checked = false;
                    return;
                }
                _regList = frm.Guids;
                lblRegionCount.Visible = true;
                lblRegionCount.Text = $"تعداد منطقه انتخاب شده جهت فیلتر: {_regList.Count}";
                frm.Dispose();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
        private void btnFinish_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            return;
        }
        private void frmBuildingFilter_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                switch (e.KeyCode)
                {
                    case Keys.Escape: btnCancel.PerformClick(); break;
                    case Keys.F5: btnFinish.PerformClick(); break;
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
