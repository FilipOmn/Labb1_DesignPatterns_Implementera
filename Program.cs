using Labb1_Implementera.Movies;
using Labb1_Implementera.ObserverStuff;
using System;
using System.Collections.Generic;

namespace Labb1_Implementera
{
    class Program
    {
        static void Main(string[] args)
        {
            //Jag använder Factory method, Observer och Singleton


            var Customer = "customer";
            var ManagerId = 0;
            var Manager_1 = new RentalShopManager("Andreas");
            var Manager_2 = new RentalShopManager("Petter");
            var provider = new RentalHandler();
            List<RentalShopManager> rentalShopManagers = new List<RentalShopManager>();
            rentalShopManagers.Add(Manager_1);
            rentalShopManagers.Add(Manager_2);

            ManagerMenu();

            void ManagerMenu()
            {
                Console.Clear();

                Console.WriteLine("Manager to notify.. \n1. Andreas \n2. Petter \n3. both");

                try
                {
                    int UserInput = Convert.ToInt32(Console.ReadLine());

                    //Här väljer användaren vilka managers som ska få notificationer när en customer hyr en film
                    if (UserInput == 1)
                    {
                        if(ManagerId == 2)
                        {
                            Manager_2.Unsubscribe();
                        }
                        if(ManagerId == 3)
                        {
                            Manager_1.Unsubscribe();
                            Manager_2.Unsubscribe();
                        }

                        Manager_1.Subscribe(provider);
                        ManagerId = 1;
                        CustomerMenu();
                    }
                    else if (UserInput == 2)
                    {
                        if (ManagerId == 1)
                        {
                            Manager_1.Unsubscribe();
                        }
                        if (ManagerId == 3)
                        {
                            Manager_1.Unsubscribe();
                            Manager_2.Unsubscribe();
                        }

                        Manager_2.Subscribe(provider);
                        ManagerId = 2;
                        CustomerMenu();
                    }
                    else if(UserInput == 3)
                    {
                        if(ManagerId == 1)
                        {
                            Manager_2.Subscribe(provider);
                        }
                        if(ManagerId == 2)
                        {
                            Manager_1.Subscribe(provider);
                        }
                        else
                        {
                            Manager_1.Subscribe(provider);
                            Manager_2.Subscribe(provider);
                        }
                        ManagerId = 3;
                        CustomerMenu();
                    }
                    else
                    {
                        Console.WriteLine("Invalid option, press any key to return to previous menu");
                        Console.ReadLine();
                        ManagerMenu();
                    }
                }
                catch
                {
                    Console.WriteLine("error");
                    Console.ReadLine();
                    ManagerMenu();
                }
            }

            void CustomerMenu()
            {
                Console.Clear();

                Console.WriteLine("Log in as Customer.. \n");

                try
                {
                    int i = 0;
                    foreach (var customer in Customers.GetInstance().GetCustomers())
                    {
                        i++;
                        Console.WriteLine($"{i}. {customer}");
                    }

                    int UserInput = Convert.ToInt32(Console.ReadLine());

                    if (UserInput == 1)
                    {
                        //Sätter en customer från en instans av singleton klassen med en listan av customers.
                        Customer = Customers.GetInstance().GetSingleCustomer("Britt");
                        MainMenu();
                    }
                    else if (UserInput == 2)
                    {
                        Customer = Customers.GetInstance().GetSingleCustomer("Bruno");
                        MainMenu();
                    }
                    else if (UserInput == 3)
                    {
                        Customer = Customers.GetInstance().GetSingleCustomer("Ben");
                        MainMenu();
                    }
                    else
                    {
                        Console.WriteLine("Invalid option, press any key to return to previous menu");
                        Console.ReadLine();
                        CustomerMenu();
                    }
                }
                catch
                {
                    Console.WriteLine("error");
                    Console.ReadLine();
                    CustomerMenu();
                }  
            }

            void MainMenu()
            {
                Console.Clear();
                try
                {
                    Console.WriteLine("Actions \n------------- \n1. Movies available for rent \n2. Choose Manager \n3. Choose Customer");
                    int UserInput = Convert.ToInt32(Console.ReadLine());

                    if(UserInput == 1)
                    {
                        MoviesForRental();
                    }
                    else if(UserInput == 2)
                    {
                        ManagerMenu();
                    }
                    else if (UserInput == 3)
                    {
                        CustomerMenu();
                    }
                    else
                    {
                        Console.WriteLine("Invalid option, press any key to return to previous menu");
                        Console.ReadLine();
                        MainMenu();
                    }
                }
                catch
                {
                    Console.WriteLine("Use any of the numbers listed above, press any key to retry");
                    Console.ReadLine();
                    MainMenu();
                }
            }

            void MoviesForRental()
            {
                Console.Clear();

                try
                {
                    Console.WriteLine("Movies available for rent \n---------------- \n1. AVeryBadMovie \n2. AnOkayMovie \n3. AGoodMovie");
                    int UserInput = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine();

                    if(UserInput == 1)
                    {
                        //Här används factory method för att sätta Imovie till en dålig film.
                        IMovie movie = MovieFactory.GetMovie("AVeryBadMovie");
                        provider.AddRental(new Rental($"{movie.GetTitle()}", $"{Customer}", DateTime.Now));
                        Notify();
                        Console.ReadLine();
                        MainMenu();
                    }
                    else if(UserInput == 2)
                    {
                        IMovie movie = MovieFactory.GetMovie("AnOkayMovie");
                        provider.AddRental(new Rental($"{movie.GetTitle()}", $"{Customer}", DateTime.Now));
                        Notify();
                        Console.ReadLine();
                        MainMenu();
                    }
                    else if(UserInput == 3)
                    {
                        IMovie movie = MovieFactory.GetMovie("AGoodMovie");
                        provider.AddRental(new Rental($"{movie.GetTitle()}", $"{Customer}", DateTime.Now));
                        Notify();
                        Console.ReadLine();
                        MainMenu();
                    }
                    else
                    {
                        Console.WriteLine("Invalid option, press any key to return to previous menu");
                        Console.ReadLine();
                        MoviesForRental();
                    }
                }
                catch(Exception e)
                {
                    Console.WriteLine(e);
                    Console.ReadLine();
                    MoviesForRental();
                }
                
            }

            void Notify()
            {
                //Här används Observer design pattern för att notifiera alla managers som är subscribed
                foreach (var managerSubscribed in rentalShopManagers)
                {
                    managerSubscribed.ListRentals();
                }
            }
        }
    }
}
