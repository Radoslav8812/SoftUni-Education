using System;

namespace Train
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] arr = new int[n];
            int sum = 0;

            for (int i = 0; i < n; i++)
            {
                int peoples = int.Parse(Console.ReadLine());
                arr[i] = peoples;
                sum += peoples;
            }
            Console.WriteLine(string.Join(" ", arr));
            Console.WriteLine(sum);
        }
    }
}
