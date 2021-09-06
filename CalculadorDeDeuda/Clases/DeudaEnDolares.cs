using CalculadorDeDeuda.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculadorDeDeuda.Clases
{
    public class DeudaEnDolares
    {
        public static double interesPorDia = 0.01;
        private decimal monto;
        private ICotizacionDolares cotizacionDolares;
        private DateTime fechaDeDeuda;

        public DeudaEnDolares(decimal monto, DateTime fechaDeDeuda, ICotizacionDolares cotizacionDolares)
        {
            this.monto = monto;
            this.cotizacionDolares = cotizacionDolares;
            this.fechaDeDeuda = fechaDeDeuda;
        }

        public decimal GetDeudaEnDolaresPorFecha(DateTime fecha)
        {
            int cantidadDeDias = (int)(fecha - this.fechaDeDeuda).TotalDays;
            decimal total = this.monto *(decimal) (1 + (interesPorDia * cantidadDeDias));

            return total;
        }

        public decimal GetDeudaEnPesosPorFecha(DateTime fecha)
        {
            int cantidadDeDias = (int)(fecha - this.fechaDeDeuda).TotalDays;
            decimal totalEnDolares = this.monto * (decimal)(1 + (interesPorDia * cantidadDeDias));
            decimal cotizacionDelDolarEnPesos = this.cotizacionDolares.GetEnPesos(fecha);
            decimal totalEnPesos = totalEnDolares * cotizacionDelDolarEnPesos;

            return totalEnPesos;
        }


    }
}
