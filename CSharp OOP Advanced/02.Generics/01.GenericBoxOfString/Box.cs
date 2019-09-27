namespace GenericBoxOfString
{
    public class Box<T>
    {
        private T value;

        public Box(T input)
        {
            this.value = input; 
        }

        public override string ToString()
        {
            return $"{this.value.GetType().FullName}: {value}";
        }
    }
}
