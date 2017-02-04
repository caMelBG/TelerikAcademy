namespace BangaloreUniversity.Views.Users
{
    using System.Text;
    using BangaloreUniversity.Models;
    using BangaloreUniversity.Interfaces;
    using BangaloreUniversity.Views.Abstract;

    public class Register : View
    {
        public Register(IUser user) : base(user)
        {
        }

        public override void BuildViewResult(StringBuilder viewResult)
        {
            viewResult.AppendFormat("User {0} registered successfully.", 
                (this.Model as User).Username).AppendLine();
        }
    }
}