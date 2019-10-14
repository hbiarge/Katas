using System;
using System.Linq;

namespace StringCalculator
{
    public class StringCalculatorWithDelimiters
    {
        private const char LineSeparator = '\n';
        private const char DefaultSeparator = ';';

        public int Add(string numbers)
        {
            if (string.IsNullOrEmpty(numbers))
            {
                return 0;
            }

            var effectiveSeparator = DefaultSeparator;
            var validNumbers = numbers.Trim();

            // Find the first
            var firstLineSeparatorIndex = validNumbers.IndexOf(LineSeparator);

            if (firstLineSeparatorIndex >= 0)
            {
                var separatorCandidate = validNumbers.Substring(0, firstLineSeparatorIndex);

                if (TryGetDelimiter(separatorCandidate, out var providedSeparator))
                {
                    effectiveSeparator = providedSeparator;
                    validNumbers = validNumbers.Substring(firstLineSeparatorIndex);
                }
            }

            var sum = validNumbers.Trim()
                .Split(new[] { effectiveSeparator }, StringSplitOptions.RemoveEmptyEntries)
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

        private static bool TryGetDelimiter(string separatorCandidate, out char separator)
        {
            if (separatorCandidate.StartsWith("//"))
            {
                separator = separatorCandidate.ElementAt(2);
                return true;
            }

            separator = default;
            return false;
        }
    }
}