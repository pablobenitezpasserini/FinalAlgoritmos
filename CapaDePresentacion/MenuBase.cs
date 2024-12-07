using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReglaDeNegocio;

namespace CapaDePresentacion
{
    public abstract class MenuBase
    {
        protected Validador _validador = new Validador();

        protected int IngresarNumero(string mensaje1, string mensaje2, string mensaje3)
        {
            bool isValid;
            string numeroTexto;
            int numeroValido = 0;

            do
            {
                Console.Write(mensaje1);
                numeroTexto = TomarInput();
                isValid = _validador.EsNumero(numeroTexto);

                if (!isValid)
                {
                    MostrarMensajeConEspera(mensaje2);
                }
                else
                {
                    numeroValido = int.Parse(numeroTexto);

                    if (_validador.EsNumeroNegativo(numeroValido))
                    {
                        MostrarMensajeConEspera(mensaje3);
                        isValid = false;
                    }
                }
            } while (!isValid);

            return numeroValido;
        }

        protected string IngresarTexto(string mensaje1, string mensaje2)
        {
            bool isValid;
            string texto;
            do
            {
                Console.Write(mensaje1);
                texto = TomarInput();
                isValid = _validador.EsTextoVacio(texto);

                if (isValid)
                {
                    MostrarMensajeConEspera(mensaje2);
                }
            } while (isValid);

            return texto;
        }

        protected void MostrarMensajeConEspera(string mensaje)
        {
            Console.WriteLine(mensaje);
            Console.ReadKey();
            Console.Clear();
        }

        protected string TomarInput()
        {
            string? input = Console.ReadLine();
            Console.Clear();
            return input.Trim().ToLower();
        }
    }
}
