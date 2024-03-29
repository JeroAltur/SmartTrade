using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using SQLite;
using SmartTrade.Models;
using System.Linq.Expressions;

namespace SmartTrade.Services
{
    internal class ServicioBD
    {
        private readonly SQLiteConnection _conexion;

        public ServicioBD(string rutaBaseDatos)
        {
            this._conexion = new SQLiteConnection(rutaBaseDatos);
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
    }
}
