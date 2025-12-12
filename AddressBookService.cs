using System.Collections.Generic;
using System.Linq;

namespace AddressBook
{
    public class AddressBookService
    {
        private readonly List<Contact> _contacts = new();

        public Contact AddContact(Contact contact)
        {
            _contacts.Add(contact);
            return contact;
        }

        public List<Contact> GetAllContacts()
        {
            return _contacts;
        }

        public Contact? FindContactByName(string name)
        {
            return _contacts.FirstOrDefault(c =>
                c.FirstName.Equals(name, System.StringComparison.OrdinalIgnoreCase));
        }

        public bool UpdateContact(Contact existing, Contact updated)
        {
            existing.FirstName = updated.FirstName;
            existing.LastName = updated.LastName;
            existing.Address = updated.Address;
            existing.City = updated.City;
            existing.State = updated.State;
            existing.Zip = updated.Zip;
            existing.PhoneNumber = updated.PhoneNumber;
            existing.Email = updated.Email;

            return true;
        }
    }
}
