using DATOS.Models.Database;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATOS.Repository
{
    public class OrderRepository
    {
        private readonly dbContext _context;
        public OrderRepository()
        {
            _context = new dbContext();
        }

        public Order Create(Order Order)
        {
            int rows = 0;
            try
            {
                Order.id = Guid.NewGuid().ToString();
                _context.Order.Add(Order);
                rows = _context.SaveChanges();
            }
            catch (Exception ex)
            {

            }

            return Order;
        }

        // Método para encontrar todos los registros
        public List<Order> FindAll()
        {
            List<Order> ls = new List<Order>();
            try
            {
                ls = _context.Order.Where(x => x.state == 1).ToList();
            }
            catch (Exception ex)
            {

            }
            return ls;
        }

        // Método para encontrar un registro por su Id
        public Order FindById(string id)
        {
            Order model = new Order();
            try
            {
                model = _context.Order.Find(id);
            }
            catch (Exception ex)
            {

            }
            return model;
        }

        // Método para actualizar un registro
        public int Update(Order Order)
        {
            int rows = 0;
            try
            {
                _context.Entry(Order).State = EntityState.Modified;
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
                var Order = _context.Order.Find(id);
                if (Order != null)
                {
                    Order.state = 0; // Suponiendo que 0 representa "inactivo"
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
