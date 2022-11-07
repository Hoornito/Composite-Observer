using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Composite_Auto;

namespace Composite_Auto
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var A1 = new Auto("Deportivo");
            var A2 = new Auto("Clasico");

            Componente puertasD = new Partes("puertas", 100, "ferrari");
            Componente puertasC = new Partes("puertas", 50, "FIAT");

            Componente llantasD = new Partes("llantas", 100, "ferrari");
            Componente llantasC = new Partes("llantas", 50, "FIAT");

            Componente motorD = new Partes("motor", 100, "ferrari");
            Componente motorC = new Partes("motor", 50, "FIAT");

            try
            {
                //A1.AgregarHijo(puertasD);
                //A1.AgregarHijo(llantasD);
                //A1.AgregarHijo(motorD);
                //A2.AgregarHijo(puertasC);
                //A2.AgregarHijo(llantasC);
                //A2.AgregarHijo(motorC);

                A1.AgregarHijo(A2);
                //A1.AgregarHijo(puertasD);
                //A1.AgregarHijo(llantasD);

                A2.AgregarHijo(A1);


                //var genericRepository = new GenericRepository<Auto>("Auto");
                //var result = genericRepository.GetAsync(1);
                //dir1.AgregarHijo(archivo6);

                ////dir3.AgregarHijo(dir1);  //Prueba depedencia circular

                ////Otra prueba
                //dir1.AgregarHijo(dir2);
                //dir2.AgregarHijo(dir3);
                //dir2.AgregarHijo(dir2);

                A1.ObtenerDetalle();
                A2.ObtenerDetalle();
                
                var CONCESIONARIO = new Concesionario_Facturacion(1, "Juan Perez");
                CONCESIONARIO.AddProduct(A1);
                CONCESIONARIO.AddProduct(A2);
                CONCESIONARIO.PrintOrder();

                

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            

            Console.WriteLine($"El precio del auto {A1.Nombre} cuesta {A1.ObtenerPrecio}");
            Console.WriteLine($"El precio del auto {A2.Nombre} cuesta {A2.ObtenerPrecio}");

            Console.ReadKey();
        }

        public static Guid ToGuid(int value)
        {
            byte[] bytes = new byte[16];
            BitConverter.GetBytes(value).CopyTo(bytes, 0);
            return new Guid(bytes);
        }
    }
}
