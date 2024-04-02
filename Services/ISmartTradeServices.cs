using SmartTrade.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartTrade.Services
{
    internal interface ISmartTradeServices
    {
        public List<Producto> Tendencias();
        public List<Producto> MejorValorado();
        public void AgregarProducto(string name, string dscription, double price, List<string> imagenes, List<string> certificados, string ficha, string tipo);
        public void IniciarBD();
    }
}
