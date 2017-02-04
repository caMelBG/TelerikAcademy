namespace BuhtigIssueTracker.Models
{
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;

    public class User
    {
        public User(string username, string password)
        {
            this.Username = username;
            this.Password = HashPassword(password);
        }

        public string Username { get; private set; }

        public string Password { get; private set; }

        public static string HashPassword(string password)
        {
            return string.Join(string.Empty, SHA1.Create()
                .ComputeHash(Encoding.Default.GetBytes(password))
                .Select(x => x.ToString()));
        }
    }
}
