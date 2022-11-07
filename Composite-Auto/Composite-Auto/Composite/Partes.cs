using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Composite_Auto
{
    public class Partes : Componente
    {
        int _precio;
        string _marca;
        public Partes(string nombre, int precio, string marca) : base(nombre)
        {
            _precio = precio;
        }
        public int Precio { get { return _precio; } }
        public string Marca { get { return _marca; } }
        public override void AgregarHijo(Componente c)
        {

        }

        public override IList<Componente> ObtenerHijos()
        {
            return null;
        }

        public override int ObtenerPrecio
        {
            get
            {
                return _precio;
            }
        }
    }
}
