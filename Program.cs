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
                Console.WriteLine("2. Add New Contact");
                Console.WriteLine("3. Edit Contact");
                Console.WriteLine("4. Delete Contact");
                Console.WriteLine("5. Exit");
                Console.Write("Choose an option: ");

                string? choice = Console.ReadLine();

                switch (choice)

                {
                    case "1":
                        Console.WriteLine("\n--- Create First Contact ---");
                        CreateOrAddContact(service);
                        break;

                    case "2":
                        Console.WriteLine("\n--- Add New Contact ---");
                        CreateOrAddContact(service);
                        break;
                    case "3":
                        EditContact(service);
                        break;
                    case "4":
                        DeleteContact(service);
                        break;

                    case "5":
                        running = false;
                        break;




                        break;

                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }
            }
        }

        static void CreateOrAddContact(AddressBookService service)
        {
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

            Console.WriteLine("\nContact Successfully Added!");
            Console.WriteLine("--------------------------------");
            Console.WriteLine(contact);
        }
        static void EditContact(AddressBookService service)
        {
            Console.Write("\nEnter FIRST NAME of contact to edit: ");
            string? name = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Name cannot be empty.");
                return;
            }

            var existing = service.FindContactByName(name);

            if (existing == null)
            {
                Console.WriteLine("Contact not found.");
                return;
            }

            Console.WriteLine("\nContact Found:");
            Console.WriteLine(existing);
            Console.WriteLine("\nEnter new details (press Enter to keep old value):");

            var updated = new Contact();

            Console.Write($"First Name ({existing.FirstName}): ");
            string? first = Console.ReadLine();
            updated.FirstName = string.IsNullOrWhiteSpace(first) ? existing.FirstName : first;

            Console.Write($"Last Name ({existing.LastName}): ");
            string? last = Console.ReadLine();
            updated.LastName = string.IsNullOrWhiteSpace(last) ? existing.LastName : last;

            Console.Write($"Address ({existing.Address}): ");
            string? address = Console.ReadLine();
            updated.Address = string.IsNullOrWhiteSpace(address) ? existing.Address : address;

            Console.Write($"City ({existing.City}): ");
            string? city = Console.ReadLine();
            updated.City = string.IsNullOrWhiteSpace(city) ? existing.City : city;

            Console.Write($"State ({existing.State}): ");
            string? state = Console.ReadLine(); updated.State = string.IsNullOrWhiteSpace(state) ? existing.State : state;

            Console.Write($"Zip ({existing.Zip}): ");
            string? zip = Console.ReadLine();
            updated.Zip = string.IsNullOrWhiteSpace(zip) ? existing.Zip : zip;

            Console.Write($"Phone ({existing.PhoneNumber}): ");
            string? phone = Console.ReadLine();
            updated.PhoneNumber = string.IsNullOrWhiteSpace(phone) ? existing.PhoneNumber : phone;

            Console.Write($"Email ({existing.Email}): ");
            string? email = Console.ReadLine();
            updated.Email = string.IsNullOrWhiteSpace(email) ? existing.Email : email;

            service.UpdateContact(existing, updated);

            Console.WriteLine("\nContact Updated Successfully!");
            Console.WriteLine(existing);
        }
        static void DeleteContact(AddressBookService service)
        {
            Console.Write("\nEnter FIRST NAME of contact to delete: ");
            string? name = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Name cannot be empty.");
                return;
            }

            bool deleted = service.DeleteContact(name);

            if (deleted)
            {
                Console.WriteLine("Contact Deleted Successfully!");
            }
            else
            {
                Console.WriteLine("Contact not found.");
            }
        }
    }
}
