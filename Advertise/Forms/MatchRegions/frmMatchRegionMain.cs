﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityCache.Bussines;
using EntityCache.ViewModels;
using MetroFramework.Forms;
using Notification;
using Services;

namespace Advertise.Forms.MatchRegions
{
    public partial class frmMatchRegionMain : MetroForm
    {
        private DivarRegion _region;
        private List<AdvertiseRelatedRegionBussines> _list = new List<AdvertiseRelatedRegionBussines>();
        private CancellationTokenSource _token = new CancellationTokenSource();

        private async Task LoadRegionsAsync()
        {
            try
            {
                _token?.Cancel();
                _token = new CancellationTokenSource();
                var list = await RegionsBussines.GetAllAsync(SettingsBussines.Setting.CompanyInfo.EconomyCity, _token.Token);
                regBingingSource.DataSource = list?.OrderBy(q => q.Name)?.ToSortableBindingList();

                await SetRelatedRegionsAsync(_region.Name.Trim());
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async Task SetRelatedRegionsAsync(string onlineRegion)
        {
            try
            {
                if (string.IsNullOrEmpty(onlineRegion)) return;
                var op = await AdvertiseRelatedRegionBussines.GetAllAsync(onlineRegion);
                foreach (var item in op)
                    for (var i = 0; i < DGrid.RowCount; i++)
                        if (item.LocalRegionGuid == ((Guid?)DGrid[dgGuid.Index, i].Value ?? Guid.Empty))
                            DGrid[dgIsChecked.Index, i].Value = true;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async Task SetDataAsync()
        {
            try
            {
                _token?.Cancel();
                _token = new CancellationTokenSource();
                var list = await RegionsBussines.GetAllAsync(_token.Token);
                if (list.Count <= 0) return;
                foreach (var item in list)
                    for (var i = 0; i < DGrid.RowCount; i++)
                        if (item.Guid == ((Guid?)DGrid[dgGuid.Index, i].Value ?? Guid.Empty))
                        {
                            if (!(bool)DGrid[dgIsChecked.Index, i].Value) continue;
                            _list.Add(new AdvertiseRelatedRegionBussines()
                            {
                                Guid = Guid.NewGuid(),
                                LocalRegionGuid = item.Guid,
                                OnlineRegionName = _region.Name.Trim()
                            });
                        }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        public frmMatchRegionMain(DivarRegion region)
        {
            InitializeComponent();
            _region = region;
        }

        private async void frmMatchRegionMain_Load(object sender, System.EventArgs e)
        {
            await LoadRegionsAsync();
            lblName.Text = _region.Name;
        }

        private void DGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DGrid.Rows[e.RowIndex].Cells["dgRadif"].Value = e.RowIndex + 1;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void frmMatchRegionMain_KeyDown(object sender, KeyEventArgs e)
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

        private async void btnFinish_Click(object sender, EventArgs e)
        {
            try
            {
                await SetDataAsync();

                var res = await AdvertiseRelatedRegionBussines.SaveRangeAsync(_list);
                if (res.HasError)
                {
                    frmNotification.PublicInfo.ShowMessage(res.ErrorMessage);
                    return;
                }

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var list = await AdvertiseRelatedRegionBussines.GetAllAsync(_region.Name.Trim());

                var res = await AdvertiseRelatedRegionBussines.RemoveRangeAsync(list);
                if (res.HasError)
                {
                    frmNotification.PublicInfo.ShowMessage(res.ErrorMessage);
                    return;
                }

                await LoadRegionsAsync();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
