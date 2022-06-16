using System.Security.Cryptography;
using System.Text;

namespace Backend.Util
{
    public class HashingUtil
    {
        private static readonly string SALT = "andrevitorvitor";
        public static string getHash(string text)
        {
            using var sha256 = SHA256.Create();
            var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(text + SALT));
            return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
        }
    }
}
