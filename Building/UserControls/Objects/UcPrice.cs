using System;
using System.Windows.Forms;

namespace Building.UserControls.Objects
{
    public partial class UcPrice : UserControl
    {
        public new event Action OnTextChanged;
        public string Title { get => lblTitle.Text; set => lblTitle.Text = value; }
        public decimal Price { get => txtPrice.TextDecimal; set => txtPrice.TextDecimal = value; }
        public UcPrice() => InitializeComponent();
        private void RaiseEvent()
        {
            var handler = OnTextChanged;
            if (handler != null)
                OnTextChanged?.Invoke();
        }
        private void txtPrice_OnTextChanged() => RaiseEvent();
    }
}
