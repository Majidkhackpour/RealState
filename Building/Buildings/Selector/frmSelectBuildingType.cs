using MetroFramework.Forms;
using Services;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WindowsSerivces;
using EntityCache.Bussines;

namespace Building.Buildings.Selector
{
    public partial class frmSelectBuildingType : MetroForm
    {
        private EnContractType type = EnContractType.None;
        private IWin32Window owner;
        private BuildingBussines bu;
        private void SwitchSelect(UcButton uc)
        {
            try
            {
                ucForoush.IsSelect = false;
                ucRahnEjare.IsSelect = false;
                ucFullRahn.IsSelect = false;
                ucPishForoush.IsSelect = false;
                ucMoaveze.IsSelect = false;
                ucMosharekat.IsSelect = false;

                if (uc.Name == ucForoush.Name)
                {
                    ucForoush.IsSelect = true;
                    type = EnContractType.Forush;
                }
                if (uc.Name == ucRahnEjare.Name)
                {
                    ucRahnEjare.IsSelect = true;
                    type = EnContractType.RahnEjare;
                }
                if (uc.Name == ucFullRahn.Name)
                {
                    ucFullRahn.IsSelect = true;
                    type = EnContractType.FullRahn;
                }
                if (uc.Name == ucPishForoush.Name)
                {
                    ucPishForoush.IsSelect = true;
                    type = EnContractType.PishForush;
                }
                if (uc.Name == ucMoaveze.Name)
                {
                    ucMoaveze.IsSelect = true;
                    type = EnContractType.Moavezeh;
                }
                if (uc.Name == ucMosharekat.Name)
                {
                    ucMosharekat.IsSelect = true;
                    type = EnContractType.Mosharekat;
                }

                if (type != EnContractType.None)
                {
                    timer1.Enabled = true;
                    timer1.Start();
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        public frmSelectBuildingType(IWin32Window _owner, BuildingBussines _bu)
        {
            InitializeComponent();
            owner = _owner;
            bu = _bu;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                timer1.Stop();
                Close();
                var list = new List<EnContractType_>();

                if (type == EnContractType.Forush)
                {
                    list.Add(EnContractType_.Appartment);
                    list.Add(EnContractType_.Home);
                    list.Add(EnContractType_.Land);
                    list.Add(EnContractType_.Villa);
                    list.Add(EnContractType_.Store);
                    list.Add(EnContractType_.Office);
                    list.Add(EnContractType_.Garden);
                    list.Add(EnContractType_.OldHouse);
                }
                else if (type == EnContractType.Mosharekat)
                {
                    list.Add(EnContractType_.Appartment);
                    list.Add(EnContractType_.Home);
                }
                else
                {
                    list.Add(EnContractType_.Appartment);
                    list.Add(EnContractType_.Home);
                    list.Add(EnContractType_.Store);
                    list.Add(EnContractType_.Office);
                }

                new frmSelectBuildingType_(owner, type, list, bu).ShowDialog();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async System.Threading.Tasks.Task ucForoush_OnClick_1(UcButton arg) => SwitchSelect(arg);
        private async System.Threading.Tasks.Task ucRahnEjare_OnClick(UcButton arg) => SwitchSelect(arg);
        private async System.Threading.Tasks.Task ucFullRahn_OnClick(UcButton arg) => SwitchSelect(arg);
        private async System.Threading.Tasks.Task ucPishForoush_OnClick(UcButton arg) => SwitchSelect(arg);
        private async System.Threading.Tasks.Task ucMoaveze_OnClick(UcButton arg) => SwitchSelect(arg);
        private async System.Threading.Tasks.Task ucMosharekat_OnClick(UcButton arg) => SwitchSelect(arg);
        private async void frmSelectBuildingType_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                switch (e.KeyCode)
                {
                    case Keys.Escape: Close(); break;
                    case Keys.F1: await ucForoush_OnClick_1(ucForoush); break;
                    case Keys.F2: await ucRahnEjare_OnClick(ucRahnEjare); break;
                    case Keys.F3: await ucFullRahn_OnClick(ucFullRahn); break;
                    case Keys.F4: await ucPishForoush_OnClick(ucPishForoush); break;
                    case Keys.F5: await ucMoaveze_OnClick(ucMoaveze); break;
                    case Keys.F6: await ucMosharekat_OnClick(ucMosharekat); break;
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
