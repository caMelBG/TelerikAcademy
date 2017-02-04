using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Phonebook
{
    public class Engine
    {
        private IPhonebookRepository phonebookRepository;

        private StringBuilder consoleOutput;

        public Engine()
        {
            this.phonebookRepository = new PhonebookRepository();
            this.consoleOutput = new StringBuilder();
        }

        public void Start()
        {
            string currentLine = Console.ReadLine();
            while (currentLine != "End")
            {
                int index = currentLine.IndexOf('(');
                string subString = currentLine.Substring(index + 1, currentLine.Length - index - 2);
                string[] commandParts = subString.Split(',');
                string commandType = currentLine.Substring(0, index);
                if (index == -1)
                {
                    throw new ArgumentException("Invalid input");
                }
                else if (!currentLine.EndsWith(")"))
                {
                    throw new ArgumentException("Invalid input");
                }
                if (commandType.StartsWith("AddPhone"))
                {
                    AddPhone(commandParts);
                }
                else if (commandType == "ChangePhone")
                {
                    ChangePhone(commandParts);
                }
                else if (commandType == "List")
                {
                    ListPhones(commandParts);
                }
                else
                {
                    throw new ArgumentException("Invalid input");
                }

                currentLine = Console.ReadLine();
            }

            Console.WriteLine(this.consoleOutput);
        }

        private void ListPhones(string[] commandParts)
        {
            int startIndex = int.Parse(commandParts[0]);
            int count = int.Parse(commandParts[1]);
            IEnumerable<Contact> contacts = this.phonebookRepository.ListEntries(startIndex, count);
            if (contacts == null)
            {
                Print("Invalid range");
                return;
            }
            foreach (var contact in contacts)
            {
                Print(contact.ToString());
            }
        }

        private void AddPhone(string[] commandParts)
        {
            string contactName = commandParts[0];
            var phoneNumbers = commandParts.Skip(1).ToList();
            for (int i = 0; i < phoneNumbers.Count; i++)
            {
                phoneNumbers[i] = Parse(phoneNumbers[i]);
            }

            bool isExist = this.phonebookRepository.AddPhone(contactName, phoneNumbers);
            if (isExist)
            {
                Print("Phone entry created.");
            }
            else
            {
                Print("Phone entry merged");
            }
        }

        private void ChangePhone(string[] commandParts)
        {
            var oldPhoneNumber = Parse(commandParts[0]);
            var newPhoneNumber = Parse(commandParts[1]);
            var numberOfChangedNumbers = this.phonebookRepository
                .ChangePhone(oldPhoneNumber, newPhoneNumber);
            Print(numberOfChangedNumbers + " numbers changed");
        }

        private string Parse(string number)
        {
            var parsedNumber = new StringBuilder();
            foreach (char symbole in number)
            {
                if (char.IsDigit(symbole) || (symbole == '+'))
                {
                    parsedNumber.Append(symbole);
                }
            }

            if (parsedNumber[0] == '0')
            {
                parsedNumber = parsedNumber.Remove(0, 1);
                parsedNumber = parsedNumber.Insert(0, "+359");
            }

            return parsedNumber.ToString();
        }

        private string[] TrimArray(string[] commandParts)
        {
            for (int index = 0; index < commandParts.Length; index++)
            {
                commandParts[index] = commandParts[index].Trim();
            }

            return commandParts;
        }

        private void Print(string text)
        {
            this.consoleOutput.AppendLine(text.Trim());
        }
    }
}