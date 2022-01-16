using EntityCache.Bussines;
using Services;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Peoples
{
    public partial class UcPeopleSelect : UserControl
    {
        private Guid _guid;
        public event Func<Guid, Task> OnShowNumbers;
        public event Func<Guid, Task> OnShowFiles;
        public Guid Guid => _guid;

        public async Task SetGuidAsync(Guid value)
        {
            try
            {
                if (value == Guid.Empty) return;
                _guid = value;
                var pe = await PeoplesBussines.GetAsync(_guid, null);
                if (pe == null) return;
                LoadData(pe);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void LoadData(PeoplesBussines owner)
        {
            try
            {
                txttxtOwnerCode.Text = owner?.Code;
                lblOwnerAddress.Text = owner?.Address;
                lblOwnerFatherName.Text = owner?.FatherName;
                lblOwnerNCode.Text = owner?.NationalCode;
                lblOwnerName.Text = owner?.Name;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void RaiseShowNumber(Guid guid)
        {
            try
            {
                var handler = OnShowNumbers;
                if (handler != null) OnShowNumbers?.Invoke(guid);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void RaiseShowFiles(Guid guid)
        {
            try
            {
                var handler = OnShowFiles;
                if (handler != null) OnShowFiles?.Invoke(guid);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        public UcPeopleSelect() => InitializeComponent();
        private async void btnCreateOwner_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new frmPeoples(new PeoplesBussines(), false);
                if (frm.ShowDialog(this) != DialogResult.OK) return;
                await SetGuidAsync(frm.SelectedGuid);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async void btnSearchOwner_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new frmShowPeoples(true);
                if (frm.ShowDialog(this) != DialogResult.OK) return;
                await SetGuidAsync(frm.SelectedGuid);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void mnuPhone_Click(object sender, EventArgs e) => RaiseShowNumber(Guid.Empty);
        private void mnuFiles_Click(object sender, EventArgs e) => RaiseShowFiles(Guid.Empty);
    }
}
