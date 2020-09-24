using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Print.Classes;
using Services;
using Stimulsoft.Report;

namespace Print
{
    public class ReportGenerator
    {
        private StiType _reportType;
        private DataSet _ds;
        private Stimulsoft.Report.StiReport _sti;
        private bool _displayPrintPreview = false;
        private int sanadId = 0;
        private int _sanadType = 0;
        private List<object> _lst;
        private static bool _stimulRegistered = false;

        public ReportGenerator(StiType reportType, EnPrintType printType)
        {
            _reportType = reportType;
            SetSti(printType);
        }
        public ReportGenerator(StiType reportType, EnPrintType printType,bool preview)
        {
            _reportType = reportType;
            _displayPrintPreview = preview;
            SetSti(printType);
        }

        public static async Task Init()
        {
            try
            {
                await Task.Delay(10 * 1000);
                if (_stimulRegistered) return;
                _stimulRegistered = true;
                Stimulsoft.Base.StiLicense.Key =
                    "6vJhGtLLLz2GNviWmUTrhSqnOItdDwjBylQzQcAOiHl2AD0gPVknKsaW0un+3PuM6TTcPMUAWEURKXNso0e5OFPaZYasFtsxNoDemsFOXbvf7SIcnyAkFX/4u37NTfx7g+0IqLXw6QIPolr1PvCSZz8Z5wjBNakeCVozGGOiuCOQDy60XNqfbgrOjxgQ5y/u54K4g7R/xuWmpdx5OMAbUbcy3WbhPCbJJYTI5Hg8C/gsbHSnC2EeOCuyA9ImrNyjsUHkLEh9y4WoRw7lRIc1x+dli8jSJxt9C+NYVUIqK7MEeCmmVyFEGN8mNnqZp4vTe98kxAr4dWSmhcQahHGuFBhKQLlVOdlJ/OT+WPX1zS2UmnkTrxun+FWpCC5bLDlwhlslxtyaN9pV3sRLO6KXM88ZkefRrH21DdR+4j79HA7VLTAsebI79t9nMgmXJ5hB1JKcJMUAgWpxT7C7JUGcWCPIG10NuCd9XQ7H4ykQ4Ve6J2LuNo9SbvP6jPwdfQJB6fJBnKg4mtNuLMlQ4pnXDc+wJmqgw25NfHpFmrZYACZOtLEJoPtMWxxwDzZEYYfT";
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void SetSti(EnPrintType peper)
        {
            try
            {
                _sti = new StiReport();
                switch (_reportType)
                {
                    case StiType.People_List: _sti = clsPeoples.One.GetSti(_sti, peper);
                        break;
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        public bool AddTable(DataTable tbl)
        {
            try
            {
                var dv = new DataView();
                dv.Table = tbl;
                AddView(dv);
                return true;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return false;
            }
        }
        public bool AddView(DataView v)
        {
            try
            {
                _ds.Tables.Add(v.ToTable());
                return true;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return false;
            }
        }
        public bool AddDs(DataSet ds)
        {
            _ds = ds;
            return true;
        }
        public ReturnedSaveFuncInfo Print2PrinterNew()
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                var cls = new _clsPrint();
                cls.Print2PrinterNew(_sti, _ds, sanadId, _sanadType, _lst);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
        }
        public ReturnedSaveFuncInfo PrintNew()
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                if (_displayPrintPreview) return PrintPreviewNew();
                return Print2PrinterNew();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
        }
        public ReturnedSaveFuncInfo PrintPreviewNew()
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                var cls = new _clsPrint();
                cls.PrintPreviewNew(_sti, _ds, sanadId, _sanadType, _lst);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
        }
        public ReturnedSaveFuncInfo DesignNew()
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                var cls = new _clsPrint();
                return cls.DesignNew(_sti, _ds, sanadId, _sanadType, _lst);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
        }
        public void AddVariable(string name, string value)
        {
            try
            {
                _sti.Dictionary.Variables.Add(name, value);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
