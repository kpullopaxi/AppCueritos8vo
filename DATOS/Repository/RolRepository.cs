using DATOS.Models.Database;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATOS.Repository
{
    public class RolRepository
    {
        private readonly dbContext _context;
        public RolRepository()
        {
            _context = new dbContext();
        }

        public int Create(Rol Rol)
        {
            int rows = 0;
            try
            {
                Rol.id = Guid.NewGuid().ToString();
                _context.Rol.Add(Rol);
                rows = _context.SaveChanges();
            }
            catch (Exception ex)
            {

            }

            return rows;
        }

        // Método para encontrar todos los registros
        public List<Rol> FindAll()
        {
            List<Rol> ls = new List<Rol>();
            try
            {
                ls = _context.Rol.Where(x => x.state == 1).ToList();
            }
            catch (Exception ex)
            {

            }
            return ls;
        }

        // Método para encontrar un registro por su Id
        public Rol FindById(string id)
        {
            Rol model = new Rol();
            try
            {
                model = _context.Rol.Find(id);
            }
            catch (Exception ex)
            {

            }
            return model;
        }

        // Método para actualizar un registro
        public int Update(Rol Rol)
        {
            int rows = 0;
            try
            {
                _context.Entry(Rol).State = EntityState.Modified;
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
                var Rol = _context.Rol.Find(id);
                if (Rol != null)
                {
                    Rol.state = 0; // Suponiendo que 0 representa "inactivo"
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
