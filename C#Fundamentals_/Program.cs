using System.Security.Cryptography.X509Certificates;

namespace C_Fundamentals_
{
    internal class Program
    {
          public delegate void MyDelegate(string msg);
          public delegate string AdditionDel();
          public delegate T AddGenericDel<T>(T param1, T param2); // generic delegate
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            MyDelegate del = MethodA;
            del("Hello World");

            // alternative callback function declaration

            MyDelegate callBackDel = (string msg) => { Console.WriteLine(msg); };
            callBackDel("Hello World from callback !");

            MyDelegate multiDel = del+callBackDel;
            multiDel("Hello World from multiDel");

            MyDelegate classADel = ClassA.MethodA;
            MyDelegate classBDel = ClassB.MethodB;
            InvokeDelegate(classADel + classBDel);


            // If delegate returns a value, addition will return the last added delegate

            AdditionDel helloDel = () => "Hello";
            AdditionDel worldDel = () => "World";
            AdditionDel addDel = helloDel + worldDel;
            InvokeAdditionDel(addDel); // will only return the worldDel delegate's return value , returns "World"


            AddGenericDel<int> intGenericDel = Sum;
            AddGenericDel<string> stringGenericDel = Concat;

            Console.WriteLine("Generic del, int sumn: " +  intGenericDel(5,6));
            Console.WriteLine("Generic del, string concat: " +  stringGenericDel("Hello from "," concat func"));
        }
        public static int Sum(int a, int b)
        {
            return a + b;
        }
        public static string Concat(string s, string z) {
            return s + z;
        }
        static void MethodA(string message) {  Console.WriteLine(message); }
        // delegate parameter
        static void InvokeDelegate(MyDelegate del)
        {
            del("Hello from delegate as param");
        }

        static void InvokeAdditionDel(AdditionDel del)
        {
            Console.WriteLine(del());
        }
    }
    class ClassA
    {
        public static void MethodA(string msg)
        {
            Console.WriteLine(msg + " from ClassA.MethodA" );
        }
    }
    class ClassB
    {
        public static void MethodB(string msg)
        {
            Console.WriteLine(msg + " from ClassB.MethodB");
        }
    }
}
