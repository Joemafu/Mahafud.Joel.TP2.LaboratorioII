using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;
using System;

namespace TestEntidades
{
    [TestClass]
    public class TestTxt
    {
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void Test_Guardar()
        {
            //Arrange
            Partida partida = null;
            Naipe naipe = null;


            //Assert
            Txt.Guardar(partida, naipe, naipe);
        }
    }
}