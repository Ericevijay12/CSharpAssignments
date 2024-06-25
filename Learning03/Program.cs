using System;

namespace FractionApp
{
    public class Fraction
    {
        private int _numerator;
        private int _denominator;

        public Fraction()
        {
            _numerator = 1;
            _denominator = 1;
        }

        public Fraction(int numerator)
        {
            _numerator = numerator;
            _denominator = 1;
        }

        public Fraction(int numerator, int denominator)
        {
            _numerator = numerator;
            _denominator = denominator;
        }

        public int GetNumerator()
        {
            return _numerator;
        }

        public void SetNumerator(int numerator)
        {
            _numerator = numerator;
        }

        public int GetDenominator()
        {
            return _denominator;
        }

        public void SetDenominator(int denominator)
        {
            _denominator = denominator;
        }

        public string GetFractionString()
        {
            return $"{_numerator}/{_denominator}";
        }

        public double GetDecimalValue()
        {
            if (_denominator == 0)
            {
                throw new InvalidOperationException("Denominator cannot be zero.");
            }
            return (double)_numerator / _denominator;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Fraction defaultFraction = new Fraction();
            Fraction wholeNumber = new Fraction(5);
            Fraction fraction = new Fraction(3, 4);

            Console.WriteLine(defaultFraction.GetFractionString()); // 1/1
            Console.WriteLine(defaultFraction.GetDecimalValue());   // 1

            Console.WriteLine(wholeNumber.GetFractionString());     // 5/1
            Console.WriteLine(wholeNumber.GetDecimalValue());       // 5

            Console.WriteLine(fraction.GetFractionString());        // 3/4
            Console.WriteLine(fraction.GetDecimalValue());          // 0.75

            // Verify getters and setters
            Fraction testFraction = new Fraction();
            testFraction.SetNumerator(7);
            testFraction.SetDenominator(8);

            Console.WriteLine(testFraction.GetFractionString());    // 7/8
            Console.WriteLine(testFraction.GetDecimalValue());      // 0.875
        }
    }
}
