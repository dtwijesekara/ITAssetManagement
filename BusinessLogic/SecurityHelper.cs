using System;
using System.Security.Cryptography;
using System.Text;

namespace ITAssetManagement.BusinessLogic
{
    public static class SecurityHelper
    {
        public static string ComputeSha256Hash(string rawData)
        {
            if (string.IsNullOrEmpty(rawData))
                throw new ArgumentNullException(nameof(rawData), "Cannot hash null or empty password.");

            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(rawData));
                StringBuilder sb = new StringBuilder();
                foreach (byte b in bytes)
                    sb.Append(b.ToString("x2"));
                return sb.ToString();
            }
        }
    }
}
