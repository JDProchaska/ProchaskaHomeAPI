using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ProchaskaHouseAPI.Code;

namespace ProchaskaHouseAPI.Controllers
{
    public class PeopleController : ApiController
    {
        // GET: api/People
        public string Get()
        {
            DatabaseCode db = new DatabaseCode();
            return db.GetPeople();
        }

        // GET: api/People/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/People
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/People/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/People/5
        public void Delete(int id)
        {
        }
    }
}
