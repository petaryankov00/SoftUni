using System;
using System.Collections.Generic;
using System.Text;

namespace ValidationAttributes.Attributes
{
    class MyRequiredAttribute : MyValidationAttribute
    {
        public override bool IsValid(object obj)
        {
            string name = (string)obj;

            return !string.IsNullOrWhiteSpace(name);
        }
    }
}
