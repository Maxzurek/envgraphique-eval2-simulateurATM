using System;
using System.Runtime.Serialization;

namespace EnvGraphique.Evaluation2.ATM.Domain.Services.Exceptions
{
    public class TransactionInvalidAmountException : Exception
    {
        public TransactionInvalidAmountException()
        {
        }

        public TransactionInvalidAmountException(string message) : base(message)
        {
        }

        public TransactionInvalidAmountException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected TransactionInvalidAmountException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
