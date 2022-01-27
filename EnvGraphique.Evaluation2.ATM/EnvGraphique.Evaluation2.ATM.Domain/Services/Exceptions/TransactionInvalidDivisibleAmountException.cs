using System;
using System.Runtime.Serialization;

namespace EnvGraphique.Evaluation2.ATM.Domain.Services.Exceptions
{
    public class TransactionInvalidDivisibleAmountException : Exception
    {
        public TransactionInvalidDivisibleAmountException()
        {
        }

        public TransactionInvalidDivisibleAmountException(string message) : base(message)
        {
        }

        public TransactionInvalidDivisibleAmountException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected TransactionInvalidDivisibleAmountException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
