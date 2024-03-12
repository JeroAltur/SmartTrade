using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace SmartTrade
{
	public static class Conexion
	{
		private MySqlConnection conexion;
		private string server = "bezz64pmlgkdtkejch0i-mysql.services.clever-cloud.com";
		private string database = "bezz64pmlgkdtkejch0i";
		private string user = "uxri6to3ohabhczv";
		private string password = "Vfg8AwmWlxQB3TrLuJoF";
		private string port = "3306";
		private string cadenaConexion;

		public static Conexion()
		{
			cadenaConexion = "Server=" + server + "; Port=" + port + "; Database" + database + "; Uid=" + user + "; Pwd=" + password;
		}

		public static MySqlConnection getConexion()
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
