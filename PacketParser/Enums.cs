using System;
using PacketParser.Services;

namespace PacketParser
{
    public enum EnPartDate
    {
        [PersianNameAttribute.PersianName("سال")] Year = 1,
        [PersianNameAttribute.PersianName("ماه")] Mounth = 2,
        [PersianNameAttribute.PersianName("روز")] Day = 3
    }
    public enum StatusCode
    {
        InPublishQueue = 1, //  در صف انتشار,
        Published = 2,//  منتشر شده,
        EditNeeded = 3,// "نیاز به اصلاح"
        WaitForPayment = 4,//  "منتظر پرداخت"
        Failed = 5,//  "رد شده"
        Deleted = 6,//  "حذف شده"
        Expired = 7,//  "منقضی شده"
        InsertError = 10,//  "خطای درج"
        Unknown = 0//  "نامشخص"
    }
    public enum EnEconomyType : int
    {
        [PersianNameAttribute.PersianName("مشاور املاک")] Amlak = 0,
        [PersianNameAttribute.PersianName("انبوه ساز")] AnbouhSaz = 1,
        [PersianNameAttribute.PersianName("سایر")] Sayer = 2
    }
    public enum EnPhoneBookGroup : short
    {
        [PersianNameAttribute.PersianName("[همه گروه ها]")] All = 0,
        [PersianNameAttribute.PersianName("اشخاص")] Peoples = 1,
        [PersianNameAttribute.PersianName("کاربران")] Users = 2,
        [PersianNameAttribute.PersianName("دریافت شده از دیوار")] Divar = 3
    }
    public enum EnSecurityQuestion : short
    {
        [PersianNameAttribute.PersianName("فامیل معلم کلاس سوم شما چه بود؟")] One = 0,
        [PersianNameAttribute.PersianName("نام دومین حیوان خانگی که داشتید چه بود؟")] Tow = 1,
        [PersianNameAttribute.PersianName("وقتی بچه بودبد، دوست داشتید در آینده چه کاره شوید؟")] Three = 2,
        [PersianNameAttribute.PersianName("زمان تحویل سال 1395 کجا بودید؟")] Four = 3,
        [PersianNameAttribute.PersianName("زمانی که خبر زلزله کرمانشاه را شنیدید، کجا بودید؟")] Five = 4,
        [PersianNameAttribute.PersianName("قهرمان دوران کودکی شما که بود؟")] Six = 5,
    }
    public enum ReturnedState : short
    {
        Information = 1,
        Error = 2,
        Warning = 3
    }
    public enum ServiceState
    {
        Unknown = -1, // The state cannot be (has not been) retrieved.
        NotFound = 0, // The service is not known on the host server.
        Stopped = 1,
        StartPending = 2,
        StopPending = 3,
        Running = 4,
        ContinuePending = 5,
        PausePending = 6,
        Paused = 7
    }

    [Flags]
    public enum ScmAccessRights
    {
        Connect = 0x0001,
        CreateService = 0x0002,
        EnumerateService = 0x0004,
        Lock = 0x0008,
        QueryLockStatus = 0x0010,
        ModifyBootConfig = 0x0020,
        StandardRightsRequired = 0xF0000,
        AllAccess = (StandardRightsRequired | Connect | CreateService |
                     EnumerateService | Lock | QueryLockStatus | ModifyBootConfig)
    }

    [Flags]
    public enum ServiceAccessRights
    {
        QueryConfig = 0x1,
        ChangeConfig = 0x2,
        QueryStatus = 0x4,
        EnumerateDependants = 0x8,
        Start = 0x10,
        Stop = 0x20,
        PauseContinue = 0x40,
        Interrogate = 0x80,
        UserDefinedControl = 0x100,
        Delete = 0x00010000,
        StandardRightsRequired = 0xF0000,
        AllAccess = (StandardRightsRequired | QueryConfig | ChangeConfig |
                     QueryStatus | EnumerateDependants | Start | Stop | PauseContinue |
                     Interrogate | UserDefinedControl)
    }

    public enum ServiceBootFlag
    {
        Start = 0x00000000,
        SystemStart = 0x00000001,
        AutoStart = 0x00000002,
        DemandStart = 0x00000003,
        Disabled = 0x00000004
    }

    public enum ServiceControl
    {
        Stop = 0x00000001,
        Pause = 0x00000002,
        Continue = 0x00000003,
        Interrogate = 0x00000004,
        Shutdown = 0x00000005,
        ParamChange = 0x00000006,
        NetBindAdd = 0x00000007,
        NetBindRemove = 0x00000008,
        NetBindEnable = 0x00000009,
        NetBindDisable = 0x0000000A
    }

    public enum ServiceError
    {
        Ignore = 0x00000000,
        Normal = 0x00000001,
        Severe = 0x00000002,
        Critical = 0x00000003
    }
    public enum EnCreateDataBase
    {
        Unknown = 0,
        ServerConnectionStringError = 1,
        DatabaseNameEmpty = 2,
        DatabaseExists = 3,
        Success = 4
    }
}
