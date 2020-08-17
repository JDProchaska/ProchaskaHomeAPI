using ProchaskaHouseAPI.Models;
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ProchaskaHouseAPI.Models;
using ProchaskaHouseAPI.Code;

namespace ProchaskaHouseAPI.Controllers
{
    public class ChoreController : ApiController
    {
        // GET: api/Chore
        [HttpGet("GetChores")]
        public List<Chore> Get()
        {
            DatabaseCode dbCode = new DatabaseCode();
            return dbCode.GetChores();
        }

        // POST: api/Chore
        public void Post(Chore value)
        {
            //Chore chore = new Chore();
            //chore = JsonConvert.DeserializeObject(value) as Chore;

            DatabaseCode dbCode = new DatabaseCode();
            value.Added = DateTime.Now;
            dbCode.AddChore(value);

        }

        // PUT: api/Chore/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Chore/5
        public void Delete(int id)
        {
        }
    }
}
