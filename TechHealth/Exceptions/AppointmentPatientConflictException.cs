using System;
using System.Runtime.Serialization;
using JetBrains.Annotations;
using TechHealth.Model;

namespace TechHealth.Exceptions
{
    public class AppointmentPatientConflictException:Exception
    {
        public AppointmentPatientConflictException(Appointment existingAppointment, Appointment incomingAppointment)
        {
            ExistingAppointment = existingAppointment;
            IncomingAppointment = incomingAppointment;
        }

        public AppointmentPatientConflictException(string message, Appointment existingAppointment, Appointment incomingAppointment) : base(message)
        {
            ExistingAppointment = existingAppointment;
            IncomingAppointment = incomingAppointment;
        }

        public AppointmentPatientConflictException(string message, Exception innerException, Appointment existingAppointment, Appointment incomingAppointment) : base(message, innerException)
        {
            ExistingAppointment = existingAppointment;
            IncomingAppointment = incomingAppointment;
        }

        protected AppointmentPatientConflictException([NotNull] SerializationInfo info, StreamingContext context, Appointment existingAppointment, Appointment incomingAppointment) : base(info, context)
        {
            ExistingAppointment = existingAppointment;
            IncomingAppointment = incomingAppointment;
        }

        public Appointment ExistingAppointment { get; }
        public Appointment IncomingAppointment { get; }
    }
}