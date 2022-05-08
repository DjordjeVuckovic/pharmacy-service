using System;
using System.Runtime.Serialization;
using JetBrains.Annotations;

namespace TechHealth.Exceptions
{
    public class SpecializationException:Exception
    {
        public SpecializationException()
        {
        }

        public SpecializationException(string message) : base(message)
        {
        }

        public SpecializationException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected SpecializationException([NotNull] SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}