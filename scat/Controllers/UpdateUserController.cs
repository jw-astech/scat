using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using scat.Models;

namespace scat.Controllers
{
    public class UpdateUserController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost]
        public HttpResponseMessage Post([FromBody] object value)
        {
            return Request.CreateResponse(HttpStatusCode.OK, "OK" + value.ToString());
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
            string value2 = value;
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}