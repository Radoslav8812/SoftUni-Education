using System;
using System.Linq;
using System.Collections.Generic;
using MilitaryElite.Implementation;
using MilitaryElite.InterFaces;

namespace MilitaryElite
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var soldiersDict = new Dictionary<int, ISoldier>();
            
            while (input != "End")
            {
                var splitedInput = input.Split();
                var type = splitedInput[0];
                var id = int.Parse(splitedInput[1]);
                var firstname = splitedInput[2];
                var lastname = splitedInput[3];
                

                if (type == "Private")
                {
                    var salary = decimal.Parse(splitedInput[4]);
                    IPrivate private_ = new Private(id, firstname, lastname, salary);
                    soldiersDict.Add(id, private_);
                }
                else if (type == "LieutenantGeneral")
                {
                    var salary = decimal.Parse(splitedInput[4]);
                    ILieutenantGeneral lieutenantGeneral = new LieutenantGeneral(id, firstname, lastname, salary);

                    for (int i = 5; i < splitedInput.Length; i++)
                    {
                        var inputId = int.Parse(splitedInput[i]);
                        var soldier = soldiersDict[inputId] as IPrivate;

                        lieutenantGeneral.privatesList.Add(soldier);
                    }
                    soldiersDict.Add(id, lieutenantGeneral);
                }
                else if (type == "Engineer")
                {
                    var salary = decimal.Parse(splitedInput[4]);
                    var corpsInput = splitedInput[5];
                    bool isValidEnum = Enum.TryParse(corpsInput, out Corps result);

                    if (!isValidEnum)
                    {
                        input = Console.ReadLine();
                        continue;
                    }

                    IEngineer engineer = new Engineer(id, firstname, lastname, salary, result);

                    for (int i = 6; i < splitedInput.Length; i += 2)
                    {
                        var partName = splitedInput[i];
                        var hoursWorked = int.Parse(splitedInput[i + 1]);

                        IRepair repair = new Repair(partName, hoursWorked);
                        engineer.repairList.Add(repair);
                    }
                    soldiersDict.Add(id, engineer);
                }
                else if (type == "Commando")
                {
                    var salary = decimal.Parse(splitedInput[4]);
                    var corpsInput = splitedInput[5];
                    bool isValidEnum = Enum.TryParse(corpsInput, out Corps result);

                    if (!isValidEnum)
                    {
                        input = Console.ReadLine();
                        continue;
                    }

                    ICommando commando = new Commando(id, firstname, lastname, salary, result);

                    for (int i = 6; i < splitedInput.Length; i += 2)
                    {
                        var missionCode = splitedInput[i];
                        var missionState = splitedInput[i + 1];

                        bool isValidMission = Enum.TryParse(missionState, out Status status);
                        if (!isValidMission)
                        {
                            continue;
                        }
                        IMission mission = new Mission(missionCode, status);
                        commando.missionList.Add(mission);
                    }
                    soldiersDict.Add(id, commando);
                }
                else if (type == "Spy")
                {
                    var codeNumber = int.Parse(splitedInput[4]);
                    ISpy spy = new Spy(id, firstname, lastname, codeNumber);
                    soldiersDict.Add(id, spy);
                }

                input = Console.ReadLine();
            }

            foreach (var item in soldiersDict)
            {
                Console.WriteLine(item.Value.ToString());
            }
        }
    }
}
