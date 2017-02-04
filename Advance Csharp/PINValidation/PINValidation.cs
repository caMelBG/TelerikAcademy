using System;
using System.IO;
using System.Linq;

class PINValidation
{
    static void Main()
    {
        string fullName;
        string gender;
        string equalGender;
        string id;
        int checksum = 0;
        int[] number = new int[] { 2, 4, 8, 5, 10, 9, 7, 3, 6 };
        int[] idArray = new int[10];
        using (StreamReader myReader = new StreamReader("text.txt"))
        {
            fullName = myReader.ReadLine();
            gender = myReader.ReadLine();
            id = myReader.ReadLine();
        }

        if (id.Length == 10)
        {
            for (int i = 0; i < 10; i++)
            {
                idArray[i] = int.Parse(id[i].ToString());
            }
        }

        if (idArray[2] > 1 && idArray[3] > 2)
        {
            Console.WriteLine("Incorect");
            return;
        }

        if (idArray[8] % 2 == 0)
        {
            equalGender = "male";
        }

        else
        {
            equalGender = "female";
        }

        if (gender != equalGender)
        {
            Console.WriteLine("Incorect");
            return;
        }

        for (int i = 0; i < 9; i++)
        {
            checksum += idArray[i] * number[i];
        }
        checksum %= 11;

        if (checksum == idArray[9])
        {
            Console.WriteLine("{\"name\":\"" + fullName + "\",\"gender\":\"" + gender + "\",\"pin\":\"" + id + "\"}");
        }
        else
        {
            Console.WriteLine("Incorect");
        }
    }
}

