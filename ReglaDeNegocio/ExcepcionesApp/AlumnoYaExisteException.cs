using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReglaDeNegocio.ExcepcionesApp
{
    public class AlumnoYaExisteException : Exception
    {
        public AlumnoYaExisteException()
            : base("El DNI ingresado ya existe en nuestro sistema. Intente nuevamente.") { }
    }
}
