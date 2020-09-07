using ProchaskaHouseAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ProchaskaHouseAPI.Code;

namespace ProchaskaHouseAPI.Controllers
{
    public class ShoppingListController : ApiController
    {
        // GET: api/ShoppingList
        [Route("api/ShoppingList/GetList")]
        [HttpGet]
        public List<ShoppingListItem> Get()
        {
            DatabaseCode dbCode = new DatabaseCode();
            return dbCode.GetShoppingList();
        }

        [Route("api/ShoppingList/GetItem/{id}")]
        [HttpGet]
        public ShoppingListItem Get(int id)
        {
            DatabaseCode dbCode = new DatabaseCode();
            return dbCode.GetListItem(id);
        }


        // POST: api/ShoppingList
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/ShoppingList/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ShoppingList/5
        public void Delete(int id)
        {
        }
    }
}
