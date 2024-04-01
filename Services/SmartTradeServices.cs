using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartTrade.Models;

namespace SmartTrade.Services
{
    internal class SmartTradeServices: ISmartTradeServices
    {
        private readonly BD bd;

        public SmartTradeServices(ServicioBD servicio)
        {
            this.bd = servicio;
        }

        public List<Producto> Tendencias()
        {
            List<Comida> comida = bd.GetAllOrdered<Comida, int>("ventas").Take(10).ToList();
            List<Electronica> electronica = bd.GetAllOrdered<Electronica, int>("ventas").Take(10).ToList();
            List<Ropa> ropa = bd.GetAllOrdered<Ropa, int>("ventas").Take(10).ToList();
            List<Producto> result = new List<Producto>();

            foreach (Comida p in comida)
            {
                result.Add(p);
            }
            foreach (Electronica p in electronica)
            {
                result.Add(p);
            }
            foreach (Ropa p in ropa)
            {
                result.Add(p);
            }

            result = result.OrderBy(p => p.ventas).Take(10).ToList();

            return result;
        }

        public List<Producto> MejorValorado()
        {
            List<Comida> comida = bd.GetAllOrdered<Comida, double>("valor").Take(10).ToList();
            List<Electronica> electronica = bd.GetAllOrdered<Electronica, double>("valor").Take(10).ToList();
            List<Ropa> ropa = bd.GetAllOrdered<Ropa, double>("valor").Take(10).ToList();
            List<Producto> result = new List<Producto>();

            foreach (Comida p in comida)
            {
                result.Add(p);
            }
            foreach (Electronica p in electronica)
            {
                result.Add(p);
            }
            foreach (Ropa p in ropa)
            {
                result.Add(p);
            }

            result = result.OrderBy(p => p.valor).Take(10).ToList();

            return result;
        }
    }
}
