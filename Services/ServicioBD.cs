using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using SQLite;
using SmartTrade.Models;
using System.Linq.Expressions;
using MySql.Data.MySqlClient;

namespace SmartTrade.Services
{
    internal class ServicioBD: BD
    {
        private readonly SQLiteConnection _conexion;

        public ServicioBD(SQLiteConnection conexion)
        {
            this._conexion = conexion;
        }

        public void Insert<T>(T entity) where T : class
        {
            _conexion.Insert(entity);
            _conexion.Commit();
        }

        public void Delete<T>(T entity) where T : class
        {
            _conexion.Delete(entity);
            _conexion.Commit();
        }

        public void Clear<T>() where T : class
        {
            _conexion.DeleteAll<T>();
        }

        public List<T> GetAll<T>() where T : new()
        {
            return _conexion.Table<T>().ToList();
        }

        public void Create<T>() where T : class
        {
            _conexion.CreateTable<T>();
        }

        public List<T> GetAllOrdered<T, U>(string orderByColumn) where T : new()
        {
            return _conexion.Table<T>().OrderBy<T, U>(x => (U)x.GetType().GetProperty(orderByColumn).GetValue(x)).ToList();
        }
    }
}
