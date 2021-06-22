using System;
using System.Runtime.Serialization;

namespace CarShop.Services
{
    [Serializable]
    internal class InvalidOperationExeption : Exception
    {
        public InvalidOperationExeption()
        {
        }

        public InvalidOperationExeption(string message) : base(message)
        {
        }

        public InvalidOperationExeption(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidOperationExeption(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}