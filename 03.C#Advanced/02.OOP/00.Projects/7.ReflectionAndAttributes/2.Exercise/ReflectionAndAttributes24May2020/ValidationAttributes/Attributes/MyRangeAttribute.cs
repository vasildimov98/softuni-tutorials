namespace ValidationAttributes.Attributes
{
    using System;
    public class MyRangeAttribute : MyValidationAttribute
    {
        private readonly int minValue;
        private readonly int maxValue;

        public MyRangeAttribute(int minValue, int maxValue)
        {
            ValidateMINAndMaxValue(minValue, maxValue);

            this.minValue = minValue;
            this.maxValue = maxValue;
        }

        public override bool IsValid(object obj)
        {
            var isParse = int.TryParse(obj.ToString(), out var number);

            if (!isParse)
            {
                throw new ArgumentException("Object cannot be parse to Int32!");
            }

            if (number < minValue || number > maxValue)
            {
                return false;
            }

            return true;
        }

        private void ValidateMINAndMaxValue(int min, int max)
        {
            if (min >= max)
            {
                throw new ArgumentException("Min value cannot be equal or greater than max value!");
            }
        }
    }
}
