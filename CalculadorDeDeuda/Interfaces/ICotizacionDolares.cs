using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculadorDeDeuda.Interfaces
{
    public interface ICotizacionDolares
    {
        decimal GetEnPesos(DateTime dateTime);
    }
}
