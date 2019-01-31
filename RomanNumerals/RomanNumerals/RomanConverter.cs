using System.Collections.Generic;

namespace RomanNumerals
{
    public class RomanConverter
    {
        private static readonly Dictionary<int, string> ArabicsToRomans = new Dictionary<int, string>
        {
            [1000] = "M",
            [900] = "CM",
            [500] = "D",
            [400] = "CD",
            [100] = "C",
            [90] = "XC",
            [50] = "L",
            [40] = "XL",
            [10] = "X",
            [9] = "IX",
            [5] = "V",
            [4] = "IV",
            [1] = "I"            
        };

        public string Convert(int number)
        {
            string result = string.Empty;
            var arabicsToRomansEnumerator = ArabicsToRomans.GetEnumerator();

            while (arabicsToRomansEnumerator.MoveNext())
            {
                var arabicToRoman = arabicsToRomansEnumerator.Current;
                var arabicNumeral = arabicToRoman.Key;
                var romanNumeral = arabicToRoman.Value;

                while (number >= arabicToRoman.Key)
                {
                    result += romanNumeral;
                    number -= arabicNumeral;
                }
            }

            return result;
        }
    }
}