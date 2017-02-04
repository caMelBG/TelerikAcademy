using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;


class UppercaseWords
{
    private static MatchCollection matchWords;

    private static Queue<string> words = new Queue<string>();

    private static Queue<string> wordsReversed = new Queue<string>();

    private static List<string> inputLines = new List<string>();

    private static List<string> outputLines = new List<string>();

    private static string input;

    static void Main()
    {
        ReadInput();
        MatchWords();
        ReverseWords();
        ReplaceReversedWords();
        WriteOutput();

    }

    private static void WriteOutput()
    {
        foreach (string line in outputLines)
        {
            Console.WriteLine(line);
        }
    }

    private static void ReplaceReversedWords()
    {
        string word = words.Dequeue();
        string reverse = wordsReversed.Dequeue();
        string currentLine = String.Empty;
        string temp = String.Empty;

        foreach (string line in inputLines)
        {
            currentLine = line;
            while (currentLine.Contains(word))
            {
                temp = currentLine.Replace(word, reverse);
                currentLine = temp;
                if (words.Count > 0)
                {
                    word = words.Dequeue();
                    reverse = wordsReversed.Dequeue();
                }

                else
                {
                    outputLines.Add(currentLine);
                    return;
                }
            }
            outputLines.Add(currentLine);
        }    
    }

    private static void ReverseWords()
    {
        foreach (Match match in matchWords)
        {
            string currentWord = match.ToString();
            string reverseWord = String.Empty;
            Match digit = Regex.Match(currentWord, @"[\d*]");

            if (digit.Success)
            {
                int index = digit.Index;

                reverseWord = currentWord.Remove(index, 1);
                if (reverseWord == Reverse(reverseWord))
                {
                    reverseWord = DoubleLetters(reverseWord);
                    reverseWord = reverseWord.Insert(index * 2, digit.Value);
                }
            }

            else if (currentWord == Reverse(currentWord))
            {
                reverseWord = DoubleLetters(currentWord);
            }

            else
            {
                reverseWord = Reverse(currentWord);
            }

            if (!wordsReversed.Contains(reverseWord))
            {
                wordsReversed.Enqueue(reverseWord);
                words.Enqueue(currentWord);
            }
        }
    }

    private static string DoubleLetters(string temp)
    {
        char[] charArray = new char[temp.Length * 2];

        for (int i = 0; i < temp.Length; i++)
        {
            for (int j = i * 2; j < i * 2 + 2; j++)
            { 
                charArray[j] = temp[i];
            }
        }

        return new string(charArray);
    }

    private static string Reverse(string word)
    {
        char[] charArray = word.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }

    private static void MatchWords()
    {
        Regex pattern = new Regex(@"\b[A-Z]+[0-9]*[A-Z]*\b");

        matchWords = pattern.Matches(input);
    }

    private static void ReadInput()
    {
        using (StreamReader myReader = new StreamReader("text.txt"))
        {
            string currentLine = myReader.ReadLine();
            StringBuilder tempString = new StringBuilder();
            while (currentLine != "END")
            {
                tempString.Append(currentLine);
                inputLines.Add(currentLine);
                currentLine = myReader.ReadLine();
            }
            input = tempString.ToString();
        }
    }
}

