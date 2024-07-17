using DATOS.Models.Database;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATOS.Repository
{
    public class ProductRepository
    {
        private readonly dbContext _context;
        public ProductRepository()
        {
            _context = new dbContext();
        }

        public int Create(Product Product)
        {
            int rows = 0;
            try
            {
                Product.id = Guid.NewGuid().ToString();
                _context.Product.Add(Product);
                rows = _context.SaveChanges();
            }
            catch (Exception ex)
            {

            }

            return rows;
        }

        // Método para encontrar todos los registros
        public List<Product> FindAll()
        {
            List<Product> ls = new List<Product>();
            try
            {
                ls = _context.Product.Where(x=>x.state==1).ToList();
            }
            catch (Exception ex)
            {

            }
            return ls;
        }
        // Método para encontrar todos los registros
        public List<Product> GetByCriteria(String criteria="")
        {
            List<Product> ls = new List<Product>();
            try
            {
                ls = _context.Product.Where(x=>x.state==1 && 
                ( 
                x.name.Contains(criteria) || 
                x.Catalog.name.Contains(criteria) || 
                x.description.Contains(criteria) || 
                x.Catalog.description.Contains(criteria)
                )
                ).ToList();
            }
            catch (Exception ex)
            {

            }
            return ls;
        }

        // Método para encontrar un registro por su Id
        public Product FindById(string id)
        {
            Product model = new Product();
            try
            {
                model = _context.Product.Find(id);
            }
            catch (Exception ex)
            {

            }
            return model;
        }

        // Método para actualizar un registro
        public int Update(Product Product)
        {
            int rows = 0;
            try
            {
                _context.Entry(Product).State = EntityState.Modified;
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
                var Product = _context.Product.Find(id);
                if (Product != null)
                {
                    Product.state = 0; // Suponiendo que 0 representa "inactivo"
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
