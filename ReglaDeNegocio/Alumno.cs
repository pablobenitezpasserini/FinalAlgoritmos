using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReglaDeNegocio
{
    public class Alumno
    {
        public int DNI { get; set; }
        public string Nombre { get; set; }
        public int Nota { get; set; }
        public int CodigoNacionalidad { get; set; }

        public Alumno(int dni, string nombre, int nota, int codigoNacionalidad)
        {
            this.DNI = dni;
            this.Nombre = nombre;
            this.Nota = nota;
            this.CodigoNacionalidad = codigoNacionalidad;
        }
        public Alumno()
        {
            this.Nombre = "";
        }
        public override string ToString()
        {
            return $"Nombre: {this.Nombre}\nNota: {this.Nota}\nDNI: {this.DNI}";
        }
    }
}