using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KAkica.Communication.AppUserPooper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KAkica.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUserPooperController : KAkicaBaseController<AppUserPooperRequest, AppUserPooperResponse>
    {
    }
}