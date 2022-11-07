using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatronObserver.Interfaces
{
    public interface ISubject
    {
        // Añade un observador al sujeto.
        void Attach(IObserver observer);

        // Quita un observador del sujeto.
        void Detach(IObserver observer);

        // Notifica a todos los observadores que ocurrió un evento
        void Notify();
    }
}
