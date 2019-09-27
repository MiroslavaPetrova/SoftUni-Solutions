using MilitaryElite.Contracts;
using MilitaryElite.Core;
using MilitaryElite.Models;
using System.Collections.Generic;

namespace MilitaryElite
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //todo try implement ISoldier in all Interface vs consecutive inheritance
            // =>  public interface ILieutenantGeneral : IPrivate, ISoldier try skip  IPrivate & check the functionality

            // try autoprops in the base cs

            //try first methid => IPrivate privateSoldier => ISoldier
            Engine enigine = new Engine();
            enigine.Run();
        }
    }
}
