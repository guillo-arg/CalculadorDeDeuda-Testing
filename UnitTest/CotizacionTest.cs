using CalculadorDeDeuda.Clases;
using CalculadorDeDeuda.Interfaces;
using System;
using Xunit;
using Moq;

namespace UnitTest
{
    public class CotizacionTest
    {
        //[Fact]
        //public void test()
        //{
        //    Assert.Equal("", "");
        //}

        [Fact]
        public void Puede_Calcular_Deuda_En_Dolares()
        {
            //Arrange
            DateTime fechaInicioDeuda = DateTime.Parse("2021-09-07");
            DateTime fechaFinDeuda = DateTime.Parse("2021-09-17");

            var mock = new Mock<ICotizacionDolares>();
            var resultadoEsperado = 110;

            DeudaEnDolares deudaEnDolares = new DeudaEnDolares(100, fechaInicioDeuda, mock.Object);
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
            DateTime fechaInicioDeuda = DateTime.Parse("2021-09-07");
            DateTime fechaFinDeuda = DateTime.Parse("2021-09-17");
            var mock = new Mock<ICotizacionDolares>();

            mock.Setup(x => x.GetEnPesos(fechaFinDeuda)).Returns(100);

            decimal resultadoEsperado = 11000;

            DeudaEnDolares deudaEnDolares = new DeudaEnDolares(100, fechaInicioDeuda, mock.Object);
            DeudaEnDolares.interesPorDia = 0.01;


            //Act
            var resultado = deudaEnDolares.GetDeudaEnPesosPorFecha(fechaFinDeuda);
            //Assert
            Assert.Equal(resultadoEsperado, resultado);
        }

        [Theory]
        [InlineData("2021-09-07", "2021-09-17", 100, 0.01, 110)]
        [InlineData("2021-09-07", "2021-09-27", 100, 0.01, 120)]
        public void Puede_Calcular_Deuda_En_Dolares2
            (string inicioDeuda,
            string finDeuda,
            decimal montoInicial,
            double interesPorDia,
            decimal montoEsperado)
        {
            //Arrange
            DateTime fechaInicioDeuda = DateTime.Parse(inicioDeuda);
            DateTime fechaFinDeuda = DateTime.Parse(finDeuda);
            var mock = new Mock<ICotizacionDolares>();

            DeudaEnDolares deudaEnDolares = new DeudaEnDolares(montoInicial, fechaInicioDeuda, mock.Object);
            DeudaEnDolares.interesPorDia = interesPorDia;

            //Act
            var resultado = deudaEnDolares.GetDeudaEnDolaresPorFecha(fechaFinDeuda);
            //Assert
            Assert.Equal(montoEsperado, resultado);
        }

        [Fact]
        public void Deberia_Levantar_Excepcion()
        {
            //Arrange
            DateTime fechaInicioDeuda = DateTime.Parse("2021-09-07");
            DateTime fechaFinDeuda = DateTime.Parse("2021-09-06");
            var mock = new Mock<ICotizacionDolares>();

            DeudaEnDolares deudaEnDolares = new DeudaEnDolares(100, fechaInicioDeuda, mock.Object);

            //Act
            //Assert
            Assert.Throws<Exception>(() => deudaEnDolares.GetDeudaEnDolaresPorFecha(fechaFinDeuda));
        }
    }
}
