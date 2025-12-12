using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
