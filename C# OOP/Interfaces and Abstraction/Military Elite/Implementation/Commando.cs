using MilitaryElite.InterFaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace MilitaryElite.Implementation
{
    public class Commando : SpecialisedSoldier, ICommando
    {
        public Commando(int id, string firstName, string lastName, decimal salary, Corps corps) : base(id, firstName, lastName, salary, corps)
        {
            missionList = new List<IMission>();
        }

        public List<IMission> missionList { get; set; }

        public void CompleteMission(string codeName)
        {
            var mission = missionList.FirstOrDefault(x => x.CodeName == codeName);
            mission.Status = Status.Finished;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            string baseInfo = base.ToString();

            sb.AppendLine(baseInfo);
            sb.AppendLine($"Corps: {Corps}");
            sb.AppendLine($"Missions:");

            foreach (var item in missionList)
            {
                sb.AppendLine($"  {item}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
