using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReglaDeNegocio.ExcepcionesApp
{
    public class NotaInvalidaException : Exception
    {
        public NotaInvalidaException()
            : base("La nota debe ser entre 0 y 10. Intente nuevamente.") { }
    }
}
