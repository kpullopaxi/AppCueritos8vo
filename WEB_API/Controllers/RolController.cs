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
    public class RolController : ApiController
    {
        // GET api/<controller>
        public List<Rol> Get()
        {
            RolRepository repo = new RolRepository();
            return repo.FindAll();
        }

        // GET api/<controller>/5
        public Rol Get(String id)
        {
            RolRepository repo = new RolRepository();
            return repo.FindById(id);
        }

        // POST api/<controller>
        public int Post([FromBody] Rol value)
        {
            RolRepository repo = new RolRepository();
            return repo.Create(value);
        }

        // PUT api/<controller>/5
        public int Put(String id, [FromBody] Rol value)
        {
            RolRepository repo = new RolRepository();
            value.id = id;
            return repo.Update(value);
        }

        // DELETE api/<controller>/5
        public int Delete(String id)
        {
            RolRepository repo = new RolRepository();
            return repo.Inactivate(id);
        }
    }
}