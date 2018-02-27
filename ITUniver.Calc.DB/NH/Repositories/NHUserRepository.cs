using ITUniver.Calc.DB.Repositories;
using ITUniver.Calc.DB.Models;
using System.Collections.Generic;

namespace ITUniver.Calc.DB.NH.Repositories
{
    public class NHUserRepository : NHBaseRepository<User>, IUserRepository
    {
        public override IEnumerable<User> GetAll()
        {
            return base.GetAll(u => u.Status != UserStatus.Deleted);
        }

        public override void Delete(long id)
        {
            var user = Find(id);
            if (user != null)
            {
                user.Status = UserStatus.Deleted;
                Save(user);
            }
        }

        public bool Check(string login, string password)
        {
            var session = Helper.GetCurrentSession();

            return session
                .QueryOver<User>()
                .And(u => u.Login == login
                && u.Password == password)
                .RowCount() > 0;

        }

        public User GetByName(string login)
        {
            var session = Helper.GetCurrentSession();

            return session
                .QueryOver<User>()
                .And(u => u.Login == login)
                .SingleOrDefault();
        }
    }
}
