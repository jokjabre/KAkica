using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KAkica.Communication.AppUser;
using KAkica.Communication.Auth;
using KAkica.Service.Implementation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace KAkica.API.Controllers
{
    [Route("[controller]")]
    [Authorize]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private LoginService m_loginService;

        public LoginController(LoginService loginService)
        {
            m_loginService = loginService;
        }

        [HttpPost("login", Name = "Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(AuthRequest request)
        {
            return Evaluate(await m_loginService.Login(request));
        }

        [HttpPost("register", Name = "Register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] AppUserRequest request)
        {
            return Evaluate(await m_loginService.Register(request));
        }


        [NonAction]
        private IActionResult Evaluate(object result)
        {
            return result != null ?
                Ok(result) :
                (IActionResult)BadRequest();
        }
    }
}