using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;

namespace TestEntidades
{
    [TestClass]
    public class TestNaipe
    {
        [TestMethod]
        public void Test_CalcularValorNaipe()
        {
            //Arrange & Act
            Naipe naipe = new Naipe(true);

            naipe.Numero = 7;
            naipe.Palo = EPalos.Espada;

            //Assert
            Assert.IsNotNull(naipe.ValorNaipe = 17);
        }

        [TestMethod]
        public void Test_CalcularValorTanto()
        {
            //Arrange & Act
            Naipe naipe = new Naipe(true);

            naipe.Numero = 11;
            naipe.Palo = EPalos.Espada;

            //Assert
            Assert.AreEqual(naipe.CalcularValorTanto(), 0);
        }

        [TestMethod]
        public void Test_RandomizarPalo()
        {
            //Arrange & Act
            bool resultado = (int)Naipe.RandomizarPalo() < 4 && Naipe.RandomizarPalo() >= 0;

            //Assert
            Assert.IsTrue(resultado);
        }
    }
}