namespace StrategyPattern
{
    using System.Collections.Generic;

    public class NameComparisson : IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            int result = x.Name.Length.CompareTo(y.Name.Length);

            if (result == 0)
            {
                char xFirstLetter = char.ToLower(x.Name[0]);
                char yFirstLetter = char.ToLower(y.Name[0]);

                result = xFirstLetter.CompareTo(yFirstLetter);
            }

            return result;
        }
    }
}
