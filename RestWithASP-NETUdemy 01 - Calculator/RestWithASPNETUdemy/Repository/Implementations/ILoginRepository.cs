using RestWithASPNETUdemy.Model;

namespace RestWithASPNETUdemy.Repository
{
    public interface ILoginRepository
    {
        Login FindByLogin(string login);
    }
}
