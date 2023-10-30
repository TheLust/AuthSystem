using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthSystem.Util.Constants
{
    public class AppConstant
    {
        public const string NOT_FOUND = " does not exists";
        public const string NOT_BLANK = " cannot be blank";
        public const string NOT_NULL = " cannot be null";
        public const string ALREADY_EXISTS = " already exists";
        public const string BAD_CREDENTIALS = "Bad credentials";
        public const string WELCOME = "Ciao cacao, ";

        public static string GetExceptionMessage(string entity, string field, string message)
        {
            return entity + " with this " + field + message;
        }

        public static string GetExceptionMessage(string field, string message)
        {
            return field + message;
        }
    }
}
