using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityCache.Bussines;
using Services;
using Settings.Classes;

namespace Settings.SettingForms
{
    public partial class frmSandouq : Form
    {
        public frmSandouq()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void txtCode_Enter(object sender, EventArgs e)
        {
            txtSetter.Focus(txtCode);
        }

        private void txtCode_Leave(object sender, EventArgs e)
        {
            txtSetter.Follow(txtCode);
        }

        private void txtNatCode_Enter(object sender, EventArgs e)
        {
            txtSetter.Focus(txtNatCode);
        }

        private void txtNatCode_Leave(object sender, EventArgs e)
        {
            txtSetter.Follow(txtNatCode);
        }

        private void txtIdCode_Enter(object sender, EventArgs e)
        {
            txtSetter.Focus(txtIdCode);
        }

        private void txtIdCode_Leave(object sender, EventArgs e)
        {
            txtSetter.Focus(txtIdCode);
        }

        private void SettData()
        {
            try
            {
                FillCmb();

                txtCode.Text = clsSandouq.NationalCode;
                txtNatCode.Text = clsSandouq.NationalCode;
                txtIdCode.Text = clsSandouq.IdCode;
                txtArzesh.Text = clsSandouq.ArzeshAfzoude;
                txtTabdil.Text = clsSandouq.Tabdil;
                cmbType.Text = clsSandouq.EconomyCodeStatus;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void FillCmb()
        {
            try
            {
                cmbType.Items.Add(EnEconomyCodeStatus.HasUserName.GetDisplay());
                cmbType.Items.Add(EnEconomyCodeStatus.HasCode.GetDisplay());
                cmbType.Items.Add(EnEconomyCodeStatus.DontHave.GetDisplay());

                cmbType.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void frmSandouq_Load(object sender, EventArgs e)
        {
            SettData();
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            try
            {
                clsSandouq.NationalCode = txtCode.Text;
                clsSandouq.NationalCode = txtNatCode.Text;
                clsSandouq.IdCode = txtIdCode.Text;
                clsSandouq.ArzeshAfzoude = txtArzesh.Text;
                clsSandouq.Tabdil = txtTabdil.Text;
                clsSandouq.EconomyCodeStatus = cmbType.Text;


                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
