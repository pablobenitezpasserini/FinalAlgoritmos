using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReglaDeNegocio.ExcepcionesApp
{
    public class DocumentoNacionalDeIdentidadNegativoException : Exception
    {
        public DocumentoNacionalDeIdentidadNegativoException()
            : base("El dni no puede ser un numero menor que 0") { }
    }
}
