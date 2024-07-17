using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATOS.Models
{
    public class AuthUser
    {
        public string Id { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public string token { get; set; }
    }
}
