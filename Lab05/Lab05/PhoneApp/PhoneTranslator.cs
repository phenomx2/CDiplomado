using Java.Lang;
using System.Linq;

namespace PhoneApp
{
    public class PhoneTranslator
    {
        private string _letters = "ABCDEFGHIJKLMNÑOPQRSTUVWXYZ";
        private string _numbers = "22233344455566677778889999";

        public string ToNumber(string alphaNumericPhoneNumber)
        {
            var numericPhoneNumber = new StringBuilder();
            if (!string.IsNullOrWhiteSpace(alphaNumericPhoneNumber))
            {
                alphaNumericPhoneNumber = alphaNumericPhoneNumber.ToUpper();
                foreach (var c in alphaNumericPhoneNumber )
                {
                    if ("0123456789".Contains(c))
                        numericPhoneNumber.Append(c);
                    else
                    {
                        var index = _letters.IndexOf(c);
                        if (index >= 0)
                            numericPhoneNumber.Append(_numbers[index]);
                    }
                }
            }
            return numericPhoneNumber.ToString();
        }
    }
}