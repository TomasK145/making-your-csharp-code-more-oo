using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using RefactoringDemo;

namespace Demo
{
    class Program
    {
        /*
        static int GetControlDigit(long number)
        {

            int sum = 0;
            bool isOddPos = true;
            // Separate digits
            // Loop through digits
            // Multiply every other digit by three
            // Calculate pondered sum of digits
            // Take module 7 of the sum 
            while (number > 0)                  // Infrastructure 
            {
                int digit = (int) (number%10);  // Infrastructure

                if (isOddPos)                   // Domain  - part of requirements
                    sum += 3 * digit;           // 3 = parameter of the algoritm
                else                            // += and * = infrastructure
                    sum += digit;

                number /= 10;                   // Infrastructure
                isOddPos = !isOddPos;           // Domain  - part of requirements

            }

            int modulo = sum%7;                 // 7 = parameter of algoritm
                                                // % = domain - true part of the algoritm
            return modulo;

        }
        */

        /*
        static int GetControlDigit(long number)
        {
            /*
            IEnumerator<int> factor = MultiplyingFactors.GetEnumerator();
            IList<int> ponderedDigits = new List<int>();
            foreach (int digit in GetDigitsOf(number))
            {
                factor.MoveNext();
                ponderedDigits.Add(digit * factor.Current);
            }*/ //nahradene so Zip

        /*IEnumerable<int> ponderedDigits =
            GetDigitsOf(number)
                .Zip(MultiplyingFactors, (a, b) => a * b);

        int sum = GetDigitsOf(number)
                .Zip(MultiplyingFactors, (a, b) => a * b)
                .Sum();

        int modulo = sum % 7;
        return modulo;
    }*/

        /*
        static int GetControlDigit(long number, Func<long, IEnumerable<int>> getDigitsOf,
            IEnumerable<int> multiplyingFactors, int modulo) => // these are not strategies, because dont affect the structure of the algoritm
            //number
                //.DigitsFromLowest()
            getDigitsOf(number)
                .Zip(multiplyingFactors, (a, b) => a * b)
                .Sum()
                % modulo;
        */

        /*private static IEnumerable<int> MultiplyingFactors
        {
            get
            {
                int factor = 3;
                while (true)
                {
                    yield return factor;
                    factor = 4 - factor;
                }
            }
        }*/

        /*
        private static IEnumerable<int> GetDigitsOf(long number)
        {
            IList<int> digits = new List<int>();
            while (number > 0)
            {
                digits.Add((int)(number % 10));
                number /= 10;
            }

            return digits;
        }*/

        static void Main(string[] args)
        {
            //int digitLowest = GetControlDigit(12345, x => x.DigitsFromLowest(), MultiplyingFactors, 7);
            //int digitHighest = GetControlDigit(12345, x => x.DigitsFromHighest(), MultiplyingFactors, 7);

            /*int controlDigit =
                new ControlDigitAlgorithm(x => x.DigitsFromHighest(), MultiplyingFactors, 7)
                    .GetControlDigit(12345);*/

            int controlDigit = ControlDigitAlgorithms.ForSalesDepartment.GetControlDigit(12345);

            Console.ReadLine();
        }
    }
}
