namespace BangaloreUniversity.Data
{
    using BangaloreUniversity.Interfaces;
    using BangaloreUniversity.Models;

    public class DataBase : IDataBase
    {
        public DataBase()
        {
            this.Users = new UsersRepository();
            this.Courses = new Repository<Course>();
        }

        public UsersRepository Users { get; protected set; }

        public IRepository<Course> Courses { get; protected set; }
    }
}