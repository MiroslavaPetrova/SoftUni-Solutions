using System.Collections.Generic;

namespace MilitaryElite.Contracts
{
    public interface IEngineer : ISoldier
    {
        List<IRepair> Repairs { get; set; }
    }
}
