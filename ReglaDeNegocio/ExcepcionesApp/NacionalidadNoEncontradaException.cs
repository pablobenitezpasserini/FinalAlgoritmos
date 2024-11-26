using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReglaDeNegocio.ExcepcionesApp
{
    public class NacionalidadNoEncontradaException : Exception
    {
        public NacionalidadNoEncontradaException(string mensaje)
            : base(mensaje) { }
    }
}
