using TechHealth.Model;

namespace TechHealth.IgnoreMeJson
{
    public class AppointmentIgnore
    {
        private Appointment _appointment;

        public AppointmentIgnore(Appointment appointment)
        {
            _appointment = appointment;
        }

        public void IgnoreMeDoctor(Appointment appointment)
        {
            appointment.Doctor.Specialization = default;
            appointment.Doctor.Email = default;
            appointment.Doctor.Name = default;
            appointment.Doctor.Surname = default;
            appointment.Doctor.Address = default;
            appointment.Doctor.Phone = default;
            appointment.Doctor.Username = default;
            appointment.Doctor.Password = default;
            appointment.Doctor.Employed = default;
        }

        public void IgnoreMeRoom(Appointment appointment)
        {
            appointment.Room.floor = default;
            appointment.Room.roomTypes = default;
            appointment.Room.availability = default;
        }

        public void IgnoreMePatient(Appointment appointment)
        {
            appointment.Patient.Email = default;
            appointment.Patient.Address = default;
            appointment.Patient.Phone = default;
            appointment.Patient.Username = default;
            appointment.Patient.Password = default;
            appointment.Patient.Lbo = default;
            appointment.Patient.Employed = default;
            appointment.Patient.IsBanned = default;
            appointment.Patient.Guest = default;
            
        }
    }
}