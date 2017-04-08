namespace SubsetsWithSumEqualToN
{
    using System;

    class SubsetsWithSumEqualToN
    {
        static void Main()
        {
            int number = int.Parse(Console.ReadLine());
            Solve(number, 0, null);
        }

        static void Solve(int num, int currNum, string sequense)
        {
            if (currNum == num)
            {
                Console.WriteLine(sequense);
                return;
            }

            if (currNum > num)
            {
                return;
            }

            for (int index = 1; index <= num; index++)
            {
                Solve(num, currNum + index, sequense + index.ToString() + " ");
            }
        }
    }
}
