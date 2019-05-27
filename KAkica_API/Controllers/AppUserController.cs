using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KAkica.Communication.AppUser;
using KAkica.Communication.AppUserPooper;
using KAkica.Domain.Models;
using KAkica.Service.Implementation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KAkica.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUserController : KAkicaBaseController<AppUserRequest, AppUserResponse>
    {
        public AppUserController(AppUserService userService)
        {
            m_service = userService;
        }

        [HttpPost("{ownerId}/assignPooper/{pooperId}")]
        public async Task<IActionResult> AssignPooper(int ownerId, int pooperId)
        {
            return Ok(await ((AppUserService)m_service).AssignPooper(ownerId, pooperId));
        }

        [HttpPost("assignPooper")]
        public async Task<IActionResult> AssignPooper([FromBody]AppUserPooperDto obj)
        {
            return Ok(await ((AppUserService)m_service).AssignPooper(obj.AppUserId, obj.PooperId));
        }
    }
}
