using System;
using System.Runtime.Serialization;

namespace EnvGraphique.Evaluation2.ATM.Domain.Services.Exceptions
{
    public class AdminCreateAccountNoCheckingAccountException : Exception
    {
        public AdminCreateAccountNoCheckingAccountException()
        {
        }

        public AdminCreateAccountNoCheckingAccountException(string message) : base(message)
        {
        }

        public AdminCreateAccountNoCheckingAccountException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected AdminCreateAccountNoCheckingAccountException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
