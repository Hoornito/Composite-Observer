using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Composite_Auto
{
    internal class Auto : Componente
    {
        private List<Componente> _hijos;
        public Auto(string nombre) : base(nombre)
        {
            _hijos = new List<Componente>();
        }

        public override void AgregarHijo(Componente c)
        {
            if (EsAncestro(c))
            {
                throw new Exception("No se puede agregar un ancestro por dependencia circular");
            }
            _hijos.Add(c);
        }

        //Metodo para resolver la dependencia circular
        private bool EsAncestro(Componente c)
        {
            //Recorrer los hijos que sean autos
            foreach (var hijo in _hijos.OfType<Auto>())
            {
                if (hijo == c && hijo is Componente)
                    return true;
                if (hijo is Auto)
                {
                    if (((Auto)hijo).EsAncestro(c))
                        return true;
                }
                if (c is Auto)
                {
                    if (((Auto)c).EsAncestro(hijo))
                        return true;
                }
            }
            foreach (Componente hijoDestino in c is Auto ? c.ObtenerHijos() : new List<Componente>())
            {
                if (hijoDestino == this)
                    return true;
            }

            return false;
        }

        public override IList<Componente> ObtenerHijos()
        {
            return _hijos.ToArray() ?? null ;
        }

        public override int ObtenerPrecio
        {
            get
            {
                int t = 0;

                foreach (var item in _hijos)
                {
                    t += item.ObtenerPrecio;
                }

                return t;
            }

        }

        public void ObtenerDetalle()
        {
            string detalle = string.Empty;

            foreach (var item in _hijos)
            {
                detalle += item.Nombre + " $" + item.ObtenerPrecio +"\n";
                    
            }
            Console.WriteLine($"El auto {this.Nombre} está compuesto de: \n" +detalle);
        }
    }
}
