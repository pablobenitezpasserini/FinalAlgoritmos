using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReglaDeNegocio.ExcepcionesApp
{
    public class NombreCapitalYaExiste : Exception
    {
        public NombreCapitalYaExiste()
            : base("El nombre de la capital ingresada ya esta registrada en nuestro sistema, intente nuevamente.") { }
    }
}
