using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb1_Implementera.ObserverStuff
{
    public class Rental
    {
        public string MovieName { get; set; }
        public string CustomerName { get; set; }
        public DateTime dateTimeRented { get; set; }
        public Rental(string movieName, string customerName, DateTime dateTime)
        {
            MovieName = movieName;
            CustomerName = customerName;
            dateTimeRented = dateTime;
        }
    }
}
