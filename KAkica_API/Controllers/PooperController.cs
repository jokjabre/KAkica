using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JokJaBre.Core.Controller;
using JokJaBre.Core.Objects;
using JokJaBre.Core.Service;
using KAkica.Communication.PooperViewModels;
using KAkica.Domain.Models;
using KAkica.Service.Implementation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KAkica.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PooperController : JokJaBreController<Pooper>
    {
        public PooperController(IJokJaBreService<Pooper> service) : base(service)
        {
        }

        [HttpPost]
        public IActionResult Create(PooperRequest request)
        {
            return Ok(m_service.Create<PooperRequest, PooperResponse>(request));
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(m_service.GetAll<PooperResponse>());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(long id)
        {
            return Ok(m_service.GetById<PooperResponse>(id));
        }


    }
}