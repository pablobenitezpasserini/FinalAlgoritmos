using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReglaDeNegocio.ExcepcionesApp
{
    public class StringConNumeroException : Exception
    {
        public StringConNumeroException(string texto)
            : base(texto) { }
    }
}
