// See https://aka.ms/new-console-template for more information
using System;

class DoWhileLoopExample
{
    static void Main()
    {
        int i = 1;
        do
        {
            Console.WriteLine("Iterasi ke-" + i);
            i++;
        } while (i <= 5);
    }
}
