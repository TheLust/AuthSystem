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

        public static void Min(string field, object toValidate, int? min)
        {
            if (min == null)
            {
                return;
            }

            if (Convert.ToInt32(toValidate) < min)
            {
                throw new ValidationException(AppConstant.GetExceptionMessage(field, AppConstant.MIN_VALUE(min.Value)));
            }
        }

        public static void Max(string field, object toValidate, int? max)
        {
            if (max == null)
            {
                return;
            }

            if (Convert.ToInt32(toValidate) > max)
            {
                throw new ValidationException(AppConstant.GetExceptionMessage(field, AppConstant.MAX_VALUE(max.Value)));
            }
        }
    }
}
