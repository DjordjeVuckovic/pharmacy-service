using System;
using System.Runtime.Serialization;
using JetBrains.Annotations;
using TechHealth.Model;

namespace TechHealth.Exceptions
{
    public class AppointmentRoomConflictException:Exception
    {
        public Appointment ExistingAppointment { get; }
        public Appointment IncomingAppointment { get; }

        public AppointmentRoomConflictException(Appointment existingAppointment, Appointment incomingAppointment)
        {
            ExistingAppointment = existingAppointment;
            IncomingAppointment = incomingAppointment;
        }

        public AppointmentRoomConflictException(string message, Appointment existingAppointment, Appointment incomingAppointment) : base(message)
        {
            ExistingAppointment = existingAppointment;
            IncomingAppointment = incomingAppointment;
        }

        public AppointmentRoomConflictException(string message, Exception innerException, Appointment existingAppointment, Appointment incomingAppointment) : base(message, innerException)
        {
            ExistingAppointment = existingAppointment;
            IncomingAppointment = incomingAppointment;
        }

        protected AppointmentRoomConflictException([NotNull] SerializationInfo info, StreamingContext context, Appointment existingAppointment, Appointment incomingAppointment) : base(info, context)
        {
            ExistingAppointment = existingAppointment;
            IncomingAppointment = incomingAppointment;
        }
    }
}