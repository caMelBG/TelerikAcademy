namespace BangaloreUniversity.Controllers
{
    using System;

    using BangaloreUniversity.Interfaces;
    using BangaloreUniversity.Models;
    using BangaloreUniversity.Utillities;

    class UsersController : Controller
    {
        public UsersController(IDataBase data, IUser user)
            : base(data, user)
        {
        }

        public IView Register(string username, string password, string confirmPassword, string role)
        {
            if (password != confirmPassword)
            {
                throw new ArgumentException("The provided passwords do not match.");
            }

            this.EnsureNoLoggedInUser();
            this.EnsureUserIsNotExist(username);
            Role userRole = (Role)Enum.Parse(typeof(Role), role, true);
            var user = new User(username, password, userRole);
            this.Data.Users.Add(user);
            return View(user);
        }

        public IView Login(string username, string password)
        {
            var existingUser = this.Data.Users.GetByUsername(username);
            this.EnsureNoLoggedInUser();
            this.EnsureUserIsExist(username);
            this.VerifePassword(existingUser, password);
            this.User = existingUser;
            return View(existingUser);
        }

        public IView Logout()
        {
            this.EnsureAuthorization(Role.Student, Role.Lecturer);
            var user = this.User;
            this.User = null;
            return View(user);
        }

        private void EnsureNoLoggedInUser()
        {
            if (this.HasCurrentUser)
            {
                throw new ArgumentException("There is already a logged in user.");
            }
        }

        private void EnsureUserIsNotExist(string username)
        {
            var existingUser = this.Data.Users.GetByUsername(username);
            if (existingUser != null)
            {
                throw new ArgumentException(string.Format(
                    "A user with username {0} already exists.", username));
            }
        }

        private void EnsureUserIsExist(string username)
        {
            var existingUser = this.Data.Users.GetByUsername(username);
            if (existingUser == null)
            {
                throw new ArgumentException(string.Format(
                    "A user with username {0} dose not exists.", username));
            }
        }

        private void VerifePassword(IUser existingUser, string password)
        {
            if (existingUser.Password != HashUtilities.HashPassword(password))
            {
                throw new ArgumentException("The provided password is wrong.");
            }
        }
    }
}