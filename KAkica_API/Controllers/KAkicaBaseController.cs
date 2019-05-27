using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KAkica.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KAkica.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KAkicaBaseController<TRequest, TResponse> : ControllerBase
        where TRequest : class
        where TResponse : class
    {
        protected IKakicaService<TRequest, TResponse> m_service;

        // GET: api/AppUser
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            return Ok(await m_service.GetAllAsync());
        }

        // GET: api/AppUser/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await m_service.GetByIdAsync(id));
        }

        // POST: api/AppUser
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TRequest request)
        {
            return Ok(await m_service.CreateAsync(request));
        }

        // PUT: api/AppUser/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] TRequest request)
        {
            return Ok(await m_service.UpdateAsync(id, request));
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await m_service.DeleteAsync(id));
        }
    }
}
