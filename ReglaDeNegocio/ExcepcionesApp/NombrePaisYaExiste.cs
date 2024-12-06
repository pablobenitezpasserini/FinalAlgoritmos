using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReglaDeNegocio.ExcepcionesApp
{
    public class NombrePaisYaExiste : Exception
    {
        public NombrePaisYaExiste()
            : base(
                "El nombre del pais ingresado ya esta registrado en nuestro sistema, intente nuevamente"
            ) { }
    }
}
