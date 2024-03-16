namespace ActionDelegate
{
    internal class Program
    {
        public delegate void Print(int val);
        static void ConsolePrint(int i)
        {
            Console.WriteLine(i);
        }
        static void Main(string[] args)
        {
            // Action Delegate similar with Func delegate but no return value (void)
            // regular delegate example
            Print prnt = ConsolePrint;
            prnt(10);

            // Action alternative
            Action<int> printActionDel = ConsolePrint;
            printActionDel(10);

            // Can also be defined with instantiating by passing function to delegate in constructor
            // Action<int> printAction = new Action<int>(ConsolePrint); 

            // Anonymous method assigned
            Action helloWorld = delegate ()
            {
                Console.WriteLine("Hello World");
            };
            helloWorld();
            // Lambda expression method action
            Action lambdaHello = () => Console.WriteLine("Hello from lambda method action");
            lambdaHello();
        }
    }
}
