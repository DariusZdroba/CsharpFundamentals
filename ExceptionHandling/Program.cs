
using System.Text.RegularExpressions;

namespace ExceptionHandling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            User user = null;
            try
            {
                user = new User();
                user.UserName = "Darius123";
                ValidateUser(user);
            }
            catch(InvalidUserNameException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void ValidateUser(User user)
        {
            Regex regex = new Regex("^[a-zA-Z]+$");
            if(!regex.IsMatch(user.UserName))
            {
                throw new InvalidUserNameException(user.UserName);
            }
        }
    }
}
