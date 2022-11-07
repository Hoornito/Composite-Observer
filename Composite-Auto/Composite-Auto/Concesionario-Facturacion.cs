using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite_Auto
{
    internal class Concesionario_Facturacion
    {
        public long OrderId { get; set; }
        public string Customer { get; set; }
        public DateTime DateTime { get; set; }

        private List<Componente> autos = new List<Componente>();

        public Concesionario_Facturacion(long orderId, string customer)
        {
            OrderId = orderId;
            Customer = customer;
            DateTime = DateTime.Now;
        }

        public List<Componente> ObtenerVehiculos()
        {
            return autos;
        }

        public double GetPrice()
        {
            double price = 0d;
            foreach (var child in autos)
            {
                price += child.ObtenerPrecio;
            }
            return price;
        }

        public void AddProduct(Componente product)
        {
            autos.Add(product);
        }

        public void RemoveProduct(Componente product)
        {
            autos.Remove(product);
        }

        public void PrintOrder()
        {
            Console.WriteLine("\n=============================================\nOrden: " + OrderId.ToString() + "\nCliente: " + Customer + "\nProductos:\n");
            foreach (var prod in autos)
            {
                Console.WriteLine(prod.Nombre + " $" + prod.ObtenerPrecio.ToString("###,##0.00"));

            }
            Console.WriteLine("Total: $" + GetPrice().ToString("###,##0.00") + "\n=============================================\n");
        }
    }
}
