using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class ValuesController : ApiController
    {
        // POST api/values
        // [Route("v1/values")]
        
        public IEnumerable<string> GetAlfa()
        {
            return new string[] { "value1", "value2" };
        }
        // GET api/values

        


        // GET api/values/5
        public string Get(int id)
        {
            return "GET value:"+id;
        }

        // POST api/values
        public string Post([FromBody] string value)
        {
            return "Post:"+value;
        }

        // PUT api/values/5
        public string Put(int id, [FromBody] string value)
        {
            return "Put:"+id + "-" + value;
        }

        // DELETE api/values/5
        public string Delete(int id)
        {
            return "Delete:" + id;

        }
    }
}

//GET POST PUT DELETE