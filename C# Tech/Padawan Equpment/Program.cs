using System;

namespace PadawanEqupment
{
    class Program
    {
        static void Main(string[] args)
        {
            double money = double.Parse(Console.ReadLine());
            int students = int.Parse(Console.ReadLine());
            double lightsabrePrice = double.Parse(Console.ReadLine());
            double robePrice = double.Parse(Console.ReadLine());
            double beltPrice = double.Parse(Console.ReadLine());

            int lightsabreCount = (int)Math.Ceiling(students * 1.10);
            int robeCount = students;
            int beltCount = (students == 0) ? 0 : students - (students / 6);

            double requiredMoney = (lightsabreCount * lightsabrePrice) + (robeCount * robePrice) + (beltCount * beltPrice);
            double diff = Math.Abs(money - requiredMoney);

            if (money >= requiredMoney)
            {
                Console.WriteLine($"The money is enough - it would cost {requiredMoney:f2}lv.");
            }
            else
            {
                Console.WriteLine($"Ivan Cho will need {diff:f2}lv more.");
            }
        }
    }
}
