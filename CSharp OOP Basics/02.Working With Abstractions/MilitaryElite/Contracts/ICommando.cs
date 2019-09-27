using System.Collections.Generic;

namespace MilitaryElite.Contracts
{
    public interface ICommando : ISoldier
    {
        List<IMission> Missions { get; set; }
    }
}
