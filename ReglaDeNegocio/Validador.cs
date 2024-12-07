using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReglaDeNegocio
{
    public class Validador
    {
        public bool EsNumero(string num)
        {
            try
            {
                int numeroValido = int.Parse(num);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool EsTextoVacio(string texto)
        {
            return texto.Length == 0;
        }

        public bool EsNumeroNegativo(int num)
        {
            return num < 0;
        }
    }
}
