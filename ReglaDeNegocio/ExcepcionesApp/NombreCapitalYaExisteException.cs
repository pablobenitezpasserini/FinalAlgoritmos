using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReglaDeNegocio.ExcepcionesApp
{
    public class NombreCapitalYaExisteException : Exception
    {
        public NombreCapitalYaExisteException()
            : base("El nombre de la capital ingresada ya esta registrada en nuestro sistema, intente nuevamente.") { }
    }
}
