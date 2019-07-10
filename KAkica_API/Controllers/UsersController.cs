using JokJaBre.Core.Identity;
using JokJaBre.Core.API;
using KAkica.API.Request;
using KAkica.API.Response;
using KAkica.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace KAkica.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : JokJaBreIdentityController<KakicaUser, UserRequest, UserResponse>
    {

        public UsersController(IJokJaBreIdentityService<KakicaUser> userService, IConfiguration config) : base(userService)
        {
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] UserRequest request)
        {
            return RegisterBase(request);
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] UserRequest request)
        {
            return LoginBase(request);
        }

    }
}