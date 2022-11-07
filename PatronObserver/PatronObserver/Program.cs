using PatronObserver.Clases;

using System;
using System.Collections.Generic;
using System.Threading;

namespace PatronObserver
{
    

    

    // El Subject posee un estado importante y notifica a los observadores cuando cambia el estado.
    

    // Los Observadores concretos reaccionan a las actualizaciones emitidas por el Sujeto al que habían sido adjuntos.
    

    

    class Program
    {
        static void Main(string[] args)
        {
            // The client code.
            var subject = new Subject();
            var observerA = new ConcreteObserverA();
            subject.Attach(observerA);

            var observerB = new ConcreteObserverB();
            subject.Attach(observerB);

            subject.SomeBusinessLogic();
            subject.SomeBusinessLogic();

            subject.Detach(observerB);

            subject.SomeBusinessLogic();

            Console.ReadKey();
        }
    }

}
