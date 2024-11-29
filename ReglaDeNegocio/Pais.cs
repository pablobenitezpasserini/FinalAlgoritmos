namespace ReglaDeNegocio
{
    public class Pais
    {
        public int CodigoInternacional { get; }
        public string Nombre { get; set; }
        public string Capital { get; set; }

        public Pais(int codigo, string nombre, string capital)
        {
            this.CodigoInternacional = codigo;
            this.Nombre = nombre;
            this.Capital = capital;
        }

        public override string ToString()
        {
            return $"Nombre: {this.Nombre} / Capital: {this.Capital} / Codigo Internacional: {this.CodigoInternacional}";
        }
    }
}

