using System;
using System.Linq;
using System.Collections.Generic;

namespace _1._The_Fight_for_Gondor
{
    class Program
    {
        static void Main()
        {
            int waves = int.Parse(Console.ReadLine());
            var deffenceQue = new Queue<int>(Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());

            var warriorOrcsLeft = new Stack<int>();
            bool isTheDefenceOfGondorDestroyed = false;

            for (int i = 1; i <= waves; i++)
            {
                var orcStack = new Stack<int>(Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());

                if (i % 3 == 0)
                {
                    int additionalPlate = int.Parse(Console.ReadLine());
                    deffenceQue.Enqueue(additionalPlate);
                }

                while (orcStack.Count != 0 && deffenceQue.Count != 0)
                {
                    if (orcStack.Peek() > deffenceQue.Peek())
                    {
                        orcStack.Push(orcStack.Pop() - deffenceQue.Dequeue());
                    }
                    else if (deffenceQue.Peek() > orcStack.Peek())
                    {
                        var updatedQue = new Queue<int>();

                        updatedQue.Enqueue(deffenceQue.Dequeue() - orcStack.Pop());

                        for (int j = 0; j < deffenceQue.Count; j++)
                        {
                            updatedQue.Enqueue(deffenceQue.ElementAt(j));
                        }

                        deffenceQue = updatedQue;
                    }
                    else
                    {
                        deffenceQue.Dequeue();
                        orcStack.Pop();
                    }

                    if (deffenceQue.Count == 0)
                    {
                        isTheDefenceOfGondorDestroyed = true;
                        warriorOrcsLeft = orcStack;
                        break;
                    }
                }
            }

            if (isTheDefenceOfGondorDestroyed)
            {
                Console.WriteLine("The orcs successfully destroyed the Gondor's defense.");
                Console.WriteLine($"Orcs left: {string.Join(", ", warriorOrcsLeft)}");
            }
            else
            {
                Console.WriteLine("The people successfully repulsed the orc's attack.");
                Console.WriteLine($"Plates left: {string.Join(", ", deffenceQue)}");
            }
        }
    }
}
