using System.Collections.Generic;

namespace MilitaryElite.InterFaces
{
    public interface ICommando : ISpecialisedSoldier
    {
        public List<IMission> missionList { get; }
        void CompleteMission(string codeName);
    }
}
