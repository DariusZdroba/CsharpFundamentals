namespace FuncDelegate
{
    internal class Program
    {
        static int Sum(int x, int y)
        {
            return x + y;
        }
        static void Main(string[] args)
        {
            Func<int, int, int> add = Sum;
            int result = add(2, 3);
            Console.WriteLine(result);
            // Can also be used as lambda function
            Func<int> getRandomNumber = () => new Random().Next(1,100); // only one input parameter for func, means it's the output param

            // Anonymous method using delegate keyword
            Func<int> getOtherRandomNumber = delegate ()
            {
                Random rnd = new Random();
                return rnd.Next(1, 100);
            };
            Console.WriteLine("lamba random: " + getRandomNumber() + "\nAnonymous delegate cast random number: "+ getOtherRandomNumber());
        }
    }
}
