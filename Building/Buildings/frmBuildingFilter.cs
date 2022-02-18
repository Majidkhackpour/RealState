using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cities.Region;
using EntityCache.Bussines;
using MetroFramework.Forms;
using Services;
using Services.FilterObjects;

namespace Building.Buildings
{
    public partial class frmBuildingFilter : MetroForm
    {
        private CancellationTokenSource _token = new CancellationTokenSource();
        private List<Guid> _regList;
        private BuildingFilter _filter;

        public BuildingFilter Filter
        {
            get
            {
                try
                {
                    if (cmbBuildingType.SelectedValue != null)
                        _filter.BuildingTypeGuid = (Guid?)cmbBuildingType.SelectedValue;
                    if (cmbUser.SelectedValue != null)
                        _filter.UserGuid = (Guid?)cmbUser.SelectedValue;
                    if (cmbAccType.SelectedValue != null)
                        _filter.BuildingAccountTypeGuid = (Guid?)cmbAccType.SelectedValue;
                    if (cmbDocType.SelectedValue != null)
                        _filter.DocumentTypeGuid = (Guid?)cmbDocType.SelectedValue;

                    if (rbtnAdvType_All.Checked)
                        _filter.AdvertiseType = null;
                    else if (rbtnAdvType_None.Checked)
                        _filter.AdvertiseType = AdvertiseType.None;
                    else if (rbtnAdvType_Recieved.Checked)
                        _filter.AdvertiseType = AdvertiseType.Divar;

                    _filter.IsFullRahn = rbtnFullRahn.Checked;
                    _filter.IsRahn = rbtnRahn.Checked;
                    _filter.IsSell = rbtnSell.Checked;
                    _filter.IsPishForoush = rbtnPishForoush.Checked;
                    _filter.IsMosharekat = rbtnMosharekat.Checked;

                    if (chbRegion.Checked) _filter.RegionList = _regList;

                    _filter.RoomCount1 = (int)txtRoomCount1.Value;
                    _filter.RoomCount2 = (int)txtRoomCount2.Value;
                    _filter.Masahat1 = (int)txtFMasahat.Value;
                    _filter.Masahat2 = (int)txtSMasahat.Value;
                    _filter.ZirBana1 = (int)txtZirBana1.Value;
                    _filter.ZirBana2 = (int)txtZirBana2.Value;
                    _filter.SellPrice1 = txtSell1.TextDecimal;
                    _filter.SellPrice2 = txtSell2.TextDecimal;
                    _filter.RahnPrice1 = txtRahn1.TextDecimal;
                    _filter.RahnPrice2 = txtRahn2.TextDecimal;
                    _filter.EjarePrice1 = txtEjare1.TextDecimal;
                    _filter.EjarePrice2 = txtEjare2.TextDecimal;
                    _filter.MaxTabaqeNo = (int)txtTabaqeNo.Value;

                    _filter.IsArchive = chbIsArchive.Checked;
                    _filter.CreateDate1 = ucFilterDate1.Date1;
                    _filter.CreateDate2 = ucFilterDate1.Date2;
                    if (cmbZoncan.SelectedValue != null)
                        _filter.ZoncanGuid = (Guid?)cmbZoncan.SelectedValue;
                }
                catch (Exception ex)
                {
                    WebErrorLog.ErrorInstence.StartErrorLog(ex);
                }
                return _filter;
            }
            set
            {
                try
                {
                    _filter = value;
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
                    txtTabaqeNo.Value = value.MaxTabaqeNo;

                    if (value.ZoncanGuid != null)
                        cmbZoncan.SelectedValue = value.ZoncanGuid;
                    if (value.IsArchive != null) chbIsArchive.Checked = value.IsArchive.Value;
                    if (value.CreateDate1 == null && value.CreateDate2 == null)
                        ucFilterDate1.All = true;
                    else
                    {
                        if (value.CreateDate1 != null)
                            ucFilterDate1.Date1 = value.CreateDate1.Value;
                        if (value.CreateDate2 != null)
                            ucFilterDate1.Date2 = value.CreateDate2.Value;
                    }
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

                var list2 = await UserBussines.GetAllAsync(_token.Token);
                list2.Add(new UserBussines()
                {
                    Guid = Guid.Empty,
                    Name = "[همه]"
                });

                var list3 = await DocumentTypeBussines.GetAllAsync(_token.Token);
                list3.Add(new DocumentTypeBussines()
                {
                    Guid = Guid.Empty,
                    Name = "[همه]"
                });

                var list4 = await BuildingAccountTypeBussines.GetAllAsync(_token.Token);
                list4.Add(new BuildingAccountTypeBussines()
                {
                    Guid = Guid.Empty,
                    Name = "[همه]"
                });

                var list5 = await BuildingZoncanBussines.GetAllAsync(_token.Token);
                list5.Add(new BuildingZoncanBussines()
                {
                    Guid = Guid.Empty,
                    Name = "[همه]"
                });


                while (!IsHandleCreated)
                    await Task.Delay(100);

                BeginInvoke(new MethodInvoker(() =>
                {
                    btBindingSource.DataSource = list?.OrderBy(q => q.Name)?.ToList();
                    userBindingSource.DataSource = list2?.Where(q => q.Status)?.OrderBy(q => q.Name)?.ToList();
                    docTypeBindingSource.DataSource = list3?.OrderBy(q => q.Name)?.ToList();
                    AccTypeBindingSource.DataSource = list4?.OrderBy(q => q.Name)?.ToList();
                    zoncanBindingSource.DataSource = list5?.OrderBy(q => q.Name)?.ToList();
                    cmbBuildingType.SelectedIndex = 0;
                    cmbUser.SelectedIndex = 0;
                    cmbDocType.SelectedIndex = 0;
                    cmbAccType.SelectedIndex = 0;
                    cmbZoncan.SelectedIndex = 0;
                }));
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
            Task.Run(FillCmbAsync);
            ucFilterDate1.All = true;
        }

        private async void chbRegion_CheckedChanged(object sender, System.EventArgs e)
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
                    await frm.SetGuidAsync(_regList);
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
