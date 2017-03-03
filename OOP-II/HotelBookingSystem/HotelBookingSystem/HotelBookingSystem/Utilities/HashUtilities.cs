namespace HotelBookingSystem.Utilities
{
    using System.Security.Cryptography;
    using System.Text;

    public class HashUtilities
    {
        public static string GetSha256Hash(string text)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(text);
            SHA256Managed hashString = new SHA256Managed();
            byte[] hash = hashString.ComputeHash(bytes);
            var hashOutput = new StringBuilder();
            foreach (byte b in hash)
            {
                hashOutput.AppendFormat("{0:x2}", b);
            }

            return hashOutput.ToString();
        }
    }
}
