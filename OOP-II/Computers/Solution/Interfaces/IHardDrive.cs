namespace Computers.Interfaces
{
    public interface IHardDrive
    {
        void SaveData(int dataAddress, string newData);

        string LoadData(int address);
    }
}
