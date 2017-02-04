namespace BangaloreUniversity.Interfaces
{
    using BangaloreUniversity.Models;
    using BangaloreUniversity.Data;

    public interface IDataBase
    {
        UsersRepository Users { get; }

        IRepository<Course> Courses { get; }
    }
}