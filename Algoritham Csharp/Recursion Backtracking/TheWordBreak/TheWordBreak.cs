namespace TheWordBreak
{
    using System;

    class TheWordBreak
    {
        static void Main()
        {
            if (!Solve("Iamdog", null))
            {
                Console.WriteLine("String can't be broken");
            }
        }

        static bool Solve(string word, string result)
        {
            if (word.Length == 0)
            {
                Console.WriteLine(result.Trim());
                return true;
            }

            for (int index = 1; index <= word.Length; index++)
            {
                string matchedWord = word.Substring(0, index);
                string subString = word.Substring(index, word.Length - index);
                if (IsExist(matchedWord))
                {
                    if (Solve(subString, (result + " " + matchedWord)))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        static bool IsExist(string word)
        {
            string[] dictionary = new string[] { "I", "have", "Jain", "Sumit", "am", "this", "dog" };
            for (int index = 0; index < dictionary.Length; index++)
            {
                if (dictionary[index] == word)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
