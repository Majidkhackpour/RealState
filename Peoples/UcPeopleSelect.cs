using EntityCache.Bussines;
using Services;
using System;
using System.Windows.Forms;

namespace Peoples
{
    public partial class UcPeopleSelect : UserControl
    {
        private Guid _guid;
        public event Action OnShowNumbers;
        public event Action OnShowFiles;
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
        private void RaiseShowNumber()
        {
            try
            {
                var handler = OnShowNumbers;
                if (handler != null) OnShowNumbers?.Invoke();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void RaiseShowFiles()
        {
            try
            {
                var handler = OnShowFiles;
                if (handler != null) OnShowFiles?.Invoke();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        public UcPeopleSelect() => InitializeComponent();
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
        private void mnuPhone_Click(object sender, EventArgs e) => RaiseShowNumber();
        private void mnuFiles_Click(object sender, EventArgs e) => RaiseShowFiles();
    }
}
