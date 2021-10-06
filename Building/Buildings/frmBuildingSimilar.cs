using System;
using System.Linq;
using System.Windows.Forms;
using MetroFramework.Forms;
using Services;

namespace Building.Buildings
{
    public partial class frmBuildingSimilar : MetroForm
    {
        private void CalculateSellPrice(short type)
        {
            try
            {
                //Type=0 ==> Masaht
                //Type=1 ==> ZirBana
                decimal masahat = 0, zirbana = 0;

                if (cmbMasahat.SelectedIndex == 0)
                    masahat = txtMasahat.Value;
                else
                    masahat = txtMasahat.Value * 10000;

                if (cmbZirBana.SelectedIndex == 0)
                    zirbana = txtZirBana.Value;
                else
                    zirbana = txtZirBana.Value * 10000;


                if (type == 0)
                    txtSellPrice.TextDecimal = txtPricePerMasashat.TextDecimal * masahat;
                else if (type == 1)
                    txtSellPrice.TextDecimal = txtPricePerZirBana.TextDecimal * zirbana;

                if (masahat > 0)
                {
                    txtPricePerMasashat.TextDecimal = 0;
                    txtPricePerMasashat.TextDecimal = txtSellPrice.TextDecimal / masahat;
                }
                if (zirbana > 0)
                {
                    txtPricePerZirBana.TextDecimal = 0;
                    txtPricePerZirBana.TextDecimal = txtSellPrice.TextDecimal / zirbana;
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void FillCmbMetr()
        {
            try
            {
                var values = Enum.GetValues(typeof(EnMetr)).Cast<EnMetr>();
                foreach (var item in values)
                {
                    cmbMasahat.Items.Add(item.GetDisplay());
                    cmbZirBana.Items.Add(item.GetDisplay());
                }

                cmbMasahat.SelectedIndex = 0;
                cmbZirBana.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        public int Masahat
        {
            get => (int)txtMasahat.Value;
            set
            {
                if (value == 0)
                {
                    txtMasahat.Value = 0;
                    cmbMasahat.SelectedIndex = 0;
                }
                if (value != 0)
                {
                    if (value >= 10000)
                    {
                        txtMasahat.Text = (value / 10000).ToString();
                        cmbMasahat.SelectedIndex = 1;
                    }
                    if (value <= 9999)
                    {
                        txtMasahat.Text = value.ToString();
                        cmbMasahat.SelectedIndex = 0;
                    }
                }
            }
        }
        public int ZirBana
        {
            get => (int)txtZirBana.Value;
            set
            {
                if (value == 0)
                {
                    txtZirBana.Text = value.ToString();
                    cmbZirBana.SelectedIndex = 0;
                }
                if (value != 0)
                {
                    if (value >= 10000)
                    {
                        txtZirBana.Text = (value / 10000).ToString();
                        cmbZirBana.SelectedIndex = 1;
                    }
                    if (value <= 9999)
                    {
                        txtZirBana.Text = value.ToString();
                        cmbZirBana.SelectedIndex = 0;
                    }
                }
            }
        }
        public int RoomCount { get => (int)txtTedadOtaq.Value; set => txtTedadOtaq.Value = value; }
        public decimal Rahn { get => txtRahnPrice1.TextDecimal; set => txtRahnPrice1.TextDecimal = value; }
        public decimal Ejare { get => txtEjarePrice1.TextDecimal; set => txtEjarePrice1.TextDecimal = value; }
        public decimal Sell
        {
            get => txtSellPrice.TextDecimal;
            set
            {
                txtSellPrice.TextDecimal = value;
                txtSellPrice_OnTextChanged();
            }
        }
        public int TabaqeNo { get=> cmbTabaqeNo.Text.ParseToInt(); set=>cmbTabaqeNo.Text=value.ToString(); }
        public clsBuildingSimilar BuildingSimilar { get; set; }

        public frmBuildingSimilar(clsBuildingSimilar s)
        {
            try
            {
                InitializeComponent();
                FillCmbMetr();
                ZirBana = s.ZirBana;
                Masahat = s.Masahat;
                RoomCount = s.RoomCount;
                Rahn = s.RahnPrice;
                Ejare = s.EjarePrice;
                Sell = s.SellPrice;
                TabaqeNo = s.TabaqeNo;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void txtSellPrice_OnTextChanged()
        {
            try
            {
                var currentControl = ActiveControl?.Name;
                if (string.IsNullOrEmpty(currentControl)) return;
                if (currentControl != txtSellPrice.Name) return;
                decimal masahat = 0, zirbana = 0;

                if (cmbMasahat.SelectedIndex == 0)
                    masahat = txtMasahat.Value;
                else
                    masahat = txtMasahat.Value * 10000;

                if (cmbZirBana.SelectedIndex == 0)
                    zirbana = txtZirBana.Value;
                else
                    zirbana = txtZirBana.Value * 10000;

                txtPricePerMasashat.TextDecimal = txtPricePerZirBana.TextDecimal = 0;

                if (masahat > 0)
                {
                    var m = Math.Truncate(txtSellPrice.TextDecimal / masahat);
                    txtPricePerMasashat.TextDecimal = m;
                }

                if (zirbana > 0)
                {
                    var m = Math.Truncate(txtSellPrice.TextDecimal / zirbana);
                    txtPricePerZirBana.TextDecimal = m;
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void txtPricePerMasashat_OnTextChanged()
        {
            try
            {
                var currentControl = ActiveControl?.Name;
                if (string.IsNullOrEmpty(currentControl)) return;
                if (currentControl != txtPricePerMasashat.Name) return;
                decimal masahat = 0, zirbana = 0;

                if (cmbMasahat.SelectedIndex == 0)
                    masahat = txtMasahat.Value;
                else
                    masahat = txtMasahat.Value * 10000;

                if (cmbZirBana.SelectedIndex == 0)
                    zirbana = txtZirBana.Value;
                else
                    zirbana = txtZirBana.Value * 10000;

                if (masahat > 0)
                    txtSellPrice.TextDecimal = txtPricePerMasashat.TextDecimal * masahat;
                if (zirbana <= 0) return;
                txtPricePerZirBana.TextDecimal = 0;
                var m = Math.Truncate(txtSellPrice.TextDecimal / zirbana);
                txtPricePerZirBana.TextDecimal = m;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void txtPricePerZirBana_OnTextChanged()
        {
            try
            {
                var currentControl = ActiveControl?.Name;
                if (string.IsNullOrEmpty(currentControl)) return;
                if (currentControl != txtPricePerZirBana.Name) return;
                decimal masahat = 0, zirbana = 0;

                if (cmbZirBana.SelectedIndex == 0)
                    zirbana = txtZirBana.Value;
                else
                    zirbana = txtZirBana.Value * 10000;

                if (cmbMasahat.SelectedIndex == 0)
                    masahat = txtMasahat.Value;
                else
                    masahat = txtMasahat.Value * 10000;

                if (zirbana > 0)
                    txtSellPrice.TextDecimal = txtPricePerZirBana.TextDecimal * zirbana;
                if (masahat <= 0) return;
                txtPricePerMasashat.TextDecimal = 0;
                var m = Math.Truncate(txtSellPrice.TextDecimal / masahat);
                txtPricePerMasashat.TextDecimal = m;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void txtMasahat_ValueChanged(object sender, EventArgs e) => CalculateSellPrice(0);
        private void txtZirBana_ValueChanged(object sender, EventArgs e) => CalculateSellPrice(1);
        private void cmbMasahat_SelectedIndexChanged(object sender, EventArgs e) => CalculateSellPrice(0);
        private void cmbZirBana_SelectedIndexChanged(object sender, EventArgs e) => CalculateSellPrice(1);
        private void btnFinish_Click(object sender, EventArgs e)
        {
            try
            {
                BuildingSimilar = new clsBuildingSimilar()
                {
                    Masahat = Masahat,
                    SellPrice = Sell,
                    RoomCount = RoomCount,
                    ZirBana = ZirBana,
                    EjarePrice = Ejare,
                    RahnPrice = Rahn,
                    Guid = Guid.NewGuid(),
                    TabaqeNo = cmbTabaqeNo.Text.ParseToInt()
                };
                DialogResult = DialogResult.OK;
                Close();
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
        private void frmBuildingSimilar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5) btnFinish.PerformClick();
            if (e.KeyCode == Keys.Escape) btnCancel.PerformClick();
        }
    }
}
