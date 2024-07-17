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
    public class OrderDetailController : ApiController
    {
        // GET api/<controller>
        public List<OrderDetail> Get()
        {
            OrderDetailRepository repo = new OrderDetailRepository();
            return repo.FindAll();
        }

        // GET api/<controller>/5
        public OrderDetail Get(String id)
        {
            OrderDetailRepository repo = new OrderDetailRepository();
            return repo.FindById(id);
        }

        // POST api/<controller>
        public OrderDetail Post([FromBody] OrderDetail value)
        {
            OrderDetailRepository repo = new OrderDetailRepository();
            return repo.Create(value);
        }

        // PUT api/<controller>/5
        public int Put(String id, [FromBody] OrderDetail value)
        {
            OrderDetailRepository repo = new OrderDetailRepository();
            value.id = id;
            return repo.Update(value);
        }

        // DELETE api/<controller>/5
        public int Delete(String id)
        {
            OrderDetailRepository repo = new OrderDetailRepository();
            return repo.Inactivate(id);
        }
    }
}