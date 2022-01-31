using System;
using MetroFramework.Forms;
using Services;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsSerivces;
using EntityCache.Bussines;

namespace Building.Buildings.Selector
{
    public partial class frmSelectBuildingType_ : MetroForm
    {
        private EnContractType _type;
        private EnContractType_ _type2;
        private List<EnContractType_> _lstItems;
        private IWin32Window owner;
        private BuildingBussines bu;

        private void Make_Buttons()
        {
            try
            {
                if (_lstItems == null || _lstItems.Count == 0) return;
                fPanel.AutoScroll = true;
                for (var i = fPanel.Controls.Count - 1; i >= 0; i--)
                    fPanel.Controls[i].Dispose();
                for (var i = 0; i < _lstItems.Count; i++)
                {
                    try
                    {
                        var btn = new UcButton();
                        Controls.Add(btn);
                        btn.Size = new Size(210, 44);
                        btn.Name = "btn" + i;
                        btn.Title = _lstItems[i].GetDisplay();
                        btn.Cursor = Cursors.Hand;
                        btn.Type = _lstItems[i];
                        btn.OnClick += BtnOnOnClick;
                        fPanel.Controls.Add(btn);
                    }
                    catch (Exception)
                    {
                        _lstItems.RemoveAt(i);
                    }
                }
            }
            catch (Exception exception)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(exception);
            }
        }
        private async Task BtnOnOnClick(UcButton sender)
        {
            try
            {
                sender.IsSelect = true;
                _type2 = sender.Type;
                timer1.Enabled = true;
                timer1.Start();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private EnBuildingParent TypeSwitcher()
        {
            try
            {
                if (_type == EnContractType.Forush)
                {
                    switch (_type2)
                    {
                        case EnContractType_.Appartment:
                            return EnBuildingParent.SellAprtment;
                        case EnContractType_.Office:
                            return EnBuildingParent.SellOffice;
                        case EnContractType_.Garden:
                            return EnBuildingParent.SellGarden;
                        case EnContractType_.Home:
                            return EnBuildingParent.SellHome;
                        case EnContractType_.Land:
                            return EnBuildingParent.SellLand;
                        case EnContractType_.OldHouse:
                            return EnBuildingParent.SellOldHouse;
                        case EnContractType_.Store:
                            return EnBuildingParent.SellStore;
                        case EnContractType_.Villa:
                            return EnBuildingParent.SellVilla;
                    }
                }
                else if (_type == EnContractType.RahnEjare)
                {
                    switch (_type2)
                    {
                        case EnContractType_.Appartment:
                            return EnBuildingParent.RentAprtment;
                        case EnContractType_.Office:
                            return EnBuildingParent.RentOffice;
                        case EnContractType_.Home:
                            return EnBuildingParent.RentHome;
                        case EnContractType_.Store:
                            return EnBuildingParent.RentStore;
                    }
                }
                else if (_type == EnContractType.FullRahn)
                {
                    switch (_type2)
                    {
                        case EnContractType_.Appartment:
                            return EnBuildingParent.FullRentAprtment;
                        case EnContractType_.Office:
                            return EnBuildingParent.FullRentOffice;
                        case EnContractType_.Home:
                            return EnBuildingParent.FullRentHome;
                        case EnContractType_.Store:
                            return EnBuildingParent.FullRentStore;
                    }
                }
                else if (_type == EnContractType.PishForush)
                {
                    switch (_type2)
                    {
                        case EnContractType_.Appartment:
                            return EnBuildingParent.PreSellAprtment;
                        case EnContractType_.Office:
                            return EnBuildingParent.PreSellOffice;
                        case EnContractType_.Home:
                            return EnBuildingParent.PreSellHome;
                        case EnContractType_.Store:
                            return EnBuildingParent.PreSellStore;
                    }
                }
                else if (_type == EnContractType.Moavezeh)
                {
                    switch (_type2)
                    {
                        case EnContractType_.Appartment:
                            return EnBuildingParent.MoavezeAprtment;
                        case EnContractType_.Office:
                            return EnBuildingParent.MoavezeOffice;
                        case EnContractType_.Home:
                            return EnBuildingParent.MoavezeHome;
                        case EnContractType_.Store:
                            return EnBuildingParent.MoavezeStore;
                    }
                }
                else if (_type == EnContractType.Mosharekat)
                {
                    switch (_type2)
                    {
                        case EnContractType_.Appartment:
                            return EnBuildingParent.MosharekatAprtment;
                        case EnContractType_.Home:
                            return EnBuildingParent.MosharekatHome;
                    }
                }
                return EnBuildingParent.None;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return EnBuildingParent.None;
            }
        }

        public frmSelectBuildingType_(IWin32Window _owner, EnContractType type, List<EnContractType_> lstItems,BuildingBussines _bu)
        {
            InitializeComponent();
            owner = _owner;
            _type = type;
            _lstItems = lstItems;
            bu = _bu;
            Make_Buttons();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                timer1.Stop();
                Close();
                bu.Parent = TypeSwitcher();
                new frmBuilding(bu,false).ShowDialog(owner);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
