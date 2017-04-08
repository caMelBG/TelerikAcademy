namespace AnnasDinner
{
    using System;

    class AnnasDinner
    {
        static char[] friends = new char[15];
        static char[] friendsOnDinner = new char[3];
        static int count = 0;

        static void Main()
        {
            for (int i = 0; i < 15; i++)
            {
                friends[i] = Convert.ToChar(65 + i);
            }

            Solve(0, 0);
            Console.WriteLine(count);
        }

        static void Solve(int index, int start)
        {
            if (index == 3)
            {
                count++;
                Console.WriteLine(new string(friendsOnDinner));
                return;
            }

            for (int i = start; i < friends.Length; i++)
            {
                friendsOnDinner[index] = friends[i];
                Solve(index + 1, i + 1);
            }
        }
    }
}
