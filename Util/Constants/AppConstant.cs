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
        public const string NOT_VALID = " is not valid";
        public const string DEFAULT_PATTERN = " does not match the set pattern";
        public static string MIN(int min)
        {
            return " must have more than " + min + " characters";
        }
        public static string MAX(int max)
        {
            return  " must have less than " + max + " characters";
        }
        public static string MIN_VALUE(int min)
        {
            return " must be greater than " + min;
        }
        public static string MAX_VALUE(int max)
        {
            return " must be less than " + max;
        }

        public const string WELCOME = "Ciao cacao, ";
        public const string ADMIN = "Admin";
        public const string USER = "User";
        public const string MY_ACCOUNT = "My account";

        public static readonly Tuple<string, string> ACCOUNT = Tuple.Create("Account", "Accounts");
        public static readonly Tuple<string, string> EMPLOYEE = Tuple.Create("Employee", "Employees");
        public static readonly Tuple<string, string> PROJECT = Tuple.Create("Project", "Projects");
        public static readonly Tuple<string, string> JOB = Tuple.Create("Job", "Jobs");
        public static readonly Tuple<string, string> ASSIGNEMNT = Tuple.Create("Assignment", "Assignments");
        public static readonly Tuple<string, string> WAGE = Tuple.Create("Wage", "Wages");
        public static readonly Tuple<string, string> BONUS = Tuple.Create("Bonus", "Bonuses");
        public static readonly Tuple<string, string> SESSION = Tuple.Create("Session", "Sessions");
        public static readonly Tuple<string, string> ROLE = Tuple.Create("Rle", "Roles");

        public const string Id = "Id";
        public const string USERNAME = "Username";
        public const string PASSWORD = "Password";
        public const string FIRST_NAME = "First name";
        public const string LAST_NAME = "Last name";
        public const string EMAIL = "Email";
        public const string PHONE_NUMBER = "Phone number";

        public const string PRIVACY_POLICY_MESSAGE = "Please read our privacy policy";
        public const string VALIDATION_ERROR_MESSAGE = "Please input valid data";
        public const string ABSTRACT_ERROR_MESSGAE = "Something went wrong";
        public const string DELETE_CONFIRMATION = "Are you sure you want to proceed?";
        public const string SURE = "Sure?";

        static string Format(string input)
        {
            return string.IsNullOrEmpty(input) ? input : input.Substring(0, 1).ToUpper() + input.Substring(1).ToLower();
        }

        public static string GetExceptionMessage(string entity, string field, string message)
        {
            return Format(entity) + " with this " + field.ToLower() + message;
        }

        public static string GetExceptionMessage(string field, string message)
        {
            return Format(field) + message;
        }
    }
}
