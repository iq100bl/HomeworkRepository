using System;

namespace array3
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] mass = { 2, 5, 8};
            var sum = 0;
            for (int i = 0; i < mass.Length; i++)
            {
                sum += mass[i];
            }
            Console.Write("Sum of all elements stored in the array is : "+ sum);
        }
    }
}
