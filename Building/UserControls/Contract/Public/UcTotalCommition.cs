using System;
using System.Windows.Forms;
using Services;

namespace Building.UserControls.Contract.Public
{
    public partial class UcTotalCommition : UserControl
    {
        public event Action<decimal> OnSumChanged;
        public string FirstTitle { set => UcCom1.Title = value; }
        public decimal FirstTotalPrice { get => UcCom1.TotalPrice; set => UcCom1.TotalPrice = value; }
        public decimal FirstDiscount { get => UcCom1.Discount; set => UcCom1.Discount = value; }
        public decimal FirstTax { get => UcCom1.Tax; set => UcCom1.Tax = value; }
        public decimal FirstAvarez { get => UcCom1.Avarez; set => UcCom1.Avarez = value; }
        public EnContractBabat FirstBabat { get => UcCom1.Babat; set => UcCom1.Babat = value; }
        public string SecondTitle { set => UcCom2.Title = value; }
        public decimal SecondTotalPrice { get => UcCom2.TotalPrice; set => UcCom2.TotalPrice = value; }
        public decimal SecondDiscount { get => UcCom2.Discount; set => UcCom2.Discount = value; }
        public decimal SecondTax { get => UcCom2.Tax; set => UcCom2.Tax = value; }
        public decimal SecondAvarez { get => UcCom2.Avarez; set => UcCom2.Avarez = value; }
        public EnContractBabat SecondBabat { get => UcCom2.Babat; set => UcCom2.Babat = value; }
        public UcTotalCommition()
        {
            InitializeComponent();
            UcCom1.OnSumChanged += UcCom1_OnSumChanged;
            UcCom2.OnSumChanged += UcCom2_OnSumChanged;
        }
        private void UcCom2_OnSumChanged(decimal sum) => RaiseSumChange(sum + UcCom1.TotalSum);
        private void UcCom1_OnSumChanged(decimal sum) => RaiseSumChange(sum + UcCom2.TotalSum);
        private void RaiseSumChange(decimal sum)
        {
            try
            {
                var handler = OnSumChanged;
                if (handler != null) OnSumChanged?.Invoke(sum);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
