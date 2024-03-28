using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SmartTrade.Models;

namespace SmartTrade.Services
{
    internal class ServicioBD
    {
        readonly SQLiteAsyncConnection _conexion;

        public ServicioBD(string rutaBaseDatos)
        {
            _conexion = new SQLiteAsyncConnection(rutaBaseDatos);
            _conexion.CreateTableAsync<Producto>().Wait(); // Crea la tabla si no existe
        }

        // Insertar un objeto en la base de datos
        public async Task<int> InsertarAsync(Producto modelo)
        {
            return await _conexion.InsertAsync(modelo);
        }

        // Obtener todos los objetos de la base de datos
        public async Task<List<Producto>> ObtenerTodosAsync()
        {
            return await _conexion.Table<Producto>().ToListAsync();
        }

    }
}
