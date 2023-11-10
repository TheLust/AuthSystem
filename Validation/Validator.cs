using AuthSystem.Util.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace AuthSystem
{
    public class Validator
    {
        public static void NotBlank(string field, string toValidate)
        {
            if (string.IsNullOrWhiteSpace(toValidate))
            {
                throw new ValidationException(AppConstant.GetExceptionMessage(field, AppConstant.NOT_BLANK));
            }
        }

        public static void Length(string field, string toValidate, int min, int max) 
        {
            if (toValidate.Length < min)
            {
                throw new ValidationException(AppConstant.GetExceptionMessage(field, AppConstant.MIN(min)));
            }

            if (toValidate.Length > max)
            {
                throw new ValidationException(AppConstant.GetExceptionMessage(field, AppConstant.MAX(max)));
            }
        }

        public static void Email(string field, string toValidate)
        {
            if (!new Regex(@"^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$").IsMatch(toValidate))
            {
                throw new ValidationException(AppConstant.GetExceptionMessage(field, AppConstant.NOT_VALID));
            }
        }

        public static void Pattern(string field, string message, string toValidate, string pattern)
        {
            if (!new Regex(@pattern).IsMatch(toValidate))
            {
                throw new ValidationException(AppConstant.GetExceptionMessage(field,
                    string.IsNullOrWhiteSpace(message) ? AppConstant.DEFAULT_PATTERN : (" " + message)));
            }
        }
    }
}
