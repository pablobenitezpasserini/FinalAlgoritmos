using ReglaDeNegocio;

namespace CapaDePresentacion
{
    class Program
    {
        static void Main(string[] args)
        {
            IniciarApp();
        }

        public static void IniciarApp()
        {
            MenuCoordinador menuCoordinador = new MenuCoordinador();
            menuCoordinador.MenuCoordinadorPrincipal();
        }
    }
}
