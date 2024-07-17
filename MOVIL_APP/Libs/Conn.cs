using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOVIL_APP.Libs
{
    public static class Conn
    {

        //  dirección base del servidor
        public static string BaseUrl = "https://localhost:44364";


       
        public static string GetProductSearchUrl()
        {
          
            return $"{BaseUrl}";
        }
    }
}
