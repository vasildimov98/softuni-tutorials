namespace ValidationAttributes.Attributes
{
    using System;
    using System.Linq;

    public static class Validator
    {
        public static bool IsValid(object obj)
        {
            if (!(obj is Person))
            {
                throw new ArgumentException("Object cannot be convert to Person!");
            }

            var personType = obj.GetType();

            var properties = personType.GetProperties();

            foreach (var property in properties)
            {
                var myAttributes = property
                    .GetCustomAttributes(false)
                    .Where(atr => atr is MyValidationAttribute)
                    .Cast<MyValidationAttribute>()
                    .ToArray();

                foreach (var attribute in myAttributes)
                {
                    if (!attribute.IsValid(property.GetValue(obj)))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
