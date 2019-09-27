namespace Animals
{
    public class Tomcat : Animal
    {
        public Tomcat(string animalType, string name, int age, string gender) 
            : base(animalType, name, age, gender)
        {
            this.Gender = "Male";
        }
    }
}
