using System;
using System.Runtime.Serialization;

namespace EnvGraphique.Evaluation2.ATM.Domain.Services.Exceptions
{
    public class TransactionInsufficientFundsException : Exception
    {
        public TransactionInsufficientFundsException()
        {
        }

        public TransactionInsufficientFundsException(string message) : base(message)
        {
        }

        public TransactionInsufficientFundsException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected TransactionInsufficientFundsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
