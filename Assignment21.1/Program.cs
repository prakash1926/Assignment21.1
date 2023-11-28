using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment21._1
{
    using System;

    public class Calculation<T>
    {
        public static T Add(T a, T b)
        {
            dynamic x = a;
            dynamic y = b;
            return x + y;
        }

        public static T Subtract(T a, T b)
        {
            dynamic x = a;
            dynamic y = b;
            return x - y;
        }

        public static T Multiply(T a, T b)
        {
            dynamic x = a;
            dynamic y = b;
            return x * y;
        }

        public static T Divide(T a, T b)
        {
            dynamic x = a;
            dynamic y = b;

            if (y == 0)
            {
                Console.WriteLine("Cannot divide by zero.");
                return default(T);
            }

            return x / y;
        }
    }

    public delegate T Operation<T>(T x, T y);

    internal class Program
    {
        static void Main(string[] args)
        {
            string choice;
            double firstnumber, secondnumber;
            Console.WriteLine("Enter first number");
            while (!ReadAndConvertInput(Console.ReadLine(), out firstnumber))
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
            Console.WriteLine("Enter second number");
            while (!ReadAndConvertInput(Console.ReadLine(), out secondnumber))
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }

            do
            {
                Console.WriteLine("Choose the operations 1.Addition 2.Subtraction 3.Multiplication 4.Division");
                int op = int.Parse(Console.ReadLine());
                Operation<double>arithmetic;

                switch (op)
                {
                    case 1:
                       arithmetic = new Operation<double>(Calculation<double>.Add);
                        Console.WriteLine("Addition of two numbers: " +arithmetic(firstnumber, secondnumber));
                        break;
                    case 2:
                       arithmetic = new Operation<double>(Calculation<double>.Subtract);
                        Console.WriteLine("Subtraction of two numbers: " +arithmetic(firstnumber, secondnumber));
                        break;
                    case 3:
                       arithmetic = new Operation<double>(Calculation<double>.Multiply);
                        Console.WriteLine("Multiplication of two numbers: " +arithmetic(firstnumber, secondnumber));
                        break;
                    case 4:
                       arithmetic = new Operation<double>(Calculation<double>.Divide);
                        Console.WriteLine("Division of two numbers: " +arithmetic(firstnumber, secondnumber));
                        break;
                    default:
                        Console.WriteLine("Invalid option");
                        break;
                }

                Console.WriteLine("Do you want to continue? Press y/n");
                choice = Console.ReadLine();
            } while (choice == "y");
        }

        // Read and convert input to the desired numeric type
        static bool ReadAndConvertInput<T>(string input, out T result)
        {
            try
            {
                result = (T)Convert.ChangeType(input, typeof(T));
                return true;
            }
            catch
            {
                result = default(T);
                return false;
            }
        }
    }
}
