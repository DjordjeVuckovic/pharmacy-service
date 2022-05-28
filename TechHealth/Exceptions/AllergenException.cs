using System;
using System.Runtime.Serialization;
using JetBrains.Annotations;

namespace TechHealth.Exceptions
{
    public class AllergenException:Exception
    {
        public AllergenException()
        {
        }

        public AllergenException(string message) : base(message)
        {
        }

        public AllergenException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected AllergenException([NotNull] SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}