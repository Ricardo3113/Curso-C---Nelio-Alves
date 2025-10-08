using System;
using ExtensionMethod.Extensions;

public class ProcessFile
{
    public static void Main()
    {
        //Parametros da data passados no DateTime(YYYY, MM, DD, HH, mm, ss)
        DateTime dt = new DateTime(2025, 10, 02, 8, 10, 45);
        Console.WriteLine(dt.ElapsedTime());
    }

}