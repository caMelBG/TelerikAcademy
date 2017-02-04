using System;
using System.Linq;
using System.Collections.Generic;

using Computers.Interfaces;

namespace Computers.Components
{
    public class HardDrive : IHardDrive
    {
        private bool isInRaid;
        private List<HardDrive> hardDrives;
        private Dictionary<int, string> data;

        public HardDrive(int capacity, bool isInRaid)
        {
            this.Capacity = capacity;
            this.isInRaid = isInRaid;
            this.data = new Dictionary<int, string>(capacity);
            this.hardDrives = new List<HardDrive>();
        }

        public int Capacity { get; set; }

        public void SaveData(int dataAddress, string newData)
        {
            if (this.isInRaid)
            {
                foreach (var hardDrive in this.hardDrives)
                {
                    hardDrive.SaveData(dataAddress, newData);
                }
            }
            else
            {
                this.data[dataAddress] = newData;
            }
        }

        public string LoadData(int address)
        {
            if (this.isInRaid)
            {
                if (!this.hardDrives.Any())
                {
                    throw new OutOfMemoryException("No hard drive in the RAID array!");
                }

                return this.hardDrives.First().LoadData(address);
            }
            else
            {
                return this.data[address];
            }
        }
    }
}
