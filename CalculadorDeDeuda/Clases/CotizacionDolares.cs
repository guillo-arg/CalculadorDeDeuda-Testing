using CalculadorDeDeuda.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculadorDeDeuda.Clases
{
    public class CotizacionDolares : ICotizacionDolares
    {
        public CotizacionDolares()
        {

        }
        public decimal GetEnPesos(DateTime dateTime)
        {
            return 100;
        }
    }
}
