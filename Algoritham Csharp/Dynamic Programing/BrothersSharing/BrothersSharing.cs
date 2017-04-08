namespace BrothersSharing
{
    using System;

    class BrothersSharing
    {
        static void Main()
        {
            int[] gifts = new[] { 3, 2, 3, 2, 2, 77, 89, 23, 90, 11, };
            int sumOfAllGifts = 0;
            for (int index = 0; index < gifts.Length; index++)
            {
                sumOfAllGifts += gifts[index];
            }

            byte[] canUse = new byte[sumOfAllGifts + 1];
            canUse[0] = 1;
            for (int i = 0; i < gifts.Length; i++)
            {
                for (int j = sumOfAllGifts; j >= 0; j--)
                {
                    if (canUse[j] == 1)
                    {
                        canUse[j + gifts[i]] = 1;
                    }
                }
            }

            int firstSon = 0;
            int secondSon = 0;
            for (int index = sumOfAllGifts / 2; index >= 0; index--)
            {
                if (canUse[index] == 1)
                {
                    firstSon = index;
                    secondSon = sumOfAllGifts - index;
                    break;
                }
            }

            Console.WriteLine(firstSon + " " + secondSon);
        }
    }
}
