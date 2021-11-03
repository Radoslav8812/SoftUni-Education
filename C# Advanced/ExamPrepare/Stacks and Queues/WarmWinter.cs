using System;
using System.Linq;
using System.Collections.Generic;

namespace _1._Warm_Winter
{
    class Program
    {
        static void Main(string[] args)
        {
            var hatStack = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
            var scarfQue = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            var resultList = new List<int>();

            while (hatStack.Count > 0 && scarfQue.Count > 0)
            {
                var hat = hatStack.Peek();
                var scarf = scarfQue.Peek();

                if (hat > scarf)
                {
                    var result = hat + scarf;
                    hatStack.Pop();
                    scarfQue.Dequeue();
                    resultList.Add(result);
                }
                else if (scarf > hat)
                {
                    hatStack.Pop();
                }
                else if (hat == scarf)
                {
                    scarfQue.Dequeue();
                    var increased = hatStack.Pop() + 1;
                    hatStack.Push(increased);
                }
            }
            Console.WriteLine($"The most expensive set is: {resultList.Max()}");
            Console.WriteLine(string.Join(" ", resultList));
        }
    }
}
