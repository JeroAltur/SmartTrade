using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartTrade.Services
{
    internal interface BD
    {
        public void Insert<T>(T entity) where T : class;
        public void Delete<T>(T entity) where T : class;
        public void Clear<T>() where T : class;
        public List<T> GetAll<T>() where T : new();
        public void Create<T>() where T : class;
        public List<T> GetAllOrdered<T, U>(string orderByColumn) where T : new();

    }
}
