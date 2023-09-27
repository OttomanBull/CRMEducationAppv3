using Core.Entitites;
using CRM_API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRM_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly RepositoryContext _context;

        public LoginController(RepositoryContext context)
        {
            _context = context;
        }

        [HttpPost("login")]
        public ActionResult Login(Login login)
        {
            try
            {
                var userToLogin = _context.Login.FirstOrDefault(x => x.UserName == login.UserName && x.Password == login.Password);
                if (userToLogin == null)
                    return BadRequest("Kullanıcı Bulunamadı");

                return Ok(userToLogin.PersonId);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);

            }
        }

    }
}
