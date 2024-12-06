using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReglaDeNegocio.ExcepcionesApp;

namespace ReglaDeNegocio
{
    public class ControladorPaises
    {
        private List<Pais> _paises;

        public ControladorPaises()
        {
            _paises = new List<Pais>();
        }

        //agregar pais
        public bool AgregarPais(Pais pais)
        {
            //implementar excepciones para capital existe y nombre pais existe
            if (CodigoPaisExiste(pais.CodigoInternacional))
            {
                return false;
            }
            else if (NombrePaisExiste(pais.Nombre))
            {
                throw new NombrePaisYaExiste();
            }
            else if (NombreCapitalExiste(pais.Capital))
            {
                throw new NombreCapitalYaExiste();
            }
            else
            {
                _paises.Add(pais);
                return true;
            }
        }

        private bool NombreCapitalExiste(string nombreCapital)
        {
            foreach (Pais pais in _paises)
            {
                if (nombreCapital.Equals(pais.Capital))
                {
                    return true;
                }
            }
            return false;
        }

        private bool NombrePaisExiste(string nombrePais)
        {
            foreach (Pais pais in _paises)
            {
                if (nombrePais.Equals(pais.Nombre))
                {
                    return true;
                }
            }
            return false;
        }

        public bool CodigoPaisExiste(int codigoInternacional)
        {
            foreach (Pais pais in _paises)
            {
                if (pais.CodigoInternacional == codigoInternacional)
                {
                    return true;
                }
            }
            return false;
        }

        //modificar pais
        public void ModificarNombrePais(string nombrePais, int codigoInternacional)
        {
            bool valido = NombrePaisExiste(nombrePais);
            if (!valido)
            {
                for (int i = 0; i < _paises.Count; i++)
                {
                    if (_paises[i].CodigoInternacional == codigoInternacional)
                    {
                        _paises[i].Nombre = nombrePais;
                    }
                }
            }
            else
            {
                throw new NombrePaisYaExiste();
            }
        }

        public void ModificarNombreCapital(string nombreCapital, int codigoInternacional) 
        {
            bool valido = NombreCapitalExiste(nombreCapital);
            if (!valido)
            {
                for (int i = 0; i < _paises.Count; i++)
                {
                    if (_paises[i].CodigoInternacional == codigoInternacional)
                    {
                        _paises[i].Capital = nombreCapital;
                    }
                }
            }
            else
            {
                throw new NombreCapitalYaExiste();
            }
        }

        //consultar pais por codigo
        public string InformacionPais(int codigoInternacional)
        {
            Pais? encontrado = BuscarPais(codigoInternacional);

            if (encontrado != null)
            {
                return encontrado.ToString();
            }
            else
            {
                return "";
            }
        }

        public Pais? BuscarPais(int codigoInternacional)
        {
            foreach (Pais pais in _paises)
            {
                if (pais.CodigoInternacional == codigoInternacional)
                {
                    return pais;
                }
            }
            return null;
        }

        //eliminar pais
        public bool EliminarPais(int codigoInternacional)
        {
            Pais? baja = BuscarPais(codigoInternacional);

            if (baja != null)
            {
                _paises.Remove(baja);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsPaisesVacio()
        {
            return _paises.Count == 0;
        }
    }
}
