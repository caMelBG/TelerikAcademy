using System;
using System.Text;
using System.Collections.Generic;

namespace Phonebook
{
    public class Contact : IComparable<Contact>
    {
        public SortedSet<string> phoneNumbers;

        public string Name { get; set; }
        
        public override string ToString()
        {
            var result = new StringBuilder();
            result.Append('[');
            result.Append(this.Name);
            bool flag = true;
            foreach (var phoneNumber in this.phoneNumbers)
            {
                if (flag)
                {
                    result.Append(": ");
                    flag = false;
                }
                else
                {
                    result.Append(", ");
                }

                result.Append(phoneNumber);
            }

            result.Append(']');
            return result.ToString();
        }

        public int CompareTo(Contact otherContact)
        {
            return this.Name.ToLower().CompareTo(otherContact.Name.ToLower());
        }
    }
}
