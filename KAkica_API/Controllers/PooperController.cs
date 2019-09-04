using JokJaBre.Core.API;
using KAkica.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using KAkica.Communication.Request;
using KAkica.Communication.Response;
using System.Threading.Tasks;

namespace KAkica.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PooperController : JokJaBreController<Pooper>
    {
        public PooperController(IJokJaBreService<Pooper> service) : base(service) { }

        [HttpPost]
        public async Task<IActionResult> Create(PooperRequest request)
        {
            return CheckState(await m_service.Create<PooperRequest, PooperResponse>(request));
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return CheckState(m_service.GetAll<PooperResponse>());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            return CheckState(await m_service.GetById<PooperResponse, long>(id));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            return CheckState(await m_service.Delete(id));
        }
    }
}