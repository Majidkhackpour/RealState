﻿using System;
using System.Windows.Forms;
using Services;

namespace Print
{
    public partial class UcFilterDate : UserControl
    {
        public DateTime Date1 { get; set; }
        public DateTime Date2 { get; set; }
        public string Title { get => grpPanel.Text; set => grpPanel.Text = value; }
        public bool Today { get => rbtnToday.Checked; set => rbtnToday.Checked = value; }
        public bool All { set => rbtnAll.Checked = value; }
        public bool SpecialDate { get => rbtnSpecialDate.Checked; set => rbtnSpecialDate.Checked = value; }
        public bool BetweenDate { set => rbtnBetweenDate.Checked = value; }

        public void SetDate1(DateTime date)
        {
            try
            {
                if (SpecialDate)
                {
                    Date1 = new DateTime(date.Year, date.Month, date.Day, 0, 0, 0);
                    Date2 = new DateTime(date.Year, date.Month, date.Day, 23, 59, 59);
                    ucSpecialDate.DateM = Date1;
                }
                else
                {
                    Date1 = date;
                    UcDate1.DateM = Date1;
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        public void SetDate2(DateTime? date)
        {
            try
            {
                Date2 = date ?? new DateTime(2050, 12, 29, 23, 59, 59);
                UcDare2.DateM = Date2;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        public UcFilterDate()
        {
            try
            {
                InitializeComponent();
                ucSpecialDate.OnDateChanged += UcSpecialDate_OnDateChanged;
                UcDate1.OnDateChanged += UcDate1_OnDateChanged;
                UcDare2.OnDateChanged += UcDare2_OnDateChanged;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void UcDare2_OnDateChanged(string dateSh)
        {
            try
            {
                var date2 = UcDare2.DateM;
                Date2 = new DateTime(date2.Year, date2.Month, date2.Day, 23, 59, 59);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void UcDate1_OnDateChanged(string dateSh)
        {
            try
            {
                var date1 = Calendar.ShamsiToMiladi(dateSh);
                Date1 = new DateTime(date1.Year, date1.Month, date1.Day, 0, 0, 0);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void UcSpecialDate_OnDateChanged(string dateSh)
        {
            try
            {
                var date = Calendar.ShamsiToMiladi(dateSh);
                Date1 = new DateTime(date.Year, date.Month, date.Day, 0, 0, 0);
                Date2 = new DateTime(date.Year, date.Month, date.Day, 23, 59, 59);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void rbtnToday_CheckedChanged(object sender, System.EventArgs e)
        {
            try
            {
                ucSpecialDate.Enabled = UcDare2.Enabled = UcDate1.Enabled = false;
                Date1 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
                Date2 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void rbtnAll_CheckedChanged(object sender, System.EventArgs e)
        {
            try
            {
                ucSpecialDate.Enabled = UcDare2.Enabled = UcDate1.Enabled = false;
                Date1 = new DateTime(2000, 01, 01, 0, 0, 0);
                Date2 = new DateTime(2050, 12, 29, 23, 59, 59);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void rbtnSpecialDate_CheckedChanged(object sender, System.EventArgs e)
        {
            try
            {
                UcDare2.Enabled = UcDate1.Enabled = false;
                ucSpecialDate.Enabled = true;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void rbtnBetweenDate_CheckedChanged(object sender, System.EventArgs e)
        {
            try
            {
                UcDare2.Enabled = UcDate1.Enabled = true;
                ucSpecialDate.Enabled = false;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
