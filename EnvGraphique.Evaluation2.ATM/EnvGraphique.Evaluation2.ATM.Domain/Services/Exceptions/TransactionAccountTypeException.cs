using System;
using System.Runtime.Serialization;

namespace EnvGraphique.Evaluation2.ATM.Domain.Services.Exceptions
{
    public class TransactionAccountTypeException : Exception
    {
        public TransactionAccountTypeException()
        {
        }

        public TransactionAccountTypeException(string message) : base(message)
        {
        }

        public TransactionAccountTypeException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected TransactionAccountTypeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
