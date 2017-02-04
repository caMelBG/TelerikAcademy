using System;

using Computers.Interfaces;

namespace Computers.Components.Abstract
{
    public abstract class Cpu : ICpu
    {
        protected Cpu(int numberOfCores, int numberOfBytes)
        {
            this.NumberOfCores = numberOfCores;
            this.NumberOfBytes = numberOfBytes;
        }

        public int NumberOfCores { get; private set; }

        public int NumberOfBytes { get; private set; }

        public void SquareNumber(int data)
        {
            var maxValue = 15.625 * this.NumberOfBytes;

            if (data < 0)
            {
                Console.WriteLine("Number too low.");
            }
            else if (data > maxValue)
            {
                Console.WriteLine("Number too high.");
            }
            else
            {
                int value = 0;
                for (int i = 0; i < data; i++)
                {
                    value += data;
                }

                Console.WriteLine(string.Format("Square of {0} is {1}.", data, value));
            }
        }

        public int Random(int start, int end)
        {
            var random = new Random();
            var randomNumber = random.Next(start, end);
            return randomNumber;
        }
    }
}