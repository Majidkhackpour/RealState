﻿using System;
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
        public frmCommition(ContractBussines contract, bool isShow)
        {
            try
            {
                InitializeComponent();
                _con = contract;
                if (!isShow)
                    ucTotalCommition1.OnSumChanged += UcTotalCommition1_OnSumChanged;
                else
                {
                    ucContractVisitor1.Enabled = false;
                    ucTotalCommition1.Enabled = false;
                    UcV1.Enabled = UcV2.Enabled = false;
                    btnFinish.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void UcTotalCommition1_OnSumChanged(decimal sum)
        {
            try
            {
                UcV1.TotalPrice = sum;
                UcV2.TotalPrice = sum;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
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
        private void btnFinish_Click(object sender, EventArgs e)
        {
            try
            {
                _con.FirstTotalPrice = ucTotalCommition1.FirstTotalPrice;
                _con.fBabat = ucTotalCommition1.FirstBabat;
                _con.FirstDiscount = ucTotalCommition1.FirstDiscount;
                _con.FirstTax = ucTotalCommition1.FirstTax;
                _con.FirstAvarez = ucTotalCommition1.FirstAvarez;

                _con.SecondTotalPrice = ucTotalCommition1.SecondTotalPrice;
                _con.sBabat = ucTotalCommition1.SecondBabat;
                _con.SecondDiscount = ucTotalCommition1.SecondDiscount;
                _con.SecondTax = ucTotalCommition1.SecondTax;
                _con.SecondAvarez = ucTotalCommition1.SecondAvarez;

                if (UcV1.BazatyabGuid != null && UcV1.BazatyabGuid != Guid.Empty)
                {
                    _con.BazaryabGuid = UcV1.BazatyabGuid;
                    _con.BazaryabPrice = UcV1.Price;
                }
                if (UcV2.BazatyabGuid != null && UcV2.BazatyabGuid != Guid.Empty)
                {
                    _con.Bazaryab2Guid = UcV2.BazatyabGuid;
                    _con.Bazaryab2Price = UcV2.Price;
                }

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
    }
}
