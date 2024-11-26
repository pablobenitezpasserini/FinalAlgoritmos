using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReglaDeNegocio.ExcepcionesApp
{
    public class NacionalidadNoExisteException : Exception
    {
        public NacionalidadNoExisteException()
            : base(
                "La nacionalidad ingresada no existe en el sistema. Cargue en el sistema primero la nacionalidad deseada desde el menu de paises."
            ) { }
    }
}
