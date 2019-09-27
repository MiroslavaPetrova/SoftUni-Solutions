namespace Ferrari
{
    public class Ferrari : IDrivable
    {
        public string Model { get ; set ; }
        public string Driver { get ; set ; }

        public Ferrari(string driver)
        {
            Model = "488-Spider";
            Driver = driver;
        }

        public string PushBrakes()
        {
            return $"Brakes!";
        }

        public string PushGasPedal()
        {
            return $"Zadu6avam sA!";
        }
    }
}
