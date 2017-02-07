using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class mgController : ApiController
    {
        // GET: api/mg
        [Authorize]
        public IEnumerable<string> Get()
        {
            return new string[] { "Auth value1", "Auth value2" };
        }

        // GET: api/mg/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/mg
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/mg/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/mg/5
        public void Delete(int id)
        {
        }
    }
}
