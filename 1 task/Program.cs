using System;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GetInput();
        }

        static public void GetInput()
        {
            Console.WriteLine("Enter the difference:");
            double diff = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter the first term:");
            double firstTerm = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter the term progression:");

            int progTerm;
            while (!int.TryParse(Console.ReadLine(), out progTerm) || progTerm <= 0)
            {
                Console.WriteLine("Term number must be greater than zero.Try again.");
            }
           

            ArithmeticProgression progression = new ArithmeticProgression(diff,firstTerm,progTerm);

           

            Console.WriteLine("Enter 1 if you want to find the sum of the arithmetic progression.");
            Console.WriteLine("Enter 2 if you want to find the term of the arithmetic progression.");


            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:

                    double sum = progression.SumProgression(progression.Difference, progression.FirstTerm, progression.ProgressionTerm);
                    PrintOutPut(sum);
                    break;
                case 2:
                    Console.WriteLine("Enter the member index");
                    int num = int.Parse(Console.ReadLine());
                    ArithmeticProgression arr = new ArithmeticProgression(diff, firstTerm, num,progTerm);
                    arr.OutputArr();
                    double term = arr[num];
                    PrintOutPut(term);
                    break;
                case 0:
                    break;
                default:
                    Console.WriteLine("There is no such option.");
                    break;

            }

        }

        static void PrintOutPut(double result)
        {
            Console.WriteLine($"Result:{result}");
            Console.ReadLine();
        }
    }
}
