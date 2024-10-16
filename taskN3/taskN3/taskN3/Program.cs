using System;
using System.Diagnostics.Metrics;
using static System.Net.Mime.MediaTypeNames;

namespace EtLecture3Arrays
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //1.შექმენით კონსოლური აპლიკაცია რომელიც ხმოვანებს დაითვლის
            //* მომხმარებელს შეაყვანინეთ input
            //*მიღებულ input ში დაითვალეთ ხმოვნები
            //*დაბეჭდეთ სულ რამდენი ხმოვანი იყო

            Console.WriteLine("Enter your phrase: ");
            string InputText = Console.ReadLine();

            int VowelCount = CountVowels(InputText);
            Console.WriteLine("The number of vowels in the text are:" + VowelCount);


            //2.შექმენით კონსოლური აპლიკაცია, რომელიც დააგენერირებს და შეინახავს გამრავლების ტაბულას მასივში და შემდეგ მის მნიშვნელობებს დაბეჭდავს.
            //მაგ.:
            //Enter a number: 5
            //Multiplication Table of 5:
            //5 x 1 = 5
            //5 x 2 = 10...
            //5 x 10 = 50


            Console.WriteLine("Enter a number: ");
            int numb = int.Parse(Console.ReadLine());

            int[] MultTable = new int[10];
            for (int i = 1; i < 10; i++)
            {
                MultTable[i] = numb * (i);
            }

            Console.WriteLine("Multiplication Table of:" + numb);
            for (int i = 1; i < 10; i++)
            {
                Console.WriteLine(MultTable[i]);
            }




            //3.მატრიცების შეკრება:
            //*შექმენით ორი 3x3 ზე მატრიცა(ორ განზომილებიანი მასივი)
            //* მოხმარებელს შეავსებინეთ მატრიცაში მნიშვნელობები
            //* შეკრიბეთ მატრიცები https://en.wikipedia.org/wiki/Matrix_addition

            int[,] matrix1 = new int[3, 3];
            int[,] matrix2 = new int[3, 3];
            int[,] result = new int[3, 3];

            Console.WriteLine("matrix1:");
            FillMatrix(matrix1);

            Console.WriteLine("matrix2:");
            FillMatrix(matrix2);

            AddMatrices(matrix1, matrix2, result);
            Console.WriteLine("result:");
            PrintMatrix(result);



            //4.შექმენით კონსოლური კალკულატორი რომელსაც მენიუ ექნება.კალკულატორი მანამდე უნდა მუშაობდეს, სანამ მომხმარებელს არ მოუნდება მისი გათიშვა.
            //მაგ.:
            //Calculator Menu:
            //1) Addition
            //2) Subtraction
            //3) Multiplication
            //4) Division
            //5) Exit
            //Choose an option: 1
            //Enter first number: 10
            //Enter second number: 5
            //Result: 15
            //[The menu repeats until the user selects Exit]




            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("\nCalculator Menu:");
                Console.WriteLine("1) Addition");
                Console.WriteLine("2) Subtraction");
                Console.WriteLine("3) Multiplication");
                Console.WriteLine("4) Division");
                Console.WriteLine("5) Exit");
                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        PerformOperation("addition", (a, b) => a + b);
                        break;
                    case "2":
                        PerformOperation("subtraction", (a, b) => a - b);
                        break;
                    case "3":
                        PerformOperation("multiplication", (a, b) => a * b);
                        break;
                    case "4":
                        PerformOperation("division", (a, b) => a / b);
                        break;
                    case "5":
                        keepRunning = false;
                        Console.WriteLine("Exiting!");
                        break;
                    default:
                        Console.WriteLine("Invalid option, please try again.");
                        break;
                }
            }
        }


        static int CountVowels(string text)
        {
            char[] vowels = { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };
            int count = 0;
            foreach (char c in text)
            {
                if (Array.Exists(vowels, vowel => vowel == c))
                {
                    count++;
                }
            }
            return count;
        }


        static void FillMatrix(int[,] matrix)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write($"enter [{i + 1}, {j + 1}] element: ");
                    matrix[i, j] = int.Parse(Console.ReadLine());
                }
            }
        }

        static void AddMatrices(int[,] matrix1, int[,] matrix2, int[,] resultMatrix)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    resultMatrix[i, j] = matrix1[i, j] + matrix2[i, j];
                }
            }
        }


        static void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(matrix[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }


        static void PerformOperation(string operation, Func<double, double, double> calculate)
        {
            Console.Write("Enter first number: ");
            double num1 = double.Parse(Console.ReadLine());

            Console.Write("Enter second number: ");
            double num2 = double.Parse(Console.ReadLine());

            if (operation == "division" && num2 == 0)
            {
                Console.WriteLine("Cannot divide by zero!");
            }
            else
            {
                double result = calculate(num1, num2);
                Console.WriteLine($"Result: {result}");
            }
        }
    }
}

