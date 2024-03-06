using RepoPatternSports.Service.Interface;
using System.Security.Cryptography;
using System.Text;

namespace RepoPatternSports.Service.Service
{
    public class PasswordHash : IPasswordHash
    {
        public string CreatePasswordHash(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                string hashString = BitConverter.ToString(hashBytes).Replace("-", "").ToLowerInvariant();
                return hashString;
            }
        }
    }
}
