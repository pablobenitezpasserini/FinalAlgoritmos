using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReglaDeNegocio;

namespace UnitTestNegocio
{
    [TestClass]
    public class TestValidador
    {
        [TestMethod]
        public void TestEsNumero()
        {
            //Arrange
            Validador validador = new Validador();
            bool esValido;
            //Act
            esValido = validador.EsNumero("20");
            //Assert
            Assert.IsTrue(esValido);
        }

        [TestMethod]
        public void TestEsTextoVacio()
        {
            //Arrange
            Validador validador = new Validador();
            bool esValido;
            //Act
            esValido = validador.EsTextoVacio("20");
            //Assert
            Assert.IsFalse(esValido);
        }

        [TestMethod]
        public void TestEsNumeroNetivo()
        {
            //Arrange
            Validador validador = new Validador();
            bool esValido;
            //Act
            esValido = validador.EsNumeroNegativo(30);
            //Assert
            Assert.IsFalse(esValido);
        }
    }
}
