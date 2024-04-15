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
    internal class ServicioBD : BD
    {
        private readonly SQLiteConnection _conexion;

        public ServicioBD(SQLiteConnection conexion)
        {
            this._conexion = conexion;
        }

        public void Insertar<T>(T entity) where T : class
        {
            _conexion.Insert(entity);
            _conexion.Commit();
        }

        public void Borrar<T>(T entity) where T : class
        {
            _conexion.Delete(entity);
            _conexion.Commit();
        }

        public void Limpiar<T>() where T : class
        {
            _conexion.DeleteAll<T>();
            _conexion.Commit();
        }

        public List<T> Todo<T>() where T : new()
        {
            return _conexion.Table<T>().ToList();
        }

        public void Crear<T>() where T : class
        {
            _conexion.CreateTable<T>();
            _conexion.Commit();
        }

        public List<T> TodoOrdenado<T, U>(string orderByColumn) where T : new()
        {
            return _conexion.Table<T>().OrderBy<T, U>(x => (U)x.GetType().GetProperty(orderByColumn).GetValue(x)).ToList();
        }

        public void BorrarTodo()
        {
            Limpiar<Producto>();
            Limpiar<Comida>();
            Limpiar<Ropa>();
            Limpiar<Electronica>();
        }
        public T BuscarPorID<T>(int id) where T : class, new()
        {
            return _conexion.Find<T>(id);
        }
        public void Actualizar<T>(T entity) where T : class
        {
            _conexion.Update(entity);
            _conexion.Commit();
        }

        public void CrearTablas()
        {
            _conexion.CreateTable<Producto>();
            _conexion.CreateTable<Valoracion>();
            _conexion.CreateTable<Electronica>();
            _conexion.CreateTable<Comida>();
            _conexion.CreateTable<Ropa>();

            _conexion.Commit();
        }
    }
}
