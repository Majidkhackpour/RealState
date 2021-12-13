using System;
using System.Windows.Forms;
using WindowsSerivces;
using EntityCache.Bussines;
using MetroFramework.Forms;
using Services;

namespace Building.Contract
{
    public partial class frmCommition : MetroForm
    {
        private ContractBussines _con;
        private void SetData()
        {
            try
            {
                ucTotalCommition1.FirstTitle = "کمیسیون طرف اول";
                ucTotalCommition1.SecondTitle = "کمیسیون طرف دوم";
                if (_con.IsModified && (_con.FirstTotalPrice != 0 || _con.SecondTotalPrice != 0))
                {
                    ucTotalCommition1.FirstTotalPrice = _con.FirstTotalPrice;
                    ucTotalCommition1.FirstBabat = _con.fBabat;
                    ucTotalCommition1.FirstDiscount = _con.FirstDiscount;
                    ucTotalCommition1.FirstTax = _con.FirstTax;
                    ucTotalCommition1.FirstAvarez = _con.FirstAvarez;

                    ucTotalCommition1.SecondTotalPrice = _con.SecondTotalPrice;
                    ucTotalCommition1.SecondBabat = _con.sBabat;
                    ucTotalCommition1.SecondDiscount = _con.SecondDiscount;
                    ucTotalCommition1.SecondTax = _con.SecondTax;
                    ucTotalCommition1.SecondAvarez = _con.SecondAvarez;
                }
                else CalculateCommition();

                UcV1.BazatyabGuid = _con.BazaryabGuid;
                UcV2.BazatyabGuid = _con.Bazaryab2Guid;
                UcV1.Price = _con.BazaryabPrice;
                UcV2.Price = _con.Bazaryab2Price;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void CalculateCommition()
        {
            try
            {
                decimal commition = 0;
                if (_con.Type == EnRequestType.Rahn)
                {
                    var tabdilPercent = Settings.Classes.clsSandouq.Tabdil.ParseToInt();
                    commition = Contract.CalculateCommition.CalculateEjare(_con.TotalPrice, _con.MinorPrice, tabdilPercent);
                    ucTotalCommition1.FirstBabat = EnContractBabat.Ejare;
                    ucTotalCommition1.SecondBabat = EnContractBabat.Ejare;
                }
                else if (_con.Type == EnRequestType.Forush)
                {
                    commition = Contract.CalculateCommition.CalculateKharid(_con.TotalPrice);
                    ucTotalCommition1.FirstBabat = EnContractBabat.Foroush;
                    ucTotalCommition1.SecondBabat = EnContractBabat.Foroush;
                }

                ucTotalCommition1.FirstTotalPrice = commition;
                ucTotalCommition1.SecondTotalPrice = commition;

                var arzehPercent = Settings.Classes.clsSandouq.ArzeshAfzoude.ParseToInt();
                var arzesh = (commition * arzehPercent) / 100;

                ucTotalCommition1.FirstTax = arzesh;
                ucTotalCommition1.SecondTax = arzesh;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        public frmCommition(ContractBussines contract)
        {
            InitializeComponent();
            _con = contract;
        }
        private void frmCommition_Load(object sender, System.EventArgs e)
        {
            try
            {
                if (_con == null)
                {
                    this.ShowWarning("قرارداد مورد نظر یافت نشد");
                    return;
                }

                SetData();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void frmCommition_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            try
            {
                switch (e.KeyCode)
                {
                    case Keys.F5: btnFinish.PerformClick(); break;
                    case Keys.Escape: btnCancel.PerformClick(); break;
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
