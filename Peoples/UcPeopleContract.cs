using System;
using System.Windows.Forms;
using EntityCache.Bussines;
using Services;

namespace Peoples
{
    public partial class UcPeopleContract : UserControl
    {
        private Guid _guid;
        public Guid Guid
        {
            get => _guid;
            set
            {
                if (value == Guid.Empty) return;
                _guid = value;
                var pe = PeoplesBussines.Get(_guid, null);
                if (pe == null) return;
                LoadData(pe);
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
        private void btnCreateOwner_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new frmPeoples();
                if (frm.ShowDialog(this) != DialogResult.OK) return;
                Guid = frm.SelectedGuid;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void btnSearchOwner_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new frmShowPeoples(true);
                if (frm.ShowDialog(this) != DialogResult.OK) return;
                Guid = frm.SelectedGuid;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
