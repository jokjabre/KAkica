using JokJaBre.Core.API;
using KAkica.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using KAkica.Communication.Request;
using KAkica.Communication.Response;

namespace KAkica.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PooperController : JokJaBreController<Pooper>
    {
        public PooperController(IJokJaBreService<Pooper> service) : base(service) { }

        [HttpPost]
        public IActionResult Create(PooperRequest request)
        {
            return CheckState(m_service.Create<PooperRequest, PooperResponse>(request));
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return CheckState(m_service.GetAll<PooperResponse>());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(long id)
        {
            return CheckState(m_service.GetById<PooperResponse, long>(id));
        }


    }
}