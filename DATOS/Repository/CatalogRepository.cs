using DATOS.Models.Database;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATOS.Repository
{
    public class CatalogRepository
    {
        private readonly dbContext _context;
        public CatalogRepository()
        {
            _context = new dbContext();
        }

        public int Create(Catalog catalog)
        {
            int rows = 0;
            try
            {
                catalog.id = Guid.NewGuid().ToString();
                _context.Catalog.Add(catalog);
                rows = _context.SaveChanges();
            }
            catch (Exception ex)
            {

            }

            return rows;
        }

        // Método para encontrar todos los registros
        public List<Catalog> FindAll()
        {
            List<Catalog> ls = new List<Catalog>();
            try
            {
                ls = _context.Catalog.Where(x => x.state == 1).ToList();
            }
            catch (Exception ex)
            {

            }
            return ls;
        }

        // Método para encontrar un registro por su Id
        public Catalog FindById(string id)
        {
            Catalog model = new Catalog();
            try
            {
                model = _context.Catalog.Find(id);
            }
            catch (Exception ex)
            {

            }
            return model;
        }

        // Método para actualizar un registro
        public int Update(Catalog catalog)
        {
            int rows = 0;
            try
            {
                _context.Entry(catalog).State = EntityState.Modified;
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
                var catalog = _context.Catalog.Find(id);
                if (catalog != null)
                {
                    catalog.state = 0; // Suponiendo que 0 representa "inactivo"
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
