using System;
using System.Text.RegularExpressions;

namespace PacketParser.Services
{
    public static class CheckPerssonValidation
    {
        public static bool CheckEmail(string email)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(email) || email == "")
                    return true;
                return Regex.IsMatch(email,
                    @"^([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$");
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return false;
            }
        }
        public static bool CheckMobile(string mobile)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(mobile) || mobile == "")
                    return true;

                var phone_regexp = "[0-9]{4}[0-9]{3}[0-9]{4}";
                var phone_regexp2 = "[0-9]{3}[0-9]{3}[0-9]{4}";
                var number = new[] { mobile };
                var Res = false;
                foreach (var phone in number)
                {
                    var m = Regex.Match(phone, phone_regexp);
                    var m2 = Regex.Match(phone, phone_regexp2);
                    if (m.Success || m2.Success) Res = true;
                    else Res = false;
                }

                return Res;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return false;
            }
        }
        public static bool CheckNationalCode(string natCode)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(natCode) || natCode == "")
                    return true;
                var chArray = natCode.ToCharArray();
                var numArray = new int[chArray.Length];
                for (var i = 0; i < chArray.Length; i++)
                    numArray[i] = (int)char.GetNumericValue(chArray[i]);
                var num2 = numArray[9];
                switch (natCode)
                {
                    case "0000000000":
                    case "1111111111":
                    case "22222222222":
                    case "33333333333":
                    case "4444444444":
                    case "5555555555":
                    case "6666666666":
                    case "7777777777":
                    case "8888888888":
                    case "9999999999":
                        return false;
                }

                var num3 =
                    ((((((((numArray[0] * 10) + (numArray[1] * 9)) + (numArray[2] * 8)) + (numArray[3] * 7)) +
                        (numArray[4] * 6)) + (numArray[5] * 5)) + (numArray[6] * 4)) + (numArray[7] * 3)) +
                    (numArray[8] * 2);
                var num4 = num3 - ((num3 / 11) * 11);
                return (((num4 == 0) && (num2 == num4)) || ((num4 == 1) && (num2 == 1))) ||
                       ((num4 > 1) && (num2 == Math.Abs((int)(num4 - 11))));
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return false;
            }
        }
    }
}
