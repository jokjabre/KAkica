using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KAkica.Communication.Pooper;
using KAkica.Service.Implementation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KAkica.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PooperController : KAkicaBaseController<PooperRequest, PooperResponse>
    {
        public PooperController(PooperService userService)
        {
            m_service = userService;
        }

    }
}