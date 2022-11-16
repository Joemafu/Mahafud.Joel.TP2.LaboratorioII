using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;
using System;

namespace TestEntidades
{
    [TestClass]
    public class TestSQL
    {
        [TestMethod]
        public void Test_LeerYCerrar()
        {
            bool abierto;
            bool cerrado;
            SQL.Leer();

            abierto = SQL.Conexion.State == System.Data.ConnectionState.Open;

            SQL.Cerrar();

            cerrado = SQL.Conexion.State == System.Data.ConnectionState.Closed;

            //Assert
            Assert.AreEqual(abierto, cerrado);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void Test_Guardar()
        {
            //Arrange
            Partida partida = null;


            //Assert
            SQL.Guardar(partida);
        }
    }
}