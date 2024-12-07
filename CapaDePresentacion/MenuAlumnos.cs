using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReglaDeNegocio;
using ReglaDeNegocio.ExcepcionesApp;

namespace CapaDePresentacion
{
    public class MenuAlumnos : MenuBase
    {
        private ControladorAlumnos _controladorAlumnos;

        public MenuAlumnos(ControladorAlumnos controladorAlumnos)
        {
            this._controladorAlumnos = controladorAlumnos;
        }

        public void MenuAlumnosPrincipal()
        {
            string opcion;

            do
            {
                Console.WriteLine("----Menu de alumnos----");
                Console.WriteLine("\n--Ingrese la opcion deseada:");
                Console.WriteLine("1- Agregar alumno");
                Console.WriteLine("2- Modificar alumno");
                Console.WriteLine("3- Eliminar alumno");
                Console.WriteLine("4- Informacion del alumno por DNI");
                Console.WriteLine("5- Mostrar alumno con nota mas alta");
                Console.WriteLine("6- Mostrar promedio general");
                Console.WriteLine("7- Volver atras");
                opcion = TomarInput();

                switch (opcion)
                {
                    case "1":
                        MostrarMenuIngresarAlumno();
                        break;
                    case "2":
                        MostrarMenuModificarAlumno();
                        break;
                    case "3":
                        MostrarMenuEliminarAlumno();
                        break;
                    case "4":
                        MostrarMenuInformacionAlumno();
                        break;
                    case "5":
                        MostrarMenuAlumnoConNotaMasAlta();
                        break;
                    case "6":
                        MostrarMenuPromedioGeneral();
                        break;
                    case "7":
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
            } while (opcion != "7");
        }

        private void MostrarMenuPromedioGeneral()
        {
            if (_controladorAlumnos.IsListadoAlumnosVacio())
            {
                MostrarMensajeConEspera(
                    "El listado de alumnos se encuentra vacio, ingrese alumnos primero."
                );
                return;
            }
            double promedio = _controladorAlumnos.CalcularPromedio();
            MostrarMensajeConEspera($"El promedio de los alumnos es: {promedio:F2}");
        }

        private void MostrarMenuAlumnoConNotaMasAlta()
        {
            if (_controladorAlumnos.IsListadoAlumnosVacio())
            {
                MostrarMensajeConEspera(
                    "El listado de alumnos se encuentra vacio, ingrese alumnos primero."
                );
                return;
            }
            string infoAlumno;

            infoAlumno = _controladorAlumnos.InformacionAlumnoConNotaMasAlta();

            MostrarMensajeConEspera(infoAlumno);
        }

        private void MostrarMenuInformacionAlumno()
        {
            if (_controladorAlumnos.IsListadoAlumnosVacio())
            {
                MostrarMensajeConEspera(
                    "El listado de alumnos se encuentra vacio, ingrese alumnos primero."
                );
                return;
            }
            string infoAlumno;
            string infoNacionalidad;
            int dni;

            dni = IngresarDNI();
            try
            {
                infoAlumno = _controladorAlumnos.InformacionAlumno(dni);
            }
            catch (AlumnoNoEncontradoException ex)
            {
                MostrarMensajeConEspera(ex.Message);
                return;
            }
            try
            {
                infoNacionalidad = _controladorAlumnos.InformacionNacionalidadAlumno(dni);
            }
            catch (NacionalidadNoEncontradaException ex)
            {
                MostrarMensajeConEspera(
                    ex.Message
                        + "\n"
                        + "Por favor actualize la nacionalidad del alumno desde la opcion \"2- Modificar Alumno\" o cargue un nuevo pais con el codigo internacional mencionado antes."
                );
                infoNacionalidad = "Nacionalidad: desconocida";
            }
            Console.WriteLine("Los datos del alumno son...");
            MostrarMensajeConEspera(infoAlumno + "\n" + infoNacionalidad);
        }

        private void MostrarMenuEliminarAlumno()
        {
            if (_controladorAlumnos.IsListadoAlumnosVacio())
            {
                MostrarMensajeConEspera(
                    "El listado de alumnos esta vacio, ingrese alumnos primero."
                );
                return;
            }

            int dni;

            dni = IngresarDNI();

            if (_controladorAlumnos.EliminarAlumno(dni))
            {
                MostrarMensajeConEspera("Alumno eliminado correctamente.");
            }
            else
            {
                MostrarMensajeConEspera($"No existe un alumno con el DNI: {dni} en el curso.");
            }
        }

        private void MostrarMenuModificarAlumno()
        {
            if (_controladorAlumnos.IsListadoAlumnosVacio())
            {
                MostrarMensajeConEspera("El listado esta vacio, ingrese alumnos primero.");
                return;
            }
            string info;
            string infoNacionalidad;
            string nombre;
            int nota;
            int dni;
            int codigoNacionalidad;
            bool operacionExitosa;

            dni = IngresarDNI();
            try
            {
                info = _controladorAlumnos.InformacionAlumno(dni);
            }
            catch (AlumnoNoEncontradoException ex)
            {
                MostrarMensajeConEspera(ex.Message);
                return;
            }
            try
            {
                infoNacionalidad = _controladorAlumnos.InformacionNacionalidadAlumno(dni);
            }
            catch (NacionalidadNoEncontradaException)
            {
                infoNacionalidad = "Nacionalidad: desconocida";
            }

            Console.WriteLine("Los datos del alumno a modificar son...");
            MostrarMensajeConEspera(info + "\n" + infoNacionalidad);
            nombre = IngresarNombreAlumno();
            nota = IngresarNotaAlumno();
            codigoNacionalidad = IngresarCodigoNacionalidadAlumno();

            try
            {
                operacionExitosa = _controladorAlumnos.ModificarAlumno(
                    dni,
                    nombre,
                    nota,
                    codigoNacionalidad
                );
                MostrarMensajeConEspera("Datos modificados correctamente.");
            }
            catch (Exception ex)
            {
                MostrarMensajeConEspera(ex.Message);
            }
        }

        private void MostrarMenuIngresarAlumno()
        {
            int dni;
            string nombre;
            int nota;
            int codigoNacionalidad;

            dni = IngresarDNI();
            nombre = IngresarNombreAlumno();
            nota = IngresarNotaAlumno();
            codigoNacionalidad = IngresarCodigoNacionalidadAlumno();
            try
            {
                _controladorAlumnos.AgregarAlumno(
                    new Alumno(dni, nombre, nota, codigoNacionalidad)
                );
            }
            catch (Exception ex)
            {
                MostrarMensajeConEspera(ex.Message);
            }
        }

        private int IngresarCodigoNacionalidadAlumno()
        {
            string mensajePedir = "Ingrese el codigo internacional: ";
            string mensajeNoEsNumero =
                "El codigo internacional deben ser solo caracteres numericos mayores a cero, intente nuevamente.";
            string mensajeNumeroNegativo =
                "El codigo internacional no pueden ser numeros negativos.";
            return IngresarNumero(mensajePedir, mensajeNoEsNumero, mensajeNumeroNegativo);
        }

        private int IngresarNotaAlumno()
        {
            string mensajePedir = "Ingrese la nota: ";
            string mensajeNoEsNumero =
                "La nota debe ser solo caracteres numericos mayores a cero, intente nuevamente.";
            string mensajeNumeroNegativo = "La nota no puede ser negativa.";
            return IngresarNumero(mensajePedir, mensajeNoEsNumero, mensajeNumeroNegativo);
        }

        private string IngresarNombreAlumno()
        {
            string mensajePedir = "Ingrese el nombre: ";
            string nombreTextoVacio = "El nombre no puede estar vacio, intente nuevamente.";
            return IngresarTexto(mensajePedir, nombreTextoVacio);
        }

        private int IngresarDNI()
        {
            string mensajePedir = "Ingrese el DNI: ";
            string mensajeNoEsNumero =
                "El DNI deben ser solo caracteres numericos mayores que 0, sin punto o espacios, intente nuevamente.";
            string mensajeNumeroNegativo =
                "El DNI no puede ser un numero menor que 0, intente nuevamente.";
            return IngresarNumero(mensajePedir, mensajeNoEsNumero, mensajeNumeroNegativo);
        }
    }
}
