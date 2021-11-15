using MilitaryElite.InterFaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Implementation
{
    public class Engineer : SpecialisedSoldier, IEngineer
    {
        public Engineer(int id, string firstName, string lastName, decimal salary, Corps corps) : base(id, firstName, lastName, salary, corps)
        {
            repairList = new List<IRepair>();
        }

        public List<IRepair> repairList { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            string baseInfo = base.ToString();

            sb.AppendLine(baseInfo);
            sb.AppendLine($"Corps: {Corps}");
            sb.AppendLine($"Repairs:");

            foreach (var item in repairList)
            {
                sb.AppendLine($"  {item}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
