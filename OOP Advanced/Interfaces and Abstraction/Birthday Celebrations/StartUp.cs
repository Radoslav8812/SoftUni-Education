using System;
using System.Linq;
using System.Collections.Generic;

namespace BorderControl
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var command = Console.ReadLine();

            var peolpeList = new List<IBirthable>();
            var petList = new List<IBirthable>();

            while (true)
            {
                var splitedInput = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (command == "End")
                {
                    var check = Console.ReadLine();
                    var resultList = peolpeList
                        .Where(x => x.Birthdate.EndsWith(check))
                        .Select(x => x.Birthdate)
                        .ToList()
                        .Concat(petList.Where(x => x.Birthdate.EndsWith(check))
                        .Select(x => x.Birthdate)
                        .ToList());

                    Console.WriteLine(string.Join(Environment.NewLine, resultList));

                    break;
                }

                if (splitedInput[0] == "Pet")
                {
                    var name = splitedInput[1];
                    var birthDate = splitedInput[2];

                    var pet = new Pet(name, birthDate);
                    petList.Add(pet);
                }
                else if (splitedInput[0] == "Citizen")
                {
                    var name = splitedInput[1];
                    var age = int.Parse(splitedInput[2]);
                    var id = splitedInput[3];
                    var birthDate = splitedInput[4];

                    var person = new Citizen(name, age, id, birthDate);
                    peolpeList.Add(person);
                }

                command = Console.ReadLine();
            }
        }
    }
}
