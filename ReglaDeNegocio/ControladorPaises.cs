using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            if (PaisExiste(pais.CodigoInternacional))
            {
                return false;
            }
            else
            {
                _paises.Add(pais);
                return true;
            }
        }

        public bool PaisExiste(int codigoInternacional)
        {
            foreach(Pais pais in _paises)
            {
                if(pais.CodigoInternacional == codigoInternacional)
                {
                    return true;
                }
            }
            return false;
        }
        //modificar pais
        public bool ModificarPais(string nombre, string capital, int codigoInternacional)
        {
            for(int i = 0; i < _paises.Count; i++)
            {
                if(_paises[i].CodigoInternacional == codigoInternacional)
                {
                    _paises[i].Nombre = nombre;
                    _paises[i].Capital = capital;
                    return true;
                }
            }
            return false;
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