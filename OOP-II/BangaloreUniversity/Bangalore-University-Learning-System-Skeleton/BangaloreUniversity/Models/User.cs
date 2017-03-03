namespace BangaloreUniversity.Models
{
    using System;
    using System.Collections.Generic;

    using BangaloreUniversity.Interfaces;
    using BangaloreUniversity.Utillities;

    public class User : IUser
    {
        private string username;

        private string password;

        public User(string username, string password, Role role)
        {
            this.Username = username;
            this.Password = password;
            this.Role = role;
            this.Courses = new List<Course>();
        }

        public string Username
        {
            get
            {
                return this.username;
            }

            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 5)
                {
                    throw new ArgumentException(
                        "The username must be at least 5 symbols long.");
                }

                this.username = value;
            }
        }

        public string Password
        {
            get
            {
                return this.password;
            }

            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 5)
                {
                    throw new ArgumentException(
                        "The password must be at least 5 symbols long.");
                }

                this.password = HashUtilities.HashPassword(value);
            }
        }

        public Role Role { get; private set; }

        public IList<Course> Courses { get; private set; }

        public bool IsInRole(Role role)
        {
            return UserRoleUtilities.IsInRole(this, role);
        }
    }
}