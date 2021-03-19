using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ProchaskaHouseAPI.Models;
using ProchaskaHouseAPI.Code;

namespace ProchaskaHouseAPI.Controllers
{
    public class DinnerController : ApiController
    {
        // GET: api/Dinner/GetMeals
        [Route("api/Dinner/GetMeals")]
        [HttpGet]
        public List<Meal> GetChores()
        {
            DatabaseCode dbCode = new DatabaseCode();
            return dbCode.GetMeals();
        }

        // POST: api/Dinner/AddMeal
        [Route("api/Dinner/AddMeal")]
        [HttpPost]
        public void Post(Meal value)
        {
            DatabaseCode dbCode = new DatabaseCode();
            dbCode.AddMeal(value);
        }
    }
}
