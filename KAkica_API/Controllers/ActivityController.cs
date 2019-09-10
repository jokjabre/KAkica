using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JokJaBre.Core.API;
using KAkica.Communication.Request;
using KAkica.Communication.Response;
using KAkica.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KAkica.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityController : JokJaBreController<Activity>
    {
        public ActivityController(IJokJaBreService<Activity> service) : base(service)
        {
        }

        [HttpPost]
        public async Task<IActionResult> Create(ActivityRequest activity)
        {
            return CheckState(await m_service.Create<ActivityRequest, ActivityResponse>(activity));
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return CheckState(m_service.GetAll<ActivityResponse>());
        }
    }
}