using System;
using System.Runtime.Serialization;

namespace EnvGraphique.Evaluation2.ATM.Domain.Services.Exceptions
{
    public class UserDataNotFoundException : Exception
    {
        public UserDataNotFoundException()
        {
        }

        public UserDataNotFoundException(string message) : base(message)
        {
        }

        public UserDataNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected UserDataNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
