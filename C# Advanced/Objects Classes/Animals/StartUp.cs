using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var animalList = new List<Animal>();
            var input = Console.ReadLine();

            while (input != "Beast!")
            {
                var currentAnimal = Console.ReadLine().Split();
                var name = currentAnimal[0];
                var age = int.Parse(currentAnimal[1]);
                var gender = currentAnimal[2];

                if (input == "Cat")
                {
                    var cat = new Cat(name, age, gender);
                    animalList.Add(cat);
                }
                else if (input == "Dog")
                {
                    var dog = new Dog(name, age, gender);
                    animalList.Add(dog);
                }
                else if (input == "Frog")
                {
                    var frog = new Frog(name, age, gender);
                    animalList.Add(frog);
                }
                else if (input == "Kitten")
                {
                    var kitten = new Kitten(name, age);
                    animalList.Add(kitten);
                }
                else if (input == "Tomcat")
                {
                    var tomcat = new Tomcat(name, age);
                    animalList.Add(tomcat);
                }

                input = Console.ReadLine();
            }

            foreach (var item in animalList)
            {
                Console.WriteLine(item.GetType().Name);
                Console.WriteLine($"{item.Name} {item.Age} {item.Gender}");
                Console.WriteLine(item.ProduceSound());
            }
        }
    }
}
