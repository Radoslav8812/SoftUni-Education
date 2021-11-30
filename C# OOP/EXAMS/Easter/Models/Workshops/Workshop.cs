using System;
using System.Linq;
using Easter.Models.Bunnies.Contracts;
using Easter.Models.Eggs.Contracts;
using Easter.Models.Workshops.Contracts;

namespace Easter.Models.Workshops
{
    public class Workshop : IWorkshop
    {
        public Workshop()
        {
        }

        public void Color(IEgg egg, IBunny bunny)
        {
            while (true)
            {
                if (bunny.Energy <= 0)
                {
                    break;
                }

                if (egg.IsDone())
                {
                    break;
                }

                if (bunny.Dyes.Count == 0)
                {
                    break;
                }

                var firstDye = bunny.Dyes.FirstOrDefault();
                firstDye.Use();
                if (firstDye.IsFinished())
                {
                    bunny.Dyes.Remove(firstDye);
                }

                bunny.Work();
                egg.GetColored();

                if (egg.IsDone())
                {
                    break;
                }
            }
        }
    }
}
