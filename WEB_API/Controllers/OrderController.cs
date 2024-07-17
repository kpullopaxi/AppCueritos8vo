using DATOS.Models.Database;
using DATOS.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WEB_API.Controllers
{
    public class OrderController : ApiController
    {
        // GET api/Order
        public List<Order> Get()
        {
            OrderRepository repo = new OrderRepository();
            return repo.FindAll();
        }

        // GET api/Order/5
        public Order Get(String id)
        {
            OrderRepository repo = new OrderRepository();
            return repo.FindById(id);
        }

        // POST api/Order
        public Order Post([FromBody] Order value)
        {
            OrderRepository repo = new OrderRepository();
            return repo.Create(value);
        }

        // PUT api/<controller>/5
        public int Put(String id, [FromBody] Order value)
        {
            OrderRepository repo = new OrderRepository();
            value.id = id;
            return repo.Update(value);
        }

        // DELETE api/<controller>/5
        public int Delete(String id)
        {
            OrderRepository repo = new OrderRepository();
            return repo.Inactivate(id);
        }
    }
}