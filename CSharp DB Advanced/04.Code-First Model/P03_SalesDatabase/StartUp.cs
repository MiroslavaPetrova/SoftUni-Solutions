namespace P03_SalesDatabase
{
    using Data;

    public class StartUp
    {
        public static void Main()
        {
            using (SalesContext context = new SalesContext())
            {
                //context.Database.EnsureDeleted();
                //context.Database.EnsureCreated();
            }
        }
    }
}
