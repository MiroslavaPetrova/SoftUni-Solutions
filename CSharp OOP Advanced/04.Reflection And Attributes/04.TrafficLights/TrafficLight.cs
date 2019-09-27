namespace TrafficLights
{
    public class TrafficLight
    {
        public TrafficLight(Colour colour)
        {
            this.Colour = colour;
        }

        public Colour Colour { get; private set; }

        public void ChangeColor()
        {
            this.Colour = (Colour)(((int)Colour + 1) % 3);
        }

        public override string ToString()
        {
            return this.Colour.ToString();
        }
    }
}
