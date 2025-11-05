using System;
using System.Linq;

namespace ExcelXML.Utilities
{
    public static class CpfValidator
    {
        public static bool IsValid(string? cpf)
        {
            if (string.IsNullOrWhiteSpace(cpf))
            {
                return false;
            }

            var digits = new string(cpf.Where(char.IsDigit).ToArray());
            if (digits.Length != 11)
            {
                return false;
            }

            if (digits.Distinct().Count() == 1)
            {
                return false;
            }

            var numbers = digits.Select(c => c - '0').ToArray();

            int firstDigit = CalculateDigit(numbers, 9);
            int secondDigit = CalculateDigit(numbers, 10);

            return numbers[9] == firstDigit && numbers[10] == secondDigit;
        }

        private static int CalculateDigit(int[] digits, int length)
        {
            int sum = 0;
            int weight = length + 1;

            for (int i = 0; i < length; i++)
            {
                sum += digits[i] * (weight - i);
            }

            int remainder = sum % 11;
            return remainder < 2 ? 0 : 11 - remainder;
        }
    }
}
