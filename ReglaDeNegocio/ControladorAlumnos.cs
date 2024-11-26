using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReglaDeNegocio.ExcepcionesApp;

namespace ReglaDeNegocio
{
    public class ControladorAlumnos
    {
        private List<Alumno> _alumnos;
        private ControladorPaises _controladorPaises;

        public ControladorAlumnos(ControladorPaises controladorPaises)
        {
            this._alumnos = new List<Alumno>();
            this._controladorPaises = controladorPaises;
        }

        public void AgregarAlumno(Alumno alumno)
        {
            Pais? pais = _controladorPaises.BuscarPais(alumno.CodigoNacionalidad);

            AlumnoValido(pais, alumno);
            _alumnos.Add(alumno);
        }

        public bool EliminarAlumno(int dni)
        {
            Alumno? baja = BuscarAlumno(dni);

            if (baja != null)
            {
                _alumnos.Remove(baja);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ModificarAlumno(int dni, string nombre, int nota, int nacionalidad)
        {
            Pais? pais = _controladorPaises.BuscarPais(nacionalidad);
            try
            {
                Alumno alumno = new Alumno(dni, nombre, nota, nacionalidad);
                AlumnoValido(pais, alumno);
                return false;
            }
            catch (AlumnoYaExisteException)
            {
                ModificarAlumnoEnElSistema(dni, nombre, nota, nacionalidad);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string InformacionAlumnoConNotaMasAlta()
        {
            int notaMasAlta = 0;
            Alumno mejorAlumno = new Alumno();

            foreach (Alumno alumno in _alumnos)
            {
                if (alumno.Nota > notaMasAlta)
                {
                    mejorAlumno = alumno;
                    notaMasAlta = alumno.Nota;
                }
            }
            return $"El alumno con la nota mas alta es:\n{InformacionAlumno(mejorAlumno.DNI)}";
        }

        public string InformacionAlumno(int dni)
        {
            Alumno? alumno = BuscarAlumno(dni);
            if (alumno == null)
            {
                throw new AlumnoNoEncontradoException(
                    $"No hay ningun alumno registrado con el DNI: {dni}"
                );
            }
            else
            {
                return alumno.ToString();
            }
        }

        public string InformacionNacionalidadAlumno(int dni)
        {
            Alumno? alumno = BuscarAlumno(dni);
            if (alumno != null)
            {
                Pais? pais = _controladorPaises.BuscarPais(alumno.CodigoNacionalidad);
                if (pais != null)
                {
                    return $"Nacionalidad: {pais.Nombre}";
                }
                else
                {
                    int codigoInternacional = alumno.CodigoNacionalidad;
                    throw new NacionalidadNoEncontradaException(
                        $"La nacionalidad con el codigo internacional {codigoInternacional} ha sido removida del sistema"
                    );
                }
            }
            else
            {
                throw new AlumnoNoEncontradoException(
                    $"No hay ningun alumno registrado con el DNI: {dni}"
                );
            }
        }

        public double CalcularPromedio()
        {
            double totalNotas = 0.0;

            foreach (Alumno alumno in _alumnos)
            {
                totalNotas += alumno.Nota;
            }
            return totalNotas / _alumnos.Count;
        }

        public bool IsListadoAlumnosVacio()
        {
            return _alumnos.Count == 0;
        }

        private void ModificarAlumnoEnElSistema(int dni, string nombre, int nota, int nacionalidad)
        {
            for (int i = 0; i < _alumnos.Count; i++)
            {
                if (_alumnos[i].DNI == dni)
                {
                    _alumnos[i].Nota = nota;
                    _alumnos[i].Nombre = nombre;
                    _alumnos[i].CodigoNacionalidad = nacionalidad;
                }
            }
        }

        private Alumno? BuscarAlumno(int dni)
        {
            foreach (Alumno alumno in _alumnos)
            {
                if (alumno.DNI == dni)
                {
                    return alumno;
                }
            }
            return null;
        }

        private bool NombreValido(int length)
        {
            return length > 0;
        }

        private bool AlumnoExiste(int dni)
        {
            foreach (Alumno alumno in _alumnos)
            {
                if (alumno.DNI == dni)
                {
                    return true;
                }
            }
            return false;
        }

        private void AlumnoValido(Pais? pais, Alumno alumno)
        {
            if (pais == null)
            {
                throw new NacionalidadNoExisteException();
            }
            else if (alumno.Nota < 0 || alumno.Nota > 10)
            {
                throw new NotaInvalidaException();
            }
            else if (!NombreValido(alumno.Nombre.Length))
            {
                throw new NombreInvalidoException();
            }
            else if (AlumnoExiste(alumno.DNI))
            {
                throw new AlumnoYaExisteException();
            }
        }
    }
}
