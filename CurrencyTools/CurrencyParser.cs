using System;
using System.Linq;
using System.Globalization;
using System.Text.RegularExpressions;

namespace BankLedger
{

    public static class CurrencyParser
    {
        // Adapted from example given at:
        // https://docs.microsoft.com/en-us/dotnet/api/system.text.regularexpressions.regex?view=netframework-4.7.2

        enum CurrencyParseMode { WholeNumberString, DecimalString };

        static bool IsValid(string input, NumberFormatInfo nfi)
        {

            // To avoid an error for single digit inputs...
            var numbers = Regex.Replace(input, "[^0-9]", "");
            if (!input.Contains(nfi.CurrencyDecimalSeparator) && numbers.Length == 1)
            {
                input += nfi.CurrencyDecimalSeparator;
                input += String.Concat(Enumerable.Repeat("0", nfi.CurrencyDecimalDigits));
            }


            // Define the regular expression pattern.
            string pattern;
            pattern = @"^\s*[";
            // Get the positive and negative sign symbols.
            pattern += Regex.Escape(nfi.PositiveSign + nfi.NegativeSign) + @"]?\s?";
            // Get the currency symbol.
            pattern += Regex.Escape(nfi.CurrencySymbol) + @"?\s?";
            // Add integral digits to the pattern.
            pattern += @"(\d*";
            // Add the decimal separator.
            pattern += Regex.Escape(nfi.CurrencyDecimalSeparator) + "?";
            // Add the fractional digits.
            pattern += @"\d{";
            // Determine the number of fractional digits in currency values.
            pattern += nfi.CurrencyDecimalDigits.ToString() + "}?){1}$";

            Regex rgx = new Regex(pattern);

            return rgx.IsMatch(input);
        }

        static string ToDecimalString(string input, NumberFormatInfo nfi)
        {
            // Check for situation where number of digits is smaller
            // than expected number of decimal digits
            var isNegative = input.Contains("-");
            var digits = nfi.CurrencyDecimalDigits;
            var number = Regex.Replace(input, "-", "");
            if (number.Length < digits)
            {
                number = String.Concat(Enumerable.Repeat("0", digits)) + number;
            }
            var decimalIndex = number.Length - digits;
            number = number.Insert(decimalIndex, nfi.CurrencyDecimalSeparator);
            if (isNegative) number = "-" + number;
            return number;
        }

        static string ToWholeNumberString(string input, NumberFormatInfo nfi)
        {
            if (!input.Contains(nfi.CurrencyDecimalSeparator))
                // Add extra digits.
                input += String.Concat(Enumerable.Repeat("0", nfi.CurrencyDecimalDigits));

            // Remove decimal points.
            input = Regex.Replace(input, "[^0-9]", "");
            return input;
        }

        static string Parse(string input, CurrencyParseMode parseMode)
        {
            // Get the current NumberFormatInfo object to build the regular 
            // expression pattern dynamically.
            NumberFormatInfo nfi = NumberFormatInfo.CurrentInfo;

            // Remove number group separators (commas in the English standard).
            input = Regex.Replace(input, nfi.CurrencyGroupSeparator, "");

            if (!IsValid(input, nfi)) return null;
            switch (parseMode)
            {
                case CurrencyParseMode.WholeNumberString:
                    return ToWholeNumberString(input, nfi);
                case CurrencyParseMode.DecimalString:
                    return ToDecimalString(input, nfi);
            }
            return null;
        }

        public static string ParseToDecimalString(string input)
        {
            return Parse(input, CurrencyParseMode.DecimalString);
        }

        public static string ParseToWholeNumberString(string input)
        {
            return Parse(input, CurrencyParseMode.WholeNumberString);
        }
    }
}