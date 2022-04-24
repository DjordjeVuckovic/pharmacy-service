using TechHealth.Model;

namespace TechHealth.JsonIgnore
{
    public class AppointmentIgnore
    {
        public AppointmentIgnore()
        {
        }

        public void IgnoreMeDoctor(Appointment appointment)
        {
            appointment.Doctor.Specialization = default;
            appointment.Doctor.Address = default;
            appointment.Doctor.Email = default;
            appointment.Doctor.Name = default;
            appointment.Doctor.Surname = default;
            appointment.Doctor.Phone = default;
            appointment.Doctor.Username = default;
            appointment.Doctor.Password = default;
            appointment.Doctor.Employed = default;
        }

        public void IgnoreMePatient(Appointment appointment)
        {
            appointment.Patient.Guest = default;
            appointment.Patient.Address = default;
            appointment.Patient.Email = default;
            //appointment.Patient.Name = default;
            //appointment.Patient.Surname = default;
            appointment.Patient.Phone = default;
            appointment.Patient.Username = default;
            appointment.Patient.Password = default;
            appointment.Patient.Employed = default;
            appointment.Patient.Lbo = default;
            appointment.Patient.IsBanned = default;
        }

        public void IgnoreMeRoom(Appointment appointment)
        {
            appointment.Room.availability = default;
            appointment.Room.floor = default;
            appointment.Room.roomTypes = default;
        }
    }
}