using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb1_Implementera.ObserverStuff
{
    //RentalShopManager klassen har rollen som observer som får notificationer från provider klassen
    public class RentalShopManager : IObserver<Rental>
    {
        public string Name { get; set; }
        public List<Rental> Rentals { get; set; }

        private IDisposable _cancellation;

        public RentalShopManager(string name)
        {
            Name = name;
            Rentals = new();
        }

        public void ListRentals()
        {
            if (Rentals.Any())
            {
                foreach(var item in Rentals)
                {
                    Console.WriteLine($"{item.dateTimeRented}: {Name}, {item.CustomerName} has rented {item.MovieName}");
                }
            }
        }

        public virtual void Subscribe(RentalHandler provider)
        {
            _cancellation = provider.Subscribe(this);
        }

        public virtual void Unsubscribe()
        {
            _cancellation.Dispose();
            Rentals.Clear();
        }

        public void OnCompleted()
        {
            Console.WriteLine("No more notifications");
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnNext(Rental rental)
        {
            Rentals.Add(rental);
        }
    }
}
