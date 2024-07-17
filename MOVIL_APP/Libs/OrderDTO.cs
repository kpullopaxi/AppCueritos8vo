using DATOS.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOVIL_APP.Libs
{
    public class OrderDTO
    {
        public List<Product> selectedProducts { get; set; }
        public List<Order> orders { get; set; }
    }
}
