namespace PredicateDelegate
{
    internal class Program
    {
        static bool isUpperCase(string s)
        {
            return s.Equals(s.ToUpper());
        }
        static void Main(string[] args)
        {
            // Predicate delegates similar to Action and Func, returns boolean type, validating an input of specified type
            Predicate<string> isUpper = isUpperCase;
            Console.WriteLine(isUpper("hello WORLD")); // will output false

            // Anonymous and lambda alternative:
            Predicate<string> isLower = delegate (string s) { return s.Equals(s.ToLower()); };
            Console.WriteLine(isLower("hello world")); // will output true

            Predicate<string> endsWithA = (string s) => { return s.ToLower().EndsWith("a"); };
            Console.WriteLine(endsWithA("holla"));  // will output true
        }
    }
}
