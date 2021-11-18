using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Implementation
{
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        public LieutenantGeneral(int id, string firstName, string lastName, decimal salary) : base(id, firstName, lastName, salary)
        {
            privatesList = new List<IPrivate>();
        }

        public List<IPrivate> privatesList { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            string baseInfo = base.ToString();
            sb.AppendLine(baseInfo);
            sb.AppendLine("Privates:");

            foreach (var item in privatesList)
            {
                sb.AppendLine($"  {item}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
