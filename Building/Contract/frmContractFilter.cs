using MetroFramework.Forms;
using Peoples;
using Services;
using System;
using System.Windows.Forms;
using EntityCache.Bussines;
using Services.FilterObjects;

namespace Building.Contract
{
    public partial class frmContractFilter : MetroForm
    {
        private Guid? _tafsilGuid = null;
        public frmContractFilter()
        {
            InitializeComponent();
            ucHeader.Text = "فیلتر قراردادها";
            ucFilterDate1.Today = true;
            rbtnAll.Checked = true;
            _tafsilGuid = null;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
        private void btnFinish_Click(object sender, EventArgs e)
        {
            try
            {
                EnRequestType? type = null;
                if (rbtnPishForoush.Checked) type = EnRequestType.PishForush;
                else if (rbtnRahn.Checked) type = EnRequestType.Rahn;
                else if (rbtnSarqofli.Checked) type = EnRequestType.Sarqofli;
                else if (rbtnSell.Checked) type = EnRequestType.Forush;
                else if (rbtnTamlik.Checked) type = EnRequestType.EjareTamlik;

                var filter = new ContractFilter()
                {
                    Status = true,
                    Type = type,
                    TafsilGuid = _tafsilGuid,
                    Date1 = ucFilterDate1.Date1,
                    Date2 = ucFilterDate1.Date2
                };
                var frm = new frmShowContract(filter);
                frm.ShowDialog(this);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
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
        private async void btnSearchOwner_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new frmShowPeoples(true);
                if (frm.ShowDialog(this) != DialogResult.OK) return;
                var cus = await PeoplesBussines.GetAsync(frm.SelectedGuid, null);
                if (cus == null) return;
                _tafsilGuid = frm.SelectedGuid;
                txttxtOwnerCode.Text = cus.Name;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
