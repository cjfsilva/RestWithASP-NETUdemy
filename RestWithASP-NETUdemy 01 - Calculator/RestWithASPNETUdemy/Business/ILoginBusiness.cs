using RestWithASPNETUdemy.Data.VO;

namespace RestWithASPNETUdemy.Business
{
    public interface ILoginBusiness
    {
        object FindByLogin(LoginVO login);
    }
}
