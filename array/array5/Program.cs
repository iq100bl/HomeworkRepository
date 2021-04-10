using System;

namespace array5
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] mass = { 5, 1, 1, 5, 8, 9, 10, 8 };
            var duple = 0;
            for (int i = 0; i < mass.Length-1; i++)
            {
                for (int x = i+1; x < mass.Length;x++)
                {
                    if (mass[x] == mass[i])
                    {
                        duple++;
                    }
                }
            }
            Console.WriteLine("Total number of duplicate elements found in the array is : " + duple);
        }
    }
}
