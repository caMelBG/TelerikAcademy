namespace TowerOfHanoi
{
    using System;

    class TowerOfHanoi
    {
        static void Main()
        {
            int n = 4;
            Move(n, "A", "B", "C");
        }

        static void Move(int disk, string source, string spare, string destination)
        {
            if (disk == 0)
            {
                return;
            }

            //Move all n-1 disks from source to spare
            Move(disk - 1, source, destination, spare);

            //Move the n disk from source to destination
            Console.WriteLine("Move disk {0} from {1} to {2}", disk, source, destination);

            //Move all n-1 disk from spare to destination
            Move(disk - 1, spare, source, destination);
        }
    }
}
