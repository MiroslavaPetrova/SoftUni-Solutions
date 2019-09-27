namespace Ferrari
{
    public interface IDrivable
    {
        string Model { get; set; }
        string Driver { get; set; }

        string PushGasPedal();
        string PushBrakes();
    }
}
