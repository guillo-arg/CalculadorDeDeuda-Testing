using CalculadorDeDeuda.Clases;
using CalculadorDeDeuda.Interfaces;
using System;
using Xunit;
using Moq;

namespace UnitTest
{
    public class CotizacionTest
    {
        [Fact]
        public void Puede_Calcular_Deuda_En_Dolares()
        {
            //Arrange
            DateTime fechaInicioDeuda = new DateTime(2021, 9, 7);
            DateTime fechaFinDeuda = new DateTime(2021, 9, 17);
            var mock = new Mock<ICotizacionDolares>();
            mock.Setup(x => x.GetEnPesos(fechaFinDeuda)).Returns(100);
            var resultadoEsperado = 110;

            DeudaEnDolares deudaEnDolares = new DeudaEnDolares(100,fechaInicioDeuda,  mock.Object);
            DeudaEnDolares.interesPorDia = 0.01;

            //Act
            var resultado = deudaEnDolares.GetDeudaEnDolaresPorFecha(fechaFinDeuda);
            //Assert
            Assert.Equal(resultadoEsperado, resultado);
        }

        [Fact]
        public void Puede_Calcular_Deuda_en_Pesos()
        {
            //Arrange
            DateTime fechaInicioDeuda = new DateTime(2021, 9, 7);
            DateTime fechaFinDeuda = new DateTime(2021, 9, 17);
            var mock = new Mock<ICotizacionDolares>();
            mock.Setup(x => x.GetEnPesos(fechaFinDeuda)).Returns(100);
            var resultadoEsperado = 11000;

            DeudaEnDolares deudaEnDolares = new DeudaEnDolares(100, fechaInicioDeuda, mock.Object);
            DeudaEnDolares.interesPorDia = 0.01;

            //Act
            var resultado = deudaEnDolares.GetDeudaEnPesosPorFecha(fechaFinDeuda);
            //Assert
            Assert.Equal(resultadoEsperado, resultado);
        }
    }
}
