using PatronObserver.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PatronObserver.Clases
{
    public class Subject : ISubject
    {
        // En pos de la simplicidad, el estado del Sujeto, esencial para todos los suscriptores, se almacena en esta variable.
        public int State { get; set; } = -0;

        // Lista de suscriptores. En la vida real, la lista de suscriptores se puede almacenar de manera más completa (categorizada por tipo de evento, etc.)
        private List<IObserver> _observers = new();

        // Los métodos de gestión de suscripciones.
        public void Attach(IObserver observer)
        {
            Console.WriteLine("Subject: Un observador ha sido añadido.");
            this._observers.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            this._observers.Remove(observer);
            Console.WriteLine("Subject: Un observador ha sido removido.");
        }

        // Activa una actualización en cada suscriptor.
        public void Notify()
        {
            Console.WriteLine("Subject: Notificando a los observadores...");

            foreach (var observer in _observers)
            {
                observer.Update(this);
            }
        }

        // Por lo general, la lógica de suscripción es solo una fracción de lo que realmente puede hacer un sujeto.
        // Los sujetos suelen tener una lógica de negocio importante, que activa un método de notificación cada vez que algo importante está a punto de suceder (o después).
        public void SomeBusinessLogic()
        {
            Console.WriteLine("\nSubject: Estoy haciendo algo importante.");
            this.State = new Random().Next(0, 10);

            Thread.Sleep(15);

            Console.WriteLine("Subject: Mi estado acaba de cambiar a: " + this.State);
            this.Notify();
        }
    }
}
