using System;
using System.Runtime.Serialization;
using JetBrains.Annotations;

namespace TechHealth.Exceptions
{
    public class AppointmentVacationException:Exception
    {
        public AppointmentVacationException()
        {
        }

        public AppointmentVacationException(string message) : base(message)
        {
        }

        public AppointmentVacationException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected AppointmentVacationException([NotNull] SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}