using CalculadorDeDeuda.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTest
{
    public class IntegracionTest
    {
        [Fact]
        public void test()
        {
            //Arrange
            DateTime fechaInicioDeuda = DateTime.Parse("2021-09-07");
            DateTime fechaFinDeuda = DateTime.Parse("2021-09-17");
            CotizacionDolares cotizacionDolares = new CotizacionDolares();

            decimal resultadoEsperado = 11000;

            DeudaEnDolares deudaEnDolares = new DeudaEnDolares(100, fechaInicioDeuda, cotizacionDolares);
            DeudaEnDolares.interesPorDia = 0.01;


            //Act
            var resultado = deudaEnDolares.GetDeudaEnPesosPorFecha(fechaFinDeuda);
            //Assert
            Assert.Equal(resultadoEsperado, resultado);
        }
    }
}
