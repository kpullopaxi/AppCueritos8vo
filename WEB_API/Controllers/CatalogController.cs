using DATOS.Models.Database;
using DATOS.Repository;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WEB_API.Controllers
{
    public class CatalogController : ApiController
    {
        // GET api/<controller>
        public List<Catalog> Get()
        {
            CatalogRepository repo = new CatalogRepository();
            return repo.FindAll();
        }

        // GET api/<controller>/45ds4a5dsa
        public Catalog Get(String id)
        {
            CatalogRepository repo = new CatalogRepository();
            return repo.FindById(id);
        }

        // POST api/<controller>
        public int Post([FromBody] Catalog value)
        {
            CatalogRepository repo = new CatalogRepository();
            return repo.Create(value);
        }

        // PUT api/<controller>/5
        public int Put(String id, [FromBody] Catalog value)
        {
            CatalogRepository repo = new CatalogRepository();
            value.id = id;
            return repo.Update(value);
        }

        // DELETE api/<controller>/5
        public int Delete(String id)
        {
            CatalogRepository repo = new CatalogRepository();
            return repo.Inactivate(id);
        }
    }
}