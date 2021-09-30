using System;
using OpenQA.Selenium;

namespace Advertise.Classes
{
    public class CookieStore : Cookie
    {
        private bool _isSecure = false;
        public override bool Secure => _isSecure;

        public CookieStore(string name, string value, string domain, string path, DateTime? expiry) : base(name, value, domain, path, expiry)
        {
        }

        public CookieStore(string name, string value, string path, DateTime? expiry) : base(name, value, path, expiry)
        {
        }

        public CookieStore(string name, string value, string path) : base(name, value, path)
        {
        }

        public CookieStore(string name, string value, bool isSecure = false, DateTime? expireDate = null) : base(name, value, "/", expireDate)
        {
            _isSecure = isSecure;
        }
    }
}
