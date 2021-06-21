namespace PersonsInfo
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices.ComTypes;

    public class Validator
    {
        public static void ValidateInput<T>(T value, T minimum, string message)
            where T : IComparable<T>
        {
            if (minimum.Equals(0))
            {
                if (value.CompareTo(minimum) <= 0)
                {
                    throw new ArgumentException(message);
                }
            }
            else if(value.CompareTo(minimum) < 0)
            {
                throw new ArgumentException(message);
            }
        }
    }
}
