using System;

namespace AddressBook
{
    class Program
    {
        static void Main()
        {
            var service = new AddressBookService();
            bool running = true;

            while (running)
            {
                Console.WriteLine("\n=== Address Book Menu ===");
                Console.WriteLine("1. Create Contact");              
                Console.WriteLine("2. Exit");
                Console.Write("Choose an option: ");

                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        CreateContact(service);
                        break;

                    case "5":
                        running = false;
                        break;
                    case "2":
                    case "3":
                    case "4":
                        
                        break;

                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }
            }
        }

        static void CreateContact(AddressBookService service)
        {
            Console.WriteLine("\n=== Create New Contact ===");

            var contact = new Contact();

            Console.Write("First Name: ");
            contact.FirstName = Console.ReadLine() ?? string.Empty;

            Console.Write("Last Name: ");
            contact.LastName = Console.ReadLine() ?? string.Empty;

            Console.Write("Address: ");
            contact.Address = Console.ReadLine() ?? string.Empty;

            Console.Write("City: ");
            contact.City = Console.ReadLine() ?? string.Empty;

            Console.Write("State: ");
            contact.State = Console.ReadLine() ?? string.Empty;

            Console.Write("Zip: ");
            contact.Zip = Console.ReadLine() ?? string.Empty;

            Console.Write("Phone Number: ");
            contact.PhoneNumber = Console.ReadLine() ?? string.Empty;

            Console.Write("Email: ");
            contact.Email = Console.ReadLine() ?? string.Empty;

            service.AddContact(contact);

            Console.WriteLine("\nContact Created Successfully!");
            Console.WriteLine("-----------------------------");
            Console.WriteLine(contact);
        }
    }
}
