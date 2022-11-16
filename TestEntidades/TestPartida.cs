using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;

namespace TestEntidades
{
    [TestClass]
    public class TestPartida
    {
        [TestMethod]
        public void Test_PartidaTerminada()
        {
            //Arrange & Act
            Jugador j1 = new Jugador("Juan",true);
            Jugador j2 = new Jugador("Romina",false);
            Partida partida = new Partida(j1,j2);

            partida.Jugador1.PuntajeGeneral = 15;

            //Assert
            Assert.IsTrue(partida.PartidaTerminada);
        }

        [TestMethod]
        public void Test_AvanzarRonda()
        {
            //Arrange & Act
            Jugador j1 = new Jugador("Juan", true);
            Jugador j2 = new Jugador("Romina", false);
            Partida partida = new Partida(j1, j2);

            partida.AvanzarRonda();

            //Assert
            Assert.AreEqual(partida.NumeroDeMano,2);
        }

        [TestMethod]
        public void Test_CalcularGanadorEmpate()
        {
            //Arrange & Act
            Jugador j1 = new Jugador("Juan", true);
            Jugador j2 = new Jugador("Romina", false);
            Partida partida = new Partida(j1, j2);

            partida.Jugador1.PuntajeGeneral = 15;
            partida.Jugador2.PuntajeGeneral = 15;

            //Assert
            Assert.IsNull(partida.CalcularGanador());
        }

        [TestMethod]
        public void Test_CalcularGanadorJugador2()
        {
            //Arrange & Act
            Jugador j1 = new Jugador("Juan", true);
            Jugador j2 = new Jugador("Romina", false);
            Partida partida = new Partida(j1, j2);

            partida.Jugador1.PuntajeGeneral = 14;
            partida.Jugador2.PuntajeGeneral = 15;

            //Assert
            Assert.AreEqual(partida.CalcularGanador(),partida.Jugador2);
        }
    }
}