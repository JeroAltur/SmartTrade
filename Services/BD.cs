using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartTrade.Services
{
    internal interface BD
    {
        public void Insertar<T>(T entity) where T : class;
        public void Borrar<T>(T entity, string id) where T : class;
        public void Limpiar<T>() where T : class;
        public List<T> Todo<T>() where T : new();
        public List<T> TodoOrdenado<T, U>(string orderByColumn) where T : new();
        public void BorrarTodo();
        public void Cerrar();
        public T BuscarPorIdProducto<T>(int id) where T : new();
        public T BuscarPorIdValoracion<T>(int id) where T : new();
        public void Actualizar<T>(T entity, string primaryKey) where T : class;

    }
}
