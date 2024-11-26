using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReglaDeNegocio.ExcepcionesApp
{
    public class NombreInvalidoException : Exception
    {
        public NombreInvalidoException()
            : base("El nombre no puede estar vacío. Intente nuevamente.") { }
    }
}
