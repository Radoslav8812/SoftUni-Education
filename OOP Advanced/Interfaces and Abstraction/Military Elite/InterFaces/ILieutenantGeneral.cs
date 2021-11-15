
using System.Collections.Generic;

namespace MilitaryElite
{
    public interface ILieutenantGeneral : IPrivate
    {
        public List<IPrivate> privatesList { get; set; }
    }
}
