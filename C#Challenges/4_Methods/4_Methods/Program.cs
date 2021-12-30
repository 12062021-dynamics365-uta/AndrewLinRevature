using System;

namespace _4_MethodsChallenge
{
    public class Program
    {
        public static void Main(string[] args)
        {
            /**
                YOUR CODE HERE.
            **/
        }

        public static string GetName()
        {
            Console.WriteLine("What is the name?");
            string name = Console.ReadLine();
            return name;
        }

        public static string GreetFriend(string name)
        {
            return "Hello, " + name + "." + " You are my friend.";
        }

        public static double GetNumber()
        {
            bool isDouble = false;
            double userInput = 0;
            while (isDouble == false)
            {

                Console.WriteLine("Give a number");
                userInput = Convert.ToDouble(Console.ReadLine());
                TypeCode typeCode = Type.GetTypeCode(userInput.GetType());
                if (typeCode == TypeCode.Double)
                {
                    isDouble = true;

                }
                else
                {
                    isDouble = false;

                }
            }
            return userInput;



        }

        public static int GetAction()
        {
            int userInput = 0;
            bool userChoice = false;
            while (userChoice == false)
            {
                Console.WriteLine(" Please enter the number to the corresponding action.\n 1)add, 2)subtract, 3)multiply, or 4)divide. ");
                userInput = Convert.ToInt32(Console.ReadLine());
                if (userInput >= 1 && userInput <= 4)
                {
                    userChoice = true;
                }
            }
            return userInput;

        }

        public static double DoAction(double x, double y, int action)
        {
            switch (action)
            {
                case 1:
                    double sum = x + y;
                    Console.WriteLine(sum);
                    return sum;
                case 2:
                    double subtract = y - x;
                    Console.WriteLine(subtract);
                    return subtract;
                case 3:
                    double multiply = x * y;
                    Console.WriteLine(multiply);
                    return multiply;
                case 4:
                    double divide = x / y;
                    Console.WriteLine(divide);
                    return divide;
                default:
                    throw new FormatException();
            }
        }
    }
}
