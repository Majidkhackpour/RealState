using System;
using System.Linq;
using System.Windows.Forms;
using Services;

namespace Building.UserControls.Objects
{
    public partial class UcConstructionStage : UserControl
    {
        public EnConstructionStage? Stage
        {
            get => (EnConstructionStage?)cmbStage.SelectedIndex + 1;
            set
            {
                if (value == null) return;
                cmbStage.SelectedIndex = (int)value - 1;
            }
        }
        public UcConstructionStage()
        {
            InitializeComponent();
            FillCmbStage();
        }
        private void FillCmbStage()
        {
            try
            {
                var values = Enum.GetValues(typeof(EnConstructionStage)).Cast<EnConstructionStage>();
                foreach (var item in values)
                    cmbStage.Items.Add(item.GetDisplay());
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
