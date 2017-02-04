using System;
using System.Text;

class SumOfAllValues
{
    static string keysString = "abcABC123abc123123ABCabc";

    static string textString = "abcABC1.12ABCabcadsvbnghmjkuytrgfdvbghrfewABC123ABCsfdgfghmktyuregfdvfabcABC345ABCabcvbgfnhgefwdvbfgrfewcabcABC100000000ABCabc";

    static string start;

    static string end;

    static double sum;

    static void Main()
    {
        FindKeys();
        FindNumber();
        Console.WriteLine(sum);
    }

    static void FindNumber()
    {
        double number;
        int startIndex = textString.IndexOf(start) + start.Length;
        int endIndex = textString.IndexOf(end) - startIndex;
        string temp = textString.Substring(startIndex, endIndex);

        while (startIndex > - 1 && endIndex > - 1)
        {
            temp = textString.Substring(startIndex, endIndex);
            if (double.TryParse(temp, out number))
            {
                sum += number;
            }
            textString = textString.Remove(0, startIndex + endIndex + end.Length);
            startIndex = textString.IndexOf(start) + start.Length;
            endIndex = textString.IndexOf(end) - startIndex;
        }

    }

    static void FindKeys()
    {
        StringBuilder temp = new StringBuilder();
        for (int i = 0; i < keysString.Length; i++)
        {
            int number;
            string symbol = keysString[i].ToString();
            if (!int.TryParse(symbol, out number))
            {
                temp.Append(symbol);
            }

            else
            {
                break;
            }
        }

        start = temp.ToString();
        temp.Clear();

        for (int i = keysString.Length - 1; i > start.Length; i--)
        {
            int number;
            string symbol = keysString[i].ToString();
            if (!int.TryParse(symbol, out number))
            {
                temp.Append(symbol);
            }

            else
            {
                break;
            }
        }
        char[] array = temp.ToString().ToCharArray();
        Array.Reverse(array);
        end = new string(array);
    }
}

