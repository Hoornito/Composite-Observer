using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatronObserver.Interfaces
{
    public interface IObserver
    {
        // Recibe una actualización proveniente del Subject
        void Update(ISubject subject);
    }
}
