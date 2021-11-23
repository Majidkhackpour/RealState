using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityCache.Bussines;
using MetroFramework.Forms;
using Services;

namespace Building.Contract
{
    public partial class frmContractMain_Sell : MetroForm
    {
        private ContractBussines cls;
        private async Task SetDataAsync()
        {
            try
            {
                ucContractHeader1.Title = "مبایعه نامه";
                ucContractHeader1.ContractCode = cls.Code;
                ucContractHeader1.CodeInArchive = cls.CodeInArchive;
                ucContractHeader1.RealStateCode = cls.RealStateCode;
                ucContractHeader1.HologramCode = cls.HologramCode;
                ucContractHeader1.ContractDate = cls.DateM;

                ucFSide.Guid = cls.FirstSideGuid;
                ucSecondSide.Guid = cls.SecondSideGuid;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }


        public frmContractMain_Sell(ContractBussines _cls)
        {
            InitializeComponent();
            cls = _cls;
        }


        private async void frmContractMain_Sell_Load(object sender, System.EventArgs e) => await SetDataAsync();
    }
}
