using System;

namespace RomanNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            var converter = new RomanNumberConverter();

            Console.WriteLine("Enter value to convert");

            while (true)
            {
                var inputNumber = Console.ReadLine();
                var convertedNumber = converter.ConvertDigit(int.Parse(inputNumber));
                Console.WriteLine(convertedNumber);
            }
        }

        
    }
}
