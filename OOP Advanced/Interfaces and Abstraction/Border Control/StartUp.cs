using System;
using System.Linq;
using System.Collections.Generic;

namespace BorderControl
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var command = Console.ReadLine().ToLower();

            var peolpeList = new List<Citizen>();
            var robotList = new List<Robot>();

            while(true)
            {
                var splitedInput = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (command == "End")
                {
                    var checkFake = Console.ReadLine();

                    var resultPeopleList = peolpeList.Where(x => x.Id.EndsWith(checkFake)).ToList();
                    foreach (var item in resultPeopleList)
                    {
                        Console.WriteLine(item.Id);
                    }

                    var resultRobotList = robotList.Where(x => x.Id.EndsWith(checkFake)).ToList();
                    foreach (var item in resultRobotList)
                    {
                        Console.WriteLine(item.Id);
                    }

                    break;
                }

                if (splitedInput.Length == 3)
                {
                    var personName = splitedInput[0];
                    var personAge = int.Parse(splitedInput[1]);
                    var personId = splitedInput[2];

                    var person = new Citizen(personName, personAge, personId);
                    peolpeList.Add(person);
                }
                else if (splitedInput.Length == 2)
                {
                    var robotName = splitedInput[0];
                    var robotId = splitedInput[1];

                    var robot = new Robot(robotName, robotId);
                    robotList.Add(robot);
                }
                command = Console.ReadLine();
            }
        }
    }
}
