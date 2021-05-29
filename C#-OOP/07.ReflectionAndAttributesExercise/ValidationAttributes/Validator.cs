using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using ValidationAttributes.Attributes;

namespace ValidationAttributes
{
    public static class Validator
    {
        public static bool IsValid(object obj)
        {
            var properties = obj.GetType().GetProperties();

            foreach (var property in properties)
            {
                var attributes = property.GetCustomAttributes()
                    .Cast<MyValidationAttribute>()
                    .ToArray();

                var value = property.GetValue(obj);

                foreach (var att in attributes)
                {
                    bool isValid = att.IsValid(value);

                    if (!isValid)
                    {
                        return false;
                    }
                }
            }

            return true;

        }
    }
}
