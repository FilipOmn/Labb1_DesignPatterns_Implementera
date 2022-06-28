using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb1_Implementera
{
    //En Singleton klass med en lista av customers(strings)
    public class Customers
    {
        private static readonly Customers instance = new Customers();
        private List<string> customers = new List<string>();

        private Customers()
        {
            customers.Add("Britt");
            customers.Add("Bruno");
            customers.Add("Ben");
        }

        public static Customers GetInstance()
        {
            return instance;
        }

        public List<string> GetCustomers()
        {
            var a = customers;

            return a;
        }

        public string GetSingleCustomer(string customer)
        {
            string customerToReturn = customers.Where(c => c.Contains(customer)).SingleOrDefault();

            return customerToReturn;
        }
    }
}
