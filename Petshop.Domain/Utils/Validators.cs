using System.Text.RegularExpressions;

namespace Petshop.Domain.Utils
{
    public partial class Validators
    {
        [GeneratedRegex(@"^(\d{2})(9\d{8}|\d{8})$")]
        private static partial Regex CellPhoneRegex();

        [GeneratedRegex(@"\D")]
        private static partial Regex OnlyNumbersRegex();

        public static bool BeAValidCellPhone(string cellPhone)
        {
            if (string.IsNullOrWhiteSpace(cellPhone))
                return false;

            var digits = OnlyNumbersRegex().Replace(cellPhone, "");

            return CellPhoneRegex().IsMatch(digits);
        }

        public static bool BeAValidCpf(string cpf)
        {
            if (string.IsNullOrWhiteSpace(cpf))
                return false;

            var digits = OnlyNumbersRegex().Replace(cpf, "");

            if (digits.Length != 11)
                return false;

            if (digits.Distinct().Count() == 1)
                return false;

            var sum = 0;
            for (int i = 0; i < 9; i++)
                sum += int.Parse(digits[i].ToString()) * (10 - i);

            var remainder = sum % 11;
            var firstDigit = remainder < 2 ? 0 : 11 - remainder;

            if (firstDigit != int.Parse(digits[9].ToString()))
                return false;

            sum = 0;
            for (int i = 0; i < 10; i++)
                sum += int.Parse(digits[i].ToString()) * (11 - i);

            remainder = sum % 11;
            var secondDigit = remainder < 2 ? 0 : 11 - remainder;

            return secondDigit == int.Parse(digits[10].ToString());
        }
    }
}
