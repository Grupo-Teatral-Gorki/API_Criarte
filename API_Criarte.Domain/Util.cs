using Newtonsoft.Json;
using System.Configuration;
using System.Drawing;
using System.Net;
using System.Net.Mail;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Text.RegularExpressions;

namespace API_Lib
{
    public static class Util
    {
        public static int parseInt(object value, object default_value)
        {
            return Convert.ToInt32(value == null ? default_value : value);
        }

        public static string ToSHA512(this string value)
        {
            using var sha = SHA512.Create();

            var bytes = Encoding.UTF8.GetBytes(value);
            var hash = sha.ComputeHash(bytes);

            return Convert.ToBase64String(hash);
        }

        public static string convertIntToHex(int cor)
        {
            string hex = "";
            var color = Color.FromArgb(cor);
            hex = "#" + color.R.ToString("X2") + color.G.ToString("X2") + color.B.ToString("X2");
            return hex;
        }

        public static bool ValidEmail(string user)
        {
            var valid = true;

            try
            {
                var emailAddress = new MailAddress(user);
            }
            catch
            {
                valid = false;
            }

            return valid;
        }

        public static bool ValidPass(string pass)
        {
            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasMinimum8Chars = new Regex(@".{8,}");

            var isValidated = hasNumber.IsMatch(pass) && hasUpperChar.IsMatch(pass) && hasMinimum8Chars.IsMatch(pass);
            return isValidated;
        }
    }

    public static class AlterClaim
    {
        public static void AddUpdateClaim(this IPrincipal currentPrincipal, string key, string value)
        {
            var identity = currentPrincipal.Identity as ClaimsIdentity;
            if (identity == null)
                return;

            // check for existing claim and remove it
            var existingClaim = identity.FindFirst(key);
            if (existingClaim != null)
                identity.RemoveClaim(existingClaim);

            // add new claim
            identity.AddClaim(new Claim(key, value));
            //var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
            //authenticationManager.AuthenticationResponseGrant = new AuthenticationResponseGrant(new ClaimsPrincipal(identity), new AuthenticationProperties() { IsPersistent = true });
        }

        public static string GetClaimValue(this IPrincipal currentPrincipal, string key)
        {
            var identity = currentPrincipal.Identity as ClaimsIdentity;
            if (identity == null)
                return null;

            var claim = identity.Claims.FirstOrDefault(c => c.Type == key);

            // ?. prevents a exception if claim is null.
            return claim?.Value;
        }
    }
}
