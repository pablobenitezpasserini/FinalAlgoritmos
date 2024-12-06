using ReglaDeNegocio;

namespace UnitTestNegocio;

[TestClass]
public class TestControladorPaises
{
    [TestMethod]
    public void TestEliminarPais()
    {
        //Arrange
        ControladorPaises controladorPaises = new ControladorPaises();
        bool eliminado;
        controladorPaises.AgregarPais(new Pais(54, "Argentina", "Buenos Aires"));
        controladorPaises.AgregarPais(new Pais(1, "Peru", "Lima"));
        controladorPaises.AgregarPais(new Pais(2, "Uruguay", "Montevideo"));
        //Act
        eliminado = controladorPaises.EliminarPais(1);
        //Assert
        Assert.AreEqual(eliminado, true);
    }

    [TestMethod]
    public void TestPaisExiste()
    {
        //Arrange
        ControladorPaises controladorPaises = new ControladorPaises();
        bool existe;
        controladorPaises.AgregarPais(new Pais(54, "Argentina", "Buenos Aires"));
        //Act
        existe = controladorPaises.CodigoPaisExiste(54);
        //Assert
        Assert.AreEqual(existe, true);
    }

    [TestMethod]
    public void TestIsPaisesVacio()
    {
        //Arrange
        ControladorPaises controladorPaises = new ControladorPaises();
        bool isPaisesVacio;
        controladorPaises.AgregarPais(new Pais(54, "Argentina", "Buenos Aires"));
        //Act
        isPaisesVacio = controladorPaises.IsPaisesVacio();
        //Assert
        Assert.AreEqual(isPaisesVacio, false);
    }

    [TestMethod]
    public void TestBuscarPais()
    {
        //Arrange
        ControladorPaises controladorPaises = new ControladorPaises();
        Pais? encontrado;
        controladorPaises.AgregarPais(new Pais(54, "Argentina", "Buenos Aires"));
        //Act
        encontrado = controladorPaises.BuscarPais(1);
        //Assert
        Assert.AreEqual(encontrado, null);        
    }

    [TestMethod]
    public void TestAgregarPais()
    {
        //Arrange
        ControladorPaises controladorPaises = new ControladorPaises();
        bool isPaisesVacio;
        //Act
        controladorPaises.AgregarPais(new Pais(54, "Argentina", "Buenos Aires"));
        isPaisesVacio = controladorPaises.IsPaisesVacio();
        //Assert
        Assert.AreEqual(isPaisesVacio, false);     
    }
}
