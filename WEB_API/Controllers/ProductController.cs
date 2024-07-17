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
    public class ProductController : ApiController
    {
        // GET api/<controller>
        public List<Product> Get()
        {
            ProductRepository repo = new ProductRepository();
            return repo.FindAll();
        }


        // GET api/<controller>
        [HttpGet]
        [Route("api/Product/getByCriteria")]
        public List<Product> GetByCriteria(String criteria="")
        {
            ProductRepository repo = new ProductRepository();
            return repo.GetByCriteria(criteria);
        }


        // GET api/<controller>/5
        public Product Get(String id)
        {
            ProductRepository repo = new ProductRepository();
            return repo.FindById(id);
        }

        // POST api/<controller>
        public int Post([FromBody] Product value)
        {
            ProductRepository repo = new ProductRepository();
            return repo.Create(value);
        }

        // PUT api/<controller>/5
        public int Put(String id, [FromBody] Product value)
        {
            ProductRepository repo = new ProductRepository();
            value.id = id;
            return repo.Update(value);
        }

        // DELETE api/<controller>/5
        public int Delete(String id)
        {
            ProductRepository repo = new ProductRepository();
            return repo.Inactivate(id);
        }
    }
}