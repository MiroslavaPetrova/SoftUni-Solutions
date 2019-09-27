using System.Collections.Generic;

namespace MilitaryElite.Contracts
{
    public interface ILieutenantGeneral : IPrivate, ISoldier
    {
        List<IPrivate> Privates { get; set; }
    }
}
