using Microsoft.AspNetCore.Mvc;
using RestWithASPNETUdemy.Business;
using Microsoft.AspNetCore.Authorization;
using RestWithASPNETUdemy.Data.VO;

namespace RestWithASPNETUdemy.Controllers

{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class LoginController : Controller
    {
        private ILoginBusiness _loginBusiness;

        public LoginController(ILoginBusiness loginBusiness)
        {
            _loginBusiness = loginBusiness;
        }

        // POST api/v1/login
        [AllowAnonymous]
        [HttpPost]
        public object Post([FromBody]LoginVO login)
        {
            if (login == null) return BadRequest();
            return _loginBusiness.FindByLogin(login);
        }
    }    
}
