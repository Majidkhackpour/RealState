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
                userBindingSource.DataSource = list2.OrderBy(q => q.Name).ToList();

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
        }

        private void chbRegion_CheckedChanged(object sender, System.EventArgs e)
        {
            try
            {
                if (!chbRegion.Checked)
                {
                    _regList = null;
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
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async void frmBuildingFilter_Load(object sender, EventArgs e) => await FillCmbAsync();
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
