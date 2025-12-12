using System;
using System.Collections.Generic;

namespace AddressBook
{
    class Program
    {
        static BookManager manager = new(); 

        static void Main()
        {
            bool running = true;

            while (running)
            {
                Console.WriteLine("\n=== Address Book System ===");
                Console.WriteLine("1. Create New Address Book");
                Console.WriteLine("2. Select Address Book");
                Console.WriteLine("3. Exit");
                Console.Write("Choose an option: ");

                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        CreateAddressBook();
                        break;

                    case "2":
                        SelectAddressBook();
                        break;

                    case "3":
                        running = false;
                        break;

                    default:
                        Console.WriteLine("Invalid Option.");
                        break;
                }
            }
        }

        static void CreateAddressBook()
        {
            Console.Write("\nEnter new Address Book name: ");
            string? name = Console.ReadLine();

            try
            {
                bool created = manager.AddAddressBook(name);

                if (!created)
                {
                    Console.WriteLine("Address Book already exists.");
                    return;
                }

                Console.WriteLine($"Address Book '{name}' created successfully!");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR: {ex.Message}");
            }
        }

        static void SelectAddressBook()
        {
            if (!manager.HasBooks())
            {
                Console.WriteLine("No Address Books exist. Create one first.");
                return;
            }

            Console.WriteLine("\nAvailable Address Books:");

            foreach (var name in manager.GetAllAddressBookNames())
                Console.WriteLine($"- {name}");

            Console.Write("\nEnter Address Book name to open: ");
            string? nameToOpen = Console.ReadLine();

            try
            {
                var selectedBook = manager.GetAddressBook(nameToOpen);
                AddressBookMenu(selectedBook);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR: {ex.Message}");
            }
        }

        static void AddressBookMenu(AddressBookService service)
        {
            bool managing = true;

            while (managing)
            {
                Console.WriteLine("\n=== Address Book Menu ===");
                Console.WriteLine("1. Create Contact");
                Console.WriteLine("2. Add Multiple Contacts");
                Console.WriteLine("3. Edit Contact");
                Console.WriteLine("4. Delete Contact");
                Console.WriteLine("5. Back to Main Menu");
                Console.Write("Choose an option: ");

                string? choice = Console.ReadLine();

                try
                {
                    switch (choice)
                    {
                        case "1":
                            CreateSingleContact(service);
                            break;

                        case "2":
                            AddMultipleContacts(service);
                            break;

                        case "3":
                            EditContact(service);
                            break;

                        case "4":
                            DeleteContact(service);
                            break;

                        case "5":
                            managing = false;
                            break;

                        default:
                            Console.WriteLine("Invalid Option.");
                            break;
                    }
                }
                catch (ContactNotFoundException ex)
                {
                    Console.WriteLine($"ERROR: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Validation Error: {ex.Message}");
                }
            }
        }
        static void CreateSingleContact(AddressBookService service)
        {
            var contact = ReadContactFromConsole();
            service.AddContact(contact);
            Console.WriteLine("\nContact Created Successfully!");
            Console.WriteLine(contact);
        }

        static void AddMultipleContacts(AddressBookService service)
        {
            bool addMore = true;

            while (addMore)
            {
                var contact = ReadContactFromConsole();
                service.AddContact(contact);

                Console.Write("\nAdd another? (y/n): ");
                addMore = Console.ReadLine()?.ToLower() == "y";
            }
        }

        static void EditContact(AddressBookService service)
        {
            Console.Write("\nEnter FIRST NAME of contact to edit: ");
            string? name = Console.ReadLine();

            var existing = service.FindContactByName(name);

            Console.WriteLine("\nEditing Contact:");
            Console.WriteLine(existing);

            var updated = ReadContactFromConsole();

            service.UpdateContact(existing, updated);
            Console.WriteLine("\nContact Updated Successfully!");
        }

        static void DeleteContact(AddressBookService service)
        {
            Console.Write("\nEnter FIRST NAME of contact to delete: ");
            string? name = Console.ReadLine();

            bool deleted = service.DeleteContact(name);

            if (deleted)
                Console.WriteLine("Contact Deleted Successfully!");
        }
        static Contact ReadContactFromConsole()
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

            return contact;
        }
    }
}
