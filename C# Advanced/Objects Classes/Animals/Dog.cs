using System;
namespace Animals
{
    public class Dog : Animal, IProduceSound
    {
        public Dog(string name, int age, string gender) : base(name, age, gender)
        {
            base.Name = name;
        }

        public string ProduceSound()
        {
            return "Woof!";
        }
    }
}
