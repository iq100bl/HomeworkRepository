using System;

namespace string2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Entered text");
            var text = Console.ReadLine();
            int size = 0;
            while (size <= text.Length - 1)
            {
                size++;
            }
            Console.WriteLine("Length of the string is: " + size);
        }
    }
}
