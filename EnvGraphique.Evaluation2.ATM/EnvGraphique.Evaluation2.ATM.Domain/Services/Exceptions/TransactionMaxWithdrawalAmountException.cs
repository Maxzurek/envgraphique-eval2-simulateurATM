using System;
using System.Runtime.Serialization;

namespace EnvGraphique.Evaluation2.ATM.Domain.Services.Exceptions
{
    public class TransactionMaxWithdrawalAmountException : Exception
    {
        public TransactionMaxWithdrawalAmountException()
        {
        }

        public TransactionMaxWithdrawalAmountException(string message) : base(message)
        {
        }

        public TransactionMaxWithdrawalAmountException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected TransactionMaxWithdrawalAmountException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
