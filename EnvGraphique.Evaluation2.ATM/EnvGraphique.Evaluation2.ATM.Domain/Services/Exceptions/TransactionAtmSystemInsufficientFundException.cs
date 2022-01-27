using System;
using System.Runtime.Serialization;

namespace EnvGraphique.Evaluation2.ATM.Domain.Services.Exceptions
{
    public class TransactionAtmSystemInsufficientFundException : Exception
    {
        public TransactionAtmSystemInsufficientFundException()
        {
        }

        public TransactionAtmSystemInsufficientFundException(string message) : base(message)
        {
        }

        public TransactionAtmSystemInsufficientFundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected TransactionAtmSystemInsufficientFundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
