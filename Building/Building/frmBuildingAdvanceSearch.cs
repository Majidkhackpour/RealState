using System;
using System.Linq;
using System.Windows.Forms;
using EntityCache.Bussines;
using MetroFramework.Forms;
using Services;

namespace Building.Building
{
    public partial class frmBuildingAdvanceSearch : MetroForm
    {
        private void SetData()
        {
            try
            {
                FillCmbReqType();
                FillBuildingAccountType();
                FillBuildingType();

                chbSystem.Checked = true;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void FillCmbReqType()
        {
            try
            {
                var values = Enum.GetValues(typeof(EnRequestType)).Cast<EnRequestType>();
                foreach (var item in values)
                    cmbReqType.Items.Add(item.GetDisplay());
                cmbReqType.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void FillBuildingType()
        {
            try
            {
                var list = BuildingTypeBussines.GetAll("").Where(q => q.Status).ToList();
                
                var a = new BuildingTypeBussines()
                {
                    Guid = Guid.Empty,
                    Name = "[همه]"
                };
                list.Add(a);

                bTypeBindingSource.DataSource = list.OrderBy(q => q.Name);
                if (bTypeBindingSource.Count > 0) cmbBuildingType.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void FillBuildingAccountType()
        {
            try
            {
                var list = BuildingAccountTypeBussines.GetAll("").Where(q => q.Status).ToList();
                
                var a = new BuildingAccountTypeBussines()
                {
                    Guid = Guid.Empty,
                    Name = "[همه]"
                };
                list.Add(a);

                batBindingSource.DataSource = list.OrderBy(q => q.Name);
                if (batBindingSource.Count > 0) cmbBuildingAccountType.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        public frmBuildingAdvanceSearch()
        {
            InitializeComponent();
        }

        private void frmBuildingAdvanceSearch_Load(object sender, EventArgs e)
        {
            SetData();
        }

        private void cmbReqType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbReqType.SelectedIndex == (int) EnRequestType.Rahn)
                {
                    lblSPrice1.Visible = lblSPrice2.Visible = true;
                    txtSPrice1.Visible = txtSPrice2.Visible = true;
                    lblFPrice1.Text = "رهن از";
                }
                else
                {
                    lblSPrice1.Visible = lblSPrice2.Visible = false;
                    txtSPrice1.Visible = txtSPrice2.Visible = false;
                    lblFPrice1.Text = "مبلغ از";
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private async void btnSeach_Click(object sender, EventArgs e)
        {
            try
            {
                var list = BuildingBussines.GetAllAsync(txtCode.Text, (Guid) cmbBuildingType.SelectedValue,
                    (Guid) cmbBuildingAccountType.SelectedValue, txtFMasahat.Text.ParseToInt(),
                    txtSMasahat.Text.ParseToInt(), txtRoomCount.Text.ParseToInt(), txtFPrice1.Text.ParseToDecimal(),
                    txtSPrice1.Text.ParseToDecimal(), txtFPrice2.Text.ParseToDecimal(),
                    txtSPrice2.Text.ParseToDecimal(), (EnRequestType) cmbReqType.SelectedIndex);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
