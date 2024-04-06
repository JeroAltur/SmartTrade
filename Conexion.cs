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
            cadenaConexion = "Server=bezz64pmlgkdtkejch0i-mysql.services.clever-cloud.com;Database=bezz64pmlgkdtkejch0i;User Id=uxri6to3ohabhczv;Password=Vfg8AwmWlxQB3TrLuJoF";
        }

        public MySqlConnection GetConexion()
        {
            if (conexion == null)
            {
                conexion = new MySqlConnection(cadenaConexion);
                try
                {
                    conexion.Open();
                }
                catch (MySqlException e){
                    Console.WriteLine(e.Message);
                }
            }
            return conexion;
        }
    }
}
