using System;
using System.Data;
using MySql.Data.MySqlClient; 

namespace SmartTrade
{
    public class Conexion
    {
        private MySqlConnection conexion;
        private string server = "bezz64pmlgkdtkejch0i-mysql.services.clever-cloud.com";
        private string database = "bezz64pmlgkdtkejch0i";
        private string user = "uxri6to3ohabhczv";
        private string password = "Vfg8AwmWlxQB3TrLuJoF";
        private string port = "3306";
        private string cadenaConexion;

        public Conexion()
        {
            cadenaConexion = $"Server={server}; Port={port}; Database={database}; Uid={user}; Pwd={password}";
        }

        public MySqlConnection GetConexion()
        {
            if (conexion == null)
            {
                conexion = new MySqlConnection(cadenaConexion);
                conexion.Open();
            }
            return conexion;
        }
    }
}
