using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;

namespace TestEntidades
{
    [TestClass]
    public class TestMano
    {
        [TestMethod]
        public void Testear_Constructor_ColeccionNoNull()
        {
            //Arrange & Act
            Mano mano = new Mano(true);

            //Assert
            Assert.IsNotNull(mano.Naipes);
        }

        [TestMethod]
        public void Testear_OrdenamientoPorValor()
        {
            //Arrange & Act
            Mano mano = new Mano(true);

            //Assert
            Assert.IsTrue(mano.Naipes[0].ValorNaipe >= mano.Naipes[1].ValorNaipe && mano.Naipes[1].ValorNaipe >= mano.Naipes[2].ValorNaipe);
        }

        [TestMethod]
        public void Testear_ValidarNaipe()
        {
            //Arrange & Act
            Mano mano = new Mano(true);
            mano.Naipes[0] = mano.Naipes[1];

            //Assert
            Assert.IsFalse(mano.ValidarNaipe(mano.Naipes[0]));
        }

        [TestMethod]
        public void Testear_CalcularSiTieneFlor()
        {
            //Arrange & Act
            Mano mano = new Mano(true);
            mano.Naipes[1].Palo = mano.Naipes[0].Palo;
            mano.Naipes[2].Palo = mano.Naipes[0].Palo;

            //Assert
            Assert.IsTrue(mano.CalcularSiTieneFlor());
        }

        [TestMethod]
        public void Testear_CalcularSiTieneTanto()
        {
            //Arrange & Act
            Mano mano = new Mano(true);

            mano.Naipes[0].Palo = EPalos.Basto;
            mano.Naipes[1].Palo = EPalos.Basto;
            mano.Naipes[2].Palo = EPalos.Copa;

            //Assert
            Assert.IsTrue(mano.CalcularSiTieneTanto());
        }

        [TestMethod]
        public void Testear_CalcularTanto()
        {
            //Arrange & Act
            Mano mano = new Mano(true);

            mano.Naipes[0].Palo = EPalos.Basto;
            mano.Naipes[0].ValorTanto = 5;
            mano.Naipes[1].Palo = EPalos.Basto;
            mano.Naipes[1].ValorTanto = 6;
            mano.Naipes[2].Palo = EPalos.Basto;
            mano.Naipes[2].ValorTanto = 7;

            //Assert
            Assert.AreEqual(38, mano.CalcularTanto());
        }

        [TestMethod]
        public void Testear_CalcularTantoDoble()
        {
            //Arrange & Act
            Mano mano = new Mano(true);

            mano.Naipes[0].Palo = EPalos.Basto;
            mano.Naipes[0].ValorTanto = 5;
            mano.Naipes[1].Palo = EPalos.Basto;
            mano.Naipes[1].ValorTanto = 1;
            mano.Naipes[2].Palo = EPalos.Copa;

            //Assert
            Assert.AreEqual(26,mano.CalcularTantoDoble());
        }

    }
}
