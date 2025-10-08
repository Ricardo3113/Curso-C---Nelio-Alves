using System;
using System.Runtime.Intrinsics.Arm;

public class ProcessFile
{
    public static void Main()
    {
        string s1 = "Good morning dear students!";
        //chamada da função Cut no console.writeline passando como argumetno a posição que se deseja cortar ou abreviar 
        Console.WriteLine(s1.Cut(15));
    }    
}
