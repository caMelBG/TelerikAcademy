using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace Phonebook
{
    class PhonebookRepository : IPhonebookRepository
    {
        private OrderedSet<Contact> orderedContacts =
            new OrderedSet<Contact>();
        private Dictionary<string, Contact> contactsByName =
             new Dictionary<string, Contact>();
        private MultiDictionary<string, Contact> contactsByNumber =
              new MultiDictionary<string, Contact>(false);

        public bool AddPhone(string name, IEnumerable<string> phoneNumbers)
        {
            string nameToLowerCase = name.ToLowerInvariant();
            Contact currentContact;
            bool flag = !this.contactsByName.TryGetValue(nameToLowerCase, out currentContact);
            if (flag)
            {
                currentContact = new Contact();
                currentContact.Name = name;
                currentContact.phoneNumbers = new SortedSet<string>();
                this.contactsByName.Add(nameToLowerCase, currentContact);
                this.orderedContacts.Add(currentContact);
            }

            foreach (var number in phoneNumbers)
            {
                this.contactsByNumber.Add(number, currentContact);
            }

            currentContact.phoneNumbers.UnionWith(phoneNumbers);
            return flag;
        }

        public int ChangePhone(string oldPhoneNumber, string newPhoneNumber)
        {
            var contacts = this.contactsByNumber[oldPhoneNumber].ToList();
            foreach (var contact in contacts)
            {
                contact.phoneNumbers.Remove(oldPhoneNumber);
                this.contactsByNumber.Remove(oldPhoneNumber, contact);
                contact.phoneNumbers.Add(newPhoneNumber);
                this.contactsByNumber.Add(newPhoneNumber, contact);
            }

            return contacts.Count;
        }

        public Contact[] ListEntries(int startIndex, int count)
        {
            if (startIndex < 0 || startIndex + count > this.contactsByName.Count)
            {
                return null;
            }
        
            Contact[] contacts = new Contact[count];
            for (int i = startIndex; i <= startIndex + count - 1; i++)
            {
                Contact contact = this.orderedContacts[i];
                contacts[i - startIndex] = contact;
            }

            return contacts;
        }
    }
}