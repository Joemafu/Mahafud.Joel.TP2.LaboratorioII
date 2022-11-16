using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;
using System;

namespace TestEntidades
{
    [TestClass]
    public class TestRonda
    {
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void Test_Aceptar()
        {
            //Arrange
            Ronda ronda = new Ronda();
            ronda.TrucoCantado = true;
            Jugador jugador = null;


            //Assert
            ronda.Aceptar(jugador, jugador);
        }

        [TestMethod]
        public void Test_Declinar()
        {
            //Arrange
            Ronda ronda = new Ronda();
            ronda.TantoCantado = true;
            Jugador jugador = null;

            ronda.Declinar(jugador);


            //Assert
            Assert.IsFalse(ronda.TantoCantado);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void Test_CederElQuiero()
        {
            //Arrange
            Ronda ronda = new Ronda();
            ronda.TrucoCantado = true;
            Jugador jugador = null;


            //Assert
            ronda.CederElQuiero(jugador,jugador);
        }

        [TestMethod]
        public void Test_Retrucar()
        {
            //Arrange
            Ronda ronda = new Ronda();
            Jugador jugador = null;

            int valor1 = ronda.ValorDelTrucoSiSeAcepta;
            ronda.Retrucar(jugador, jugador);
            int valor2 = ronda.ValorDelTrucoSiSeAcepta;


            //Assert
            Assert.IsFalse(valor1 == valor2);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void Test_AceptarTruco()
        {
            //Arrange
            Ronda ronda = new Ronda();
            Jugador jugador = null;

            ronda.AceptarTruco(jugador, jugador);
        }

        [TestMethod]
        public void Test_ReavivarEnvido()
        {
            //Arrange
            Jugador jugador1 = new Jugador("Juan", false);
            Jugador jugador2 = new Jugador("Maria", true);
            Partida partida = new Partida(jugador1, jugador2);
            partida.Jugador1.PuntajeGeneral = 11;
            partida.Jugador2.PuntajeGeneral = 2;

            partida.Ronda.ReavivarEnvido(partida);

            Assert.AreEqual(partida.Ronda.ValorDelTantoSiSeAcepta, 4);
        }

        [TestMethod]
        public void Test_CalcularValorFaltaEnvido()
        {
            //Arrange
            Jugador jugador1 = new Jugador("Juan", false);
            Jugador jugador2 = new Jugador("Maria", true);
            Partida partida = new Partida(jugador1, jugador2);
            partida.Jugador1.PuntajeGeneral = 12;
            partida.Jugador2.PuntajeGeneral = 4;

            Assert.AreEqual(partida.Ronda.CalcularValorFaltaEnvido(partida), 3);
        }

        [TestMethod]
        public void Test_TerminarRonda()
        {
            //Arrange
            Jugador jugador1 = new Jugador("Juan", false);
            Jugador jugador2 = new Jugador("Maria", true);
            Partida partida = new Partida(jugador1, jugador2);
            partida.Jugador1.PuntajeGeneral = 5;
            partida.Ronda.GanadorEnvido = jugador2;
            partida.Ronda.GanadorTruco = jugador1;
            partida.Ronda.ValorDelTrucoActual = 3;

            partida.Ronda.TerminarRonda();

            Assert.AreEqual(partida.Jugador1.PuntajeGeneral, 8); ;
        }
    }
}
