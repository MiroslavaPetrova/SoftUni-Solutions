namespace P03_BarraksWars.Core.Command
{
    using _03BarracksFactory.Contracts;
    using System;

    public class RetireCommand : Command
    {
        public RetireCommand(string[] data, IRepository repository, IUnitFactory unitFactory)
            : base(data, repository, unitFactory)
        {
        }

        public override string Execute()
        {
            try
            {
                this.Repository.RemoveUnit(this.Data[1]);
                return $"{this.Data[1]} retired!";
            }
            catch (InvalidOperationException e)
            {
                return (e.Message);
            }
        }
    }
}
