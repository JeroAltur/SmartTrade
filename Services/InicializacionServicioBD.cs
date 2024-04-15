using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartTrade.Services
{
    internal class InicializacionServicioBD
    {
        public InicializacionServicioBD() { }

        public static string GetDatabasePath()
        {
            string dbName = "smarttrade.db3"; // Nombre de la base de datos
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData); // Ruta del directorio de datos local
            string fullPath = Path.Combine(folderPath, "Data", dbName); // Ruta completa de la base de datos
            return fullPath;
        }
    }
}
