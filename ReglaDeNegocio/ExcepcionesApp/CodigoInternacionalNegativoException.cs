using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReglaDeNegocio.ExcepcionesApp
{
    public class CodigoInternacionalNegativoException : Exception
    {
        public CodigoInternacionalNegativoException()
            : base("El codigo internacional no puede ser menor a 0") { }
    }
}
