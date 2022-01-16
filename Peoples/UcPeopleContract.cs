using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityCache.Bussines;
using Services;

namespace Peoples
{
    public partial class UcPeopleContract : UserControl
    {
        private Guid _guid;
        public event Action<Guid> OnChanged;
        public Guid Guid => _guid;

        public async Task SetGuidAsync(Guid value)
        {
            try
            {
                if (value == Guid.Empty) return;
                _guid = value;
                var pe =await PeoplesBussines.GetAsync(_guid, null);
                if (pe == null) return;
                RaiseChange(_guid);
                LoadData(pe);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        public string Title { get => grpPanel.Text; set => grpPanel.Text = value; }
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
        public UcPeopleContract() => InitializeComponent();
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
        private void RaiseChange(Guid guid)
        {
            try
            {
                var handler = OnChanged;
                if (handler != null) OnChanged?.Invoke(guid);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
