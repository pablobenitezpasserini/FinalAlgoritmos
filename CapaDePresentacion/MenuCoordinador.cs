using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReglaDeNegocio;

namespace CapaDePresentacion
{
    public class MenuCoordinador : MenuBase
    {
        private MenuAlumnos _menuAlumnos;
        private MenuPaises _menuPaises;

        public MenuCoordinador()
        {
            ControladorPaises controladorPaises = new ControladorPaises();
            ControladorAlumnos controladorAlumnos = new ControladorAlumnos(controladorPaises);
            this._menuAlumnos = new MenuAlumnos(controladorAlumnos);
            this._menuPaises = new MenuPaises(controladorPaises);
        }

        public void MenuCoordinadorPrincipal()
        {
            string? opcion;

            do
            {
                Console.WriteLine("----Bienvenido a la app de paises y alumnos----");
                Console.WriteLine("\n--Seleccione la opcion deseada:");
                Console.WriteLine("1- Ingresar al menu de Paises");
                Console.WriteLine("2- Ingresar al menu de alumnos");
                Console.WriteLine("3- Salir de la app");
                opcion = TomarInput();

                switch (opcion)
                {
                    case "1":
                        MostrarMensajeConEspera("Direccionandolo al menu de paises\nPresione enter para continuar...");
                        _menuPaises.MenuPaisesPrincipal();
                        break;
                    case "2":
                        MostrarMensajeConEspera("Direccionandolo al menu de alumnos\nPresione enter para continuar...");
                        _menuAlumnos.MenuAlumnosPrincipal();
                        break;
                    case "3":
                        MostrarMensajeConEspera("Gracias por utilizar nuestra app");
                        break;
                    default:
                        MostrarMensajeConEspera("Opcion incorrecta, vuelva a inventar");
                        break;
                }
            }while(opcion != "3");
        }
    }
}