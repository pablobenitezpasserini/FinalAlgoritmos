using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReglaDeNegocio;

namespace UnitTestNegocio
{
    [TestClass]
    public class TestControladorAlumnos
    {
        [TestMethod]
        public void TestCalcularPromedio()
        {
            //Arrange
            ControladorPaises controladorPaises= new ControladorPaises();
            ControladorAlumnos controladorAlumnos= new ControladorAlumnos(controladorPaises);
            controladorPaises.AgregarPais(new Pais(54, "Argentina", "Buenos aires"));
            controladorAlumnos.AgregarAlumno(new Alumno(1,"Pepe", 10, 54));
            controladorAlumnos.AgregarAlumno(new Alumno(2, "Pepito", 7, 54));
            double promedio;
            //Act
            promedio = controladorAlumnos.CalcularPromedio();
            //Assert
            Assert.AreEqual(promedio, 8.50);
        }
        [TestMethod]
        public void TestIsListadoAlumnosVacio()
        {
            //Arrange
            ControladorPaises controladorPaises= new ControladorPaises();
            ControladorAlumnos controladorAlumnos= new ControladorAlumnos(controladorPaises);
            controladorPaises.AgregarPais(new Pais(54, "Argentina", "Buenos aires"));
            controladorAlumnos.AgregarAlumno(new Alumno(1,"Pepe", 10, 54));
            controladorAlumnos.AgregarAlumno(new Alumno(2, "Pepito", 7, 54));
            bool isVacio;
            //Act
            isVacio = controladorAlumnos.IsListadoAlumnosVacio();
            //Assert
            Assert.IsFalse(isVacio);
        }
        [TestMethod]
        public void TestAgregarAlumno()
        {
            //Arrange
            ControladorPaises controladorPaises= new ControladorPaises();
            ControladorAlumnos controladorAlumnos= new ControladorAlumnos(controladorPaises);
            controladorPaises.AgregarPais(new Pais(54, "Argentina", "Buenos aires"));
            bool isVacio;
            //Act
            controladorAlumnos.AgregarAlumno(new Alumno(1,"Pepe", 10, 54));
            controladorAlumnos.AgregarAlumno(new Alumno(2, "Pepito", 7, 54));
            isVacio = controladorAlumnos.IsListadoAlumnosVacio();
            //Assert
            Assert.IsFalse(isVacio);
        }
    }
}