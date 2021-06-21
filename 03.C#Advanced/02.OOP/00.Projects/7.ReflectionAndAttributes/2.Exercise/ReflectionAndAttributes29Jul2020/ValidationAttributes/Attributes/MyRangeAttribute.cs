using System;

namespace ValidationAttributes.Attributes
{
    public class MyRangeAttribute : MyValidationAttribute
    {
        private readonly int minValue;
        private readonly int maxValue;

        public MyRangeAttribute(int minValue, int maxValue)
        {
            this.minValue = minValue;
            this.maxValue = maxValue;
        }

        public override bool IsValid(object obj)
        {
            var isParsed = int.TryParse(obj.ToString(), out var age);

            if (!isParsed)
            {
                throw new ArgumentException("Object cannot be parsed to Int32!");
            }

            if (age < this.minValue || age > this.maxValue)
            {
                return false;
            }

            return true;
        }
    }
}
