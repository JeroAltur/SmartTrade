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

        public List<Producto> Tendencias()
        {
            return bd.GetAllOrdered<Producto, int>("ventas").Take(10).ToList();
        }

        //importante revisar, puede q no funcione bien, ya que hay q comprobar si esta bien pasado el argumento
        public List<Producto> MejorValorado()
        {
            return bd.GetAllOrdered<Producto, double>("valor").Take(10).ToList();
        }
    }
}
