using AuthSystem.Component;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AuthSystem.Util
{
    public class GenericUtils
    {
        public static object GetPropertyValue(object obj, string propertyName)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }

            Type type = obj.GetType();
            PropertyInfo property = type.GetProperty(propertyName);

            if (property == null)
            {
                throw new ArgumentException($"Property '{propertyName}' not found on type '{type.FullName}'.");
            }

            var result = property.GetValue(obj);

            if (result is ValidationException)
            {
                throw (ValidationException) result;
            }

            return result;
        }

        public static void SetPropertyValue(object obj, string propertyName, object value)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }

            Type type = obj.GetType();
            PropertyInfo property = type.GetProperty(propertyName);

            if (property == null)
            {
                throw new ArgumentException($"Property '{propertyName}' not found on type '{type.FullName}'.");
            }

            property.SetValue(obj, value);
        }

        public static bool HasProperty<T>(string propertyName)
        {
            Type type = typeof(T);
            PropertyInfo propertyInfo = type.GetProperty(propertyName);
            return propertyInfo != null;
        }
    }
}
