﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityCache.Bussines;
using MetroFramework.Forms;
using Print;
using Services;

namespace Accounting
{
    public partial class frmGardeshHesab : MetroForm
    {
        private Guid _hesabGuid;
        private IEnumerable<GardeshHesabBussines> list;
        private async Task LoadDataAsync(Guid hesabGuid, string search = "")
        {
            try
            {
                list = await GardeshHesabBussines.GetAllAsync(hesabGuid, search);
                gardeshBindingSource.DataSource = list.Where(q => q.Status).ToSortableBindingList();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void SetLabels(EnAccountingType _type)
        {
            try
            {
                //if (_type == EnAccountingType.Peoples)
                //{
                //   var hesab = PeoplesBussines.Get(_hesabGuid);
                //   if (hesab == null) return;
                //   lblName.Text = hesab.Name;
                //   lblAccount.Text = hesab.Account_.ToString("N0");
                //   if (hesab.Account == 0)
                //   {
                //       lblAccount.Text = "بی حساب";
                //       lblAccount_.ForeColor = Color.Black;
                //   }
                //   if (hesab.Account > 0)
                //   {
                //       lblAccount_.Text = "بدهکار";
                //       lblAccount_.ForeColor = Color.Red;
                //   }
                //   if (hesab.Account < 0)
                //   {
                //       lblAccount_.Text = "بستانکار";
                //       lblAccount_.ForeColor = Color.Green;
                //   }
                //}
                //else if (_type == EnAccountingType.Hazine)
                //{
                //   var hesab = HazineBussines.Get(_hesabGuid);
                //   if (hesab == null) return;
                //   lblName.Text = hesab.Name;
                //   lblAccount.Text = hesab.Account_.ToString("N0");
                //   if (hesab.Account == 0)
                //   {
                //       lblAccount.Text = "بی حساب";
                //       lblAccount_.ForeColor = Color.Black;
                //   }
                //   if (hesab.Account > 0)
                //   {
                //       lblAccount_.Text = "بدهکار";
                //       lblAccount_.ForeColor = Color.Red;
                //   }
                //   if (hesab.Account < 0)
                //   {
                //       lblAccount_.Text = "بستانکار";
                //       lblAccount_.ForeColor = Color.Green;
                //   }
                //}
                //else if (_type == EnAccountingType.Users)
                //{
                //    var hesab = UserBussines.Get(_hesabGuid);
                //    if (hesab == null) return;
                //    lblName.Text = hesab.Name;
                //    lblAccount.Text = hesab.Account_.ToString("N0");
                //    if (hesab.Account == 0)
                //    {
                //        lblAccount.Text = "بی حساب";
                //        lblAccount_.ForeColor = Color.Black;
                //    }
                //    if (hesab.Account > 0)
                //    {
                //        lblAccount_.Text = "بدهکار";
                //        lblAccount_.ForeColor = Color.Red;
                //    }
                //    if (hesab.Account < 0)
                //    {
                //        lblAccount_.Text = "بستانکار";
                //        lblAccount_.ForeColor = Color.Green;
                //    }
                //}
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        public frmGardeshHesab(Guid hesabGuid, EnAccountingType type)
        {
            InitializeComponent();
            _hesabGuid = hesabGuid;
            SetLabels(type);
        }

        private async void frmGardeshHesab_Load(object sender, EventArgs e) => await LoadDataAsync(_hesabGuid);

        private async void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                await LoadDataAsync(_hesabGuid, txtSearch.Text);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void DGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DGrid.Rows[e.RowIndex].Cells["dgRadif"].Value = e.RowIndex + 1;
        }

        private void frmGardeshHesab_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new frmSetPrintSize();
                if (frm.ShowDialog(this) != DialogResult.OK) return;
                if (frm._PrintType != EnPrintType.Excel)
                {
                    var cls = new ReportGenerator(StiType.Account_Performence_List, frm._PrintType)
                        {Lst = new List<object>(list)};
                    cls.PrintNew();
                    return;
                }

                ExportToExcel.ExportGardesh(list,this);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
