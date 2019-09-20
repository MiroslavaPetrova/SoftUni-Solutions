using BillsPaymentSystem.App.Core;
using BillsPaymentSystem.App.Core.Contracts;
using BillsPaymentSystem.Data;

namespace BillsPaymentSystem.App
{
    public class StartUp
    {
        public static void Main()
        {
            using (BillsPaymentSystemContext context = new BillsPaymentSystemContext())
            {
                //context.Database.EnsureDeleted();
                //context.Database.EnsureCreated();
                //DbInitializer.Seed(context);

                ICommandInterpreter commandInterpreter = new CommandInterpreter();
                Engine engine = new Engine(commandInterpreter);
                engine.Run();

                //TODO
                //1.call UserINFO
                //2.call PayBills
                //3.DrawCommand
                //4.DepositCommand

            }
        }
    }
}
