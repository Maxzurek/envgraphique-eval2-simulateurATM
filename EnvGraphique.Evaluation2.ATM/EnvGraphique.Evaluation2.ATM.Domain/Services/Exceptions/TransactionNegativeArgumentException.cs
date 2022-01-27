using System;
using System.Runtime.Serialization;

namespace EnvGraphique.Evaluation2.ATM.Domain.Services.Exceptions
{
    public class TransactionNegativeArgumentException : Exception
    {
        public TransactionNegativeArgumentException()
        {
        }

        public TransactionNegativeArgumentException(string message) : base(message)
        {
        }

        public TransactionNegativeArgumentException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected TransactionNegativeArgumentException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
