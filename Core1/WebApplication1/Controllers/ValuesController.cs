using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> GetUser([FromQuery] User user)
        {
            //if (ModelState.IsValid)
            //{
                return new string[] { "value1", "value2" };
            //}
            //else
            //    return new string[] { "" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get2(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post2([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put2(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete2(int id)
        {
        }
    }
}
