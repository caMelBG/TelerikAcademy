namespace BangaloreUniversity.Interfaces
{
    using BangaloreUniversity.Models;
    using System.Collections.Generic;

    public interface IUser
    {
        string Username { get; }

        string Password { get; }

        Role Role { get; }

        IList<Course> Courses { get; }

        bool IsInRole(Role role);
    }
}