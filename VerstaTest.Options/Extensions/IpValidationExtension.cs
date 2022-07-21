using System.Text.RegularExpressions;

namespace VerstaTest.Options.Extensions
{
    public static class IpValidationExtension
    {
        const string ipAdressPattern = @"(\b25[0-5]|\b2[0-4][0-9]|\b[01]?[0-9][0-9]?)(\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)){3}";

        private static readonly Regex _ipAdressRegEx = CreateRegEx(ipAdressPattern);
        private static Regex CreateRegEx(string ipPattern)
        {
            const RegexOptions options = RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture;
            return new Regex(ipPattern, options);
        }

        public static bool IsIpAdress(this string ip) => _ipAdressRegEx.IsMatch(ip);
    }
}
