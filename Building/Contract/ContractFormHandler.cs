using EntityCache.Bussines;
using Services;
using System;
using System.Windows.Forms;

namespace Building.Contract
{
    public class ContractFormHandler
    {
        public static DialogResult FormHandler(ContractBussines con, bool isShowMode, IWin32Window owner)
        {
            try
            {
                Form frm = null;
                switch (con.Type)
                {
                    case EnRequestType.Forush:
                        frm = new frmContractMain_Sell(con, isShowMode);
                        break;
                    case EnRequestType.Rahn:
                        frm = new frmContractMain_Rahn(con, isShowMode);
                        break;
                    case EnRequestType.EjareTamlik:
                        frm = new frmContractMain_EjareTamlik(con, isShowMode);
                        break;
                    case EnRequestType.Sarqofli:
                        frm = new frmContractMain_Sarqofli(con, isShowMode);
                        break;
                    case EnRequestType.PishForush:
                        frm = new frmContractMain_PishForoush(con, isShowMode);
                        break;
                }

                return frm?.ShowDialog(owner) ?? DialogResult.Cancel;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return DialogResult.Cancel;
        }
    }
}
