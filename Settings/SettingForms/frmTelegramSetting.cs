using System;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using Services;
using Settings.Classes;

namespace Settings.SettingForms
{
    public partial class frmTelegramSetting : Form
    {
        private void SettData()
        {
            try
            {
                txtToken.Text = clsTelegram.Token;
                txtChannel.Text = clsTelegram.Channel;
                txtText.Text = clsTelegram.Text;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        public frmTelegramSetting()
        {
            InitializeComponent();
        }
        private void SetDataInTxt(ButtonX btn, TextBox txt)
        {
            try
            {
                var insertText = btn.Text;
                var selectionIndex = txt.SelectionStart;
                txt.Text = txt.Text.Insert(selectionIndex, insertText);
                txt.SelectionStart = selectionIndex + insertText.Length;
                txt.Focus();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void txtToken_Enter(object sender, System.EventArgs e)
        {
            txtSetter.Focus(txtToken);
        }

        private void txtToken_Leave(object sender, System.EventArgs e)
        {
            txtSetter.Follow(txtToken);
        }

        private void txtChannel_Enter(object sender, System.EventArgs e)
        {
            txtSetter.Focus(txtChannel);
        }

        private void txtChannel_Leave(object sender, System.EventArgs e)
        {
            txtSetter.Follow(txtChannel);
        }

        private void frmTelegramSetting_Load(object sender, EventArgs e)
        {
            SettData();
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            try
            {
                clsTelegram.Token = txtToken.Text;
                clsTelegram.Channel = txtChannel.Text;
                clsTelegram.Text = txtText.Text;


                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void btnCode_Click(object sender, EventArgs e)
        {
            SetDataInTxt((ButtonX)sender, txtText);
        }

        private void btnType_Click(object sender, EventArgs e)
        {
            SetDataInTxt((ButtonX)sender, txtText);
        }

        private void btnConType_Click(object sender, EventArgs e)
        {
            SetDataInTxt((ButtonX)sender, txtText);
        }

        private void btnAccType_Click(object sender, EventArgs e)
        {
            SetDataInTxt((ButtonX)sender, txtText);
        }

        private void btnRegion_Click(object sender, EventArgs e)
        {
            SetDataInTxt((ButtonX)sender, txtText);
        }

        private void btnSell_Click(object sender, EventArgs e)
        {
            SetDataInTxt((ButtonX)sender, txtText);
        }

        private void btnRahn_Click(object sender, EventArgs e)
        {
            SetDataInTxt((ButtonX)sender, txtText);
        }

        private void btnEjare_Click(object sender, EventArgs e)
        {
            SetDataInTxt((ButtonX)sender, txtText);
        }

        private void btnMasahat_Click(object sender, EventArgs e)
        {
            SetDataInTxt((ButtonX)sender, txtText);
        }

        private void btnZirBana_Click(object sender, EventArgs e)
        {
            SetDataInTxt((ButtonX)sender, txtText);
        }

        private void btnDocType_Click(object sender, EventArgs e)
        {
            SetDataInTxt((ButtonX)sender, txtText);
        }

        private void btnSide_Click(object sender, EventArgs e)
        {
            SetDataInTxt((ButtonX)sender, txtText);
        }

        private void btnTarakom_Click(object sender, EventArgs e)
        {
            SetDataInTxt((ButtonX)sender, txtText);
        }

        private void btnTabaqeNo_Click(object sender, EventArgs e)
        {
            SetDataInTxt((ButtonX)sender, txtText);
        }

        private void btnTabaqeCount_Click(object sender, EventArgs e)
        {
            SetDataInTxt((ButtonX)sender, txtText);
        }

        private void btnRoomCount_Click(object sender, EventArgs e)
        {
            SetDataInTxt((ButtonX)sender, txtText);
        }

        private void btnSaleSakht_Click(object sender, EventArgs e)
        {
            SetDataInTxt((ButtonX)sender, txtText);
        }

        private void btnTejari_Click(object sender, EventArgs e)
        {
            SetDataInTxt((ButtonX)sender, txtText);
        }

        private void btnChannel_Click(object sender, EventArgs e)
        {
            SetDataInTxt((ButtonX)sender, txtText);
        }
    }
}
