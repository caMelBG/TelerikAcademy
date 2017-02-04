namespace BangaloreUniversity.Data
{
    using System.Collections.Generic;
    using System.Linq;
    
    using BangaloreUniversity.Interfaces;

    public class UsersRepository : Repository<IUser>
    {
        private Dictionary<string, IUser> usersByUsername;

        public IUser GetByUsername(string username)
        {
            return this.items.FirstOrDefault(u => u.Username == username);
        }
    }
}