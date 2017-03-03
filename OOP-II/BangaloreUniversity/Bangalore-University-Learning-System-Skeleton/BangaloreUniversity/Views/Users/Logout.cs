namespace BangaloreUniversity.Views.Users
{
    using System.Text;
    using BangaloreUniversity.Interfaces;
    using BangaloreUniversity.Views.Abstract;
    using BangaloreUniversity.Models;

    public class Logout : View
    {
        public Logout(IUser user) : base(user)
        {
        }

        public override void BuildViewResult(StringBuilder viewResult)
        {
            viewResult.AppendFormat("User {0} logged out successfully.",
                (this.Model as User).Username).AppendLine();
        }
    }
}