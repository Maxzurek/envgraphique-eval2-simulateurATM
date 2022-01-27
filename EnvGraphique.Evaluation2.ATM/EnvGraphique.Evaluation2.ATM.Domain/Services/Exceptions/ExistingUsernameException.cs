using System;
using System.Runtime.Serialization;

namespace EnvGraphique.Evaluation2.ATM.Domain.Services.Exceptions
{
    public class ExistingUsernameException : Exception
    {
        public ExistingUsernameException()
        {
        }

        public ExistingUsernameException(string message) : base(message)
        {
        }

        public ExistingUsernameException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ExistingUsernameException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
