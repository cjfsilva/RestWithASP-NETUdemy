using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Model.Context;
using System.Linq;

namespace RestWithASPNETUdemy.Repository.Implementations
{
    public class LoginRepositoryImpl : ILoginRepository
    {
        private readonly MySQLContext _context;

        public LoginRepositoryImpl(MySQLContext context)
        {
            _context = context;
        }

        public Login FindByLogin(string login)
        {
            return _context.Logins.SingleOrDefault(u => u.Logins.Equals(login));
        }
    }
}
