using System;
using System.Runtime.Serialization;
using JetBrains.Annotations;
using TechHealth.Model;

namespace TechHealth.Exceptions
{
    public class AppointmentConflictException : Exception
    {
        public Appointment ExistingAppointment { get; }
        public Appointment IncomingAppointment { get; }

        public AppointmentConflictException(Appointment existingAppointment, Appointment incomingAppointment)
        {
            ExistingAppointment = existingAppointment;
            IncomingAppointment = incomingAppointment;
        }


        public AppointmentConflictException(string message, Exception innerException, Appointment existingAppointment,
            Appointment incomingAppointment) : base(message, innerException)
        {
            ExistingAppointment = existingAppointment;
            IncomingAppointment = incomingAppointment;
        }

        protected AppointmentConflictException([NotNull] SerializationInfo info, StreamingContext context,
            Appointment existingAppointment, Appointment incomingAppointment) : base(info, context)
        {
            ExistingAppointment = existingAppointment;
            IncomingAppointment = incomingAppointment;
        }

    }
}