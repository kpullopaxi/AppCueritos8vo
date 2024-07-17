using DATOS.Models.Database;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATOS.Repository
{
    public class UserRepository
    {
        private readonly dbContext _context;
        public UserRepository()
        {
            _context = new dbContext();
        }

        public int Create(User User)
        {
            int rows = 0;
            try
            {
                User.id = Guid.NewGuid().ToString();
                _context.User.Add(User);
                rows = _context.SaveChanges();
            }
            catch (Exception ex)
            {

            }

            return rows;
        }

        // Método para encontrar todos los registros
        public List<User> FindAll()
        {
            List<User> ls = new List<User>();
            try
            {
                ls = _context.User.Where(x => x.state == 1).ToList();
            }
            catch (Exception ex)
            {

            }
            return ls;
        }

        // Método para encontrar un registro por su Id
        public User FindById(string id)
        {
            User model = new User();
            try
            {
                model = _context.User.Find(id);
            }
            catch (Exception ex)
            {

            }
            return model;
        }
        public User finByCredentials(String userName, String password)
        {
            User model = new User();
            try
            {
                model = _context.User.FirstOrDefault(x=>x.userName== userName && x.password == password);
            }
            catch (Exception ex)
            {

            }
            return model;
        }

        // Método para actualizar un registro
        public int Update(User User)
        {
            int rows = 0;
            try
            {
                _context.Entry(User).State = EntityState.Modified;
                rows = _context.SaveChanges();
            }
            catch (Exception ex)
            {

            }
            return rows;
        }

        // Método para desactivar un registro
        public int Inactivate(string id)
        {
            int rows = 0;
            try
            {
                var User = _context.User.Find(id);
                if (User != null)
                {
                    User.state = 0; // Suponiendo que 0 representa "inactivo"
                    rows = _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {

            }

            return rows;
        }
    }
}
