using System;
using System.Collections.Generic;
using System.Linq;
using MySql.Data.MySqlClient;
using SmartTrade.Models;

namespace SmartTrade.Services
{
    internal class ServicioBD: BD
    {
        private readonly MySqlConnection _conexion;

        public ServicioBD(MySqlConnection conexion)
        {
            _conexion = conexion;
            _conexion.Open();
        }

        public void Insertar<T>(T entity) where T : class
        {
            var tableName = typeof(T).Name;
            var query = $"INSERT INTO {tableName} (...) VALUES (...)";
            ExecuteNonQuery(query);
        }

        public void Borrar<T>(T entity) where T : class
        {
            var tableName = typeof(T).Name;
            var query = $"DELETE FROM {tableName} WHERE ...";
            ExecuteNonQuery(query);
        }

        public void Limpiar<T>() where T : class
        {
            var tableName = typeof(T).Name;
            var query = $"DELETE FROM {tableName}";
            ExecuteNonQuery(query);
        }

        public List<T> Todo<T>() where T : new()
        {
            var query = $"SELECT * FROM {typeof(T).Name}";
            return ExecuteQuery<T>(query);
        }

        public void Crear<T>() where T : class
        {
            var query = $"CREATE TABLE IF NOT EXISTS {typeof(T).Name} (...)";
            ExecuteNonQuery(query);
        }

        public List<T> TodoOrdenado<T, U>(string orderByColumn) where T : new()
        {
            var query = $"SELECT * FROM {typeof(T).Name} ORDER BY {orderByColumn}";
            return ExecuteQuery<T>(query);
        }

        public void BorrarTodo()
        {
            Limpiar<Producto>();
            Limpiar<Comida>();
            Limpiar<Ropa>();
            Limpiar<Electronica>();
        }

        public void Cerrar()
        {
            _conexion.Close();
        }

        private void ExecuteNonQuery(string query)
        {
            using var cmd = new MySqlCommand(query, _conexion);
            cmd.ExecuteNonQuery();
        }

        private List<T> ExecuteQuery<T>(string query) where T : new()
        {
            var result = new List<T>();
            using var cmd = new MySqlCommand(query, _conexion);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                // Mapea los datos del lector al objeto T 
                var item = new T();
                
                result.Add(item);
            }
            return result;
        }
    }
}
