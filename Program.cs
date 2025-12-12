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
                Console.WriteLine("2. Add Multiple Contacts");
                Console.WriteLine("3. Edit Contact");
                Console.WriteLine("4. Delete Contact");
                Console.WriteLine("5. Exit");
                Console.Write("Choose an option: ");

                string? choice = Console.ReadLine();

                try
                {
                    switch (choice)
                    {
                        case "1":
                            Console.WriteLine("\n--- Create First Contact ---");
                            CreateSingleContact(service);
                            break;

                        case "2":
                            Console.WriteLine("\n--- Add Multiple Contacts ---");
                            AddMultipleContacts(service);
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

                        default:
                            Console.WriteLine("Invalid option. Try again.");
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
            Console.WriteLine("\nContact Successfully Created!");
            Console.WriteLine(contact);
        }
        static void AddMultipleContacts(AddressBookService service)
        {
            bool addMore = true;

            while (addMore)
            {
                var contact = ReadContactFromConsole();
                service.AddContact(contact);

                Console.WriteLine("\nContact Added Successfully!");
                Console.WriteLine(contact);

                Console.Write("\nDo you want to add another contact? (y/n): ");
                string? choice = Console.ReadLine();

                addMore = choice?.ToLower() == "y";
            }
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
            {
                Console.WriteLine("Contact Deleted Successfully!");
            }
        }
    }
}
