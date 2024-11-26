using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReglaDeNegocio.ExcepcionesApp
{
    public class AlumnoNoEncontradoException : Exception
    {
        public AlumnoNoEncontradoException(string mensaje)
            : base(mensaje) { }
    }
}
