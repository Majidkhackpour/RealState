using EntityCache.Bussines;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Building.UserControls.Contract.Public
{
    public partial class UcContractVisitor : UserControl
    {
        private decimal _totalPrice = 0;
        public Guid? BazatyabGuid => (Guid?)cmbBazaryab.SelectedValue;
        public async Task SetBazaryabGuidAsync(Guid? value)
        {
            try
            {
                if (bazaryabBindingSource.Count <= 0)
                    await LoadBazaryabAsync();
                if (value != null && value != Guid.Empty)
                    cmbBazaryab.SelectedValue = value;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        public decimal Price { get => txtBazaryabPrice.TextDecimal; set => txtBazaryabPrice.TextDecimal = value; }
        public decimal TotalPrice
        {
            get => _totalPrice;
            set
            {
                _totalPrice = value;
                if (txtBazaryabPrice.TextDecimal == 0) return;
                txtPercent.Text = Price > 0 ? (Math.Round(Price / TotalPrice, 3) * 100).ToString() : "";
                txtPercent.Text = txtPercent.Text.Replace(".", "/");
            }
        }
        private async Task LoadBazaryabAsync()
        {
            try
            {
                var list = await AdvisorBussines.GetAllAsync() ?? new List<AdvisorBussines>();
                list.Add(new AdvisorBussines()
                {
                    Guid = Guid.Empty,
                    Name = "[هیچکدام]",
                    Status = true
                });
                bazaryabBindingSource.DataSource = list.Where(q => q.Status).OrderBy(q => q.Name).ToList();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        public UcContractVisitor() => InitializeComponent();
        private void txtBazaryabPrice_OnTextChanged()
        {
            try
            {
                var currentControl = ActiveControl?.Name;
                if (string.IsNullOrEmpty(currentControl)) return;
                if (currentControl != txtBazaryabPrice.Name) return;
                txtPercent.Text = Price > 0 ? (Math.Round(Price / TotalPrice, 3) * 100).ToString() : "";
                txtPercent.Text = txtPercent.Text.Replace(".", "/");
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void txtPercent_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!txtPercent.Focused) return;
                if (txtPercent.Text.ParseToDecimal() != 0)
                {
                    var d = txtPercent.Text.ParseToDecimal() / 100;
                    Price = TotalPrice * d;
                }
                else Price = 0;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
