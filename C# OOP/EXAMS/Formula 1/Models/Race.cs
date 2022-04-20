using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Formula1.Models.Contracts;

namespace Formula1.Models
{
	public class Race : IRace
	{
        private string raceName;
        private int numberOfLaps;
        private bool tookPlace;
        private readonly List<IPilot> pilots;

        public Race(string raceName, int numberOfLaps)
		{
            RaceName = raceName;
            NumberOfLaps = numberOfLaps;
            tookPlace = false;
            pilots = new List<IPilot>();
		}

        public string RaceName
        {
            get
            {
                return raceName;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 5)
                {
                    throw new ArgumentException($"Invalid race name: {value}.");
                }
                raceName = value;
            }
        }

        public int NumberOfLaps
        {
            get
            {
                return numberOfLaps;
            }
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException($"Invalid lap numbers: {value}.");
                }
                numberOfLaps = value;
            }
        }

        public bool TookPlace
        {
            get
            {
                return tookPlace;
            }
            set
            {
                tookPlace = value;
            }
        }

        public ICollection<IPilot> Pilots
        {
            get
            {
                return pilots;
            }
        }

        public void AddPilot(IPilot pilot)
        {
            pilots.Add(pilot);
        }

        public string RaceInfo()
        {
            var builder = new StringBuilder();

            builder.AppendLine($"The { RaceName } race has:");
            builder.AppendLine($"Participants: {Pilots.Count(x => x.CanRace == true)}");
            builder.AppendLine($"Number of laps: { NumberOfLaps }");
            var place = TookPlace == true ? "Yes" : "No";
            builder.AppendLine($"TookPlace: {place}");

            return builder.ToString().TrimEnd();
        }
    }
}

