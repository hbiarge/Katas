using System;
using System.Globalization;
using System.Linq;

namespace StringCalculator
{
    public class StringCalculator
    {
        private const char Separator = ',';

        public int Add(string numbers)
        {
            if (string.IsNullOrEmpty(numbers))
            {
                return 0;
            }

            var sum = numbers.Trim()
                .Split(new[] { Separator }, StringSplitOptions.RemoveEmptyEntries)
                .Aggregate(
                    seed: 0,
                    func: (accumulator, number) =>
                    {
                        if (int.TryParse(number.Trim(), out var current))
                        {
                            return accumulator + current;
                        }

                        return accumulator;
                    });

            return sum;
        }
    }
}
