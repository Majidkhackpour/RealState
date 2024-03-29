﻿using Print.Classes;
using Services;
using Stimulsoft.Report;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Print
{
    public class ReportGenerator
    {
        private static bool _stimulRegistered = false;
        private bool _displayPrintPreview = false;

        public StiType ReportType { get; set; }
        public StiReport Sti { get; set; }
        public bool IsLimited { get; set; }
        public Guid SanadGuid { get; set; }
        public int SanadType { get; set; }
        public List<object> Lst { get; set; }
        public int RefrenceId { get; set; }
        public object CompanyInfo { get; set; }


        public ReportGenerator(StiType reportType, EnPrintType printType)
        {
            ReportType = reportType;
            SetSti(printType);
        }
        public ReportGenerator(StiType reportType, EnPrintType printType, bool preview)
        {
            ReportType = reportType;
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
                Sti = new StiReport();
                switch (ReportType)
                {
                    case StiType.People_List:
                        Sti = clsPeoples.One.GetSti(Sti, peper);
                        break;
                    case StiType.Building_One:
                        Sti = clsBuilding.One.GetSti(Sti, peper);
                        break;
                    case StiType.Building_List:
                        Sti = clsBuilding.List.GetSti(Sti, peper);
                        break;
                    case StiType.Building_Request_One:
                        Sti = clsBuildingRequest.One.GetSti(Sti, peper);
                        break;
                    case StiType.Building_Request_List:
                        Sti = clsBuildingRequest.List.GetSti(Sti, peper);
                        break;
                    case StiType.Contract_One:
                        Sti = clsContract.One.GetSti(Sti, peper);
                        break;
                    case StiType.Contract_List:
                        Sti = clsContract.List.GetSti(Sti, peper);
                        break;
                    case StiType.Contract_Rasmi_One:
                        Sti = clsContract.One_Rasmi.GetSti(Sti, peper);
                        break;
                    case StiType.User_Performence_List:
                        Sti = clsUserPerformence.List.GetSti(Sti, peper);
                        break;
                    case StiType.Account_Performence_List:
                        Sti = clsAccountPerformence.List.GetSti(Sti, peper);
                        break;
                    case StiType.Reception_One:
                        Sti = clsReception.One.GetSti(Sti, peper);
                        break;
                    case StiType.Reception_List:
                        Sti = clsReception.List.GetSti(Sti, peper);
                        break;
                    case StiType.Pardakht_One:
                        Sti = clsPardakht.One.GetSti(Sti, peper);
                        break;
                    case StiType.Pardakht_List:
                        Sti = clsPardakht.List.GetSti(Sti, peper);
                        break;
                    case StiType.SmsSent_List:
                        Sti = clsSms.List.GetSti(Sti, peper);
                        break;
                    case StiType.AdvSent_List:
                        Sti = clsAdvertise.List.GetSti(Sti, peper);
                        break;
                    case StiType.Sood_Zian:
                        Sti = clsSood_Zian.One.GetSti(Sti, peper);
                        break;
                    case StiType.Sanad:
                        Sti = clsSanad.One.GetSti(Sti, peper);
                        break;
                    case StiType.Roozname:
                        Sti = clsRoozname.List.GetSti(Sti, peper);
                        break;
                    case StiType.TarazAzmayeshi:
                        Sti = clsTarazAzmayeshi.List.GetSti(Sti, peper);
                        break;
                    case StiType.TarazHesab:
                        Sti = clsTarazHesab.List.GetSti(Sti, peper);
                        break;
                    case StiType.DepartmentOrder:
                        Sti = clsDepartmentOrder.List.GetSti(Sti, peper);
                        break;
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        public ReturnedSaveFuncInfo Print2PrinterNew()
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                var cls = new _clsPrint();
                cls.Print2PrinterNew(Sti, SanadGuid, SanadType, Lst, RefrenceId, CompanyInfo, IsLimited);
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
                cls.PrintPreviewNew(Sti, SanadGuid, SanadType, Lst, RefrenceId, CompanyInfo, IsLimited);
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
                return cls.DesignNew(Sti, SanadGuid, SanadType, Lst, RefrenceId, CompanyInfo, IsLimited);
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
                Sti.Dictionary.Variables.Add(name, value);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
