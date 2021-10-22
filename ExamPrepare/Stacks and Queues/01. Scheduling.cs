using System;
using System.Linq;
using System.Collections.Generic;

namespace _01.Scheduling
{
    class Program
    {
        static void Main(string[] args)
        {
            var taskkStack = new Stack<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());
            var threadQueue = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());
            var toKill = int.Parse(Console.ReadLine());

            while (true)
            {
                var task = taskkStack.Peek();
                var thread = threadQueue.Peek();

                 if (task == toKill)
                {
                    Console.WriteLine($"Thread with value {thread} killed task {task}");
                    Console.WriteLine(string.Join(" ", threadQueue));
                    break;
                }
                if (thread >= task)
                {
                    taskkStack.Pop();
                    threadQueue.Dequeue();
                }
                else if (task > thread)
                {
                    threadQueue.Dequeue();
                }
            }
        }
    }
}
