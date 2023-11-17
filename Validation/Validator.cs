using AuthSystem.Component;
using AuthSystem.Util;
using AuthSystem.Util.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace AuthSystem
{
    public class Validator
    {

        public static void NotNull(string field, object toValidate)
        {
            if (toValidate == null)
            {
                throw new ValidationException(AppConstant.GetExceptionMessage(field, AppConstant.NOT_NULL));
            }
        }

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

        public static void Unique<T>(string field, object toValidate, List<T> entities, object id)
        {
            T foundEntity = entities.FirstOrDefault(x => GenericUtils.GetPropertyValue(x, field).Equals(toValidate));
            if (foundEntity != null) 
            {
                if (id != null)
                {
                    if (!id.Equals(GenericUtils.GetPropertyValue(foundEntity, "Id")))
                    {
                        throw new ValidationException(AppConstant.GetExceptionMessage(field, AppConstant.ALREADY_EXISTS));
                    }
                    return;
                }
                throw new ValidationException(AppConstant.GetExceptionMessage(field, AppConstant.ALREADY_EXISTS));
            }
        }

        public static void Min(string field, object toValidate, long min)
        {
            if (Convert.ToInt64(toValidate) < min)
            {
                throw new ValidationException(AppConstant.GetExceptionMessage(field, AppConstant.MIN_VALUE(min)));
            }
        }

        public static void Max(string field, object toValidate, long max)
        {
            if (Convert.ToInt64(toValidate) > max)
            {
                throw new ValidationException(AppConstant.GetExceptionMessage(field, AppConstant.MAX_VALUE(max)));
            }
        }

        public static void PastOrPresent(string field, object toValidate)
        {
            if (Convert.ToDateTime(toValidate).CompareTo(DateTime.Now) >= 0)
            {
                throw new ValidationException(AppConstant.GetExceptionMessage(field, AppConstant.PAST_OR_PRESENT));
            }
        }

        public static void IsLaterThan(string field, object toValidate, DateTimeField target)
        {
            if (Convert.ToDateTime(toValidate).CompareTo(target.FieldValue) < 0)
            {
                throw new ValidationException(AppConstant.GetExceptionMessage(field, AppConstant.LATER(target.Label)));
            }
        }
    }
}
