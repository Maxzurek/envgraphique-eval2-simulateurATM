using System;
using System.Runtime.Serialization;

namespace EnvGraphique.Evaluation2.ATM.Domain.Services.Exceptions
{
    public class DbConnectionFailedException : Exception
    {
        public DbConnectionFailedException()
        {
        }

        public DbConnectionFailedException(string message) : base(message)
        {
        }

        public DbConnectionFailedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DbConnectionFailedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
