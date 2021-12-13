using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gym.Core.Contracts;
using Gym.Models.Athletes;
using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms;
using Gym.Models.Gyms.Contracts;
using Gym.Repositories;

namespace Gym.Core
{
    public class Controller : IController
    {
        private EquipmentRepository equipmentRepository;
        private List<IGym> gyms;

        public Controller()
        {
            equipmentRepository = new EquipmentRepository();
            gyms = new List<IGym>();
        }

        public string AddAthlete(string gymName, string athleteType, string athleteName, string motivation, int numberOfMedals)
        {
            IAthlete athlete;

            if (athleteType == "Boxer")
            {
                athlete = new Boxer(athleteName, motivation, numberOfMedals);
            }
            else if (athleteType == "Weightlifter")
            {
                athlete = new Weightlifter(athleteName, motivation, numberOfMedals);
            }
            else
            {
                throw new InvalidOperationException("Invalid athlete type.");
            }

            var gymType = gyms.FirstOrDefault(x => x.Name == gymName).GetType().Name;
            var currGym = gyms.FirstOrDefault(x => x.Name == gymName);

            if (gymType == "BoxingGym")
            {
                gyms.Add((IGym)athlete);
            }
            else if (gymType == "WeightliftingGym")
            {
                gyms.Add((IGym)athlete);
            }
            else
            {
                return "The gym is not appropriate.";
            }

            return $"Successfully added {athleteType} to {gymName}.";
        }

        public string AddEquipment(string equipmentType)
        {
            if(equipmentType == "BoxingGloves")
            {
                equipmentRepository.Add(new BoxingGloves());
            }
            else if (equipmentType == "Kettlebell")
            {
                equipmentRepository.Add(new Kettlebell());
            }
            else
            {
                throw new InvalidOperationException("Invalid equipment type.");
            }

            return $"Successfully added {equipmentType}.";
        }

        public string AddGym(string gymType, string gymName)
        {
            IGym gym;

            if (gymType == "BoxingGym")
            {
                gym = new BoxingGym(gymName);
            }
            else if (gymType == "WeightliftingGym")
            {
                gym = new WeightliftingGym(gymName);
            }
            else
            {
                throw new InvalidOperationException("Invalid gym type.");
            }

            gyms.Add(gym);
            return $"Successfully added {gymType}.";
        }

        public string EquipmentWeight(string gymName)
        {
            throw new NotImplementedException();
        }

        public string InsertEquipment(string gymName, string equipmentType)
        {
            
            IGym currGym = gyms.FirstOrDefault(x => x.Name == gymName);
            IEquipment currEquipment = equipmentRepository.Models.FirstOrDefault(x => x.GetType().Name == equipmentType);

            if (currEquipment == null)
            {
                throw new InvalidOperationException($"There isn’t equipment of type {equipmentType}.");
            }
            else
            {
                gyms.Add((IGym)currEquipment);
                equipmentRepository.Remove(currEquipment);
                return $"Successfully added {equipmentType} to {gymName}.";
            }
        }

        public string Report()
        {
            var builder = new StringBuilder();

            foreach (var gym in gyms)
            {
                builder.AppendLine(gym.GymInfo());
            }

            return builder.ToString().TrimEnd();
        }

        public string TrainAthletes(string gymName)
        {
            IGym currGym = gyms.FirstOrDefault(x => x.Name == gymName);
            currGym.Exercise();

            return $"The total weight of the equipment in the gym {gymName} is {currGym.EquipmentWeight:f2} grams."
            + "\r\n" +
            $"Exercise athletes: {currGym.Athletes.Count}.";
        }
    }
}
