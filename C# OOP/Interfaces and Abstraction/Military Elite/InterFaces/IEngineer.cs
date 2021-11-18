using System.Collections.Generic;

namespace MilitaryElite.InterFaces
{
    public interface IEngineer : ISpecialisedSoldier
    {
        public List<IRepair> repairList { get; }
    }
}
