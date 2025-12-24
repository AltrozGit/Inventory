namespace Indotalent.Web.Modules.Material.Request
{
    public class NumberToWordsConverter
    {
        public static string ConvertToWords(decimal number)
        {
            if (number == 0) return "Zero Rupees";

            // Separate the integral and decimal part (Paise)
            long integralPart = (long)number;
            int decimalPart = (int)((number - integralPart) * 100);  // For paise (up to two decimal places)

            string words = ConvertNumberToWords(integralPart) + " Rupees";

            if (decimalPart > 0)
            {
                words += " and " + ConvertNumberToWords(decimalPart) + " Paise";
            }

            return words;
        }

        private static string ConvertNumberToWords(long number)
        {
            string words = "";

            if (number >= 10000000)
            {
                words += ConvertNumberToWords(number / 10000000) + " Crore ";
                number %= 10000000;
            }
            if (number >= 100000)
            {
                words += ConvertNumberToWords(number / 100000) + " Lakh ";
                number %= 100000;
            }
            if (number >= 1000)
            {
                words += ConvertNumberToWords(number / 1000) + " Thousand ";
                number %= 1000;
            }
            if (number >= 100)
            {
                words += ConvertNumberToWords(number / 100) + " Hundred ";
                number %= 100;
            }

            if (number > 0)
            {
                string[] ones = { "", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
                string[] tens = { "", "", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };

                if (number < 20)
                {
                    words += ones[number];
                }
                else
                {
                    words += tens[number / 10];
                    if ((number % 10) > 0)
                    {
                        words += "-" + ones[number % 10];
                    }
                }
            }

            return words.Trim();
        }
    }
}