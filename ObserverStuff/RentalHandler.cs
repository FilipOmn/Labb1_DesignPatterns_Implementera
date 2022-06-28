using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb1_Implementera.ObserverStuff
{
    //RentalHandler är Provider klassen som skickar notificationer till observers
    public class RentalHandler : IObservable<Rental>
    {
        private readonly List<IObserver<Rental>> _observers;
        public List<Rental> Rentals { get; set; }
        public RentalHandler()
        {
            _observers = new();
            Rentals = new();
        }

        public IDisposable Subscribe(IObserver<Rental> observer)
        {
            if (!_observers.Contains(observer))
            {
                _observers.Add(observer);

                foreach (var rentals in Rentals)
                {
                    observer.OnNext(rentals);
                }
            }
            return new Unsubscribe(_observers, observer);
        }

        public void AddRental(Rental rental)
        {
            Rentals.Add(rental);
            foreach (var observer in _observers)
            {
                observer.OnNext(rental);
            }
        }
        public void CloseRentals()
        {
            foreach (var observer in _observers)
            {
                observer.OnCompleted();
                _observers.Clear();
            }
        }
    }
}
