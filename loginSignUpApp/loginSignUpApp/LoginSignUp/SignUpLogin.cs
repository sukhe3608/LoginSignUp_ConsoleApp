using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace loginSignUpApp.LoginSignUp
{
    internal class SignUpLogin
    {
        static string userFile = "c:\\Users\\dell\\source\\repos\\loginSignUpApp\\loginSignUpApp\\LoginSignUp\\Users.txt";
        static string logFile = "c:\\Users\\dell\\source\\repos\\loginSignUpApp\\loginSignUpApp\\LoginSignUp\\Logs.txt";
        static void Main(string[] args)
        {

            Console.WriteLine("WELCOME TO THE PAGE...\n\n");
            Console.WriteLine("Select a operation to start execution\n");
            Console.WriteLine("(1) for Login \n" +
                "(2) for Signup \n" +
                "(3) exit\n\n");
            Console.Write("Enter you choice : \n");
            string choice = Console.ReadLine();
            switch (Convert.ToInt32(choice))
            {
                case 1:
                    LogIn();
                    break;

                case 2:
                    SignUp();
                    break;

                case 3:
                    break;

                default:
                    Console.WriteLine("Please enter a valid choice");
                    break;

            }

            Console.ReadLine();
        }

        static void LogIn()
        {
            Console.Write("Enter the Username : ");
            string username = Console.ReadLine();

            Console.Write("Enter the Passwrd : ");
            string password = Console.ReadLine();

            if (ValidUser(username, password))
            {
                LogAction($"{username} Logged In...");
                Console.WriteLine("Logged In Successful.");
            }
            else
            {
                LogAction($"{username}loggedIn Failed..");
                Console.WriteLine("Invalid credentials)");
            }

        }

        static void SignUp()
        {
            Console.Write("Enter the Username : ");
            string username = Console.ReadLine();

            Console.Write("Enter the Passwrd : ");
            string password = Console.ReadLine();

            if (UserExist(username))
            {
                Console.WriteLine("The User already exist");
            }

            else
            {
                File.AppendAllText(userFile, $"{username},{password}\n");
                LogAction($"{username} registered..\n");
                Console.WriteLine("User registered successful");

            }
        }

        static bool ValidUser(string username, string password)
        {
            if (!File.Exists(userFile)) return false;

            string[] lines = File.ReadAllLines(userFile);

            foreach (string line in lines)
            {
                var parts = line.Split(',');

                if (parts.Length >= 2 && parts[0] == username && parts[1] == password)
                {
                    return true;
                }
            }
            return false;
        }

        static bool UserExist(string username)
        {
            if (!File.Exists(userFile)) return false;

            string[] lines = File.ReadAllLines(userFile);

            foreach (string line in lines)
            {
                var parts = line.Split(',');
                if (parts[0] == username)
                {
                    return true;
                }
            }
            return false;

        }

        static void LogAction(string message)
        {
            string log = $"[{DateTime.Now}] {message}\n";
            File.AppendAllText(logFile, log);
        }

    }
}
