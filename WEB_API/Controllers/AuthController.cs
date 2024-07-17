using DATOS.Models;
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
    public class AuthController : ApiController
    {
        // GET api/<controller>
        public List<User> Get()
        {
            UserRepository repo = new UserRepository();
            return repo.FindAll();
        }

        // GET api/<controller>/5
        public User Get(String id)
        {
            UserRepository repo = new UserRepository();
            return repo.FindById(id);
        }

        // POST api/<controller>
        public int Post([FromBody] User value)
        {
            UserRepository repo = new UserRepository();
            return repo.Create(value);
        }

        // POST api/<controller>/Login
        [HttpPost]
        [Route("api/Auth/Login")]
        public User Login([FromBody] User value)
        {
            UserRepository repo = new UserRepository();
            User logedUser = repo.finByCredentials(value.userName, value.password);
            return logedUser;
        }

        // PUT api/<controller>/5
        public int Put(String id, [FromBody] User value)
        {
            UserRepository repo = new UserRepository();
            value.id = id;
            return repo.Update(value);
        }

        // DELETE api/<controller>/5
        public int Delete(String id)
        {
            UserRepository repo = new UserRepository();
            return repo.Inactivate(id);
        }
    }
}