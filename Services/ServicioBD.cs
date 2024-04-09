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
        }

        public void Insertar<T>(T entity) where T : class
        {
            var tableName = typeof(T).Name;
            var properties = typeof(T).GetProperties();
            var columnNames = string.Join(", ", properties.Select(p => p.Name));
            var valuePlaceholders = string.Join(", ", properties.Select(p => $"@{p.Name}"));

            var query = $"INSERT INTO {tableName} ({columnNames}) VALUES ({valuePlaceholders})";
            ExecuteNonQuery(query, entity);
        }

        public void Borrar<T>(T entity) where T : class
        {
            var tableName = typeof(T).Name;
            var primaryKey = "Id"; // Cambia esto al nombre de tu clave primaria
            var primaryKeyValue = entity.GetType().GetProperty(primaryKey)?.GetValue(entity);

            if (primaryKeyValue != null)
            {
                var query = $"DELETE FROM {tableName} WHERE {primaryKey} = @PrimaryKeyValue";
                ExecuteNonQuery(query, new { PrimaryKeyValue = primaryKeyValue });
            }
            else
            {
                System.Console.WriteLine("no hay clave primaria");
            }
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
            Limpiar<Valoracion>();
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

        private void ExecuteNonQuery(string query, object parameters = null)
        {
            using var command = new MySqlCommand(query, _conexion);

            if (parameters != null)
            {
                foreach (var property in parameters.GetType().GetProperties())
                {
                    command.Parameters.AddWithValue($"@{property.Name}", property.GetValue(parameters));
                }
            }

            command.ExecuteNonQuery();
        }
    }
}
