namespace Cars
{
    public interface ICar
    {
        string Colour { get; set; }
        string Model { get; set; }

        string Start();
        string Stop();
    }
}
