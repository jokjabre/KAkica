using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KAkica.Communication.AppUser;
using KAkica.Domain.Models;
using KAkica.Service.Implementation;
using Microsoft.AspNetCore.Mvc;

namespace KAkica_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private AppUserService m_userService;

        public ValuesController(AppUserService service)
        {
            m_userService = service;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<AppUserResponse>> Get()
        {
            return Ok(m_userService.GetAll());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
