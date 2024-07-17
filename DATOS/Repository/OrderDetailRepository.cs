using DATOS.Models.Database;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATOS.Repository
{
    public class OrderDetailRepository
    {
        private readonly dbContext _context;
        public OrderDetailRepository()
        {
            _context = new dbContext();
        }

        public OrderDetail Create(OrderDetail OrderDetail)
        {
            int rows = 0;
            OrderDetail data = new OrderDetail();
            try
            {
                OrderDetail.id = Guid.NewGuid().ToString();
                _context.OrderDetail.Add(OrderDetail);
                rows = _context.SaveChanges();
            }
            catch (Exception ex)
            {

            }

            return OrderDetail;
        }

        // Método para encontrar todos los registros
        public List<OrderDetail> FindAll()
        {
            List<OrderDetail> ls = new List<OrderDetail>();
            try
            {
                ls = _context.OrderDetail.Where(x => x.state == 1).ToList();
            }
            catch (Exception ex)
            {

            }
            return ls;
        }

        // Método para encontrar un registro por su Id
        public OrderDetail FindById(string id)
        {
            OrderDetail model = new OrderDetail();
            try
            {
                model = _context.OrderDetail.Find(id);
            }
            catch (Exception ex)
            {

            }
            return model;
        }

        // Método para actualizar un registro
        public int Update(OrderDetail OrderDetail)
        {
            int rows = 0;
            try
            {
                _context.Entry(OrderDetail).State = EntityState.Modified;
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
                var OrderDetail = _context.OrderDetail.Find(id);
                if (OrderDetail != null)
                {
                    OrderDetail.state = 0; // Suponiendo que 0 representa "inactivo"
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
