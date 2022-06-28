using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb1_Implementera.ObserverStuff
{
    public class Unsubscribe : IDisposable
    {
        private readonly List<IObserver<Rental>> _observers;
        private readonly IObserver<Rental> _observer;

        public Unsubscribe(List<IObserver<Rental>> observers, IObserver<Rental> observer)
        {
            _observers = observers;
            _observer = observer;
        }

        public void Dispose()
        {
            if (_observers.Contains(_observer))
            {
                _observers.Remove(_observer);
            }
        }
    }
}
