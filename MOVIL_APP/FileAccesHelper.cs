using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOVIL_APP
{
    internal class FileAccesHelper
    {
        public static string GetlocalFilePath(string fileename)
        {
            return System.IO.Path.Combine(FileSystem.AppDataDirectory, fileename);
        }
    }
}
