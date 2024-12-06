using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReglaDeNegocio;

namespace CapaDePresentacion
{
    public class MenuPaises : MenuBase
    {
        private ControladorPaises _controladorPaises;

        public MenuPaises(ControladorPaises controladorPaises)
        {
            this._controladorPaises = controladorPaises;
        }

        public void MenuPaisesPrincipal()
        {
            string opcion;

            do
            {
                Console.WriteLine("----Menu de paises----");
                Console.WriteLine("\n--Ingrese la opcion deseada:");
                Console.WriteLine("1- Agregar pais");
                Console.WriteLine("2- Modificar pais");
                Console.WriteLine("3- Eliminar pais");
                Console.WriteLine("4- Informacion de pais por codigo");
                Console.WriteLine("5- Volver atras");
                opcion = TomarInput();

                switch (opcion)
                {
                    case "1":
                        MostrarMenuIngresarPais();
                        break;
                    case "2":
                        MostrarMenuModificarPais();
                        break;
                    case "3":
                        MostrarMenuEliminarPais();
                        break;
                    case "4":
                        MostrarMenuInformacionPais();
                        break;
                    case "5":
                        MostrarMensajeConEspera(
                            "Volviendo al menu de paises y alumnos\nPresione enter para continuar..."
                        );
                        break;
                    default:
                        MostrarMensajeConEspera(
                            "La opcion ingresada no existe, intente nuevamente."
                        );
                        break;
                }
            } while (opcion != "5");
        }

        private void MostrarMenuInformacionPais()
        {
            if (_controladorPaises.IsPaisesVacio())
            {
                MostrarMensajeConEspera(
                    "El listado de paises se encuentra vacio, ingrese paises primero."
                );
                return;
            }
            string info;
            int codigoInternacional;

            codigoInternacional = IngresarCodigoInternacional();
            info = _controladorPaises.InformacionPais(codigoInternacional);

            if (info.Length > 0)
            {
                Console.WriteLine("Los datos del pais son...");
                MostrarMensajeConEspera(info);
            }
            else
            {
                MostrarMensajeConEspera(
                    $"El codigo internacional {codigoInternacional} no existe en el sistema."
                );
            }
        }

        private void MostrarMenuEliminarPais()
        {
            if (_controladorPaises.IsPaisesVacio())
            {
                MostrarMensajeConEspera(
                    "El listado de paises se encuentra vacio, ingrese paises primero."
                );
                return;
            }

            int codigoInternacional;

            codigoInternacional = IngresarCodigoInternacional();

            if (_controladorPaises.EliminarPais(codigoInternacional))
            {
                MostrarMensajeConEspera("Pais eliminado correctamente.");
            }
            else
            {
                MostrarMensajeConEspera(
                    $"No existe un pais con el codigo internacional: {codigoInternacional} en el listado."
                );
            }
        }

        private void MostrarMenuModificarPais()
        {
            if (_controladorPaises.IsPaisesVacio())
            {
                MostrarMensajeConEspera(
                    "El listado de paises se encuentra vacio, ingrese paises primero."
                );
                return;
            }
            string info;
            string nombrePais;
            string nombreCapital;
            int codigoInternacional;

            codigoInternacional = IngresarCodigoInternacional();
            info = _controladorPaises.InformacionPais(codigoInternacional);

            if (info.Length > 0)
            {
                Console.WriteLine("Los datos del pais a modificar son...");
                MostrarMensajeConEspera(info + "\nPresione enter para continuar...");
            }
            else
            {
                MostrarMensajeConEspera(
                    "El codigo internacional ingresado no existe en el sistema."
                );
                return;
            }
            Console.WriteLine("--Ingrese la opcion deseada:");
            Console.WriteLine("1- Modificar nombre del pais");
            Console.WriteLine("2- Modificar capital del pais");
            Console.WriteLine("3- Volver al menu de paises");
            string opcion = TomarInput();
            bool tareaCompletada = false;
            do
            {
                switch (opcion)
                {
                    case "1":
                        nombrePais = IngresarNombrePais();
                        tareaCompletada = true;
                        try
                        {
                            _controladorPaises.ModificarNombrePais(nombrePais, codigoInternacional);
                            MostrarMensajeConEspera("Datos modificados correctamente.");
                        }
                        catch (Exception ex)
                        {
                            MostrarMensajeConEspera(ex.Message);
                        }
                        break;
                    case "2":
                        nombreCapital = IngresarCapital();
                        tareaCompletada = true;
                        try 
                        {
                            _controladorPaises.ModificarNombreCapital(nombreCapital, codigoInternacional);
                            MostrarMensajeConEspera("Datos modificados correctamente.");
                        }
                        catch(Exception ex)
                        {
                            MostrarMensajeConEspera(ex.Message);
                        }
                        break;
                    case "3":
                        tareaCompletada = true;
                        break;
                    default:
                        MostrarMensajeConEspera("Opcion invalida, intente nuevamente...");
                        break;
                }
            } while (!tareaCompletada);
        }

        private void MostrarMenuIngresarPais()
        {
            bool operacionExitosa;
            int codigoInternacional;
            string nombre;
            string capital;

            codigoInternacional = IngresarCodigoInternacional();
            nombre = IngresarNombrePais();
            capital = IngresarCapital();
            try
            {
                operacionExitosa = _controladorPaises.AgregarPais(
                    new Pais(codigoInternacional, nombre, capital)
                );
                if (operacionExitosa)
                {
                    MostrarMensajeConEspera("Pais guardado exitosamente.");
                }
                else
                {
                    MostrarMensajeConEspera(
                        "El codigo internacional ingresado ya existe en nuestro sistema, intente nuevamente."
                    );
                }
            }
            catch (Exception ex)
            {
                MostrarMensajeConEspera(ex.Message);
            }
        }

        private string IngresarCapital()
        {
            string mensajePedir = "Ingrese la capital: ";
            string mensajeTextoVacio = "La capital no puede estar vacia, intente nuevamente.";
            return IngresarTexto(mensajePedir, mensajeTextoVacio);
        }

        private string IngresarNombrePais()
        {
            string mensajePedir = "Ingrese el pais: ";
            string nombreTextoVacio = "El pais no puede estar vacio, intente nuevamente.";
            return IngresarTexto(mensajePedir, nombreTextoVacio);
        }

        private int IngresarCodigoInternacional()
        {
            string mensajePedir = "Ingrese el codigo internacional: ";
            string mensajeNoEsNumero =
                "El codigo internacional deben ser solo caracteres numericos mayores a cero, intente nuevamente.";
            string mensajeNumeroNegativo =
                "El codigo internacional no pueden ser numeros negativos.";
            return IngresarNumero(mensajePedir, mensajeNoEsNumero, mensajeNumeroNegativo);
        }
    }
}
